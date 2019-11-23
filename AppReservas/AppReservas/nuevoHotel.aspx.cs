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
    public partial class nuevoHotel : System.Web.UI.Page
    {
        HotelManager hotelManager = new HotelManager();
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
                Response.Redirect("~Login.aspx");
            }
            else
            {
                lblResultado.Visible = false;
            }

        }

        async protected void btnCrear_Click(object sender, EventArgs e)
        {
            Models.Hotel hotel = new Models.Hotel()
            {
                HOT_NOMBRE = txtNombre.Text,
                HOT_DIRECCION = txtDireccion.Text,
                HOT_EMAIL = txtEmail.Text
            };

            Models.Hotel hotelIngresado = await hotelManager.Ingresar(hotel, VG.usuarioActual.CadenaToken);

            if (!String.IsNullOrEmpty(hotelIngresado.HOT_NOMBRE))
            {
                lblResultado.Text = "Hotel Ingresado exitosamente";
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        public void limpiar()
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
        }
    }
}