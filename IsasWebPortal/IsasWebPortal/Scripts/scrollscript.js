// Reposition the content to be below the fixed header
var heightHeader = $(".header").outerHeight();
$(".content").css("margin-top", heightHeader);

// If ENTER in search fields
//$(document).ready(
//$(".header input:text").keydown
//(function (e) {
    //if (e.keyCode == 13) {

        // This is the final layout for the table (biggest column wins)
        var arrLayout = [];

        // Get the column widths in the first row in the "header" table
        $(".header tr:first").find("td").each(function () {
            var index = $(this).index();
            var width = $(this).outerWidth(true);
            //width == '' ? 0 : width;
            
            arrLayout[index] = width ;
        });

        //arrLayout[2] == '' ? '0' : arrLayout[2];

        // Get the column widths in the first row in the "data" table
        $(".data tr:first").find("td").each(function () {
            var index = $(this).index();
            var width = $(this).outerWidth(true);
            // Override the final layout if this column is bigger
            if (width > arrLayout[index]) {
                arrLayout[index] = width;
            }
        });

        // Summarize the final table width
        var widthSum = 0;
        for (var i = 0; i < arrLayout.length; i++) {
            widthSum += parseInt(arrLayout[i]);
        }

        // Set the new width to the two tables        
        $(".header").width(widthSum);
        $(".data").width(widthSum);

        // Set the new widths on the columns (both tables)
        for (var i = 0; i < arrLayout.length; i++) {
            $(".header tr:first td:eq(" + i + ")").css({ "min-width": arrLayout[i] });
            $(".data tr:first td:eq(" + i + ")").css({ "min-width": arrLayout[i] });
        }

    //} // if(e.keyCode == 13)
//}
//); // $(".tableheader input:text").keydown(function(e)
