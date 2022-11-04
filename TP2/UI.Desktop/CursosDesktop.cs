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
    public partial class CursosDesktop : UI.Desktop.ApplicationForm
    {
        Business.Entities.Curso CursoActual = new Business.Entities.Curso();

        public CursosDesktop()
        {
            InitializeComponent();
        }
        public CursosDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
            ComisionLogic comisionLogic = new ComisionLogic();
            this.cmbComision.DataSource = comisionLogic.GetAll();
            MateriaLogic materiaLogic = new MateriaLogic();
            this.cmbMateria.DataSource = materiaLogic.GetAll();
        }

        public CursosDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            CursoLogic curso = new CursoLogic();
            CursoActual = curso.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }
        private void CursosDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.IDCurso.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();

            ComisionLogic comisionLogic = new ComisionLogic();
            this.cmbComision.DataSource = comisionLogic.GetAll();
            this.cmbComision.SelectedItem = (Business.Entities.Comision)comisionLogic.GetOne(this.CursoActual.Comision.IDComision);
            
            MateriaLogic materiaLogic = new MateriaLogic();
            this.cmbMateria.DataSource = materiaLogic.GetAll();
            this.cmbMateria.SelectedItem = (Business.Entities.Materia)materiaLogic.GetOne(this.CursoActual.Materia.IDMateria);



            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtAnioCalendario.ReadOnly = true;
                txtCupo.ReadOnly = true;
                cmbComision.Enabled = false;
                cmbMateria.Enabled = false;
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
                CursoActual = new Business.Entities.Curso();
                CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);

                ComisionLogic comisionLogic = new ComisionLogic();
                CursoActual.Comision = comisionLogic.GetOne(Convert.ToInt32(this.cmbComision.SelectedValue));

                MateriaLogic materiaLogic = new MateriaLogic();
                CursoActual.Materia = materiaLogic.GetOne(Convert.ToInt32(this.cmbMateria.SelectedValue));

                CursoActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
                ComisionLogic comisionLogic = new ComisionLogic();
                CursoActual.Comision = comisionLogic.GetOne(Convert.ToInt32(this.cmbComision.SelectedValue));

                MateriaLogic materiaLogic = new MateriaLogic();
                CursoActual.Materia = materiaLogic.GetOne(Convert.ToInt32(this.cmbMateria.SelectedValue));

                CursoActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                CursoActual.State = BusinessEntity.States.Deleted;
            }
        }


        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                CursoLogic cl = new CursoLogic();
                cl.Save(CursoActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override bool Validar()
        {
            if ((this.txtAnioCalendario == null) | (this.txtCupo.Text == null)) return false;
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
