<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs"  enableSessionState="true" Inherits="SuperFastDelivery.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/toastr.css" rel="stylesheet" />
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap-theme.min.css"/>
    <link href="CSS/Login.css" rel="stylesheet" />
    <style>
        .loginBtn :hover {
            background : black
        }
        </style>
</head>
<body>
   
    <div style ="width:1000px">
       <section class="login">
	<div class="titulo">
        <label id ="lbltype" style ="height:100px">User Login</label>
	</div>
	<form action="#" method="post" enctype="application/x-www-form-urlencoded" runat ="server">
        <div id ="divLogin">

                <asp:TextBox  runat="server"   required ="required" id ="txtUserName" title="Username required" placeholder="Username"  />
                <asp:TextBox  runat="server" TextMode="Password"  required ="required" id ="txtPassWord" title="Username required" placeholder="Password"  />
                <asp:Label ID ="lblInvalidUser" style ="color:white"  runat="server"/>
    	        <%--<input type="text" required ="required" id ="txtUserName" title="Username required" placeholder="Username" data-icon="U"/>
                <input type="password" required ="required" id ="txtPassWord" title="Password required" placeholder="Password" data-icon="x"/>--%>
                <div class="olvido">
        	        <div class="col"><a href="#register" id ="hrfRegister" title="Ver Carásteres">Register</a></div>
                    <div class="col"><a href="#ForgetPassword" title="Recuperar Password">Forgot Password?</a></div>
                </div>
                <%--<input type ="button" id ="btnLogin" style =" margin-top:15px; margin-right:20px ;float:left" class ="btn btn-success" value ="Submit"/>--%>
                         <asp:Button id ="btnLogin" style =" margin-top:15px; margin-right:20px ;float:left" class ="btn btn-success" runat="Server" Text="Submit" OnClick="Button_Login" />

                <div style="margin-top:15px;" >
                <input type ="button" id ="btnLgnWithGoogle" class ="btn btn-primary" value="LoginWithGoogle"/>

            </div>
         </div>
                            <div id ="register" style ="display:none">
                                <table id ="tblRegister">
                                    <tr>
                                        <td style ="color:whitesmoke;margin-right:10px">
                                            UserName:
                                        </td>
                                        <td></td>
                                        <td>
                                            <input type ="text" style ="height:50px;width:500px" placeholder ="username" id ="sgnUserName"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style ="color:whitesmoke">
                                            PassWord:
                                        </td>
                                         <td></td>
                                        <td>
                                            <input type ="password"  placeholder ="password" id ="sgnPassword"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style ="color:whitesmoke">
                                            Email:
                                        </td>
                                         <td></td>
                                        <td>
                                            <input type ="text"  placeholder ="Email" id ="sgnEmail"/>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td style ="color:whitesmoke">
                                            Mobile Number:
                                        </td>
                                           <td></td>
                                        <td>
                                            <input type ="text"  placeholder ="Mobile Number" id ="sgnMobileNumber"/>
                                        </td>
                                    </tr>
                                    
                           </table>
                                <br /> <br/> <br/>
                                <input type ="button" id="btnSignUp" class ="btn btn-success" value="Sign-Up"/> &nbsp &nbsp &nbsp
                                    <input type ="button" id="btnCancelSignUp" class ="btn btn-primary" value="Cancel"/>
                    </div>
    </form>
</section>

    </div>
  
</body>
<script src="scripts/jquery-3.2.1.js" type ="text/javascript"></script>
<script src="scripts/bootstrap.min.js" type="text/javascript"></script>
<script src="scripts/toastr.js" type="text/javascript"></script>
<%--<script src="scripts/Jquery.Toastr.js" type="text/javascript"></script>--%>
<script src="JsFiles/Login.js" type="text/javascript"></script>
    <script type="text/javascript" >

        toastr.options = {
            "closeButton": true,
            "progressBar": true
        }
        $("#btnLgnWithGoogle").click(function(){
        
            var url = "https://accounts.google.com/o/oauth2/auth?";
            url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
            url += "state=%2Fprofile&"
            url += "redirect_uri=http://localhost:1583/LoginCallBackFromGoogle.aspx&"
            url += "response_type=token&"
            url += "client_id=482355408112-afq2bm4daflpmc8q293eg7ili0qd87mg.apps.googleusercontent.com";

            window.location = url;
        
        
        
        
        });
      


    </script>
</html>
