namespace ProjektKolory
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KolorCzerwony = new System.Windows.Forms.TrackBar();
            this.KolorZielony = new System.Windows.Forms.TrackBar();
            this.Panel = new System.Windows.Forms.Panel();
            this.KolorNiebieski = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.KolorCzerwony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KolorZielony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KolorNiebieski)).BeginInit();
            this.SuspendLayout();
            // 
            // KolorCzerwony
            // 
            this.KolorCzerwony.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KolorCzerwony.Location = new System.Drawing.Point(0, 797);
            this.KolorCzerwony.Maximum = 255;
            this.KolorCzerwony.Name = "KolorCzerwony";
            this.KolorCzerwony.Size = new System.Drawing.Size(1128, 101);
            this.KolorCzerwony.TabIndex = 1;
            this.KolorCzerwony.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.KolorCzerwony.ValueChanged += new System.EventHandler(this.ObsulaKolorow);
            // 
            // KolorZielony
            // 
            this.KolorZielony.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KolorZielony.Location = new System.Drawing.Point(0, 696);
            this.KolorZielony.Maximum = 255;
            this.KolorZielony.Name = "KolorZielony";
            this.KolorZielony.Size = new System.Drawing.Size(1128, 101);
            this.KolorZielony.TabIndex = 2;
            this.KolorZielony.Scroll += new System.EventHandler(this.ObsulaKolorow);
            // 
            // Panel
            // 
            this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1128, 225);
            this.Panel.TabIndex = 3;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // KolorNiebieski
            // 
            this.KolorNiebieski.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KolorNiebieski.Location = new System.Drawing.Point(0, 595);
            this.KolorNiebieski.Maximum = 255;
            this.KolorNiebieski.Name = "KolorNiebieski";
            this.KolorNiebieski.Size = new System.Drawing.Size(1128, 101);
            this.KolorNiebieski.TabIndex = 4;
            this.KolorNiebieski.Scroll += new System.EventHandler(this.ObsulaKolorow);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1128, 898);
            this.Controls.Add(this.KolorNiebieski);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.KolorZielony);
            this.Controls.Add(this.KolorCzerwony);
            this.Name = "Form1";
            this.Text = "Projekt: Kolory";
            this.Load += new System.EventHandler(this.Default_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KolorCzerwony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KolorZielony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KolorNiebieski)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TrackBar KolorCzerwony;
        private TrackBar KolorZielony;
        private Panel Panel;
        private TrackBar KolorNiebieski;
    }
}