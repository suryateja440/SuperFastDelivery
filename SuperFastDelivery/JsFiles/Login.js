$(document).ready(function () {
    $("#hrfRegister").click(function () {
        $("#divLogin").hide();
        $("#register").show();
        $("#lbltype").text("Sign-Up Form");
    });
    $("#btnCancelSignUp").click(function () {
        $("#divLogin").show();
        $("#register").hide();
        $("#lbltype").text("User Login");

    });
    $("#btnSignUp").click(function () {
        var Username = $("#sgnUserName").val();
        var PassWord = $("#sgnPassword").val();
        var EmaiID = $("#sgnEmail").val();
        var MobileNumber = $("#sgnMobileNumber").val();
        //$.toaster({ priority: "success", title: Username, message: MobileNumber });
        //toastr.success('Success messages', { closeButton: true });
        //toastr.success("<div><input class='input-small' value='textbox'/>&nbsp;<a href='http://johnpapa.net' target='_blank'>This is a hyperlink</a></div><div><button type='button' id='okBtn' class='btn btn-primary'>Close me</button><button type='button' id='surpriseBtn' class='btn' style='margin: 0 8px 0 8px'>Surprise me</button></div>");
     //   toastr.
        if (Username == "" ) 
        {
            toastr.warning("Please fill Username", { closeButton: true });
            return;
        }

        if (PassWord == "" ) 
        {
            toastr.warning("Please fill PassWord", {closeButton:true});
            return;
        }
        if (EmaiID == "" ) 
        {
            toastr.warning("Please fill EmaiID", { closeButton: true });
            return;
        }
        if (MobileNumber == "" ) 
        {
            toastr.warning("Please fill MobileNumber", { closeButton: true });
            return;
        }
        $.ajax({
            async: false,
            type: "GET",
            url: "AjaxHnadlers/Login.ashx",
            data: { type: 3, Username: Username, PassWord: PassWord, EmaiID: EmaiID, MobileNumber: MobileNumber },
            dataType: "json",
            success: function (res)
            {
                alert(res.RetMsg);
            },
            error: function (res)
            {
                alert(res.RetMsg);
            }
        });

      

    });
    //$("#btnLogin").click(function ()
    //{
    //    var username = $("#txtUserName").val();
    //    var password = $("#txtPassWord").val();

    //    $.ajax({
    //        async: false,
    //        type: "GET",
    //        url: "AjaxHnadlers/Login.ashx",
    //       // contentType: "application/json; charset=utf-8",
    //        data: { type: 1, username: username, password: password },
    //        dataType: "json",
    //        success: function (res)
    //        {
    //            if (res.Success == true)
    //            {
    //                if (res.Message == "Valid Username and Password") {
    //                    alert("Username and Password correct");
                       
    //                }
    //                else
    //                {
    //                    alert("Username and Password are  Incorrect");
    //                }
    //            }
                
    //        },
    //        error: function (res)
    //        { }

    //    });


    //});

});