namespace ImageSearch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelExcelFile = new System.Windows.Forms.Label();
            this.buttonOutputFolder = new System.Windows.Forms.Button();
            this.buttonAddFolders = new System.Windows.Forms.Button();
            this.textBoxFolders = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelFilesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelIndexCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFoldersCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOutputFolder = new System.Windows.Forms.Label();
            this.buttonExcelFile = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.listBoxSheetSelector = new System.Windows.Forms.ListBox();
            this.checkBoxMoveLinks = new System.Windows.Forms.CheckBox();
            this.folderDialogIndexed = new System.Windows.Forms.FolderBrowserDialog();
            this.folderDialogOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxLog, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelProgress, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelExcelFile, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonOutputFolder, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddFolders, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFolders, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelOutputFolder, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonExcelFile, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonGo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSheetSelector, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMoveLinks, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 511);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelExcelFile
            // 
            this.labelExcelFile.AutoSize = true;
            this.labelExcelFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExcelFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExcelFile.Location = new System.Drawing.Point(124, 128);
            this.labelExcelFile.Margin = new System.Windows.Forms.Padding(5);
            this.labelExcelFile.Name = "labelExcelFile";
            this.labelExcelFile.Size = new System.Drawing.Size(592, 30);
            this.labelExcelFile.TabIndex = 7;
            this.labelExcelFile.Text = "Excel file no selected";
            this.labelExcelFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOutputFolder
            // 
            this.buttonOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutputFolder.Enabled = false;
            this.buttonOutputFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOutputFolder.Location = new System.Drawing.Point(8, 88);
            this.buttonOutputFolder.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOutputFolder.Name = "buttonOutputFolder";
            this.buttonOutputFolder.Size = new System.Drawing.Size(106, 30);
            this.buttonOutputFolder.TabIndex = 4;
            this.buttonOutputFolder.Text = "Output folder";
            this.buttonOutputFolder.UseVisualStyleBackColor = true;
            this.buttonOutputFolder.Click += new System.EventHandler(this.buttonOutputFolder_Click);
            // 
            // buttonAddFolders
            // 
            this.buttonAddFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFolders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddFolders.Location = new System.Drawing.Point(8, 8);
            this.buttonAddFolders.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAddFolders.Name = "buttonAddFolders";
            this.buttonAddFolders.Size = new System.Drawing.Size(106, 30);
            this.buttonAddFolders.TabIndex = 0;
            this.buttonAddFolders.Text = "Add folder";
            this.buttonAddFolders.UseVisualStyleBackColor = true;
            this.buttonAddFolders.Click += new System.EventHandler(this.buttonAddFolders_Click);
            // 
            // textBoxFolders
            // 
            this.textBoxFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFolders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFolders.Location = new System.Drawing.Point(124, 8);
            this.textBoxFolders.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFolders.Multiline = true;
            this.textBoxFolders.Name = "textBoxFolders";
            this.textBoxFolders.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.textBoxFolders, 2);
            this.textBoxFolders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFolders.Size = new System.Drawing.Size(592, 70);
            this.textBoxFolders.TabIndex = 2;
            this.textBoxFolders.Text = "No folder";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelFilesCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelIndexCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelFoldersCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(724, 6);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(154, 74);
            this.panel1.TabIndex = 3;
            // 
            // labelFilesCount
            // 
            this.labelFilesCount.AutoSize = true;
            this.labelFilesCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFilesCount.Location = new System.Drawing.Point(84, 51);
            this.labelFilesCount.Name = "labelFilesCount";
            this.labelFilesCount.Size = new System.Drawing.Size(13, 13);
            this.labelFilesCount.TabIndex = 5;
            this.labelFilesCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Files:";
            // 
            // labelIndexCount
            // 
            this.labelIndexCount.AutoSize = true;
            this.labelIndexCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIndexCount.Location = new System.Drawing.Point(84, 31);
            this.labelIndexCount.Name = "labelIndexCount";
            this.labelIndexCount.Size = new System.Drawing.Size(13, 13);
            this.labelIndexCount.TabIndex = 3;
            this.labelIndexCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Index records:";
            // 
            // labelFoldersCount
            // 
            this.labelFoldersCount.AutoSize = true;
            this.labelFoldersCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFoldersCount.Location = new System.Drawing.Point(84, 11);
            this.labelFoldersCount.Name = "labelFoldersCount";
            this.labelFoldersCount.Size = new System.Drawing.Size(13, 13);
            this.labelFoldersCount.TabIndex = 1;
            this.labelFoldersCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder in index:";
            // 
            // labelOutputFolder
            // 
            this.labelOutputFolder.AutoSize = true;
            this.labelOutputFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOutputFolder.Enabled = false;
            this.labelOutputFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOutputFolder.Location = new System.Drawing.Point(124, 88);
            this.labelOutputFolder.Margin = new System.Windows.Forms.Padding(5);
            this.labelOutputFolder.Name = "labelOutputFolder";
            this.labelOutputFolder.Size = new System.Drawing.Size(592, 30);
            this.labelOutputFolder.TabIndex = 5;
            this.labelOutputFolder.Text = "Output folder no selected";
            this.labelOutputFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExcelFile
            // 
            this.buttonExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExcelFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExcelFile.Location = new System.Drawing.Point(8, 128);
            this.buttonExcelFile.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExcelFile.Name = "buttonExcelFile";
            this.buttonExcelFile.Size = new System.Drawing.Size(106, 30);
            this.buttonExcelFile.TabIndex = 6;
            this.buttonExcelFile.Text = "Excel file";
            this.buttonExcelFile.UseVisualStyleBackColor = true;
            this.buttonExcelFile.Click += new System.EventHandler(this.buttonExcelFile_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonGo, 3);
            this.buttonGo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGo.ForeColor = System.Drawing.Color.Black;
            this.buttonGo.Location = new System.Drawing.Point(8, 168);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(5);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(868, 30);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "WORK!";
            this.buttonGo.UseVisualStyleBackColor = false;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // listBoxSheetSelector
            // 
            this.listBoxSheetSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSheetSelector.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxSheetSelector.FormattingEnabled = true;
            this.listBoxSheetSelector.Location = new System.Drawing.Point(731, 86);
            this.listBoxSheetSelector.Margin = new System.Windows.Forms.Padding(10, 3, 6, 3);
            this.listBoxSheetSelector.Name = "listBoxSheetSelector";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxSheetSelector, 2);
            this.listBoxSheetSelector.Size = new System.Drawing.Size(144, 74);
            this.listBoxSheetSelector.TabIndex = 10;
            this.listBoxSheetSelector.Visible = false;
            this.listBoxSheetSelector.SelectedIndexChanged += new System.EventHandler(this.listBoxSheetSelector_SelectedIndexChanged);
            // 
            // checkBoxMoveLinks
            // 
            this.checkBoxMoveLinks.AutoSize = true;
            this.checkBoxMoveLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxMoveLinks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxMoveLinks.Location = new System.Drawing.Point(13, 53);
            this.checkBoxMoveLinks.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxMoveLinks.Name = "checkBoxMoveLinks";
            this.checkBoxMoveLinks.Size = new System.Drawing.Size(96, 20);
            this.checkBoxMoveLinks.TabIndex = 11;
            this.checkBoxMoveLinks.Text = "copy images";
            this.checkBoxMoveLinks.UseVisualStyleBackColor = true;
            this.checkBoxMoveLinks.CheckStateChanged += new System.EventHandler(this.moveLinks_CheckStateChanged);
            // 
            // folderDialogIndexed
            // 
            this.folderDialogIndexed.SelectedPath = "w:\\dev\\workspace\\Developed\\ImageSearch\\TestData\\";
            this.folderDialogIndexed.ShowNewFolderButton = false;
            // 
            // folderDialogOutput
            // 
            this.folderDialogOutput.SelectedPath = "w:\\dev\\workspace\\Developed\\ImageSearch\\TestData\\3\\New";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.xlsx";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelProgress, 2);
            this.labelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProgress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProgress.Location = new System.Drawing.Point(8, 208);
            this.labelProgress.Margin = new System.Windows.Forms.Padding(5);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(708, 30);
            this.labelProgress.TabIndex = 12;
            this.labelProgress.Text = "...";
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(724, 206);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(152, 34);
            this.progressBar.TabIndex = 13;
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxLog, 3);
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLog.Location = new System.Drawing.Point(8, 248);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(868, 255);
            this.textBoxLog.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageSearch";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAddFolders;
        private System.Windows.Forms.TextBox textBoxFolders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelIndexCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFoldersCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOutputFolder;
        private System.Windows.Forms.Label labelOutputFolder;
        private System.Windows.Forms.Label labelExcelFile;
        private System.Windows.Forms.Button buttonExcelFile;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.FolderBrowserDialog folderDialogIndexed;
        private System.Windows.Forms.FolderBrowserDialog folderDialogOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listBoxSheetSelector;
        private System.Windows.Forms.CheckBox checkBoxMoveLinks;
        private System.Windows.Forms.Label labelFilesCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

