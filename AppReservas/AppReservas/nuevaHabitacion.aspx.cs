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
    public partial class nuevaHabitacion : System.Web.UI.Page
    {
        HotelManager hotelManager = new HotelManager();
        HabitacionManager habitacionManager = new HabitacionManager();
        IEnumerable<Models.Hotel> hoteles = new ObservableCollection<Models.Hotel>();

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
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarHoteles();
                }
               
            }
        }

        async private void CargarHoteles()
        {
            hoteles = await hotelManager.ObtenerHoteles(VG.usuarioActual.CadenaToken);
            ddlHotel.DataSource = hoteles;
            ddlHotel.DataValueField = "HOT_CODIGO";
            ddlHotel.DataTextField = "HOT_NOMBRE";
            ddlHotel.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        async protected void btnCrear_Click(object sender, EventArgs e)
        {
            Habitacion habitacion = new Habitacion()
            {
                HAB_CANT_HUESP = Convert.ToInt32(txtCantidad.Text),
                HAB_TIPO = ddlEstado.SelectedValue.ToString(),
                HAB_PRECIO = Convert.ToDecimal(txtPrecio.Text),
                HOT_CODIGO = Convert.ToInt32(ddlHotel.SelectedValue.ToString()),
                HAB_ESTADO = "A"
            };

            Habitacion habitacionIngresada = await habitacionManager.Ingresar(habitacion, VG.usuarioActual.CadenaToken);

            if (!String.IsNullOrEmpty(habitacionIngresada.HAB_ESTADO))
            {
                lblResultado.Text = "Habitacion Ingresado exitosamente";
                lblResultado.ForeColor = Color.Green;
                lblResultado.Visible = true;
                limpiar();
            }
            else
            {
                lblResultado.Text = "Error al ingresar el hotel";
                lblResultado.ForeColor = Color.Red;
                lblResultado.Visible = true;
            }
        }

        private void limpiar()
        {
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            ddlEstado.SelectedIndex = 0;
            ddlHotel.SelectedIndex = 0;
        }
       
    }
}