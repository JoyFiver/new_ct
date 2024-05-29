namespace Test_Form
{
    partial class Caricamento
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
            this.progBMainPanel = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progBMainPanel
            // 
            this.progBMainPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progBMainPanel.Location = new System.Drawing.Point(22, 11);
            this.progBMainPanel.Name = "progBMainPanel";
            this.progBMainPanel.Size = new System.Drawing.Size(293, 38);
            this.progBMainPanel.TabIndex = 36;
            // 
            // Caricamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 61);
            this.ControlBox = false;
            this.Controls.Add(this.progBMainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Caricamento";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Caricamento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ProgressBar progBMainPanel;
    }
}