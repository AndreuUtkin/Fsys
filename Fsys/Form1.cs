namespace Fsys
{
    public partial class Form1 : Form
    {
        myFileSystem fs = new myFileSystem(@"c:/app/fsys.txt");
        public Form1()
        {
            InitializeComponent();
            myFileSystem fs = new myFileSystem(@"c:/app/fsys.txt");
            List<string> files = fs.Display();
            listBox1.BeginUpdate();
            for (int i = 0; i < files.Count; i++)
            {
                listBox1.Items.Add(files[i]);
            }
            listBox1.EndUpdate();
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Удалить", null, DeleteItem);
            contextMenu.Items.Add("Читать", null, ReadItem);
            // Привязываем контекстное меню к ListBox
            listBox1.ContextMenuStrip = contextMenu;
            listBox2.BeginUpdate();
            files = fs.ReDisp();
            for (int i = 0; i < files.Count; i++)
            {
                listBox2.Items.Add(files[i]);
            }
            listBox2.EndUpdate();
            ContextMenuStrip contextMenuR = new ContextMenuStrip();
            contextMenuR.Items.Add("Восстановить", null, RecoverItem);
            // Привязываем контекстное меню к ListBox
            listBox2.ContextMenuStrip = contextMenuR;
            richTextBox2.Text = fs.ReadHex();
            richTextBox3.Text = fs.ReadChar();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 16;
            int occuped=16 -fs.FreeClasters(); ;
            progressBar1.Value = occuped;
            label6.Text = Convert.ToString(occuped * 32);
        }
        private void UpdateFiles()
        {
            listBox1.Items.Clear();
            List<string> files = fs.Display();
            listBox1.BeginUpdate();
            for (int i = 0; i < files.Count; i++)
            {
                listBox1.Items.Add(files[i]);
            }
            listBox1.EndUpdate();
            listBox2.Items.Clear();
            files = fs.ReDisp();
            listBox2.BeginUpdate();
            for (int i = 0; i < files.Count; i++)
            {
                listBox2.Items.Add(files[i]);
            }
            listBox2.EndUpdate();
            richTextBox2.Text = fs.ReadHex();
            richTextBox3.Text = fs.ReadChar();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 16;
            int occuped = 16 - fs.FreeClasters(); ;
            progressBar1.Value = occuped;
            label6.Text = Convert.ToString(occuped * 32);
        }
        private void DeleteItem(object sender, EventArgs e)
        {
            // Удаление выбранного элемента из ListBox
            if (listBox1.SelectedIndex != -1)
            {
                string name = listBox1.SelectedItem.ToString();
                fs.Delete(name);
            }
            UpdateFiles();
        }
        private void RecoverItem(object sender, EventArgs e)
        {

            // Удаление выбранного элемента из ListBox
            if (listBox2.SelectedIndex != -1)
            {
                string name = listBox2.SelectedItem.ToString();
                if (fs.CanBeRecovered(name))
                {
                    fs.Recovery(name);
                }
                else
                {
                    richTextBox4.Text = name + " cant be recovered";
                }
            }
            UpdateFiles();
        }
        private void ReadItem(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string name = listBox1.SelectedItem.ToString();
                string content = fs.Read(name);
                richTextBox1.Text = content;
            }
            UpdateFiles();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (name.Length != 7)
            {
                richTextBox4.Text = "Invalid name";
            }
            else
            {
                string content = richTextBox1.Text;
                if (fs.convert((double)content.Length/32) > fs.FreeClasters())
                {
                    richTextBox4.Text = "Too long";
                }
                else
                {
                    fs.NewFile(name, content);
                    UpdateFiles();
                }
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fs.Formatting();
            UpdateFiles();
        }

      
    }
}
