(function () {
    var imdbApiUrl = 'http://www.omdbapi.com/?t=##movieName##&y=&plot=short&r=json';

    var getRelatedMovies = function (movieName, successCallback, errorCallback) {
        var queryUrl = imdbApiUrl.replace("##movieName##", encodeURIComponent(movieName));
        $.ajax(queryUrl, {
            method: 'Get'
        })
        .done(successCallback)
        .fail(errorCallback);
    }

    return imdbApiClient = {
        'getRelatedMovies': getRelatedMovies
    };
})();