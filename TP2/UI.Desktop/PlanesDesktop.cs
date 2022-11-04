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
    public partial class PlanesDesktop : UI.Desktop.ApplicationForm
    {
        Plan PlanActual = new Plan();
        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();

            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            this.cmbEspecialidad.DataSource = especialidadLogic.GetAll();
        }

        public PlanesDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            PlanLogic plan = new PlanLogic();
            PlanActual = plan.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }
        private void PlanesDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.IDPlan.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;

            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            this.cmbEspecialidad.DataSource = especialidadLogic.GetAll();
            this.cmbEspecialidad.SelectedItem = (Business.Entities.Especialidad)especialidadLogic.GetOne(this.PlanActual.Especialidad.IDEspecialidad);

            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtDescripcion.ReadOnly = true;
                cmbEspecialidad.Enabled = false;
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
                PlanActual = new Business.Entities.Plan();
                PlanActual.Descripcion = this.txtDescripcion.Text;

                EspecialidadLogic especialidadLogic = new EspecialidadLogic();
                PlanActual.Especialidad = especialidadLogic.GetOne(Convert.ToInt32(this.cmbEspecialidad.SelectedValue));

                PlanActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadLogic especialidadLogic = new EspecialidadLogic();
                PlanActual.Especialidad = especialidadLogic.GetOne(Convert.ToInt32(this.cmbEspecialidad.SelectedValue));
                PlanActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                PlanActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                PlanLogic pl = new PlanLogic();
                pl.Save(PlanActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public override bool Validar()
        {
            if ((this.txtDescripcion == null)) return false;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
