function chatHub() {
	var hub = $.connection.chatHub;
	var _this = this;
	this.addToRoom = function (roomName) {
		$.connection.hub.start().done(function () {
			hub.server.addToRoom(roomName);
		})
	}
	this.removeToRoom = function (roomName) {
		$.connection.hub.start().done(function () {
			hub.server.removeToRoom(roomName);
		})
	}
	this.sendMessageToGroup = function () {
		hub.client.sendMessageToGroup = function (message) {
			return message;
		}
	}
	this.tellToGroup = function () {
		hub.client.TellToGroup = function (data) {
			return data;
		}
	}
}