<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ClubArcada.BarCalendar.Web.Pages.Main" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

            HandleWorkTime($(".ddlType").val());

            $(".ddlType").change(function () {
                HandleWorkTime($(".ddlType").val());
            });

            $(document).on('click', '.deleteBtn', function () {

                var elm = $(this);
                var id = $(this).attr('id');

                $.ajax({
                    url: '../Services/BarService.asmx/DeleteShift',
                    type: 'POST',
                    data: JSON.stringify({ shiftId: id }),
                    contentType: "application/json",
                    success: function (data) {
                        elm.parent().parent().fadeOut();
                    }
                });
            });

        });

        function HandleWorkTime(val) {
            var txtWorkTime = $("#<%=txtWorkTime.ClientID%>");

            if (val == 1 || val == 2) {
                txtWorkTime.val("12");
            }
            else {
                txtWorkTime.val("6");
            }
            txtWorkTime.blur();
            return false;
        }

        function NewShift(date) {
            $('.divRollEdit').slideDown();

            $('.txtDate').val(date);

        }
        function CloseShift() {
            $('.divRollEdit').fadeOut();
        }

        function OnTypeChange() {
            var select = $('.ddlType');
            alert(select.val());
        }

        function CreateShift() {
            var userid = $("#ddlUser").val();
            var type = $("#ddlType").val();
            var time = $("#txtWorkTime").val();
            var year = $("#txtDate").val().split(".")[2];
            var month = $("#txtDate").val().split(".")[1];
            var day = $("#txtDate").val().split(".")[0];

            var parameters =
                {
                    userid: userid,
                    type: type,
                    hours: time,
                    year: year,
                    month: month,
                    day: day
                };

            var container = $(".li_" + day + "_" + month + "_" + year);

            $.ajax({
                url: '../Services/BarService.asmx/Create',
                type: 'POST',
                data: JSON.stringify(parameters),
                contentType: "application/json",
                success: function (data) {

                    container.find('.workerContainer').each(function (idx, elm) {
                        $(this).remove();
                    });

                    $.each(data.d, function (key, value) {
                        var iconStyle = "";
                        if (value.ShiftType == 1)
                            iconStyle = "divIconDay";
                        else if (value.ShiftType == 2)
                            iconStyle = "divIconNight";
                        else if (value.ShiftType == 3)
                            iconStyle = "divIconHelp";

                        var elm = '<div style="background-color:#' + value.ColorHex + '" class="workerContainer"><a href="../Pages/UserEdit.aspx?uid=' + value.UserId + '"><img src="data:image/jpg;base64,' + value.ImageData + '" title="' + value.FirstName + ' ' + value.LastName + '" class="divWorkerAvatar"></a></img><div class="divName">' + value.FirstName + ' </br> ' + value.LastName + '</div><div class="' + iconStyle + '"></div><div class="divWorkTime"> ' + value.DurationDisplayName + ' </div><div class="edit"><div class="deleteBtn" id="' + value.ShiftId + '"></div></div>';

                        if (value.ImageData == "") {
                            var elm = '<div style="background-color:#' + value.ColorHex + '" class="workerContainer"><a style="display:none;" href="../Pages/UserEdit.aspx?uid=' + value.UserId + '"><div title="' + value.FirstName + ' ' + value.LastName + '" class="divWorkerAvatar"></div></a><div class="divName">' + value.FirstName + ' </br> ' + value.LastName + '</div><div class="' + iconStyle + '"></div><div class="divWorkTime"> ' + value.DurationDisplayName + ' </div><div class="edit"><div class="deleteBtn" id="' + value.ShiftId + '"></div></div>';
                        }

                        container.append(elm);

                    });

                    CloseShift();

                    $('.workerContainer').hover(function (e) {
                        e.stopPropagation();
                        $(this).find('.edit').show();
                    }, function (e) {
                        e.stopPropagation();
                        $(this).find('.edit').hide();
                    });

                }
            });
        }
    </script>

    <div class="divRollEdit">

        <ul style="margin-left: 10px; width: 100px;">
            <li>Dátum</li>
            <li>Personal</li>
            <li>Typ</li>
            <li>Počet hodín</li>
            <li>.</li>
            <li>.</li>
        </ul>
        <ul style="display: inline-block; width: 220px;">
            <li>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="txtDate" ID="txtDate"></asp:TextBox>
                <ajaxToolkit:CalendarExtender Format="dd.MM.yyyy" runat="server" BehaviorID="TextBox3_CalendarExtender" TargetControlID="txtDate" ID="TextBox3_CalendarExtender"></ajaxToolkit:CalendarExtender>
            </li>
            <li>
                <asp:DropDownList ClientIDMode="Static" runat="server" ID="ddlUser" />
            </li>

            <li>
                <asp:DropDownList runat="server" ClientIDMode="Static" CssClass="ddlType" ID="ddlType">
                    <asp:ListItem Text="Denná" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Nočná" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Výpomoc" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <asp:TextBox runat="server" CssClass="txtWorkTime" ClientIDMode="Static" ID="txtWorkTime"></asp:TextBox></li>
            <li></li>
            <li></li>
            <li>
                <asp:Button OnClientClick="CreateShift();return false;" CssClass="greenButton" Style="width: 100px;" runat="server" Text="Uložiť" ID="btnSave" />
                <asp:Button CssClass="redButton" Style="width: 100px;" runat="server" OnClientClick="CloseShift();return false;" Text="Zavriet" ID="btnReset" /></li>
        </ul>
    </div>

    <div class="divCalendarNavigetionBar">
        <asp:ImageButton OnClick="ibtnCalendarPrev_Click" ID="ibtnCalendarPrev" Width="30" runat="server" ImageUrl="~/Images/icons/arrow-left.png" />
        <asp:Label CssClass="lblDate" Text="Oktober" runat="server" ID="lblDate" />

        <input class="hfSelectedDate" type="hidden" id="hfSelectedDate" runat="server" />

        <asp:ImageButton OnClick="ibtnCalendarNext_Click" ID="ibtnCalendarNext" Width="30" runat="server" ImageUrl="~/Images/icons/arrow-right.png" />
    </div>

    <div id="divCalendarContainer">
        <ul>

            <asp:Repeater runat="server" ID="rptDays">
                <ItemTemplate>
                    <li id="liContainer" runat="server">
                        <div onclick="NewShift('<%# Eval("JsDateTime") %>');" class="divNewShift">
                        </div>

                        <div class="separator"></div>

                        <div class="divDate">
                            <asp:Label runat="server" ID="lblDate"></asp:Label>
                            <input type="hidden" runat="server" class="hfDate" id="hfDate" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>