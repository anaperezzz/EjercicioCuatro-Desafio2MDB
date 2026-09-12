namespace EjercicioCuatro
{
    partial class FrmInicio
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnMantenimientoAlumnos = new System.Windows.Forms.Button();
            this.btnMantenimientoMaterias = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalirApp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMantenimientoAlumnos
            // 
            this.btnMantenimientoAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnMantenimientoAlumnos.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimientoAlumnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnMantenimientoAlumnos.Location = new System.Drawing.Point(325, 263);
            this.btnMantenimientoAlumnos.Name = "btnMantenimientoAlumnos";
            this.btnMantenimientoAlumnos.Size = new System.Drawing.Size(209, 57);
            this.btnMantenimientoAlumnos.TabIndex = 0;
            this.btnMantenimientoAlumnos.Text = "Mantenimiento Alumnos";
            this.btnMantenimientoAlumnos.UseVisualStyleBackColor = false;
            this.btnMantenimientoAlumnos.Click += new System.EventHandler(this.btnMantenimientoAlumnos_Click);
            // 
            // btnMantenimientoMaterias
            // 
            this.btnMantenimientoMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnMantenimientoMaterias.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimientoMaterias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnMantenimientoMaterias.Location = new System.Drawing.Point(325, 337);
            this.btnMantenimientoMaterias.Name = "btnMantenimientoMaterias";
            this.btnMantenimientoMaterias.Size = new System.Drawing.Size(209, 51);
            this.btnMantenimientoMaterias.TabIndex = 1;
            this.btnMantenimientoMaterias.Text = "Mantenimiento Materias";
            this.btnMantenimientoMaterias.UseVisualStyleBackColor = false;
            this.btnMantenimientoMaterias.Click += new System.EventHandler(this.btnMantenimientoMaterias_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(265, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "SISTEMA DE GESTIÓN ACADÉMICA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(249, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione el módulo al que desea ingresar:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSalirApp
            // 
            this.btnSalirApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSalirApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSalirApp.Location = new System.Drawing.Point(719, 478);
            this.btnSalirApp.Name = "btnSalirApp";
            this.btnSalirApp.Size = new System.Drawing.Size(144, 48);
            this.btnSalirApp.TabIndex = 4;
            this.btnSalirApp.Text = "Salir del Sistema";
            this.btnSalirApp.UseVisualStyleBackColor = false;
            this.btnSalirApp.Click += new System.EventHandler(this.btnSalirApp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(381, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bienvenido";
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(875, 538);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSalirApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMantenimientoMaterias);
            this.Controls.Add(this.btnMantenimientoAlumnos);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FrmInicio";
            this.Text = "FrmInicio";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnMantenimientoAlumnos;
        private System.Windows.Forms.Button btnMantenimientoMaterias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalirApp;
        private System.Windows.Forms.Label label3;
    }
}