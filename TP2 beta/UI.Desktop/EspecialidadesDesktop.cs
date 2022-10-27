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
    public partial class EspecialidadesDesktop : UI.Desktop.ApplicationForm
    {
        Especialidad EspecialidadActual = new Especialidad();
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadesDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
        }
        public EspecialidadesDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            EspecialidadLogic esp = new EspecialidadLogic();
            EspecialidadActual = esp.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }

        private void EspecialidadesDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos() {
            this.txtID.Text = this.EspecialidadActual.IDEspecialidad.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtDescripcion.ReadOnly = true;
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
                EspecialidadActual = new Business.Entities.Especialidad();
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                EspecialidadActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(EspecialidadActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }
        public override bool Validar() {
            if (this.txtDescripcion == null) return false;
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

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
