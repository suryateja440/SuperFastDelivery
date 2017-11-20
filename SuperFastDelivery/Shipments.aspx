<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shipments.aspx.cs" Inherits="SuperFastDelivery.Shipments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <input type ="hidden" id ="hdnShipMent" lcation ="" fromdate ="" todate ="" runat="server"/>
    </div>
    </form>
</body>
    <script src="scripts/jquery-3.2.1.js" type ="text/javascript"></script>
    <script type ="text/javascript">
        $(document).ready(function () {
            alert($("#hdnShipMent").attr("lcation"));
            alert($("#hdnShipMent").attr("fromdate"));
            alert($("#hdnShipMent").attr("todate"));

        });
        </script>
</html>

