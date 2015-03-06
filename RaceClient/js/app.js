'use strict';

var raceApp = angular
    .module('raceApp', [])
    .constant('timePerRequest', 5000) 
.constant('url','http://localhost:43147/api/values')
    