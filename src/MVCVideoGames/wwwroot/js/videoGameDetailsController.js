(function () {

    var movieApiCallStatus = $('#movie-api-call-status');
    var movieDialog = $("#movie-dialog");
    movieDialog.dialog();
    if (movieDialog.dialog("isOpen"))
        movieDialog.dialog("close");;

    /* function passed as a callback after getting the successful movie
    * clears the dialog, appends the data and displays it
    */
    var displayMovieDataInModal = function (response) {
        if (response.Response === "True") { // odd, but that's how the api works.
            movieDialog.empty();
            var titleHtml = '<h4>' + response.Title + '</h4>';
            var plotHtml = '<p>' + response.Plot + '</p>';
            var imageHtml = '<img src="' + response.Poster + '"/>';

            $(titleHtml).appendTo(movieDialog);
            $(imageHtml).addClass('movie-poster').appendTo(movieDialog);
            $(plotHtml).appendTo(movieDialog);

            movieDialog.dialog("open");
            movieApiCallStatus.removeClass();
            movieApiCallStatus.text('');
        } else {
            displayError(response);
        }
    };

    var displayError = function (response) {
        console.log(response);
        movieApiCallStatus.removeClass();
        movieApiCallStatus.addClass('label label-danger');
        movieApiCallStatus.text('error!');
    };

    var displayRelatedMovieInModal = function (movieName) {
        if (!movieDialog.dialog("isOpen")) {
            imdbApiClient.getRelatedMovies(movieName, displayMovieDataInModal, displayError); // get the movie data
            movieApiCallStatus.removeClass();
            movieApiCallStatus.addClass('label label-default');
            movieApiCallStatus.text('pending...');
        }
    };

    return videoGameDetailsController = {
        'displayRelatedMovieInModal': displayRelatedMovieInModal
    };
})();