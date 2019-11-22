<%@ Page Async="true" Title="" Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="frmHotel.aspx.cs" Inherits="AppReservas.frmHotel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 97px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  


    <asp:GridView ID="grdHoteles" runat="server" BackColor="White" CssClass="table table-bordered" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#0067C6" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#0067C6" />
    </asp:GridView>

    <br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Codigo</td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Direccion</td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
       
        <tr>
            <td class="auto-style1">
                <br />
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" CssClass="btn btn-success btn-user btn-icon-split" Height="42px" Width="110px" />
            </td>
            <td>
                 <br />
                <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" CssClass="btn btn-warning btn-user btn-icon-split" Height="42px" Width="110px" />
             &nbsp;<asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" CssClass="btn btn-danger btn-user btn-icon-split" Height="42px" Width="110px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblResultado" runat="server" ForeColor="#009933" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>


</asp:Content>
