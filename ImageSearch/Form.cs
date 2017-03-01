using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ImageIndex;
using XlsxModifier;

namespace ImageSearch
{
    public partial class MainForm : Form
    {
        private Index index = new Index();
        private XlsxEditor editor;
        private string outputFolder;
        private string xlsxFile;
        private bool moveLinks;
        private List<string> folders = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddFolders_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialogIndexed.ShowDialog();
            if (result == DialogResult.OK)
            {
                Stopwatch timer = new Stopwatch();

                string selectedPath = folderDialogIndexed.SelectedPath;

                try
                {
                    timer.Start();
                    index.Add(selectedPath);
                    timer.Stop();

                    folders.Add(selectedPath);
                    UpdateFolderStatus();
                    UpdateLog($"Add folder: \"{selectedPath}\"");
                    UpdateFilesStatus();
                    UpdateLog($"Index build: files - {index.FilesCount}, index records - {index.IndexCount}, search pattern - {index.Pattern}");
                    UpdateLog($"Time - {timer.ElapsedMilliseconds / 1000}s");
                }
                catch (Exception ex)
                {
                    UpdateLog($"{ex.Message}", MsgStatus.Error);
                }
            }
        }

        private void buttonOutputFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialogOutput.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputFolder = folderDialogOutput.SelectedPath;
            }

            UpdateOutputFolderStatus();
            UpdateLog($"Selecting output folder: \"{outputFolder}\"");
        }

        private void buttonExcelFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                xlsxFile = openFileDialog.FileName;

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

        private async void buttonGo_Click(object sender, EventArgs e)
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

            if (listBoxSheetSelector.SelectedIndex == -1)
            {
                UpdateLog("Select sheet", MsgStatus.Error);
                return;
            }

            UpdateLog($"Work with sheet: \"{editor.Sheets[listBoxSheetSelector.SelectedIndex]}\"");

            try
            {
                Stopwatch timer = new Stopwatch();

                timer.Start();
                Tuple<int, string> result = editor.Change(index, listBoxSheetSelector.SelectedIndex, outputFolder, moveLinks);
                timer.Stop();

                UpdateLog($"Found images for {result.Item1} item(s)");
                UpdateLog($"File saved as \"{result.Item2}\"");
                UpdateLog($"Time - {timer.ElapsedMilliseconds / 1000}s");

                int filesCopied = 0;

                if (moveLinks)
                {
                    progressBar.Maximum = editor.FilesToCollect;
                    progressBar.Minimum = 0;

                    timer.Start();
                    var progress = new Progress<Tuple<string, string, int, int>>(ProgressReport);
                    filesCopied = await editor.CollectFiles(progress);
                    timer.Stop();
                }

                UpdateLog($"Copied {filesCopied} files to \"{outputFolder}\"");
                UpdateLog($"Time - {timer.ElapsedMilliseconds / 1000}s");

                editor = null;
                xlsxFile = "Excel file no selected";
                listBoxSheetSelector.Items.Clear();

                labelProgress.Text = "";
                buttonAddFolders.Enabled = false;
                progressBar.Value = 0;

                UpdateXlsStatus();
                UpdateProgress();
            }
            catch (Exception ex)
            {
                UpdateLog($"{ex.Message}", MsgStatus.Error);
            }
        }

        private void moveLinks_CheckStateChanged(object sender, EventArgs e)
        {
            moveLinks = !moveLinks;
            buttonOutputFolder.Enabled = moveLinks;
            labelOutputFolder.Enabled = moveLinks;
        }

        private void listBoxSheetSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLog($"Select sheet: \"{editor.Sheets[listBoxSheetSelector.SelectedIndex]}\"");
        }

        private void UpdateXlsStatus()
        {
            labelExcelFile.Text = xlsxFile;

            if (editor != null)
            {
                listBoxSheetSelector.Visible = true;

                foreach (var sheet in editor.Sheets)
                {
                    listBoxSheetSelector.Items.Add(sheet);
                }
            }
            else listBoxSheetSelector.Visible = false;
        }

        private void UpdateOutputFolderStatus()
        {
            labelOutputFolder.Text = outputFolder;
        }

        private void UpdateFolderStatus()
        {
            textBoxFolders.Text = "";
            for (int index = 0; index < folders.Count; index++) textBoxFolders.Text += $"[{index}] {folders[index]}{Environment.NewLine}";

            labelFoldersCount.Text = folders.Count.ToString();
        }

        private void UpdateFilesStatus()
        {
            labelIndexCount.Text = index.IndexCount.ToString();
            labelFilesCount.Text = index.FilesCount.ToString();
        }

        private void UpdateProgress()
        {
            labelProgress.Text = "";
            buttonAddFolders.Enabled = false;
            progressBar.Value = 0;
            InitLayout();
        }

        private void UpdateLog(string msg, MsgStatus status = MsgStatus.Info)
        {
            switch (status)
            {
                case MsgStatus.Error:
                    textBoxLog.Text += "[Error] ";
                    textBoxLog.Text += msg.ToUpper();
                    break;
                case MsgStatus.Info:
                    textBoxLog.Text += "[Info] ";
                    textBoxLog.Text += msg;
                    break;
            }

            textBoxLog.Text += Environment.NewLine;
        }

        private void ProgressReport(Tuple<string, string, int, int> msg)
        {
            string reportString = $"Copy file {msg.Item4} from {msg.Item3} [{msg.Item1}]";

            if (labelProgress.InvokeRequired)
            {
                labelProgress.BeginInvoke((MethodInvoker)delegate () { labelProgress.Text = reportString; });
            }
            else
            {
                labelProgress.Text = reportString;
            }

            if (progressBar.InvokeRequired)
            {
                progressBar.BeginInvoke((MethodInvoker)delegate () { progressBar.Value = msg.Item4; });
            }
            else
            {
                progressBar.Value = msg.Item4;
            }
        }

        private enum MsgStatus
        {
            Info,
            Error,
        }
    }
}