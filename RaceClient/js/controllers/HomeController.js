'use strict';

raceApp.controller('HomeController',
    function HomeController($scope, $http,url,timePerRequest) {
    $scope.raceEvents = [];
  
     
    $scope.orderOddDecimal=0;
    $scope.orderName=0;
    
    $scope.orderByName=function(){
        if($scope.orderName==0)
        {
            $scope.orderName=1;
        }
        else if($scope.orderName==1)
        {
            $scope.orderName=-1;
        }
        else if($scope.orderName==-1)
        {
            $scope.orderName=0;
        }
        requestData();
    }
    
    $scope.orderByOddDecimal=function(){
               if($scope.orderOddDecimal==0)
        {
            $scope.orderOddDecimal=1;
        }
        else if($scope.orderOddDecimal==1)
        {
            $scope.orderOddDecimal=-1;
        }
        else if($scope.orderOddDecimal==-1)
        {
            $scope.orderOddDecimal=0;
        }
        requestData();
    }
    $scope.url=url+"?sortByName="+$scope.orderName+"&sortByOddNumber="+$scope.orderOddDecimal;
    requestData();
    
   
    function requestData()
    {
          $scope.url=url+"?sortByName="+$scope.orderName+"&sortByOddNumber="+$scope.orderOddDecimal;
    
            $http({method:'GET', url:$scope.url})
            .success(function(data){
                $scope.raceEvents=data;
    });
    }
    
    function callFnOnInterval(timeInterval) {
            setInterval(function(){
      requestData();
                },timeInterval);
            };
     callFnOnInterval(timePerRequest);


});
