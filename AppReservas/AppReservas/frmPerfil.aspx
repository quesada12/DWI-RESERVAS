<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmPerfil.aspx.cs" Inherits="AppReservas.frmPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 261px;
        }
        td{
            padding: 10px;
        }

        .boton{
            padding: 6px !important;
            margin: 10px;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <h1>Actualizar Perfil</h1>

   
    <table style="width:100%;">
         <tr>
            <td class="auto-style1">Código:</td> 
            <td colspan="2">
                <asp:TextBox ID="txtCodigo" runat="server" Width="351px" CssClass="form-control form-control-user" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Identificación:</td> 
            <td colspan="2">
                <asp:TextBox ID="txtIdentificacion" runat="server" Width="351px" CssClass="form-control form-control-user" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Nombre:</td>
            <td colspan="2">
                <asp:TextBox ID="txtNombre" runat="server" Width="351px" CssClass="form-control form-control-user"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Contraseña:</td>
            <td colspan="2">
                <asp:TextBox ID="txtContra" runat="server" Width="351px" CssClass="form-control form-control-user" TextMode="Password" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Confirmar Contraseña:</td>
            <td colspan="2">
                <asp:TextBox ID="txtConfirmar" runat="server" Width="351px" CssClass="form-control form-control-user" TextMode="Password" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email:</td>
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" Width="351px" CssClass="form-control form-control-user"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass=" btn btn-success btn-user btn-icon-split boton" OnClick="btnActualizar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-user btn-icon-split boton" OnClick="btnCancelar_Click"/>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

   


   
</asp:Content>
