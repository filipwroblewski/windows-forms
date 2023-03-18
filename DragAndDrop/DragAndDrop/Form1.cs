namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        object dragDropSource = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lbSender = sender as ListBox;
            // int indeks = lbSender.IndexFromPoint(e.X, e.Y);
            dragDropSource = sender; // przechowanie referencji dla DragOver
            //if (e.Button == MouseButtons.Left && indeks != -1)
            if (e.Button == MouseButtons.Left && (lbSender.SelectedIndices.Count > 0))
            {
                DragDropEffects operacja =
                //lbSender.DoDragDrop(lbSender.Items[indeks], DragDropEffects.Copy | DragDropEffects.Move);
                lbSender.DoDragDrop(lbSender.SelectedItems, DragDropEffects.Copy |
                DragDropEffects.Move);
                if (operacja == DragDropEffects.Move)
                {
                    // foreach (int indeks in lbSender.SelectedIndices)
                    //lbSender.Items.RemoveAt(indeks)
                    for (int i = lbSender.SelectedItems.Count - 1; i >= 0; i--)
                        lbSender.Items.Remove(lbSender.SelectedItems[i]);
                }
            }
            dragDropSource = null;
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            if (sender == dragDropSource)
                e.Effect = DragDropEffects.None;
            else
            {
                if ((e.KeyState & 8) == 8)
                    e.Effect = DragDropEffects.Copy; // z CTRL
                else
                    e.Effect = DragDropEffects.Move;
            }
                 
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            ListBox lbSender = sender as ListBox;
            ListBox lbSource = dragDropSource as ListBox;
            int indeks = lbSender.IndexFromPoint(lbSender.PointToClient(new
           Point(e.X, e.Y)));
            if (indeks == -1) indeks = lbSender.Items.Count;
            // lbSender.Items.Insert(indeks, e.Data.GetData(DataFormats.Text).ToString());
            for (int i = lbSource.SelectedItems.Count - 1; i >= 0; i--)
                lbSender.Items.Insert(indeks,
               lbSource.Items[lbSource.SelectedIndices[i]]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}