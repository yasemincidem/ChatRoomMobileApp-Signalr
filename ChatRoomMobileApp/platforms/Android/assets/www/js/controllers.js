angular.module('starter.controllers', [])

.controller('LoginCtrl', ['$scope', function ($scope) {
	$scope.user = {};
	$scope.AddUser = function () {
		window.localStorage['items'] = JSON.stringify([{
			userName: $scope.user.username,
		}]);
		console.log($scope.user.username)
	}

}])
.controller('ChatCtrl', function ($scope, Chats, $ionicHistory, $location) {
	$scope.items = {};
	Chats.GetRoomList().success(function (data) {
		$scope.items = data;
		$scope.LoginRoom = function (index) {
			Chats.data = $scope.items[index].RoomName;
			$location.path("/detail")
		}
	}).error(function (err) {
		alert(err);
	})
})
.controller('DetailCtrl', function ($scope,Chats) {
	$scope.room = {};
	$scope.room = Chats.data;
	console.log($scope.room);
})
.controller('MenuCtrl', function ($scope) {
	$scope.Logout = function () {
		window.localStorage.clear();
		$ionicHistory.clearCache();
		$ionicHistory.clearHistory();
		$location.path("/login")
	}
})

