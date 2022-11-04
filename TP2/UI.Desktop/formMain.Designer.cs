
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
            this.mnuReporte = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.BackColor = System.Drawing.Color.DodgerBlue;
            this.mnsPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.mnuReporte});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(1213, 28);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            this.mnsPrincipal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnsPrincipal_ItemClicked_1);
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.mnuArchivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(77, 24);
            this.mnuArchivo.Text = "Archivo";
            this.mnuArchivo.Click += new System.EventHandler(this.mnuArchivo_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(122, 26);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(77, 24);
            this.mnuUsuario.Text = "Usuario";
            this.mnuUsuario.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            // 
            // mnuEspecialidad
            // 
            this.mnuEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuEspecialidad.Name = "mnuEspecialidad";
            this.mnuEspecialidad.Size = new System.Drawing.Size(108, 24);
            this.mnuEspecialidad.Text = "Especialidad";
            this.mnuEspecialidad.Click += new System.EventHandler(this.especialidadToolStripMenuItem_Click);
            // 
            // mnuPlan
            // 
            this.mnuPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuPlan.Name = "mnuPlan";
            this.mnuPlan.Size = new System.Drawing.Size(53, 24);
            this.mnuPlan.Text = "Plan";
            this.mnuPlan.Click += new System.EventHandler(this.planToolStripMenuItem_Click);
            // 
            // mnuComision
            // 
            this.mnuComision.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuComision.Name = "mnuComision";
            this.mnuComision.Size = new System.Drawing.Size(88, 24);
            this.mnuComision.Text = "Comision";
            this.mnuComision.Click += new System.EventHandler(this.comisionToolStripMenuItem_Click);
            // 
            // mnuMateria
            // 
            this.mnuMateria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuMateria.Name = "mnuMateria";
            this.mnuMateria.Size = new System.Drawing.Size(77, 24);
            this.mnuMateria.Text = "Materia";
            this.mnuMateria.Click += new System.EventHandler(this.materiaToolStripMenuItem_Click);
            // 
            // mnuCurso
            // 
            this.mnuCurso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuCurso.Name = "mnuCurso";
            this.mnuCurso.Size = new System.Drawing.Size(63, 24);
            this.mnuCurso.Text = "Curso";
            this.mnuCurso.Click += new System.EventHandler(this.cursoToolStripMenuItem_Click);
            // 
            // mnuPersona
            // 
            this.mnuPersona.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuPersona.Name = "mnuPersona";
            this.mnuPersona.Size = new System.Drawing.Size(79, 24);
            this.mnuPersona.Text = "Persona";
            this.mnuPersona.Click += new System.EventHandler(this.personaToolStripMenuItem_Click);
            // 
            // mnuInscripcion
            // 
            this.mnuInscripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuInscripcion.Name = "mnuInscripcion";
            this.mnuInscripcion.Size = new System.Drawing.Size(99, 24);
            this.mnuInscripcion.Text = "Inscripcion";
            this.mnuInscripcion.Click += new System.EventHandler(this.inscripcionToolStripMenuItem_Click);
            // 
            // mnuModulo
            // 
            this.mnuModulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuModulo.Name = "mnuModulo";
            this.mnuModulo.Size = new System.Drawing.Size(77, 24);
            this.mnuModulo.Text = "Modulo";
            this.mnuModulo.Click += new System.EventHandler(this.moduloToolStripMenuItem_Click);
            // 
            // mnuModuloUsuario
            // 
            this.mnuModuloUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuModuloUsuario.Name = "mnuModuloUsuario";
            this.mnuModuloUsuario.Size = new System.Drawing.Size(140, 24);
            this.mnuModuloUsuario.Text = "Modulo usuarios";
            this.mnuModuloUsuario.Click += new System.EventHandler(this.moduloUsuariosToolStripMenuItem_Click);
            // 
            // mnuReporte
            // 
            this.mnuReporte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuNotas,
            this.cursosToolStripMenuItem,
            this.planesToolStripMenuItem});
            this.mnuReporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuReporte.Name = "mnuReporte";
            this.mnuReporte.Size = new System.Drawing.Size(79, 24);
            this.mnuReporte.Text = "Reporte";
            this.mnuReporte.Click += new System.EventHandler(this.reporteToolStripMenuItem_Click);
            // 
            // tsmnuNotas
            // 
            this.tsmnuNotas.Name = "tsmnuNotas";
            this.tsmnuNotas.Size = new System.Drawing.Size(224, 26);
            this.tsmnuNotas.Text = "Notas";
            this.tsmnuNotas.Click += new System.EventHandler(this.tsmnuNotas_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cursosToolStripMenuItem.Text = "Cursos";
            this.cursosToolStripMenuItem.Click += new System.EventHandler(this.cursosToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pictureBox1.Image = global::UI.Desktop.Properties.Resources.school__1_;
            this.pictureBox1.Location = new System.Drawing.Point(292, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(472, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "¡Bienvenido al sitio de Academia!";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1213, 554);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1213, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnsPrincipal);
            this.Controls.Add(this.pictureBox2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formMain";
            this.Text = "Academia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem mnuReporte;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem tsmnuNotas;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
    }
}