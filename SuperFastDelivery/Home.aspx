<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs"  enableSessionState="true" Inherits="SuperFastDelivery.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1> this is test</h1>
        <label id ="lblUsername"></label>
        <input type ="hidden" id ="hdnUserName" runat ="server" />
        <input type ="button" class ="btn btn-primary" id ="btnExcel" value ="Download to Excel"/>
        <select id ="items">
            <option value ="0">Lunch</option>
            <option value ="1">Tiffin</option>
            <option value ="2">Dinner</option>
            <option value ="3">Snacks</option>
        </select>
        <a class ="redirectUrl" id ="EMpID"  > ShipmentTrack </a>
    </div>
    </form>
</body>
<script src="scripts/jquery-3.2.1.js" type ="text/javascript"></script>
    <script type ="text/javascript">
        $(document).ready(function () {
            $("#hdnUserName").val('<%= Username %>');
            var username = $("#hdnUserName").val();
            $("#lblUsername").text("hi " + username);

            var items = $("#items option").length;
            var item = $("#items option[value='0']").length
           
            if ($("#items option[value='0']").length > 0)
            {
                alert(items);
                alert(item);
            }
            $("#EMpID").click(function(){
            
                var $form = $("<form/>").attr("id", "data_form")
                               .attr("action", "Shipments.aspx")
                               .attr("method", "post");
                $("body").append($form);
 
                //Append the values to be send
                AddParameter($form, "Location", "Hyderabad");
                AddParameter($form, "technology", ".Net");
 
                //Send the Form
                $form[0].submit();
            });
       
        function AddParameter(form, name, value) {
            var $input = $("<input />").attr("type", "hidden")
                                    .attr("name", name)
                                    .attr("value", value);
            form.append($input);
           
        }
            $("#btnExcel").click(function () {
                    $.ajax({
                        async: false,
                        type: "GET",
                        url: "AjaxHnadlers/Login.ashx",
                       // contentType: "application/json; charset=utf-8",
                        data: { type: 2  },
                        dataType: "json",
                        success: function (res)
                        {
                            if (res.Success == true)
                            {
                                if (res.Message == "Valid Username and Password") {
                                    alert("Username and Password correct");

                                }
                                else
                                {
                                    alert("Username and Password are  Incorrect");
                                }
                            }

                        },
                        error: function (res)
                        { }

                    });




            });

        });
        </script>
</html>
