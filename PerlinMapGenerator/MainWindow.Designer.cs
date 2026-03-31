namespace PerlinMapGenerator
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnMapAttributes = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.imageSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditColors = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageSizeToolStripMenuItem,
            this.mapAttributesToolStripMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.propertiesToolStripMenuItem.Text = "&Properties";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripZoom25,
            this.toolStripZoom50,
            this.toolStripZoom100,
            this.toolStripZoom200});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // toolStripZoom25
            // 
            this.toolStripZoom25.Name = "toolStripZoom25";
            this.toolStripZoom25.Size = new System.Drawing.Size(102, 22);
            this.toolStripZoom25.Text = "25%";
            this.toolStripZoom25.Click += new System.EventHandler(this.toolStripZoom25_Click);
            // 
            // toolStripZoom50
            // 
            this.toolStripZoom50.Name = "toolStripZoom50";
            this.toolStripZoom50.Size = new System.Drawing.Size(102, 22);
            this.toolStripZoom50.Text = "50%";
            this.toolStripZoom50.Click += new System.EventHandler(this.toolStripZoom50_Click);
            // 
            // toolStripZoom100
            // 
            this.toolStripZoom100.Checked = true;
            this.toolStripZoom100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripZoom100.Name = "toolStripZoom100";
            this.toolStripZoom100.Size = new System.Drawing.Size(102, 22);
            this.toolStripZoom100.Text = "100%";
            this.toolStripZoom100.Click += new System.EventHandler(this.toolStripZoom100_Click);
            // 
            // toolStripZoom200
            // 
            this.toolStripZoom200.Name = "toolStripZoom200";
            this.toolStripZoom200.Size = new System.Drawing.Size(102, 22);
            this.toolStripZoom200.Text = "200%";
            this.toolStripZoom200.Click += new System.EventHandler(this.toolStripZoom200_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editColorsToolStripMenuItem});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.colorsToolStripMenuItem.Text = "&Colors";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnMapAttributes,
            this.toolStripSeparator1,
            this.btnZoomOut,
            this.btnZoomIn,
            this.toolStripSeparator2,
            this.btnEditColors});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(26, 17);
            this.lblStatus.Text = "OK.";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.panel1.Controls.Add(this.picMap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 379);
            this.panel1.TabIndex = 3;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.Black;
            this.picMap.Location = new System.Drawing.Point(264, 96);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(100, 50);
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picMap_Paint);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::PerlinMapGenerator.Properties.Resources.CanvasScaleHS;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Image size...";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnMapAttributes
            // 
            this.btnMapAttributes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMapAttributes.Image = global::PerlinMapGenerator.Properties.Resources.PropertiesHS;
            this.btnMapAttributes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMapAttributes.Name = "btnMapAttributes";
            this.btnMapAttributes.Size = new System.Drawing.Size(23, 22);
            this.btnMapAttributes.Text = "Map attributes...";
            this.btnMapAttributes.Click += new System.EventHandler(this.btnMapAttributes_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = global::PerlinMapGenerator.Properties.Resources.ZoomOutHS;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOut.Text = "Zoom out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = global::PerlinMapGenerator.Properties.Resources.ZoomInHS;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.btnZoomIn.Text = "Zoom in";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // imageSizeToolStripMenuItem
            // 
            this.imageSizeToolStripMenuItem.Image = global::PerlinMapGenerator.Properties.Resources.CanvasScaleHS;
            this.imageSizeToolStripMenuItem.Name = "imageSizeToolStripMenuItem";
            this.imageSizeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.imageSizeToolStripMenuItem.Text = "Image size...";
            this.imageSizeToolStripMenuItem.Click += new System.EventHandler(this.imageSizeToolStripMenuItem_Click);
            // 
            // mapAttributesToolStripMenuItem
            // 
            this.mapAttributesToolStripMenuItem.Image = global::PerlinMapGenerator.Properties.Resources.PropertiesHS;
            this.mapAttributesToolStripMenuItem.Name = "mapAttributesToolStripMenuItem";
            this.mapAttributesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.mapAttributesToolStripMenuItem.Text = "Map attributes...";
            this.mapAttributesToolStripMenuItem.Click += new System.EventHandler(this.mapAttributesToolStripMenuItem_Click);
            // 
            // editColorsToolStripMenuItem
            // 
            this.editColorsToolStripMenuItem.Image = global::PerlinMapGenerator.Properties.Resources.ColorHS;
            this.editColorsToolStripMenuItem.Name = "editColorsToolStripMenuItem";
            this.editColorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editColorsToolStripMenuItem.Text = "Edit colors...";
            this.editColorsToolStripMenuItem.Click += new System.EventHandler(this.editColorsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditColors
            // 
            this.btnEditColors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditColors.Image = global::PerlinMapGenerator.Properties.Resources.ColorHS;
            this.btnEditColors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditColors.Name = "btnEditColors";
            this.btnEditColors.Size = new System.Drawing.Size(23, 22);
            this.btnEditColors.Text = "Edit colors...";
            this.btnEditColors.Click += new System.EventHandler(this.btnEditColors_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Perlin Map Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapAttributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnMapAttributes;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripZoom25;
        private System.Windows.Forms.ToolStripMenuItem toolStripZoom50;
        private System.Windows.Forms.ToolStripMenuItem toolStripZoom100;
        private System.Windows.Forms.ToolStripMenuItem toolStripZoom200;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEditColors;
    }
}

