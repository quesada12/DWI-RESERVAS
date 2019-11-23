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
            lblResultado.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        async protected  void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validarPassword())
            {
                Usuario usuario = new Usuario()
                {
                    USU_CODIGO = VG.usuarioActual.USU_CODIGO,
                    USU_NOMBRE = txtNombre.Text,
                    USU_EMAIL = txtEmail.Text,
                    USU_PASSWORD = txtContra.Text
                };


                Usuario usuarioModificado = await usuarioManager.Actualizar(usuario, VG.usuarioActual.CadenaToken);

                if (!String.IsNullOrEmpty(usuarioModificado.USU_NOMBRE))
                {
                    lblResultado.Text = "Usuario Modificado exitosamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;

                }
                else
                {
                    lblResultado.Text = "Error al modificar el Usuario";
                    lblResultado.ForeColor = Color.Red;
                    lblResultado.Visible = true;
                }
            }
            else
            {
                lblResultado.Visible = true;
                lblResultado.Text = "Contraseñas no coinciden";
                lblResultado.ForeColor = Color.Red;
            }
            
        }

        public bool validarPassword()
        {
            if (txtContra.Text.Equals(txtConfirmar.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}