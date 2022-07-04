using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class ComisionesDesktop : UI.Desktop.ApplicationForm
    {
        Comision ComisionActual = new Comision();
        PlanLogic PlanNegocio = new PlanLogic();
        public ComisionesDesktop()
        {
            InitializeComponent();
        }

        public ComisionesDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
        }

        public ComisionesDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            ComisionLogic comision = new ComisionLogic();
            ComisionActual = comision.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }

        private void ComisionesDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.IDComision.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();


            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtDescripcion.ReadOnly = true;
                txtIDPlan.ReadOnly = true;
                txtAnioEspecialidad.ReadOnly = true;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ComisionActual = new Business.Entities.Comision();
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                ComisionActual.IDPlan = Convert.ToInt32((this.txtIDPlan.Text));
                ComisionActual.AnioEspecialidad = Convert.ToInt32((this.txtAnioEspecialidad.Text));


                ComisionActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                ComisionActual.IDPlan = Convert.ToInt32((this.txtIDPlan.Text));
                ComisionActual.AnioEspecialidad = Convert.ToInt32((this.txtAnioEspecialidad.Text));
                ComisionActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                ComisionActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();

            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }

        public override bool Validar()
        {
            if ((this.txtDescripcion.Text != "") & (this.txtIDPlan.Text != "")& (this.txtAnioEspecialidad.Text != ""))
            {
                var PlanActual = PlanNegocio.GetOne(Convert.ToInt32(txtIDPlan.Text));
                if (PlanActual != null) return true;
                else return false;
            }
            return false;

            /*
            if ((this.txtDescripcion.Text != "") & (this.txtIDEspecialidad.Text != ""))
            {
                var EspecialidadActual = EspecialidadNegocio.GetOne(Convert.ToInt32(txtIDEspecialidad.Text));
                if (EspecialidadActual != null) return true;
                else return false;
            }
            return false;
            */
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
            else
            {
                this.Notificar("Datos Invalidos", "Los datos ingresados no son correctos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
