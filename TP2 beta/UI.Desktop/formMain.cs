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
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Load(object sender, EventArgs e)
        {

        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if(appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLista appLista = new formLista();
            appLista.ShowDialog();
        }

        private void mnsPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void mnuArchivo_Click(object sender, EventArgs e)
        {

        }

        private void especialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEspecialidad appEspecialidad = new formEspecialidad();
            appEspecialidad.ShowDialog();
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPlan appPlan = new formPlan();
            appPlan.ShowDialog();
        }

        private void comisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formComision appComision = new formComision();
            appComision.ShowDialog();
        }
    }
}
