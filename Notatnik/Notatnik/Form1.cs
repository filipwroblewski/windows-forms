using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Notatnik
{
    public partial class Notatnik : Form
    {
        public Notatnik()
        {
            InitializeComponent();
            statusStrip1.Visible= false;
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> tekst = new List<string>();

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string nazwaPliku = openFileDialog1.FileName;
                    using (StreamReader sr = new StreamReader(nazwaPliku))
                    {
                        string wiersz;
                        while ((wiersz = sr.ReadLine()) != null)
                            tekst.Add(wiersz);
                    }
                }
                textBox1.Lines = tekst.ToArray();
            }
            catch (Exception info)
            {
                MessageBox.Show("Blad odczytu pliku " + info.Message);
            }

        }

        private void ZapiszDoPlikuTekstowego_Click(object sender, EventArgs e)
        {

        }

        public static void ZapiszDoPlikuTekstowego(string nazwaPliku, string[] tekst)
        {
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
                foreach (string wiersz in tekst)
                    sw.WriteLine(wiersz);
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nazwaPliku = openFileDialog1.FileName;
            if (nazwaPliku.Length > 0) saveFileDialog1.FileName = nazwaPliku;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nazwaPliku = saveFileDialog1.FileName;
                ZapiszDoPlikuTekstowego(nazwaPliku, textBox1.Lines);
            }
        }

        private void tłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                textBox1.BackColor = colorDialog1.Color;

        }

        private void czcionkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            fontDialog1.Color = textBox1.ForeColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
                textBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
        }

        private void zaznaczWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void pasekstanuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int start = textBox1.SelectionStart;
            int line = textBox1.GetLineFromCharIndex(start) + 1;
            int column = start - textBox1.GetFirstCharIndexOfCurrentLine() + 1;

            string rowAndColumn = $"Linijka: {line.ToString()}, Kolumna: {column.ToString()}";
            rowAndColumnInfo.Text = rowAndColumn;
        }

        private void AppendText(TextBox ctrl, string Text)
        {
            if (ctrl != null && !string.IsNullOrEmpty(Text))
                ctrl.AppendText(Text);
        }

        private void SetEnable(Control ctrl, bool Enable)
        {
            if (ctrl != null)
                ctrl.Enabled = Enable;
        }
    }
}