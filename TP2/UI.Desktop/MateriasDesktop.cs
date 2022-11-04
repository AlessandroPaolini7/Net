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
    public partial class MateriasDesktop : UI.Desktop.ApplicationForm
    {
        Business.Entities.Materia MateriaActual = new Business.Entities.Materia();
        public MateriasDesktop()
        {
            InitializeComponent();
        }

        public MateriasDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
        }

        public MateriasDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            MateriaLogic materia = new MateriaLogic();
            MateriaActual = materia.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }

        private void MateriasDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.IDMateria.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HorasSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HorasTotales.ToString();


            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
            this.cmbPlan.SelectedItem = (Business.Entities.Plan)planLogic.GetOne(this.MateriaActual.Plan.IDPlan);


            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtDescripcion.ReadOnly = true;
                cmbPlan.Enabled = false;
                txtHsSemanales.ReadOnly = true;
                txtHsTotales.ReadOnly = true;
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
                MateriaActual = new Business.Entities.Materia();
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                MateriaActual.HorasSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MateriaActual.HorasTotales = Convert.ToInt32(this.txtHsTotales.Text);

                PlanLogic planLogic = new PlanLogic();
                MateriaActual.Plan = planLogic.GetOne(Convert.ToInt32(this.cmbPlan.SelectedValue));

                MateriaActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                MateriaActual.HorasSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MateriaActual.HorasTotales = Convert.ToInt32(this.txtHsTotales.Text);
                PlanLogic planLogic = new PlanLogic();
                MateriaActual.Plan = planLogic.GetOne(Convert.ToInt32(this.cmbPlan.SelectedValue));

                MateriaActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                MateriaLogic ml = new MateriaLogic();
                ml.Save(MateriaActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override bool Validar()
        {
            if ((this.txtDescripcion == null) | (this.txtHsSemanales.Text == "") | (this.txtHsTotales.Text == "")) return false;
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
    }
}
