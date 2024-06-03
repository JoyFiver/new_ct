namespace Test_Form
{
    partial class _FormProgramma
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalaDiGrigiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlowCoronal = new System.Windows.Forms.PictureBox();
            this.FlowSaggital = new System.Windows.Forms.PictureBox();
            this.FlowImage = new System.Windows.Forms.PictureBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FlowAxial = new System.Windows.Forms.PictureBox();
            this._menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlowCoronal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowSaggital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowAxial)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Location = new System.Drawing.Point(849, 692);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Location = new System.Drawing.Point(-3, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 36;
            // 
            // _menuBar
            // 
            this._menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modificaToolStripMenuItem});
            this._menuBar.Location = new System.Drawing.Point(0, 0);
            this._menuBar.Name = "_menuBar";
            this._menuBar.Size = new System.Drawing.Size(1069, 24);
            this._menuBar.TabIndex = 34;
            this._menuBar.Text = "menuBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.apriToolStripMenuItem.Text = "Apri";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.apriToolStripMenuItem_Click_1);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scalaDiGrigiToolStripMenuItem});
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.modificaToolStripMenuItem.Text = "Modifica";
            // 
            // scalaDiGrigiToolStripMenuItem
            // 
            this.scalaDiGrigiToolStripMenuItem.Name = "scalaDiGrigiToolStripMenuItem";
            this.scalaDiGrigiToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scalaDiGrigiToolStripMenuItem.Text = "Scala di grigi";
            this.scalaDiGrigiToolStripMenuItem.Click += new System.EventHandler(this.scalaDiGrigiToolStripMenuItem_Click);
            // 
            // FlowCoronal
            // 
            this.FlowCoronal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlowCoronal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FlowCoronal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlowCoronal.Location = new System.Drawing.Point(114, 452);
            this.FlowCoronal.Name = "FlowCoronal";
            this.FlowCoronal.Size = new System.Drawing.Size(250, 240);
            this.FlowCoronal.TabIndex = 1;
            this.FlowCoronal.TabStop = false;
            this.FlowCoronal.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowCoronal_Paint);
            this.FlowCoronal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlowCoronal_MouseDown);
            this.FlowCoronal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlowCoronal_MouseMove);
            this.FlowCoronal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FlowCoronal_MouseUp);
            // 
            // FlowSaggital
            // 
            this.FlowSaggital.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlowSaggital.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FlowSaggital.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlowSaggital.Location = new System.Drawing.Point(570, 53);
            this.FlowSaggital.Name = "FlowSaggital";
            this.FlowSaggital.Size = new System.Drawing.Size(235, 236);
            this.FlowSaggital.TabIndex = 1;
            this.FlowSaggital.TabStop = false;
            this.FlowSaggital.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowSaggital_Paint);
            this.FlowSaggital.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlowSaggital_MouseDown);
            this.FlowSaggital.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlowSaggital_MouseMove);
            this.FlowSaggital.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FlowSaggital_MouseUp);
            // 
            // FlowImage
            // 
            this.FlowImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlowImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FlowImage.Location = new System.Drawing.Point(570, 455);
            this.FlowImage.Name = "FlowImage";
            this.FlowImage.Size = new System.Drawing.Size(250, 240);
            this.FlowImage.TabIndex = 42;
            this.FlowImage.TabStop = false;
            this.FlowImage.Visible = false;
            this.FlowImage.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowImage_Paint);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl1.Location = new System.Drawing.Point(12, 810);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(68, 30);
            this.lbl1.TabIndex = 43;
            this.lbl1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(694, 810);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 30);
            this.label2.TabIndex = 44;
            this.label2.Text = "label2s";
            // 
            // FlowAxial
            // 
            this.FlowAxial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlowAxial.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FlowAxial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlowAxial.Location = new System.Drawing.Point(114, 46);
            this.FlowAxial.Name = "FlowAxial";
            this.FlowAxial.Size = new System.Drawing.Size(250, 243);
            this.FlowAxial.TabIndex = 0;
            this.FlowAxial.TabStop = false;
            this.FlowAxial.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLAxial_Paint);
            this.FlowAxial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlowAxial_MouseDown);
            this.FlowAxial.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlowAxial_MouseMove);
            this.FlowAxial.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FlowAxial_MouseUp);
            // 
            // _FormProgramma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1069, 849);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.FlowImage);
            this.Controls.Add(this.FlowSaggital);
            this.Controls.Add(this.FlowCoronal);
            this.Controls.Add(this.FlowAxial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._menuBar);
            this.MinimumSize = new System.Drawing.Size(1085, 0);
            this.Name = "_FormProgramma";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this._FormProgramma_KeyDown);
            this.MouseEnter += new System.EventHandler(this._FormProgramma_MouseEnter);
            this.MouseLeave += new System.EventHandler(this._FormProgramma_MouseLeave);
            this.MouseHover += new System.EventHandler(this._FormProgramma_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this._FormProgramma_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this._FormProgramma_MouseUp);
            this.Resize += new System.EventHandler(this._FormProgramma_Resize);
            this._menuBar.ResumeLayout(false);
            this._menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlowCoronal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowSaggital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowAxial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Panel panel2;
        public Panel panel1;
        public MenuStrip _menuBar;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem apriToolStripMenuItem;
        private ToolStripMenuItem modificaToolStripMenuItem;
        public PictureBox FlowImage;
        private Label lbl1;
        private Label label2;
        private ToolStripMenuItem scalaDiGrigiToolStripMenuItem;
        public PictureBox FlowCoronal;
        public PictureBox FlowSaggital;
        public PictureBox FlowAxial;
    }
}