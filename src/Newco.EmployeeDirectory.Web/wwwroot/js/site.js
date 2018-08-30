// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//NAVBAR - Used to set the active state for the link
$(document).ready(function() {
    // clear the active class from all nav bar options
    $('.nav > li').removeClass('active');

    // get current URL path and assign 'active' class
    var pathname = window.location.pathname;
    $('.nav > li > a[href="' + pathname + '"]').parent().addClass('active');


    //Employee Search Page to do post back and render view to page
    $("#EmployeeSearch").on('click', function(e) {
            e.preventDefault();
            var term = $("#SearchTerm").val();

            $("#SearchResultsTable").html('');

            if (!term) {
                return;
            }

            $.post("Home/Search", { searchTerm: term}, function (data) {
                $("#SearchResultsTable").html(data);
            });
        });
});

$(document).on('click','.employeeLink',function(e) {
        e.preventDefault();
        var username = e.currentTarget.dataset.id;

        $.post("Home/GetEmployeeDetails",
            { id: username },
            function(data) {
                $("#SearchResultsTable").html(data);
            });
    });
