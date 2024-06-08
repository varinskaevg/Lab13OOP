using System;
using System.IO;
using System.Windows.Forms;

namespace Lab13OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Завантаження доступних дисків при запуску програми
            LoadDrives();
            // Призначення обробників подій для елементів управління
            listBoxDrives.SelectedIndexChanged += listBoxDrives_SelectedIndexChanged;
            listBoxContent.SelectedIndexChanged += listBoxContent_SelectedIndexChanged;
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // Ініціалізація комбо-боксу фільтрації каталогів
            InitializeDirectoryFilterComboBox();
        }

        // Метод для завантаження доступних дисків
        private void LoadDrives()
        {
            listBoxDrives.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                listBoxDrives.Items.Add(drive.Name);
            }
        }

        // Метод для ініціалізації комбо-боксу фільтрації каталогів
        private void InitializeDirectoryFilterComboBox()
        {
            comboBoxDirectoryFilter.Items.Clear();
            comboBoxDirectoryFilter.Items.Add("Всі каталоги (*.*)");
            comboBoxDirectoryFilter.Items.Add("*.txt");
            comboBoxDirectoryFilter.Items.Add("*.exe");
            comboBoxDirectoryFilter.Items.Add("*.doc");
            comboBoxDirectoryFilter.SelectedIndex = 0; // Встановлення значення за замовчуванням на "Всі каталоги"
        }

        // Обробник події вибору диска у списку дисків
        private void listBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDrives.SelectedItem != null)
            {
                string selectedDrive = listBoxDrives.SelectedItem.ToString();
                textBoxPath.Text = selectedDrive;
                LoadDirectoryContent(selectedDrive);
                ShowDriveProperties(selectedDrive);
            }
        }

        // Обробник події вибору елемента у списку вмісту каталогу
        private void listBoxContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxContent.SelectedItem != null)
            {
                string selectedPath = Path.Combine(textBoxPath.Text, listBoxContent.SelectedItem.ToString());
                if (Directory.Exists(selectedPath))
                {
                    textBoxPath.Text = selectedPath;
                    LoadDirectoryContent(selectedPath);
                    ShowDirectoryProperties(selectedPath);
                }
                else if (File.Exists(selectedPath))
                {
                    textBoxPath.Text = selectedPath;
                    string fileExtension = Path.GetExtension(selectedPath).ToLower();

                    if (IsImageFile(fileExtension))
                    {
                        // Відображення зображення у PictureBox
                        pictureBoxImage.ImageLocation = selectedPath;
                    }
                    else if (IsTextFile(fileExtension))
                    {
                        // Відображення текстового файлу у RichTextBox
                        ShowTextFile(selectedPath);
                    }
                    else
                    {
                        // Інші типи файлів, можна додати логіку для їх обробки
                        ShowFileProperties(selectedPath);
                    }
                }
            }
        }

        private bool IsImageFile(string fileExtension)
        {
            return fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif";
        }

        private bool IsTextFile(string fileExtension)
        {
            return fileExtension == ".txt" || fileExtension == ".doc" || fileExtension == ".docx";
        }

        private void ShowTextFile(string filePath)
        {
            try
            {
                // Завантаження тексту з файлу та відображення у RichTextBox
                richTextBoxContent.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                // Відображення властивостей файлу
                ShowFileProperties(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка відображення текстового файлу: " + ex.Message);
            }
        }

        // Метод для завантаження вмісту каталогу
        private void LoadDirectoryContent(string path)
        {
            listBoxContent.Items.Clear();
            try
            {
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                string directoryFilter = GetDirectoryFilterFromComboBox();
                string fileFilter = textBoxFileFilter.Text;

                foreach (string directory in directories)
                {
                    if (string.IsNullOrEmpty(directoryFilter) || directory.EndsWith(directoryFilter))
                    {
                        listBoxContent.Items.Add(Path.GetFileName(directory));
                    }
                }

                foreach (string file in files)
                {
                    if (string.IsNullOrEmpty(fileFilter) || Path.GetFileName(file).Contains(fileFilter))
                    {
                        listBoxContent.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження вмісту каталогу: " + ex.Message);
            }
        }

        // Метод для відображення властивостей диска
        private void ShowDriveProperties(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName);
            labelProperties.Text = $"Диск {drive.Name}\n" +
                                   $"Тип: {drive.DriveType}\n" +
                                   $"Формат: {drive.DriveFormat}\n" +
                                   $"Загальний розмір: {drive.TotalSize}\n" +
                                   $"Доступний простір: {drive.AvailableFreeSpace}";
        }

        // Метод для відображення властивостей каталогу
        private void ShowDirectoryProperties(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                labelProperties.Text = $"Каталог {directory.Name}\n" +
                                       $"Повна назва: {directory.FullName}\n" +
                                       $"Створений: {directory.CreationTime}\n" +
                                       $"Останній доступ: {directory.LastAccessTime}\n" +
                                       $"Останні зміни: {directory.LastWriteTime}\n" +
                                       $"Корінь: {directory.Root}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка відображення властивостей каталогу: " + ex.Message);
            }
        }

        // Метод для відображення властивостей файлу та його вмісту
        private void ShowFileProperties(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                string fileContent = File.ReadAllText(path);

                // Очищення вмісту RichTextBox перед відображенням нового файлу
                richTextBoxContent.Clear();
                // Додавання вмісту текстового файлу до RichTextBox
                richTextBoxContent.AppendText(fileContent);

                labelProperties.Text = $"Файл {file.Name}\n" +
                                       $"Повна назва: {file.FullName}\n" +
                                       $"Розмір: {file.Length}\n" +
                                       $"Створений: {file.CreationTime}\n" +
                                       $"Останній доступ: {file.LastAccessTime}\n" +
                                       $"Останні зміни: {file.LastWriteTime}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка відображення властивостей файлу: " + ex.Message);
            }
        }

        // Метод для обробки натискання кнопки застосування фільтру
        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            LoadDirectoryContent(textBoxPath.Text);

            string fileNameFilter = textBoxFileFilter.Text;
            if (!string.IsNullOrEmpty(fileNameFilter))
            {
                FilterFilesByName(fileNameFilter);
            }
        }

        // Метод для отримання фільтра каталогів з комбо-боксу

        private string GetDirectoryFilterFromComboBox()
        {
            switch (comboBoxDirectoryFilter.SelectedIndex)
            {
                case 0:
                    return null; 
                default:
                    return comboBoxDirectoryFilter.SelectedItem.ToString();
            }
        }
        private void FilterFilesByName(string fileNameFilter)
        {
            for (int i = listBoxContent.Items.Count - 1; i >= 0; i--)
            {
                string listItem = listBoxContent.Items[i].ToString();
                if (!listItem.Contains(fileNameFilter))
                {
                    listBoxContent.Items.RemoveAt(i);
                }
            }
        }
    }
}
