using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using AppReservas.Models;
using AppReservas.Controllers;
using System.Collections.ObjectModel;
using System.Drawing;

namespace AppReservas
{
    public partial class frmHabitacion : System.Web.UI.Page
    {
        HabitacionManager habitacionManager = new HabitacionManager();
        IEnumerable<Models.Habitacion> habitaciones = new ObservableCollection<Models.Habitacion>();

        protected override void OnInitComplete(EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);

            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!VG.usuarioActual.EstadoSesion.Equals("A") || (DateTime.Now > VG.usuarioActual.Token.ValidTo))
            {
                Response.Redirect("~Login.aspx");
            }
            else
            {
                InicializarControles();
            }
        }

        async void InicializarControles()
        {
            habitaciones = await habitacionManager.ObtenerHabitaciones(VG.usuarioActual.CadenaToken);
            grdHabitaciones.DataSource = habitaciones.ToList();
            grdHabitaciones.DataBind();
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            Models.Habitacion habitacion = new Models.Habitacion()
            {
                HAB_CODIGO = Convert.ToInt32(txtCodigo.Text),
                HAB_CANT_HUESP = Convert.ToInt32(txtCantHuesp.Text),
                HAB_TIPO = ddlTipo.SelectedValue,
                HAB_PRECIO = Convert.ToDecimal(txtPrecio.Text),
                HAB_ESTADO = txtEstado.Text,
                HOT_CODIGO = Convert.ToInt32(txtHotel.Text)
                
            };


            Habitacion habitacionModificada = await habitacionManager.Actualizar(habitacion, VG.usuarioActual.CadenaToken);


            if (habitacionModificada != null)
            {
                lblResultado.Text = "Habitacion modificada exitosamente";
                lblResultado.ForeColor = Color.Green;
                lblResultado.Visible = true;
                InicializarControles();

            }
            else
            {
                lblResultado.Text = "Error al modificar la habitacion";
                lblResultado.ForeColor = Color.Red;
                lblResultado.Visible = true;
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigoHabitacionEliminada = await habitacionManager.Eliminar(txtCodigo.Text, VG.usuarioActual.CadenaToken);


            if (!String.IsNullOrEmpty(codigoHabitacionEliminada))
            {
                lblResultado.Text = "habitacion eliminada exitosamente";
                lblResultado.ForeColor = Color.Green;
                lblResultado.Visible = true;
                InicializarControles();

            }
            else
            {
                lblResultado.Text = "Error al eliminar la habitacion";
                lblResultado.ForeColor = Color.Red;
                lblResultado.Visible = true;
            }
        }

        protected void grdHabitaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtCodigo.Text = grdHabitaciones.Rows[index].Cells[1].Text;
            txtCantHuesp.Text = grdHabitaciones.Rows[index].Cells[2].Text;
            ddlTipo.SelectedValue = grdHabitaciones.Rows[index].Cells[3].Text;
            txtPrecio.Text = grdHabitaciones.Rows[index].Cells[4].Text;
            txtEstado.Text = grdHabitaciones.Rows[index].Cells[5].Text;
            txtHotel.Text = grdHabitaciones.Rows[index].Cells[6].Text;
        }
    }
}