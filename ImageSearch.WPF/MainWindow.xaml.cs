using ImageIndex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using XlsxModifier;

namespace ImageSearch.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConfigFile = "ImageSearch.conf";
        private string imageRoot;
        private string noImageStub;
        private string pattern;

        private Index index;
        private XlsxEditor editor;
        private ConfigManager config;
        private string outputFolder;
        private string xlsxFile;
        private bool moveLinks;
        private List<string> folders = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            AddVersionToTitle();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            config = new ConfigManager(ConfigFile);
            ConfigManager.LoadStatus status = config.LoadConfig();

            if (status == ConfigManager.LoadStatus.LoadedDefault)
            {
                System.Windows.MessageBox.Show("Dafault config loaded", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            imageRoot = config.Conf.ImageRoot;
            noImageStub = config.Conf.NoImageStub;
            pattern = config.Conf.Pattern;

            Progress<string> p = new Progress<string>(ProgressReportIndex);
            index = new Index(pattern, p);

            PatternTextBox.Text = index.Pattern;
            NoImageFileTextBox.Text = noImageStub;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            config.Conf.ImageRoot = imageRoot;
            config.Conf.NoImageStub = noImageStub;
            config.Conf.Pattern = PatternTextBox.Text;
            config.SaveConfig();
        }

        private async void AddFolderButton_Click(object sender, RoutedEventArgs e)
        {
            try { if (!string.IsNullOrEmpty(PatternTextBox.Text)) index.Pattern = PatternTextBox.Text; }
            catch (Exception ex) { UpdateLog($"{ex.Message}", MsgStatus.Error); return; }

            using (var folderDialog = new FolderBrowserDialog() { SelectedPath = imageRoot})
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Stopwatch timer = new Stopwatch();

                    string selectedPath = folderDialog.SelectedPath;
                    imageRoot = selectedPath;

                    try
                    {
                        timer.Start();
                        AddFolderButton.IsEnabled = false;
                        ClearIndexButton.IsEnabled = false;
                        await Task.Run(async () => { await index.Add(selectedPath); });
                        AddFolderButton.IsEnabled = true;
                        ClearIndexButton.IsEnabled = true;
                        IndexProgressLabel.Text = "";
                        timer.Stop();

                        folders.Add(selectedPath);
                        UpdateFolderStatus();
                        UpdateLog($"Add folder: \"{selectedPath}\"");
                        UpdateLog($"Index build: files - {index.FilesCount}, index records - {index.IndexCount}, search pattern - {index.Pattern}");
                        UpdateLog($"Time - {timer.ElapsedMilliseconds / 1000}s");
                    }
                    catch (Exception ex)
                    {
                        UpdateLog($"{ex.Message}", MsgStatus.Error);
                    }

                    if (folders.Count > 0) ViewIndexButton.IsEnabled = true;
                }
            }
        }

        private void ClearIndexButton_Click(object sender, RoutedEventArgs e)
        {
            ClearIndexButton.IsEnabled = false;
            ViewIndexButton.IsEnabled = false;
            Progress<string> p = new Progress<string>(ProgressReportIndex);
            index = new Index(pattern, p);
            folders = new List<string>();
            UpdateFolderStatus();
            UpdateLog($"Index is empty");
        }

        private void GetStubFileButton_Click(object sender, RoutedEventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                DialogResult result = fileDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    noImageStub = fileDialog.FileName;
                    UpdateLog($"Selecting NoImageStub file: \"{noImageStub}\"");
                    NoImageFileTextBox.Text = noImageStub;
                }
            }
        }

        private void OpenExcelFileButton_Click(object sender, RoutedEventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                DialogResult result = fileDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    xlsxFile = fileDialog.FileName;

                    try
                    {
                        editor = new XlsxEditor(xlsxFile);
                        UpdateXlsStatus();
                        UpdateLog($"Selecting Excel file: \"{xlsxFile}\", sheets count - {editor.Sheets.Count}");
                    }
                    catch (IOException ex)
                    {
                        UpdateLog($"{ex.Message}", MsgStatus.Error);
                    }
                }
            }
        }

        private void FolderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((System.Windows.Controls.ListBox)sender).SelectedIndex != -1) UpdateLog($"Select sheet: \"{editor.Sheets[((System.Windows.Controls.ListBox)sender).SelectedIndex]}\"");
        }

        private void CopyFilesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            moveLinks = !moveLinks;
            SelectOutputButton.IsEnabled = moveLinks;
            OutPutFolderlabelD.IsEnabled = moveLinks;
            OutPutFolderlabel.IsEnabled = moveLinks;
        }

        private void SelectOutputButton_Click(object sender, RoutedEventArgs e)
        {
            using (var OutputFolderDialog = new FolderBrowserDialog())
            {
                DialogResult result = OutputFolderDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    outputFolder = OutputFolderDialog.SelectedPath;
                    UpdateOutputFolderStatus();
                    UpdateLog($"Selecting output folder: \"{outputFolder}\"");
                }
            }
        }

        private async void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            if (folders.Count == 0)
            {
                UpdateLog("Add image folders", MsgStatus.Error);
                return;
            }

            if (moveLinks && string.IsNullOrEmpty(outputFolder))
            {
                UpdateLog("Select output directory", MsgStatus.Error);
                return;
            }

            if (editor == null)
            {
                UpdateLog("Select Excel file", MsgStatus.Error);
                return;
            }

            if (SheetSelectorListBox.SelectedIndex == -1)
            {
                UpdateLog("Select sheet", MsgStatus.Error);
                return;
            }

            UpdateLog($"Work with sheet: \"{editor.Sheets[SheetSelectorListBox.SelectedIndex]}\"");

            try
            {
                Stopwatch timer = new Stopwatch();

                editor.NoImageFile = noImageStub;
                index.Pattern = PatternTextBox.Text;

                timer.Start();
                Tuple<int, string> result = editor.Change(index, SheetSelectorListBox.SelectedIndex, outputFolder, moveLinks);
                timer.Stop();

                UpdateLog($"Found images for {result.Item1} item(s)");
                UpdateLog($"File saved as \"{result.Item2}\"");
                UpdateLog($"Time - {timer.ElapsedMilliseconds / 1000}s");

                int filesCopied = 0;

                if (moveLinks)
                {
                    CopyProgressBar.Maximum = editor.FilesToCollect;
                    CopyProgressBar.Minimum = 0;

                    timer.Start();
                    var progress = new Progress<Tuple<string, string, int, int>>(ProgressReport);
                    filesCopied = await editor.CollectFiles(progress);
                    timer.Stop();
                    UpdateLog($"Copied {filesCopied} files to \"{outputFolder}\"");
                    UpdateLog($"Time - {timer.ElapsedMilliseconds / 1000}s");
                }

                ClearWorkspace();
            }
            catch (Exception ex)
            {
                UpdateLog($"{ex.Message}", MsgStatus.Error);
            }
        }

        private void ViewIndexButton_Click(object sender, RoutedEventArgs e)
        {
            Window indexWindow = new IndexWindow(index);
            indexWindow.Owner = this;
            indexWindow.ShowDialog();
        }

        private void LogTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LogTextBox.CaretIndex = LogTextBox.Text.Length;
            LogTextBox.ScrollToEnd();
        }

        private void UpdateOutputFolderStatus()
        {
            OutPutFolderlabel.Text = outputFolder;
        }

        private void UpdateXlsStatus()
        {
            ExcelFileLabel.Text = xlsxFile;
            SheetSelectorListBox.ItemsSource = null;

            if (editor != null)
            {
                SheetSelectorListBox.ItemsSource = editor.Sheets;
            }
        }

        private void UpdateFolderStatus()
        {
            FolderListBox.Items.Clear();

            foreach (string folder in folders)
            {
                FolderListBox.Items.Add(folder);
            }

            foldersLabel.Content = folders.Count;
            filesLabel.Content = index.FilesCount;
            recordsLabel.Content = index.IndexCount;
            errorsLabel.Content = index.ErrorDictionary.Count;

            if (folders.Count != 0) ClearIndexButton.IsEnabled = true;
        }

        private void UpdateLog(string msg, MsgStatus status = MsgStatus.Info)
        {
            switch (status)
            {
                case MsgStatus.Error:
                    LogTextBox.Text += "[Error] ";
                    LogTextBox.Text += msg.ToUpper();
                    break;
                case MsgStatus.Info:
                    LogTextBox.Text += "[Info] ";
                    LogTextBox.Text += msg;
                    break;
            }

            LogTextBox.Text += Environment.NewLine;
        }

        private void AddVersionToTitle()
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;

