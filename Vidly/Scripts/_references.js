/// <autosync enabled="true" />
/// <reference path="ai.0.22.9-build00167.min.js" />
/// <reference path="bootstrap.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
/// <reference path="jquery-1.10.2.js" />
/// <reference path="modernizr-2.6.2.js" />
/// <reference path="respond.js" />


$.get("/api/movies/1", {
    success: function (obj) {
        alert("finish");
    }
});


$.get("/api/movies/2", {
    success: function (obj) {
        alert("finish2");
    }
});