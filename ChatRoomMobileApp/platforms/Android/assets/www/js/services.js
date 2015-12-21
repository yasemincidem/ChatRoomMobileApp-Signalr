var baseURl = "http://localhost/ChatRoomWebApi/"

angular.module('starter.services', [])
.factory('Hub', function() {
	var sensplorerHub = $.connection ? $.connection.chatHub : {};

	var Hub = {};
	return Hub;
})
.factory('Chats', function ($http) {
	var Chats = {}
	Chats.GetRoomList = function () {
		return $http({
			method: 'GET',
			url: baseURl + 'api/values',
		})
	}
	return Chats;
})