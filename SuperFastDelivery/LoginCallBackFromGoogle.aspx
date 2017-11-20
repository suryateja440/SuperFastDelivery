<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginCallBackFromGoogle.aspx.cs" Inherits="SuperFastDelivery.LoginCallBackFromGoogle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
<script src="scripts/jquery-3.2.1.min.js" type="text/javascript" ></script>
    <script type="text/javascript">
        try {
            // First, parse the query string
            var params = {}, queryString = location.hash.substring(1),
    regex = /([^&=]+)=([^&]*)/g, m;
            while (m = regex.exec(queryString)) {
                params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
            }
            var ss = queryString.split("&")
            // window.location = "Home.aspx?" + ss[1];
            if (ss != undefined) {
                window.location = "Home.aspx?" + ss[1];
                history.pushState("", "", "Home.aspx");
            }
            else
                window.location = "Home.aspx";


        } catch (exp) {

        }
    </script> 
</html>
