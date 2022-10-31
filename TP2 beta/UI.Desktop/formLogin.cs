using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        Business.Logic.UsuarioLogic UsuarioNegocio;

        public formLogin()
        {
            InitializeComponent();
            UsuarioNegocio = new Business.Logic.UsuarioLogic();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var user = UsuarioNegocio.BuscarPorNombre(txtUsuario.Text);
            if (user is null) MessageBox.Show("Usuario incorrecto.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (user.Clave != txtPass.Text)
            {
                MessageBox.Show("Contraseña incorrecta.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                formMain appMain = new formMain(user);
                appMain.ShowDialog();
                this.Close();
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es usted un usuario muy descuidado, haga memoria","Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
