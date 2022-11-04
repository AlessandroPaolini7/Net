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
    public partial class ModulosDesktop : UI.Desktop.ApplicationForm
    {
        Business.Entities.Modulo ModuloActual = new Business.Entities.Modulo();
        public ModulosDesktop()
        {
            InitializeComponent();
        }

        public ModulosDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
        }

        public ModulosDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            ModuloLogic moduloLogic = new ModuloLogic();
            ModuloActual = moduloLogic.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }

        private void ModulosDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ModuloActual.IDModulo.ToString();
            this.txtDescripcion.Text = this.ModuloActual.Descripcion;
         


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
                ModuloActual = new Business.Entities.Modulo();
                ModuloActual.Descripcion = this.txtDescripcion.Text;


                ModuloActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                ModuloActual.Descripcion = this.txtDescripcion.Text;
                ModuloActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                ModuloActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                ModuloLogic moduloLogic  = new ModuloLogic();
                moduloLogic.Save(ModuloActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override bool Validar()
        {
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
    }
}
