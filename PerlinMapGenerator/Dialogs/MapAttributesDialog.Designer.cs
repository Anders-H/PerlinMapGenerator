namespace PerlinMapGenerator.Dialogs
{
    partial class MapAttributesDialog
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
            this.trbScale = new System.Windows.Forms.TrackBar();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.trbOctaves = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trbPersistence = new System.Windows.Forms.TrackBar();
            this.lblPersistenceCaption = new System.Windows.Forms.Label();
            this.trbLacunarity = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.trbSeed = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblScale = new System.Windows.Forms.Label();
            this.lblOctaves = new System.Windows.Forms.Label();
            this.lblPersistence = new System.Windows.Forms.Label();
            this.lblLacunarity = new System.Windows.Forms.Label();
            this.lblSeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPersistence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLacunarity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale:";
            // 
            // trbScale
            // 
            this.trbScale.LargeChange = 10;
            this.trbScale.Location = new System.Drawing.Point(8, 24);
            this.trbScale.Maximum = 150;
            this.trbScale.Minimum = 10;
            this.trbScale.Name = "trbScale";
            this.trbScale.Size = new System.Drawing.Size(528, 45);
            this.trbScale.TabIndex = 1;
            this.trbScale.TickFrequency = 5;
            this.trbScale.Value = 50;
            this.trbScale.Scroll += new System.EventHandler(this.trbScale_Scroll);
            this.trbScale.ValueChanged += new System.EventHandler(this.trbScale_ValueChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(380, 348);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(460, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(300, 348);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // trbOctaves
            // 
            this.trbOctaves.Location = new System.Drawing.Point(8, 92);
            this.trbOctaves.Maximum = 20;
            this.trbOctaves.Minimum = 1;
            this.trbOctaves.Name = "trbOctaves";
            this.trbOctaves.Size = new System.Drawing.Size(528, 45);
            this.trbOctaves.TabIndex = 3;
            this.trbOctaves.Value = 20;
            this.trbOctaves.Scroll += new System.EventHandler(this.trbOctaves_Scroll);
            this.trbOctaves.ValueChanged += new System.EventHandler(this.trbOctaves_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Octaves:";
            // 
            // trbPersistence
            // 
            this.trbPersistence.LargeChange = 20;
            this.trbPersistence.Location = new System.Drawing.Point(8, 160);
            this.trbPersistence.Maximum = 100;
            this.trbPersistence.Minimum = 1;
            this.trbPersistence.Name = "trbPersistence";
            this.trbPersistence.Size = new System.Drawing.Size(528, 45);
            this.trbPersistence.TabIndex = 5;
            this.trbPersistence.TickFrequency = 5;
            this.trbPersistence.Value = 20;
            this.trbPersistence.Scroll += new System.EventHandler(this.trbPersistence_Scroll);
            this.trbPersistence.ValueChanged += new System.EventHandler(this.trbPersistence_ValueChanged);
            // 
            // lblPersistenceCaption
            // 
            this.lblPersistenceCaption.AutoSize = true;
            this.lblPersistenceCaption.Location = new System.Drawing.Point(8, 144);
            this.lblPersistenceCaption.Name = "lblPersistenceCaption";
            this.lblPersistenceCaption.Size = new System.Drawing.Size(65, 13);
            this.lblPersistenceCaption.TabIndex = 4;
            this.lblPersistenceCaption.Text = "Persistence:";
            // 
            // trbLacunarity
            // 
            this.trbLacunarity.LargeChange = 20;
            this.trbLacunarity.Location = new System.Drawing.Point(8, 228);
            this.trbLacunarity.Maximum = 50;
            this.trbLacunarity.Minimum = 1;
            this.trbLacunarity.Name = "trbLacunarity";
            this.trbLacunarity.Size = new System.Drawing.Size(528, 45);
            this.trbLacunarity.TabIndex = 7;
            this.trbLacunarity.TickFrequency = 5;
            this.trbLacunarity.Value = 5;
            this.trbLacunarity.Scroll += new System.EventHandler(this.trbLacunarity_Scroll);
            this.trbLacunarity.ValueChanged += new System.EventHandler(this.trbLacunarity_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lacunarity:";
            // 
            // trbSeed
            // 
            this.trbSeed.LargeChange = 100;
            this.trbSeed.Location = new System.Drawing.Point(8, 296);
            this.trbSeed.Maximum = 1000000;
            this.trbSeed.Minimum = 1;
            this.trbSeed.Name = "trbSeed";
            this.trbSeed.Size = new System.Drawing.Size(528, 45);
            this.trbSeed.TabIndex = 9;
            this.trbSeed.TickFrequency = 20000;
            this.trbSeed.Value = 20;
            this.trbSeed.Scroll += new System.EventHandler(this.trbSeed_Scroll);
            this.trbSeed.ValueChanged += new System.EventHandler(this.trbSeed_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seed:";
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(92, 8);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(13, 13);
            this.lblScale.TabIndex = 13;
            this.lblScale.Text = "0";
            // 
            // lblOctaves
            // 
            this.lblOctaves.AutoSize = true;
            this.lblOctaves.Location = new System.Drawing.Point(92, 76);
            this.lblOctaves.Name = "lblOctaves";
            this.lblOctaves.Size = new System.Drawing.Size(13, 13);
            this.lblOctaves.TabIndex = 14;
            this.lblOctaves.Text = "0";
            // 
            // lblPersistence
            // 
            this.lblPersistence.AutoSize = true;
            this.lblPersistence.Location = new System.Drawing.Point(92, 144);
            this.lblPersistence.Name = "lblPersistence";
            this.lblPersistence.Size = new System.Drawing.Size(13, 13);
            this.lblPersistence.TabIndex = 15;
            this.lblPersistence.Text = "0";
            // 
            // lblLacunarity
            // 
            this.lblLacunarity.AutoSize = true;
            this.lblLacunarity.Location = new System.Drawing.Point(92, 212);
            this.lblLacunarity.Name = "lblLacunarity";
            this.lblLacunarity.Size = new System.Drawing.Size(13, 13);
            this.lblLacunarity.TabIndex = 16;
            this.lblLacunarity.Text = "0";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(92, 280);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(13, 13);
            this.lblSeed.TabIndex = 17;
            this.lblSeed.Text = "0";
            // 
            // MapAttributesDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(542, 377);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.lblLacunarity);
            this.Controls.Add(this.lblPersistence);
            this.Controls.Add(this.lblOctaves);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPersistenceCaption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbScale);
            this.Controls.Add(this.trbOctaves);
            this.Controls.Add(this.trbPersistence);
            this.Controls.Add(this.trbLacunarity);
            this.Controls.Add(this.trbSeed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapAttributesDialog";
            this.ShowInTaskbar = false;
            this.Text = "MapAttributesDialog";
            this.Load += new System.EventHandler(this.MapAttributesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPersistence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLacunarity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trbScale;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TrackBar trbOctaves;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trbPersistence;
        private System.Windows.Forms.Label lblPersistenceCaption;
        private System.Windows.Forms.TrackBar trbLacunarity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trbSeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Label lblOctaves;
        private System.Windows.Forms.Label lblPersistence;
        private System.Windows.Forms.Label lblLacunarity;
        private System.Windows.Forms.Label lblSeed;
    }
}