function ChatHub() {
	this.chatHub = $.connection ? $.connection.chatHub : {};
	var _this = this;
	this.initHub = function () {
		$.connection.hub
            .start()
            .done(function () {
            });
	};
	this.addToRoom = function (roomName) {
		$.connection.hub
            .start()
            .done(function () {
            	_this.chatHub
                    .server
                    .addToRoom(roomName)
                    .done(function () { });
            });
	};
	this.tellToGroup = function (callback) {
		if (!_this.isSignalREnabled)
			return;
		_this.chatHub
            .client
            .tellToGroup = function (data) {
            	callback(data)
            };
	};
}