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
    public partial class frmReserva : System.Web.UI.Page
    {
        ReservaManager reservaManager = new ReservaManager();
        IEnumerable<Models.Reserva> reservas = new ObservableCollection<Models.Reserva>();

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
            reservas = await reservaManager.ObtenerReservas(VG.usuarioActual.CadenaToken);
            grdReservas.DataSource = reservas.ToList();
            grdReservas.DataBind();
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            Models.Reserva reserva = new Models.Reserva()
            {
                RES_CODIGO = Convert.ToInt32(txtCodigo.Text),
                RES_FECHA = Convert.ToDateTime(txtFecha.Text),
                RES_FECHA_INGRESO = Convert.ToDateTime(txtFechaIngreso.Text),
                RES_FECHA_SALIDA = Convert.ToDateTime(txtFechaSalida.Text),
                RES_ESTADO = txtEstado.Text,
                
                HAB_CODIGO = Convert.ToInt32(txtHabitacion.Text),
                USU_CODIGO = Convert.ToInt32(txtUsuario.Text)

            };


            Reserva reservaModificada = await reservaManager.Actualizar(reserva, VG.usuarioActual.CadenaToken);


            if (!String.IsNullOrEmpty(reservaModificada.RES_ESTADO))
            {
                lblResultado.Text = "Reserva modificada exitosamente";
                lblResultado.ForeColor = Color.Green;
                lblResultado.Visible = true;
                InicializarControles();

            }
            else
            {
                lblResultado.Text = "Error al modificar la reserva";
                lblResultado.ForeColor = Color.Red;
                lblResultado.Visible = true;
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigoReservaEliminada = await reservaManager.Eliminar(txtCodigo.Text, VG.usuarioActual.CadenaToken);


            if (!String.IsNullOrEmpty(codigoReservaEliminada))
            {
                lblResultado.Text = "Reserva eliminada exitosamente";
                lblResultado.ForeColor = Color.Green;
                lblResultado.Visible = true;
                InicializarControles();

            }
            else
            {
                lblResultado.Text = "Error al eliminar la reserva";
                lblResultado.ForeColor = Color.Red;
                lblResultado.Visible = true;
            }
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtCodigo.Text = grdReservas.Rows[index].Cells[1].Text;
            txtFecha.Text = grdReservas.Rows[index].Cells[2].Text;
            txtFechaIngreso.Text = grdReservas.Rows[index].Cells[3].Text;
            txtFechaSalida.Text = grdReservas.Rows[index].Cells[4].Text;
            txtEstado.Text = grdReservas.Rows[index].Cells[5].Text;
            txtHabitacion.Text = grdReservas.Rows[index].Cells[6].Text;
            txtUsuario.Text = grdReservas.Rows[index].Cells[7].Text;
        }
    }
}