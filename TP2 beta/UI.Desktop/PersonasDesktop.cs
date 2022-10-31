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
    public partial class PersonasDesktop : UI.Desktop.ApplicationForm
    {
        Business.Entities.Personas PersonaActual = new Business.Entities.Personas();

        public PersonasDesktop()
        {
            InitializeComponent();
        }
        public PersonasDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
            this.cmbTipoPersona.Items.Add(Business.Entities.Personas.TipoPersonas.Docente);
            this.cmbTipoPersona.Items.Add(Business.Entities.Personas.TipoPersonas.Alumno);
            this.cmbTipoPersona.Items.Add(Business.Entities.Personas.TipoPersonas.Administrador);       
        }

        public PersonasDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            PersonaLogic persona = new PersonaLogic();
            PersonaActual = persona.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }

        private void PersonasDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.IDPersona.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono;

            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
            this.cmbPlan.SelectedItem = (Business.Entities.Plan)planLogic.GetOne(this.PersonaActual.Plan.IDPlan);

            this.cmbTipoPersona.Items.Clear();
            this.cmbTipoPersona.Items.Add(Business.Entities.Personas.TipoPersonas.Docente);
            this.cmbTipoPersona.Items.Add(Business.Entities.Personas.TipoPersonas.Alumno);
            this.cmbTipoPersona.Items.Add(Business.Entities.Personas.TipoPersonas.Administrador);
            this.cmbTipoPersona.SelectedItem = this.PersonaActual.TipoPersona;


            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtFechaNacimiento.ReadOnly = true;
                txtLegajo.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                cmbPlan.Enabled = false;
                cmbTipoPersona.Enabled = false;
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
                PersonaActual = new Business.Entities.Personas();
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text);
                PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                PersonaActual.Telefono = this.txtTelefono.Text;

                PlanLogic planLogic = new PlanLogic();
                PersonaActual.Plan = planLogic.GetOne(Convert.ToInt32(this.cmbPlan.SelectedValue));
                PersonaActual.TipoPersona = (Business.Entities.Personas.TipoPersonas)cmbTipoPersona.SelectedItem;


                PersonaActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text);
                PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                PersonaActual.Telefono = this.txtTelefono.Text;

                PlanLogic planLogic = new PlanLogic();
                PersonaActual.Plan = planLogic.GetOne(Convert.ToInt32(this.cmbPlan.SelectedValue));
                PersonaActual.TipoPersona = (Business.Entities.Personas.TipoPersonas)cmbTipoPersona.SelectedItem;
                PersonaActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                PersonaActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                PersonaLogic pl = new PersonaLogic();
                pl.Save(PersonaActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override bool Validar()
        {
            if ((this.txtNombre.Text == "") | (this.txtApellido.Text == "")| (this.txtDireccion.Text == "")| (this.txtEmail.Text == "")| (this.txtFechaNacimiento.Text == "")| (this.txtLegajo.Text == "")| (this.txtTelefono.Text == "")) return false;
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
