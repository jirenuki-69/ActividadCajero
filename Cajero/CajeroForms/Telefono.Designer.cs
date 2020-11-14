namespace CajeroForms
{
    partial class Telefono
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNUM = new System.Windows.Forms.TextBox();
            this.btn5p = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nunito SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduzca su número de teléfono:";
            // 
            // txtNUM
            // 
            this.txtNUM.Font = new System.Drawing.Font("Nunito SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNUM.Location = new System.Drawing.Point(32, 72);
            this.txtNUM.Name = "txtNUM";
            this.txtNUM.Size = new System.Drawing.Size(352, 33);
            this.txtNUM.TabIndex = 1;
            this.txtNUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNUM.TextChanged += new System.EventHandler(this.txtNUM_TextChanged);
            // 
            // btn5p
            // 
            this.btn5p.BackColor = System.Drawing.Color.DarkViolet;
            this.btn5p.Font = new System.Drawing.Font("Nunito", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5p.ForeColor = System.Drawing.Color.White;
            this.btn5p.Location = new System.Drawing.Point(79, 132);
            this.btn5p.Name = "btn5p";
            this.btn5p.Size = new System.Drawing.Size(268, 45);
            this.btn5p.TabIndex = 32;
            this.btn5p.Text = "Ingresar número";
            this.btn5p.UseVisualStyleBackColor = false;
            this.btn5p.Click += new System.EventHandler(this.btn5p_Click);
            // 
            // Telefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(417, 189);
            this.Controls.Add(this.btn5p);
            this.Controls.Add(this.txtNUM);
            this.Controls.Add(this.label1);
            this.Name = "Telefono";
            this.Text = "Telefono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNUM;
        private System.Windows.Forms.Button btn5p;
    }
}