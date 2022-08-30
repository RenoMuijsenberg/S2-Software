$(document).ready(function () {
    ChangeNutritionDate();
    SearchNutrition();
});

function ChangeNutritionDate() {
    $(".nutrition-date").change(function (e) {
        var selectedDate = $(this).val();
        $.ajax({
            method: "Post",
            url: '/Nutrition/UpdateTable',
            data: {
                date: selectedDate
            },
            success: function(data) {
                $(".table-partial").empty().html(data);
            }
        });
    });
}

function SearchNutrition() {
    $(".search-nutrition").keyup(function() {
        var value = $(this).val().toLowerCase();
        console.log(value);
        $(".nutrition-table tr").filter(function() {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
}