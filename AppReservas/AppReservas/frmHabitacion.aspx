<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmHabitacion.aspx.cs" Inherits="AppReservas.frmHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 97px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:GridView ID="grdHabitaciones" runat="server" BackColor="White" CssClass="table table-bordered" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowCommand="grdHabitaciones_RowCommand">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ButtonField ControlStyle-ForeColor="Blue" Text="Editar/Eliminar" />
        </Columns>
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
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control form-control-user" Width="386px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Cantidad Huespedes</td>
            <td>
                <asp:TextBox ID="txtCantHuesp" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Tipo</td>
            <td>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="btn btn-primary dropdown-toggle" Width="380px">
                    <asp:ListItem Value="jj">Seleccione Tipo</asp:ListItem>
                    <asp:ListItem Value="S">Simple</asp:ListItem>
                    <asp:ListItem Value="D">Doble</asp:ListItem>
                    <asp:ListItem Value="T">Triple</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Precio</td>
            <td>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Estado</td>
            <td>
                <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Hotel</td>
            <td>
                <asp:TextBox ID="txtHotel" runat="server" CssClass="form-control form-control-user" Width="386px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <br />
            </td>
            <td>
                 <br />
                <asp:Button ID="btnModificar" runat="server"  Text="Modificar" CssClass="btn btn-warning btn-user btn-icon-split" Height="42px" Width="110px" OnClick="btnModificar_Click" />
             &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-user btn-icon-split" Height="42px" Width="110px" OnClick="btnEliminar_Click" />
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
