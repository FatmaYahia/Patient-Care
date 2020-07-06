using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.DAL;
using PatientCare.Repository;
using System.Linq;

namespace PatientCare.App.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public PharmacyController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        public IActionResult Index(string Name, int fk_City = 0)
        {
            return View(_DBContext.Pharmacies.Where(a => string.IsNullOrEmpty(Name) || a.Name.Contains(Name))
                                             .Where(a => fk_City == 0 || a.Fk_City == fk_City)
                                             .Include(a => a.City)
                                             .ToList());
        }
    }
}
