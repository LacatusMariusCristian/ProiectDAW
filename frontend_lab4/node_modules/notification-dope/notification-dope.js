"use strict";
var spawn = require("child_process").spawn,
    EventEmitter = require("events").EventEmitter,
    WebNotification,
    util = require("util"),
    permission;

if (typeof window !== "undefined"){
    WebNotification = window.Notification;
}

module.exports = Notification;

function Notification(options){
    options.title = options.title || "";
    options.message = options.message || "";
    options.sound = options.sound || "";
    
    var self = this;
    if (WebNotification){
        if (permission === "granted"){
            new WebNotification(options.title, { body: options.message });
        }
    } else {
        var handle = spawn("terminal-notifier", [ 
            "-title", options.title, 
            "-message", options.message,
            "-sound", options.sound
        ]);
        handle.on("error", function(err){
            self.emit("error", err);
        });
    }
}
util.inherits(Notification, EventEmitter);

Notification.requestPermission = function(){
    if (WebNotification){
        WebNotification.requestPermission(function(perms){
            permission = perms;
        });    
    }
};
