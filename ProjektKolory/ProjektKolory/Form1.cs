namespace ProjektKolory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Color panelColor = Panel.BackColor;

            KolorCzerwony.Value = panelColor.R;
            KolorZielony.Value = panelColor.G;
            KolorNiebieski.Value = panelColor.B;
        }

        private void Default_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void KolorCzerwony_ValueChanged(object sender, EventArgs e)
        {
            changeColors();
        }

        private void KolorZielony_Scroll(object sender, EventArgs e)
        {
            changeColors();
        }

        private void KolorNiebieski_Scroll(object sender, EventArgs e)
        {
            changeColors();
        }

        private void changeColors()
        {
            this.BackColor = Color.FromArgb(KolorCzerwony.Value, KolorZielony.Value, KolorNiebieski.Value);
        }

        private void ObsulaKolorow(object sender, EventArgs e)
        {
            if(sender is TrackBar)
            {
                var bar = sender as TrackBar;

                Color panelColor = Panel.BackColor;

                int r = panelColor.R;
                int g = panelColor.G;
                int b = panelColor.B;

                if(bar!.Name == "KolorCzerwony")
                    r = bar.Value;
                else if (bar!.Name == "KolorZielony")
                    g = bar.Value;
                else if (bar!.Name == "KolorNiebieski")
                    b = bar.Value;

                Panel.BackColor = Color.FromArgb(r, g, b);
            }
        }
    }
}