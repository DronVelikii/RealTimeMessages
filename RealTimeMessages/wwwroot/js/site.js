"use strict";

const url =  "http://localhost:5000"

let connection = new signalR.HubConnectionBuilder().withUrl(`${url}/messageHub`).build();

$('.js-status').html(`Инициализация соединения c ${url} ... `)

connection.start().then(function () { 
    $('.js-status').html(`Связь с сервером ${url} установлена`)
}).catch(function (err) {
    $('.js-status').html(`Ошибка ${err.toString()} при установке связи с сервером ${url} `) 
});

connection.on("ReceiveMessages", function (messages) {
   for (const message of messages){
        AppendMessage(message.text);
   }
});
 
connection.on("ReceiveMessage", function (message) {
   AppendMessage(message.text);
});

function AppendMessage(text){
    $(".js-messages-list").prepend(`<li class="list-group-item">${text}</li>`);
}