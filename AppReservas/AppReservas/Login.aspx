<%@ Page Async="true" Title="Ingresar" Language="C#" MasterPageFile="~/Externo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppReservas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
body {font-family: Arial, Helvetica, sans-serif;}
form {border: 3px solid #f1f1f1;}

input[type=text], input[type=password] {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    box-sizing: border-box;
}

.boton{
            width:130px;
            height: 60px;
            padding: 6px !important;
            margin: 10px;
            text-align:center;
        }

.button {
    background-color: #243054;
    color: white;
    padding: 14px 20px;
    margin: 8px 0;
    border: none;
    cursor: pointer;
    width: 100%;
}

button:hover {
    opacity: 0.8;
}

.cancelbtn {
    width: 100%;
    padding: 10px 18px;
    color: white;
    background-color: #898989;
}

.imgcontainer {
    text-align: center;
    margin: 24px 0 12px 0;
}

img.avatar {
    width: 10%;
    border-radius: 10%;
}

/* Clear floats */
.clearfix::after {
    content: "";
    clear: both;
    display: table;
}

.container {
    padding: 16px;
}

span.psw {
    float: right;
    padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
    span.psw {
       display: block;
       float: none;
        text-align: left;
    }
    .cancelbtn {
       width: 100%;
    }
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

  <div class="container">
    <label for="uname"><b>Ingrese sus credenciales</b></label>
    <asp:TextBox Placeholder="Ingrese su identificacion"  runat="server" ID="Identificacion" CssClass="form-control form-control-user"  />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="Identificacion" CssClass="text-danger" ErrorMessage="El campo de nombre de usuario es obligatorio." />
      <br />
    <asp:TextBox Placeholder="Ingrese su password" runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="El campo de password es obligatorio." />
    <asp:Button type="button" CssClass="btn btn-primary btn-user btn-block boton" ID="btnLogin" OnClick="btnIngresar_Click"  runat="server" Text="Ingresar"/> 
   <hr>
      <asp:Button type="button" CssClass="btn btn-google btn-user btn-block boton" ID="btnCancelar"  runat="server" Text="Cancelar" />

      <asp:PlaceHolder runat="server" ID="ErrorMessage"  Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server"  ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
     <br><br>
    
      <a href="Register.aspx" class="btn btn-facebook btn-user btn-block  ">
                       Registrarme
                    </a>
  </div>

</asp:Content>
