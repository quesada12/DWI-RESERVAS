<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="nuevaReserva.aspx.cs" Inherits="AppReservas.nuevaReserva" %>
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
     <h1>Crear Reserva</h1>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Fecha Ingreso:</td> 
            <td colspan="2">
                <asp:Calendar ID="txtCalendarioIngreso" runat="server" Height="142px" Width="231px"></asp:Calendar>
               </td>
        </tr>
        <tr>
            <td class="auto-style1">Fecha Salida:</td> 
            <td colspan="2">
                <asp:Calendar ID="txtCalendarioSalida" runat="server" Height="142px" Width="271px"></asp:Calendar>
               </td>
        </tr>
 
        <tr>
            <td class="auto-style1">Hotel:</td> 
            <td colspan="2">
             <asp:DropDownList ID="ddlHotel" runat="server" CssClass="btn btn-primary dropdown-toggle" Width="351px" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged" AutoPostBack="True">
           
                </asp:DropDownList>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlHotel" CssClass="text-danger" ErrorMessage="El campo de hotel es obligatorio."></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="auto-style1">Habitacion:</td> 
            <td colspan="2">
                <asp:DropDownList ID="ddlHabitacion" runat="server" CssClass="btn btn-primary dropdown-toggle" Width="351px">
                 
                </asp:DropDownList>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlHabitacion" CssClass="text-danger" ErrorMessage="El campo de tipo es obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
               
         <tr>
            <td class="auto-style1">Precio:</td> 
            <td colspan="2">
                <asp:TextBox ID="txtPrecio" runat="server" Width="351px" CssClass="form-control form-control-user"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrecio" CssClass="text-danger" ErrorMessage="El campo de precio es obligatorio."></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass=" btn btn-success btn-user btn-icon-split boton" OnClick="btnCrear_Click"   />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-user btn-icon-split boton" OnClick="btnCancelar_Click"  />
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
