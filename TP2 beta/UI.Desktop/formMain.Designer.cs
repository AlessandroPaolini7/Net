
namespace UI.Desktop
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComision = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersona = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModulo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModuloUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo,
            this.mnuUsuario,
            this.mnuEspecialidad,
            this.mnuPlan,
            this.mnuComision,
            this.mnuMateria,
            this.mnuCurso,
            this.mnuPersona,
            this.mnuInscripcion,
            this.mnuModulo,
            this.mnuModuloUsuario,
            this.reporteToolStripMenuItem});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(910, 24);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            this.mnsPrincipal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnsPrincipal_ItemClicked_1);
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            this.mnuArchivo.Click += new System.EventHandler(this.mnuArchivo_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(96, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(59, 20);
            this.mnuUsuario.Text = "Usuario";
            this.mnuUsuario.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            // 
            // mnuEspecialidad
            // 
            this.mnuEspecialidad.Name = "mnuEspecialidad";
            this.mnuEspecialidad.Size = new System.Drawing.Size(84, 20);
            this.mnuEspecialidad.Text = "Especialidad";
            this.mnuEspecialidad.Click += new System.EventHandler(this.especialidadToolStripMenuItem_Click);
            // 
            // mnuPlan
            // 
            this.mnuPlan.Name = "mnuPlan";
            this.mnuPlan.Size = new System.Drawing.Size(42, 20);
            this.mnuPlan.Text = "Plan";
            this.mnuPlan.Click += new System.EventHandler(this.planToolStripMenuItem_Click);
            // 
            // mnuComision
            // 
            this.mnuComision.Name = "mnuComision";
            this.mnuComision.Size = new System.Drawing.Size(70, 20);
            this.mnuComision.Text = "Comision";
            this.mnuComision.Click += new System.EventHandler(this.comisionToolStripMenuItem_Click);
            // 
            // mnuMateria
            // 
            this.mnuMateria.Name = "mnuMateria";
            this.mnuMateria.Size = new System.Drawing.Size(59, 20);
            this.mnuMateria.Text = "Materia";
            this.mnuMateria.Click += new System.EventHandler(this.materiaToolStripMenuItem_Click);
            // 
            // mnuCurso
            // 
            this.mnuCurso.Name = "mnuCurso";
            this.mnuCurso.Size = new System.Drawing.Size(50, 20);
            this.mnuCurso.Text = "Curso";
            this.mnuCurso.Click += new System.EventHandler(this.cursoToolStripMenuItem_Click);
            // 
            // mnuPersona
            // 
            this.mnuPersona.Name = "mnuPersona";
            this.mnuPersona.Size = new System.Drawing.Size(61, 20);
            this.mnuPersona.Text = "Persona";
            this.mnuPersona.Click += new System.EventHandler(this.personaToolStripMenuItem_Click);
            // 
            // mnuInscripcion
            // 
            this.mnuInscripcion.Name = "mnuInscripcion";
            this.mnuInscripcion.Size = new System.Drawing.Size(77, 20);
            this.mnuInscripcion.Text = "Inscripcion";
            this.mnuInscripcion.Click += new System.EventHandler(this.inscripcionToolStripMenuItem_Click);
            // 
            // mnuModulo
            // 
            this.mnuModulo.Name = "mnuModulo";
            this.mnuModulo.Size = new System.Drawing.Size(61, 20);
            this.mnuModulo.Text = "Modulo";
            this.mnuModulo.Click += new System.EventHandler(this.moduloToolStripMenuItem_Click);
            // 
            // mnuModuloUsuario
            // 
            this.mnuModuloUsuario.Name = "mnuModuloUsuario";
            this.mnuModuloUsuario.Size = new System.Drawing.Size(108, 20);
            this.mnuModuloUsuario.Text = "Modulo usuarios";
            this.mnuModuloUsuario.Click += new System.EventHandler(this.moduloUsuariosToolStripMenuItem_Click);
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reporteToolStripMenuItem.Text = "Reporte";
            this.reporteToolStripMenuItem.Click += new System.EventHandler(this.reporteToolStripMenuItem_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(910, 450);
            this.Controls.Add(this.mnsPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Name = "formMain";
            this.Text = "Academia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem mnuPlan;
        private System.Windows.Forms.ToolStripMenuItem mnuComision;
        private System.Windows.Forms.ToolStripMenuItem mnuMateria;
        private System.Windows.Forms.ToolStripMenuItem mnuCurso;
        private System.Windows.Forms.ToolStripMenuItem mnuPersona;
        private System.Windows.Forms.ToolStripMenuItem mnuInscripcion;
        private System.Windows.Forms.ToolStripMenuItem mnuModulo;
        private System.Windows.Forms.ToolStripMenuItem mnuModuloUsuario;
        private System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
    }
}