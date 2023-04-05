using System.ComponentModel;
using System.Text.Json;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        private BindingList<ToDoEntry> entries = new BindingList<ToDoEntry>();
        public Form1()
        {
            InitializeComponent();
            titleText.DataBindings.Add("Text", entriesSource, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            dueDatePicker.DataBindings.Add("Value", entriesSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged);
            entriesSource.DataSource = entries;
        }

        private void CreateNewItem(string title, DateTime dueDate, string description)
        {
            ToDoEntry newEntry = (ToDoEntry)entriesSource.AddNew();
            newEntry.Title = title;
            newEntry.DueDate = dueDate;
            newEntry.Description = description;
            entriesSource.ResetCurrentItem();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entriesListView.SelectedIndices.Count != 0)
            {
                int entryIndex = entriesListView.SelectedIndices[0];
                entriesSource.Position = entryIndex;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewItem("", DateTime.Now, "");
        }

        private void entriesSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    MakeListViewItemForNewEntry(e.NewIndex);
                    break;
                case ListChangedType.ItemDeleted:
                    RemoveListViewItem(e.NewIndex);
                    break;
                case ListChangedType.ItemChanged:
                    UpdateListViewItem(e.NewIndex);
                    break;
            }

        }

        private void MakeListViewItemForNewEntry(int newItemIndex)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add("");
            entriesListView.Items.Insert(newItemIndex, item);
        }

        private void UpdateListViewItem(int itemIndex)
        {
            ListViewItem item = entriesListView.Items[itemIndex];
            ToDoEntry entry = entries[itemIndex];
            item.SubItems[0].Text = entry.Title;
            item.SubItems[1].Text = entry.DueDate.ToShortDateString();
        }

        private void RemoveListViewItem(int deletedItemIndex)
        {
            entriesListView.Items.RemoveAt(deletedItemIndex);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (entriesListView.SelectedIndices.Count != 0)
            {
                int entryIndex = entriesListView.SelectedIndices[0];
                entriesSource.RemoveAt(entryIndex);
            }

        }

        private void SerializeToJsonFile(string filePath, BindingList<ToDoEntry> entries)
        {
            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText(filePath, json);
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Wywolanie SaveFileDialog zeby uzyskac sciezke do pliku do zapisu danych
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            try
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SerializeToJsonFile(saveFileDialog.FileName, entries);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad zapisu ToDo do pliku JSON: " + ex.Message);
            }
            
        }

        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            // OpenFileDialog zeby wskazac plik json do zaladowania danych
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Load ToDo List from JSON File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // wczytanie danych json
                    string jsonData = File.ReadAllText(openFileDialog.FileName);

                    // deserializacja json do List<ToDoEntry>
                    List<ToDoEntry> loadedEntries = JsonSerializer.Deserialize<List<ToDoEntry>>(jsonData);

                    // zresetowanie entries w celu zaladowania nowych danych
                    entries.Clear();
                    foreach (ToDoEntry entry in loadedEntries)
                    {
                        CreateNewItem(entry.Title, DateTime.Now, entry.Description);
                    }

                    MessageBox.Show("ToDo pomyslnie zaladowane z pliku JSON.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Blad ladowania ToDo z pliku JSON: " + ex.Message);
                }
            }
        }

    }
}