#if RELEASE
            Title += $" [{v.Major}.{v.Minor}]";
#endif

#if DEBUG
            Title += $" [{v.Major}.{v.Minor} build {v.Build} revision {v.Revision}]";
#endif
        }

        private void ClearWorkspace()
        {
            editor.Dispose();
            editor = null;
            xlsxFile = "[Empty]";

            UpdateXlsStatus();

            CopyProgressLabel.Content = "";
            CopyProgressFileLabel.Text = "";
            IndexProgressLabel.Text = "";
            CopyProgressBar.Value = 0;
        }

        private void ProgressReport(Tuple<string, string, int, int> msg)
        {
            string reportString1 = $"Copy file {msg.Item4} from {msg.Item3}";
            string reportString2 = $"{msg.Item1}";

            CopyProgressLabel.Dispatcher.Invoke(() => CopyProgressLabel.Content = reportString1);
            CopyProgressFileLabel.Dispatcher.Invoke(() => CopyProgressFileLabel.Text = reportString2);
            CopyProgressBar.Value = msg.Item4;
        }

        private void ProgressReportIndex(string msg)
        {
            IndexProgressLabel.Dispatcher.Invoke(() => IndexProgressLabel.Text = msg);
        }

        private enum MsgStatus
        {
            Info,
            Error,
        }
    }
}