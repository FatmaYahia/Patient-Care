"use strict";
const _connectionId = '';
const chatid = parseInt(document.getElementById("chatid").value);
const setupConnection = (chatid) => {
     connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub?chatid=" + chatid)
        .configureLogging(signalR.LogLevel.Debug)
        .withAutomaticReconnect()
        .build();
};
    connection.on("receiveMessage", function (data){
        console.log(data);
        var message = document.createElement("div")
        message.classList.add('message')

        var header = document.createElement("header")
        if (data.IsDoctor) {
            header.appendChild(document.createTextNode(data.Chat.Doctor.FullName));
        } else {
            header.appendChild(document.createTextNode(data.Chat.Patient.FullName));
        }
        var p = document.createElement("p")
        p.appendChild(document.createTextNode(data.MessageContent))

        var footer = document.createElement("footer")
        footer.appendChild(document.createTextNode(data.CreatedAt))

        message.appendChild(header);
        message.appendChild(p);
        message.appendChild(footer);
        document.querySelector('.chat-body').append(message);
    });
    var joinRoom = function () {
        var roomid = document.getElementById("chatid").value;
        var url = '/Chat/JoinRoom/' + _connectionId + '/' + roomid;
        axios.post(url, null)
            .then(res => {
                console.log("Room Joined!", res);
            })
            .catch(function (err) {
                return console.error(err.toString());
            })
    }
    connection.start().then(function () {
        connection.invoke('getConnectionId')
            .then(function (connectionId) {
                _connectionId = connectionId;
                joinRoom();
            })
    }).catch(function (err) {
        return console.error(err.toString());
    });




var sendMessage= function (event) {
    event.preventDefault();
    var data = new FormData(event.target);
    document.getElementById("message-input").value = '';
    axios.post('/Chat/SendMessage', data)
        .then(res => {
            console.log("Message Sent!")
        })
        .catch(err => {
            console.log("Failed to sent Message!")
        })
};
