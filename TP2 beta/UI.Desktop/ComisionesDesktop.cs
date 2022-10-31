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
        Business.Entities.Comision ComisionActual = new Business.Entities.Comision();
        public ComisionesDesktop()
        {
            InitializeComponent();
        }

        public ComisionesDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
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
            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
            this.cmbPlan.SelectedItem = (Business.Entities.Plan)planLogic.GetOne(this.ComisionActual.Plan.IDPlan);
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();


            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtDescripcion.ReadOnly = true;
                cmbPlan.Enabled = false;
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
                PlanLogic planLogic = new PlanLogic();
                ComisionActual.Plan = planLogic.GetOne(Convert.ToInt32(this.cmbPlan.SelectedValue));
                ComisionActual.AnioEspecialidad = Convert.ToInt32((this.txtAnioEspecialidad.Text));


                ComisionActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                PlanLogic planLogic = new PlanLogic();
                ComisionActual.Plan = planLogic.GetOne(Convert.ToInt32(this.cmbPlan.SelectedValue));
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
            try
            {
                this.MapearADatos();

                ComisionLogic cl = new ComisionLogic();
                cl.Save(ComisionActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public override bool Validar()
        {
            if ((this.txtDescripcion == null) | (this.txtAnioEspecialidad.Text == "")) return false;
            else return true;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
