
angular.module('adventureWorksApp.controllers', [])

.factory('mobileServiceFactory', function ($http) {
    var factory = {};
    factory.authenticate = function (mobileNumber, password)
    {
        var authData = { mobileNumber: mobileNumber, password: password };

        return $http.post('http://adventureworksmobile.azurewebsites.net/Mobileservice/Authenticate', authData);
    }
    factory.signup = function (model)
    {
        return $http.post('http://adventureworksmobile.azurewebsites.net/Mobileservice/Signup', model);
    }

        return factory;
})

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
.controller('signupCtrl', function ($scope, $ionicPopup, $timeout, $state, mobileServiceFactory) {
    $scope.signup = {
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

    
    $scope.signupsubmit = function (form) {
        if (form.$valid) {
            
            var model = {
                  FirstName: $scope.signup.firstName, 
                  LastName: $scope.signup.lastName, 
                  MobileNumber : $scope.signup.mobileNumber,
                  Password : $scope.signup.password,
                  EmailAddress: $scope.signup.emailAddress,
                  StreetAddress: $scope.signup.addressline1, 
                  Landmark: $scope.signup.addressline2,
                  City: $scope.signup.city, 
                  State : $scope.signup.state,
                Pincode: $scope.signup.zip 
            };
            if ($scope.signup.password != $scope.signup.confirmPassword) {
                $scope.signup.errorMessage = 'entered password do not match confirm password';
                $scope.signup.password = '';
                $scope.signup.confirmPassword = '';
                return;
            }
            $scope.data = { isLoading: true };
            var result = mobileServiceFactory.signup(model)
            .success(function (response) {
                if (response.IsSuccess == true) {
                    var alertPopup = $ionicPopup.alert({
                        title: 'Welcome',
                        template: 'Congratulations! Your account has been created successfully. Login to LaundryPro to get started!'
                    });
                    $state.go('/login');
                }
                else {
                    $scope.signup.errorMessage = response.ErrorMessage;
                }
                $scope.data = { isLoading: false };
            })
            .error(function (error) {
                $scope.signup.errorMessage = error.message;
                $scope.data = { isLoading: false };
            });
        }
    };
})
.controller('forgotPasswordCtrl', function ($scope) {   
})

.controller('loginCtrl', function ($scope, $ionicPopup, $timeout, $state, mobileServiceFactory) {
    $scope.authorization = {
        username: '',
        password: '',
        errorMessage: ''
    };

    $scope.signIn = function (form) {
        //$state.go('tab.dash');
        if (form.$valid) {
            //// perform the validation here
            //var alertPopup = $ionicPopup.alert({
            //    title: 'alert',
            //    template: $scope.authorization.username
            //});
            $scope.data = { isLoading: true};
           
            $scope.authorization.errorMessage = '';
            var result = mobileServiceFactory.authenticate($scope.authorization.username, $scope.authorization.password)
            .success(function (response) {
                if (response.IsSuccess == true) {
                   
                    $state.go('tab-dash');
                }
                else {
                
                    $scope.authorization.errorMessage = response.ErrorMessage;
                }            
                $scope.data = { isLoading: false };
            })
            .error(function (error) {
                $scope.authorization.errorMessage = error.message;
                $scope.data = { isLoading: false };
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
