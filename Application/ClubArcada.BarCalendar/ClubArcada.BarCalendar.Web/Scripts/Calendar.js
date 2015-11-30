$(document).ready(function () {
    SizeCalendar();

    $(window).resize(function () {
        SizeCalendar();
    });

    $('.hfDate').each(function () {
        var date = new Date($(this).val().split('-')[2], $(this).val().split('-')[1] - 1, $(this).val().split('-')[0]);
        var selectedMonth = parseInt($('.hfSelectedDate').val()) + 1;

        var year = parseInt($(this).val().split('-')[2], 0);
        var month = parseInt($(this).val().split('-')[1], 0);
        var day = parseInt($(this).val().split('-')[0], 0);

        if (month != selectedMonth) {
            $(this).parent().parent().append('<div class="divShader"></div>');
            console.log(date.getDate() + " ___ " + date.getMonth() + "---" + (new Date().getMonth() + 1));
        }

        var dayx = date.getDay();
        var isWeekend = (dayx == 0) || (dayx == 6);
        if (isWeekend) {
            $(this).parent().parent().css("background-color", "#D8FFD3");
        }

        if ((new Date()).getMonth() == date.getMonth() && (new Date()).getDate() == date.getDate()) {
            $(this).parent().parent().css("background-color", "#FFD3D3");
        }

        var container = $(this);

        $.ajax({
            url: '../Services/BarService.asmx/GetShifts',
            type: 'POST',
            data: JSON.stringify({ year: year, month: month, day: day }),
            contentType: "application/json",
            success: function (data) {
                $.each(data.d, function (key, value) {
                    var iconStyle = "";
                    if (value.ShiftType == 1)
                        iconStyle = "divIconDay";
                    else if (value.ShiftType == 2)
                        iconStyle = "divIconNight";
                    else if (value.ShiftType == 3)
                        iconStyle = "divIconHelp";

                    var elm = '<div style="background-color:#' + value.ColorHex + '" class="workerContainer"><a href="../Pages/UserEdit.aspx?uid=' + value.UserId + '"><img src="data:image/jpg;base64,' + value.ImageData + '" title="' + value.FirstName + ' ' + value.LastName + '" class="divWorkerAvatar"></img></a><div class="divName">' + value.FirstName + ' </br> ' + value.LastName + '</div><div class="' + iconStyle + '"></div><div class="divWorkTime"> ' + value.DurationDisplayName + ' </div><div class="edit"><div class="deleteBtn" id="' + value.ShiftId + '"><div></div></div>';

                    if (value.ImageData == "") {
                        var elm = '<div style="background-color:#' + value.ColorHex + '" class="workerContainer"><a href="../Pages/UserEdit.aspx?uid=' + value.UserId + '"><div title="' + value.FirstName + ' ' + value.LastName + '" class="divWorkerAvatar"></div></a><div class="divName">' + value.FirstName + ' </br> ' + value.LastName + '</div><div class="' + iconStyle + '"></div><div class="divWorkTime"> ' + value.DurationDisplayName + ' </div><div class="edit"><div class="deleteBtn" id="' + value.ShiftId + '"><div></div></div>';
                    }
                    container.parent().parent().append(elm);
                });

                $('.workerContainer').hover(function (e) {
                    e.stopPropagation();
                    $(this).find('.edit').show();
                }, function (e) {
                    e.stopPropagation();
                    $(this).find('.edit').hide();
                });
            }
        });
    });
});

function SizeCalendar() {
    var dayWidth = ($('#divCalendarContainer').width() - (9)) / 7;

    $('#divCalendarContainer ul li').css("width", dayWidth + "px");
}