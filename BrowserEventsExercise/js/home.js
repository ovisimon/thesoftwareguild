$(document).ready(function () {
    $("#akronInfoDiv, #minneapolisInfoDiv, #louisvilleInfoDiv").hide();
    $("#akronButton").on("click", function(){
        $("#mainInfoDiv, #minneapolisInfoDiv, #louisvilleInfoDiv").hide();
        $("#akronInfoDiv").show();
        $("#akronWeather").hide();
    });
    $("#akronWeatherButton").on("click", function () {
            $("#akronWeather").toggle("slow");
        })

    $("#minneapolisButton").on("click", function(){
        $("#mainInfoDiv, #akronInfoDiv, #louisvilleInfoDiv").hide();
        $("#minneapolisInfoDiv").show();
        $("#minneapolisWeather").hide();
    });
    $("#minneapolisWeatherButton").on("click", function () {
            $("#minneapolisWeather").toggle("slow");
        })

    $("#louisvilleButton").on("click", function(){
        $("#mainInfoDiv, #akronInfoDiv, #minneapolisInfoDiv").hide();
        $("#louisvilleInfoDiv").show();
        $("#louisvilleWeather").hide();
    });
    $("#louisvilleWeatherButton").on("click", function () {
            $("#louisvilleWeather").toggle("slow");
        })

     $("#mainButton").on("click", function(){
        $("#louisvilleInfoDiv, #akronInfoDiv, #minneapolisInfoDiv").hide();
        $("#mainInfoDiv").show();
    });

    $("tr").not("tr:first").hover(
    function () {
        $(this).css("background-color", "WhiteSmoke");
    },
    function () {
        $(this).css("background-color", "");
    }
);

});