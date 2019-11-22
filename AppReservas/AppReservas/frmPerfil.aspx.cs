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
    public partial class frmPerfil : System.Web.UI.Page
    {
        UsuarioManager usuarioManager = new UsuarioManager();

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


        public void InicializarControles()
        {
            txtCodigo.Text = VG.usuarioActual.USU_CODIGO.ToString();
            txtIdentificacion.Text = VG.usuarioActual.USU_IDENTIFICACION;
            txtNombre.Text = VG.usuarioActual.USU_NOMBRE;
            txtEmail.Text = VG.usuarioActual.USU_EMAIL;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        async protected  void btnActualizar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                USU_CODIGO = VG.usuarioActual.USU_CODIGO,
                USU_NOMBRE = txtNombre.Text,
                USU_EMAIL = txtEmail.Text,
                USU_PASSWORD = txtContra.Text
            };


            Usuario usuarioModificado = await usuarioManager.Actualizar(usuario, VG.usuarioActual.CadenaToken);

           
        }
    }
}