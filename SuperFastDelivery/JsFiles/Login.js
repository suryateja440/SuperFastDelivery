$(document).ready(function () {
    $("#btnLogin").click(function ()
    {
        var username = $("#txtUserName").val();
        var password = $("#txtPassWord").val();

        $.ajax({
            async: false,
            type: "GET",
            url: "AjaxHnadlers/Login.ashx",
           // contentType: "application/json; charset=utf-8",
            data: { type: 1, username: username, password: password },
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