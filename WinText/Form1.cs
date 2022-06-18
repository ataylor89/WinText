namespace WinText
{
    public partial class Form1 : Form
    {
        private string filePath;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;

        public Form1()
        {
            InitializeComponent();
            filePath = string.Empty;
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            fontDialog = new FontDialog();
            richTextBox.Font = new Font("Segoe Print", 12, FontStyle.Regular);
            richTextBox.ForeColor = System.Drawing.Color.Maroon;
        }

        private void newDocument(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }

        private void openFile(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                richTextBox.Clear();
                richTextBox.AppendText(fileContent);               
            }
        }

        private void saveFile(object sender, EventArgs e)
        { 
            if (filePath != string.Empty)
            {
                File.WriteAllText(filePath, richTextBox.Text);
            }
            else
            {
                saveFileAs(sender, e);
            }
        }

        private void saveFileAs(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, richTextBox.Text);
            }
        }

        private void exitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoAction(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void redoAction(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        private void cutSelection(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void copySelection(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void pasteSelection(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void setFont(object sender, EventArgs e)
        {
            fontDialog.ShowColor = true;

            fontDialog.Font = richTextBox.Font;
            fontDialog.Color = richTextBox.ForeColor;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox.Font = fontDialog.Font;
                richTextBox.ForeColor = fontDialog.Color;
            }
        }
    }
}