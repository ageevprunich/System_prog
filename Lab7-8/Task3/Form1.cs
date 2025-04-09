using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPath.KeyDown += textBoxPath_KeyDown;
            listView1.DoubleClick += listView1_DoubleClick;
            btnCreateFile.Click += btnCreateFile_Click;
            btnDelete.Click += btnDelete_Click;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.Add("File_Name", 200);
            listView1.Columns.Add("Size", 100);
            listView1.Columns.Add("Extension", 100);
            listView1.Columns.Add("Created", 150);

            // Початковий шлях
            string initialPath = @"C:\";
            textBoxPath.Text = initialPath;
            LoadDirectory(initialPath);
        }

        private void LoadDirectory(string path)
        {
            listView1.Items.Clear();

            try
            {
                // Папки
                foreach (var dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo dInfo = new DirectoryInfo(dir);
                    ListViewItem item = new ListViewItem(dInfo.Name);                     // File_Name
                    item.SubItems.Add("");                                               // Size (порожній для папки)
                    item.SubItems.Add("Directory");                                      // Extension
                    item.SubItems.Add(dInfo.CreationTime.ToString());                    // Created
                    item.Tag = dInfo.FullName;
                    listView1.Items.Add(item);
                }

                // Файли
                foreach (var file in Directory.GetFiles(path))
                {
                    FileInfo fInfo = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fInfo.Name);                    // File_Name
                    item.SubItems.Add(fInfo.Length.ToString());                          // Size
                    item.SubItems.Add(fInfo.Extension);                                  // Extension
                    item.SubItems.Add(fInfo.CreationTime.ToString());                    // Created
                    item.Tag = fInfo.FullName;
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка доступу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string fullPath = listView1.SelectedItems[0].Tag.ToString();

                if (Directory.Exists(fullPath))
                {
                    textBoxPath.Text = fullPath;
                    LoadDirectory(fullPath);
                }
                else if (File.Exists(fullPath))
                {
                    try
                    {
                        Process.Start(fullPath);
                    }
                    catch
                    {
                        MessageBox.Show("Не вдалося відкрити файл.");
                    }
                }
            }
        }

        private void textBoxPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string path = textBoxPath.Text.Trim();
                if (Directory.Exists(path))
                {
                    LoadDirectory(path);
                }
                else
                {
                    MessageBox.Show("Директорія не існує.");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentPath = textBoxPath.Text;
            DirectoryInfo di = new DirectoryInfo(currentPath);

            if (di.Parent != null)
            {
                textBoxPath.Text = di.Parent.FullName;
                LoadDirectory(di.Parent.FullName);
            }
            else
            {
                MessageBox.Show("Ви вже в кореневій директорії.");
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string currentPath = textBoxPath.Text.Trim();
            string newFileName = textBoxNewFileName.Text.Trim();

            if (string.IsNullOrWhiteSpace(newFileName))
            {
                MessageBox.Show("Введіть назву файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullPath = Path.Combine(currentPath, newFileName);

            try
            {
                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath).Close(); // створення і одразу закрити
                    LoadDirectory(currentPath);    // оновити список
                    MessageBox.Show("Файл створено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Файл з такою назвою вже існує.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення файлу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть файл або папку для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            string selectedName = selectedItem.Text;
            string selectedType = selectedItem.SubItems[2].Text; 
            string fullPath = selectedItem.Tag.ToString();

            var confirm = MessageBox.Show($"Ви впевнені, що хочете видалити '{selectedName}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (selectedType == "Directory")
                {
                    Directory.Delete(fullPath, true);
                }
                else
                {
                    File.Delete(fullPath);
                }

                MessageBox.Show($"'{selectedName}' видалено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDirectory(textBoxPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
