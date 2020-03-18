$(document).click(function (event) {
    $target = $(event.target);
    if (!$target.closest('#weather').length &&
        $('#weather').is(":visible")) {
        $('#weather').hide();
    }
});

$("#toggle_weather").click(function () {
    //$("#weather").show();
    setTimeout(function (e) {
        $('#weather').show();
    }, 20);
});

$("#myInput").keyup(function () {
    var value = $(this).val().toLowerCase();

    if (value == "") {
        $('#weather a').hide().filter(':lt(0)').show();
    }
    else {
        $("#weather a").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });

        $('#weather a:visible').hide().filter(':lt(7)').show();
    }
});


// hide all a and then show the first two
$('#weather a').hide().filter(':lt(0)').show();

function getWeather(city) {
    $.get("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&APPID=c16e6afdfb6e410963c75506963bc8fb&units=metric", function (data) {

        $("#deg1").html(parseInt(data.main.temp))
        $("#weather_desc").html(data.weather[0].description);
        var daysWeek = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
        var date = new Date(parseInt(data.dt) * 1000);
        var ampm = date.getHours() >= 12 ? "PM" : "AM";
        $("#weather_date").html(daysWeek[date.getDay()] + ", " + date.getHours() + ":" + date.getMinutes() + " " + (ampm));
        $("#weather_humidity").html(data.main.humidity);
        $("#weather_winds").html(data.wind.speed);
        $("#weather_title").html(city);
        $("#weather_country").html(data.sys.country == "PS" ? "IL" : data.sys.country);

        $("#show_weather").show();
    });
}

getWeather("Holon");

$('#weather a').click(function () {
    getWeather($(this).html());
    $("#weather").hide();
});

$("#selectLocation").click(function () {
    $("#locationSelected").show();
});

$(document).click(function () {
    //if ($(this).attr('id') != "weather" )
    //$("#weather").hide();

    if ($(this).attr('id') != "locationSelected")
        $("#locationSelected").hide();
});



$("#locationSelected a").click(function () {
    $("#gmap_canvas").attr("src", "https://maps.google.com/maps?q=" + $(this).html() + "&t=&z=13&ie=UTF8&iwloc=&output=embed");
});




$.get("https://graph.facebook.com/me?fields=id%2Cname%2Cposts&access_token=EAANPSHxsjsQBAJPTSLoKcqWQtyBBTSBZCanfVwSN9YteBNNDIAZC4LsCjqH9BkuSbXOZCaQImU4fj6LJ1IAkyWSHGbADzLhuLeZAW6CRqxY6QT88LD1mpT3QF0N9zIzZAZBumpL8FmDORrCLySVNlTEODfUFK5nDCZAQlBUcLZCfTONGcrZCRZCRJE", function (data) {
    var size = data.posts.data.length > 3 ? 3 : data.posts.data.length;
    for (var i = 0; i < size; i++) {
        //var date = new Date(parseInt(data.posts.data[i].created_time));
        var string =
            '<div class="card text-white bg-primary mb-3" style="border-radius: 3px;  margin-left: 20px; margin-right: 20px;">' +
            '<div class="card-body">' +
            '<p class="card-text">' + data.posts.data[i].message + '</p>' +
            '</div >' +
            '</div>';

        if (i == 0) {
            $("#facebook_posts").html(string);
        }
        else {
            $("#facebook_posts").append(string);
        }
    }
});


