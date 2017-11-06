function searchFilms() {
    $.ajax({
        url: "Search/SearchFilms",
        contentType: "application/x-www-form-urlencoded",
        type: "POST",
        datatype: "json",
        data: param,
        success: function (data) {
            if (data != null) {
                alert("success");
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function searchShows() {
}