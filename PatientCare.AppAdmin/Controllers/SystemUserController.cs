using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.AppAdmin.Filters;
using PatientCare.AppAdmin.ViewModel;
using PatientCare.DAL;
using PatientCare.Entity.AuthModel;
using PatientCare.Repository;
using System.Collections.Generic;
using System.Linq;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    public class SystemUserController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public SystemUserController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: SystemView
        //Authorize uses our custom identity(using PatientCare.AppAdmin.Filters;)
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.SystemUserRepository.GetAllInclude());
        }

        // GET: SystemUser/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            SystemUser SystemUser = _UnitOfWork.SystemUserRepository.GetByID(id);
            if (SystemUser == null)
            {
                return NotFound();
            }
            return View(SystemUser);
        }

        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            SystemUser SystemUser = new SystemUser();

            if (id > 0)
            {
                SystemUser = _UnitOfWork.SystemUserRepository.GetByIDInclude(id);
                if (SystemUser == null)
                {
                    return NotFound();
                }
            }
            return View(GetViewModel(SystemUser));
        }

        // POST: SystemUser/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, SystemUser SystemUser, List<int> SelectedFullAccess,
                                                      List<int> SelectedControlAccess, List<int> SelectedViewAccess)
        {
            if (id != SystemUser.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.SystemUserRepository.CreateEntity(SystemUser);
                        _UnitOfWork.SystemUserRepository.Save();
                    }
                    else
                    {
                        SystemUser Data = _UnitOfWork.SystemUserRepository.GetByID(id);
                        _Mapper.Map(SystemUser, Data);
                        _UnitOfWork.SystemUserRepository.UpdateEntity(Data);
                        _UnitOfWork.SystemUserRepository.Save();
                    }
                    _UnitOfWork.SystemUserPermissionRepository.DeleteEntity(_UnitOfWork.SystemUserPermissionRepository.GetAll(a => a.Fk_SystemUser == id));
                    _UnitOfWork.SystemUserPermissionRepository.CreateEntity(new SystemUserPermission
                    {
                        Fk_SystemView = (int)SystemViewEnum.Home,
                        Fk_SystemUser = SystemUser.Id,
                        Fk_AccessLevel = (int)AccessLevelEnum.ViewAccess,
                    });
                    if (SelectedFullAccess != null && SelectedFullAccess.Any())
                    {
                        foreach (int item in SelectedFullAccess)
                        {
                            _UnitOfWork.SystemUserPermissionRepository.CreateEntity(new SystemUserPermission
                            {
                                Fk_SystemView = item,
                                Fk_SystemUser = SystemUser.Id,
                                Fk_AccessLevel = (int)AccessLevelEnum.FullAccess
                            });
                        }
                    }
                    if (SelectedControlAccess != null && SelectedControlAccess.Any())
                    {
                        if (SelectedFullAccess != null && SelectedFullAccess.Any())
                        {
                            SelectedControlAccess = SelectedControlAccess.Where(a => !SelectedFullAccess.Contains(a)).ToList();
                        }
                        foreach (int item in SelectedControlAccess)
                        {
                            _UnitOfWork.SystemUserPermissionRepository.CreateEntity(new SystemUserPermission
                            {
                                Fk_SystemView = item,
                                Fk_SystemUser = SystemUser.Id,
                                Fk_AccessLevel = (int)AccessLevelEnum.ControlAccess
                            });
                        }
                    }
                    if (SelectedViewAccess != null && SelectedViewAccess.Any())
                    {
                        if (SelectedFullAccess != null && SelectedFullAccess.Any())
                        {
                            SelectedViewAccess = SelectedViewAccess.Where(a => !SelectedFullAccess.Contains(a)).ToList();
                        }
                        if (SelectedControlAccess != null && SelectedControlAccess.Any())
                        {
                            SelectedViewAccess = SelectedViewAccess.Where(a => !SelectedControlAccess.Contains(a)).ToList();
                        }
                        foreach (int item in SelectedViewAccess)
                        {
                            _UnitOfWork.SystemUserPermissionRepository.CreateEntity(new SystemUserPermission
                            {
                                Fk_SystemView = item,
                                Fk_SystemUser = SystemUser.Id,
                                Fk_AccessLevel = (int)AccessLevelEnum.ViewAccess
                            });
                        }
                    }
                    _UnitOfWork.SystemUserPermissionRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.SystemUserRepository.Any(a => a.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(GetViewModel(SystemUser));
        }

        // GET: SystemUser/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            SystemUser SystemUser = _UnitOfWork.SystemUserRepository.GetByID(id);
            if (SystemUser == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;

            if (id == 1)
            {
                ViewBag.CanDelete = false;
            }

            return View(SystemUser);
        }

        // POST: SystemUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            SystemUser SystemUser = _UnitOfWork.SystemUserRepository.GetByID(id);

            _UnitOfWork.SystemUserRepository.DeleteEntity(SystemUser);

            _UnitOfWork.SystemUserRepository.Save();
            return RedirectToAction(nameof(Index));
        }


        public SystemUserViewModel GetViewModel(SystemUser SystemUser)
        {
            SystemUserViewModel data = new SystemUserViewModel
            {
                SystemUser = SystemUser,
            };
            if (SystemUser.SystemUserPermission != null && SystemUser.SystemUserPermission.Any())
            {
                data.SelectedFullAccess = SystemUser.SystemUserPermission.Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess).Select(a => a.Fk_SystemView).ToList();
                data.SelectedControlAccess = SystemUser.SystemUserPermission.Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess).Select(a => a.Fk_SystemView).ToList();
                data.SelectedViewAccess = SystemUser.SystemUserPermission.Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess).Select(a => a.Fk_SystemView).ToList();
            }
            return data;
        }
    }
}
