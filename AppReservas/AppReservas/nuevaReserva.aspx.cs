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
    public partial class nuevaReserva : System.Web.UI.Page
    {
        HotelManager hotelManager = new HotelManager();
        HabitacionManager habitacionManager = new HabitacionManager();
        ReservaManager reservaManager = new ReservaManager();
        IEnumerable<Models.Hotel> hoteles = new ObservableCollection<Models.Hotel>();
        static IEnumerable<Models.Habitacion> habitaciones = new ObservableCollection<Models.Habitacion>();

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
                    CargarHabitaciones();
                }
                lblResultado.Visible = false;
            }

        }

        async private void CargarHoteles()
        {
            hoteles = await hotelManager.ObtenerHoteles(VG.usuarioActual.CadenaToken);
            ddlHotel.DataSource = hoteles;
            ddlHotel.DataValueField = "HOT_CODIGO";
            ddlHotel.DataTextField = "HOT_NOMBRE";
            ddlHotel.DataBind();
            ListItem item = new ListItem();
            item.Text = "Seleccione un hotel";
            item.Value = "0";
            ddlHotel.Items.Add(item);
            ddlHotel.Items.FindByValue("0").Selected = true;
        }

        async private void CargarHabitaciones()
        {
            habitaciones = await habitacionManager.ObtenerHabitaciones(VG.usuarioActual.CadenaToken);
        }

        protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlHabitacion.Items.Clear();
            foreach(Habitacion habitacion in habitaciones)
            {
                if (habitacion.HOT_CODIGO == Convert.ToInt32(ddlHotel.SelectedValue))
                {
                    ListItem item = new ListItem();
                    item.Value = Convert.ToString(habitacion.HAB_CODIGO);
                    item.Text = Convert.ToString("Cod: " + habitacion.HAB_CODIGO + " Cantidad("+habitacion.HAB_CANT_HUESP+")");
                    ddlHabitacion.Items.Add(item);
                }
            }
        }

        async protected void btnCrear_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva()
            {
                RES_FECHA = DateTime.Now,
                RES_FECHA_INGRESO = txtCalendarioIngreso.SelectedDate,
                RES_FECHA_SALIDA = txtCalendarioSalida.SelectedDate,
                HAB_CODIGO = Convert.ToInt32(ddlHabitacion.SelectedItem.Value),
                RES_ESTADO = "A",
                USU_CODIGO = VG.usuarioActual.USU_CODIGO
            };

            Reserva ReservaIngresada = await reservaManager.Ingresar(reserva, VG.usuarioActual.CadenaToken);

            if (ReservaIngresada.RES_ESTADO != null)
            {
                lblResultado.Text = "Reserva creada exitosamente";
                lblResultado.ForeColor = Color.Green;
                lblResultado.Visible = true;
                limpiar();
            }
            else
            {
                lblResultado.Text = "Error al crear la reserva";
                lblResultado.ForeColor = Color.Red;
                lblResultado.Visible = true;
            }
        }

        private void limpiar()
        {
            txtPrecio.Text = "";
            txtPrecio.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}