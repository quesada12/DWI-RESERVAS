<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="nuevoHotel.aspx.cs" Inherits="AppReservas.nuevoHotel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 261px;
        }
        td{
            padding: 10px;
        }

        .boton{
            width:130px;
            height: 60px;
            padding: 6px !important;
            margin: 10px;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Crear Hotel</h1>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Nombre:</td> 
            <td colspan="2">
                <asp:TextBox ID="txtNombre" runat="server" Width="351px" CssClass="form-control form-control-user"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" CssClass="text-danger" ErrorMessage="El campo de nombre es obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email:</td> 
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" Width="351px" CssClass="form-control form-control-user"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="El campo de email es obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td class="auto-style1">Direccion:</td> 
            <td colspan="2">
                <asp:TextBox ID="txtDireccion" runat="server" Width="351px" CssClass="form-control form-control-user"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDireccion" CssClass="text-danger" ErrorMessage="El campo de Direccion es obligatorio."></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass=" btn btn-success btn-user btn-icon-split boton" OnClick="btnCrear_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-user btn-icon-split boton" OnClick="btnCancelar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td colspan="3">
                <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
