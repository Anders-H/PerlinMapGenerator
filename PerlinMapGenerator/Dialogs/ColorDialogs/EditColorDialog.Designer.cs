namespace PerlinMapGenerator.Dialogs.ColorDialogs
{
    partial class EditColorDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblHighestValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trbHighestValue = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trbHighestValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(312, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(232, 116);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblHighestValue
            // 
            this.lblHighestValue.AutoSize = true;
            this.lblHighestValue.Location = new System.Drawing.Point(88, 48);
            this.lblHighestValue.Name = "lblHighestValue";
            this.lblHighestValue.Size = new System.Drawing.Size(13, 13);
            this.lblHighestValue.TabIndex = 6;
            this.lblHighestValue.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Highest value:";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(352, 22);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(36, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "...";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(244, 24);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(104, 20);
            this.txtColor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(8, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Layer name:";
            // 
            // trbHighestValue
            // 
            this.trbHighestValue.Location = new System.Drawing.Point(8, 64);
            this.trbHighestValue.Maximum = 100;
            this.trbHighestValue.Name = "trbHighestValue";
            this.trbHighestValue.Size = new System.Drawing.Size(380, 45);
            this.trbHighestValue.TabIndex = 7;
            this.trbHighestValue.TickFrequency = 5;
            this.trbHighestValue.Value = 50;
            this.trbHighestValue.Scroll += new System.EventHandler(this.trbHighestValue_Scroll);
            this.trbHighestValue.ValueChanged += new System.EventHandler(this.trbHighestValue_ValueChanged);
            // 
            // EditColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 146);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblHighestValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbHighestValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditColorDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit color";
            this.Load += new System.EventHandler(this.EditColorDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbHighestValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblHighestValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trbHighestValue;
    }
}