<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="ClubArcada.BarCalendar.Web.Pages.UserEdit" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formCover">

        <div class="divUserListContainer">
            <asp:Repeater runat="server" ID="rptUsers">
                <ItemTemplate>
                    <div class="divUserContainer" runat="server" id="divUserContainer">
                        <asp:HyperLink runat="server" ID="hlUser"></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="formCoverTwoCol">

            <ul style="display: inline-block; margin-left: 10px; width: 120px;">
                <li style="height:30px;"><asp:Image runat="server" ID="imgAvatar" /></li>
                <li>Meno</li>
                <li>Priezvisko</li>
                <li>Avatar</li>
                <li>Farba</li>
                <li>.</li>
                <li>.</li>
            </ul>
            <ul style="display: inline-block; width: 300px;">
                <li style="height:30px;"><asp:Label Font-Bold="true" Font-Size="16" runat="server" ID="txtFullname"></asp:Label></li>
                <li>
                    <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox></li>
                <li>
                    <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox></li>
                <li>
                    <asp:FileUpload runat="server" ID="fuAvatar" /></li>
                <li>

                    <asp:TextBox runat="server" ID="txtColor"></asp:TextBox><ajaxToolkit:ColorPickerExtender runat="server" BehaviorID="txtColor_ColorPickerExtender" TargetControlID="txtColor" ID="txtColor_ColorPickerExtender"></ajaxToolkit:ColorPickerExtender>
                </li>
                <li></li>
                <li>
                    <asp:Button Style="width: 100px;" OnClick="btnSave_Click" runat="server" Text="Uložiť" ID="btnSave" /><asp:Button Style="width: 100px;" runat="server" Text="Reset" ID="btnReset" /></li>
            </ul>
        </div>
    </div>
</asp:Content>