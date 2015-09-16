
angular.module('adventureWorksApp.controllers', [])

.factory('mobileServiceFactory', [ $http, function () {
    var factory = {};
    factory.authenticate = function (mobileNumber, password)
    {
        var authData = { mobileNumber: mobileNumber, password: password };

        return $http.post('http://adventureworksmobile.azurewebsites.net/Mobileservice/Authenticate', authData);
       
    }

        return factory;
}])

.controller('DashCtrl', function ($scope, $state) {
    $scope.orderPref = {
        clientName: 'Chetan Vihite',
        addressline1: 'A 403, Leisure Apts',
        addressline2: 'behind maratha mandir',
        city: 'Pune',
        state: 'Maharashtra'
    };
    $scope.submitOrder = function (form) {
        $state.go('/orderconfirm');
        //if (form.$valid) {
        //    // perform the validation here
        //    $state.go('tab.dash');
        //}
    };

})
.controller('orderConfirmCtrl', function ($scope) { })
.controller('signupCtrl', function ($scope) { })
.controller('forgotPasswordCtrl', function ($scope) {
    $scope.signupForm = {
        firstName: '',
        lastName: '',
        mobileNumber: '',
        emailAddress: '',
        password: '',
        confirmPassword: '',
        addressline1: '',
        addressline2: '',
        city: '',
        state: '',
        zip: ''

    };
})

.controller('loginCtrl', function ($scope, $ionicPopup, $timeout, $state, mobileServiceFactory) {
    $scope.authorization = {
        username: '',
        password: ''
    };

    $scope.signIn = function (form) {
        //$state.go('tab.dash');
        if (form.$valid) {
            // perform the validation here
            var alertPopup = $ionicPopup.alert({
                title: 'Don\'t eat that!',
                template: form.authorization.username + form.auth.password
            });
            var result = mobileServiceFactory.authenticate(form.authorization.username, form.authorization.password)
            .success(function (response) {
                var alertPopup = $ionicPopup.alert({
                    title: 'Don\'t eat that!',
                    template: 'It might taste good'
                });
                $state.go('tab.dash');
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
            });

            
        }
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
