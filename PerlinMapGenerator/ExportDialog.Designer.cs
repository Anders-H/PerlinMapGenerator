namespace PerlinMapGenerator
{
    partial class ExportDialog
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
            this.radioBmp = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioPng = new System.Windows.Forms.RadioButton();
            this.radioJson = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioCs = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioBmp
            // 
            this.radioBmp.AutoSize = true;
            this.radioBmp.Location = new System.Drawing.Point(20, 36);
            this.radioBmp.Name = "radioBmp";
            this.radioBmp.Size = new System.Drawing.Size(48, 17);
            this.radioBmp.TabIndex = 1;
            this.radioBmp.TabStop = true;
            this.radioBmp.Text = "BMP";
            this.radioBmp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select export format:";
            // 
            // radioPng
            // 
            this.radioPng.AutoSize = true;
            this.radioPng.Location = new System.Drawing.Point(20, 60);
            this.radioPng.Name = "radioPng";
            this.radioPng.Size = new System.Drawing.Size(48, 17);
            this.radioPng.TabIndex = 2;
            this.radioPng.TabStop = true;
            this.radioPng.Text = "PNG";
            this.radioPng.UseVisualStyleBackColor = true;
            // 
            // radioJson
            // 
            this.radioJson.AutoSize = true;
            this.radioJson.Location = new System.Drawing.Point(20, 84);
            this.radioJson.Name = "radioJson";
            this.radioJson.Size = new System.Drawing.Size(53, 17);
            this.radioJson.TabIndex = 3;
            this.radioJson.TabStop = true;
            this.radioJson.Text = "JSON";
            this.radioJson.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(64, 140);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(144, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // radioCs
            // 
            this.radioCs.AutoSize = true;
            this.radioCs.Location = new System.Drawing.Point(20, 108);
            this.radioCs.Name = "radioCs";
            this.radioCs.Size = new System.Drawing.Size(39, 17);
            this.radioCs.TabIndex = 4;
            this.radioCs.TabStop = true;
            this.radioCs.Text = "C#";
            this.radioCs.UseVisualStyleBackColor = true;
            // 
            // ExportDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(228, 171);
            this.Controls.Add(this.radioCs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.radioJson);
            this.Controls.Add(this.radioPng);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioBmp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.ExportDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioPng;
        private System.Windows.Forms.RadioButton radioJson;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioCs;
    }
}