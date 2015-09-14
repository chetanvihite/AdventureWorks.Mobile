angular.module('adventureWorksApp.controllers', [])

.controller('DashCtrl', function ($scope) { })

.controller('signupCtrl', function ($scope) { })
.controller('forgotPasswordCtrl', function ($scope) { })

.controller('loginCtrl', function ($scope, $ionicPopup, $timeout, $state) {
    $scope.authorization = {
        username: '',
        password: ''
    };

    $scope.signIn = function (form) {
        $state.go('tab.dash');
        //if (form.$valid) {
        //    // perform the validation here
        //    $state.go('tab.dash');
        //}
    };

    $scope.settings = {
        enableFriends: true
    };
      
})


.controller('ChatsCtrl', function($scope, Chats) {
  $scope.chats = Chats.all();
  $scope.remove = function(chat) {
    Chats.remove(chat);
  }
})

.controller('ChatDetailCtrl', function($scope, $stateParams, Chats) {
  $scope.chat = Chats.get($stateParams.chatId);
})

.controller('AccountCtrl', function($scope) {
  $scope.settings = {
    enableFriends: true
  };
});
