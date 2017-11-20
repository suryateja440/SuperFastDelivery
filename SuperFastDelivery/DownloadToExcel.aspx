<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadToExcel.aspx.cs" Inherits="SuperFastDelivery.DownloadToExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ExportToExcel.ashx">Export to Excel</asp:HyperLink>
    <a href="AjaxHnadlers/ExportToExcel.ashx">Export to Excel </a>
        <input type ="button" id ="btnExportToExcel" class ="btn btn-primary" value ="Export To Excel"/>
    </div>
    </form>
</body>
<script type ="text/javascript" src="scripts/jquery-3.2.1.js"></script>
<script type ="text/javascript" src="scripts/bootstrap.js"></script>
    <script  type ="text/javascript">
        $("#btnExportToExcel").click(function () {
            $.ajax({
                url: "AjaxHnadlers/ExportToExcel.ashx",
                type: "GET",
                data:{type :2}
              //  dataType: 'json',
                //success: function (data) {
                //    //if (data.NeedRedirect)
                //    //    window.location.replace("WhereToMove.aspx");
                //    alert("Success");
                //},
                //error: function (responseText, textStatus, XMLHttpRequest) {
                //    window.location.replace("WhereToMove.aspx");
                //}
            });




        });


    </script>
</html>
