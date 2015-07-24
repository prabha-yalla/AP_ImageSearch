
var press = angular.module('Press',[]);

press.controller('searchController',function($scope,$http){

    $scope.images = [];
    $scope.keyword="avatar";
    $scope.data=null;
    $scope.submit= function(){

        if($scope.keyword!==null && $scope.keyword!=="" && typeof $scope.keyword !=="undefined"){
            $http({
                method:"GET",
                header:{
                    accept:"application/json"
                },
                url: "http://localhost:52293//api/Image/",
                params:{
                    search:$scope.keyword
                }

            })
                .success(function(data){
                    $scope.data=data;
                    if(data.entries && data.entries.length){
                        $scope.images =[];
                        for(var i=0;i<data.entries.length;i++){
                          $scope.images.push(data.entries[i].contentLinks[0].href)
                            console.log(data.entries[i].contentLinks[0].href)
                        }
                    }
                    $("#grid").igGrid({
                        dataSource: data.entries, //JSON Array defined above
                        dataSourceType : "JSON "
                    });

                })
                .error(function(data){
                    console.log("Error")
                });
        }


    };

    $scope.submit();

});