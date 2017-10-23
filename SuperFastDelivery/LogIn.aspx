<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SuperFastDelivery.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/Login.css" rel="stylesheet" />
    <style>
        .loginBtn :hover {
            background : black
        }
        </style>
</head>
<body>
   
    <div>
       <section class="login">
	<div class="titulo">User Login</div>
	<form action="#" method="post" enctype="application/x-www-form-urlencoded">

    	<input type="text" required ="required" id ="txtUserName" title="Username required" placeholder="Username" data-icon="U"/>
        <input type="password" required ="required" id ="txtPassWord" title="Password required" placeholder="Password" data-icon="x"/>
        <div class="olvido">
        	<div class="col"><a href="#" title="Ver Carásteres">Register</a></div>
            <div class="col"><a href="#" title="Recuperar Password">Forgot Password?</a></div>
        </div>
        <input type ="button" id ="btnLogin" style =" margin-top:15px; margin-right:20px ;float:left" class ="btn btn-success" value ="Submit"/>
        <div style="margin-top:15px;" >
        <input type ="button" class ="btn btn-primary" value="LoginWithGoogle">
         </div>
    </form>
</section>

    </div>
  
</body>
<script src="scripts/jquery-3.2.1.js" type ="text/javascript"></script>
<script src="scripts/jquery-3.2.1.min.js" type ="text/javascript"></script>
<script src="JsFiles/Login.js" type="text/javascript"></script>
</html>
