<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmReserva.aspx.cs" Inherits="AppReservas.frmReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:GridView ID="grdReservas" runat="server" BackColor="White" CssClass="table table-bordered" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowCommand="RowCommand">
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
            <td class="auto-style1">Fecha</td>
            <td>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Fecha Ingreso</td>
            <td>
                <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Fecha Salida</td>
            <td>
                <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control form-control-user" Width="386px"></asp:TextBox>
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
            <td class="auto-style1">Habitacion</td>
            <td>
                <asp:TextBox ID="txtHabitacion" runat="server" CssClass="form-control form-control-user" Width="386px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
          <tr>
            <td class="auto-style1">Usuario</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control form-control-user" Width="386px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <br />
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
