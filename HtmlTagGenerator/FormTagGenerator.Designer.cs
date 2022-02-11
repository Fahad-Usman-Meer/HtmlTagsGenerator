namespace HtmlTagGenerator
{
    partial class frmTagGenerator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTagGenerator));
            this.btnDetectHeadings = new System.Windows.Forms.Button();
            this.txtOriginalContent = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateTags = new System.Windows.Forms.Button();
            this.btnSearchImagesAndVideos = new System.Windows.Forms.Button();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetectedHeadings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideoLinks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUpdatedContent = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnCopyUpdatedContent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArticleName = new System.Windows.Forms.TextBox();
            this.BtnCreateFolder = new System.Windows.Forms.Button();
            this.txtArticleId = new System.Windows.Forms.NumericUpDown();
            this.btnCopyTableContent = new System.Windows.Forms.Button();
            this.txtExtraSearchKeywords = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticleId)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetectHeadings
            // 
            this.btnDetectHeadings.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetectHeadings.Location = new System.Drawing.Point(9, 236);
            this.btnDetectHeadings.Name = "btnDetectHeadings";
            this.btnDetectHeadings.Size = new System.Drawing.Size(115, 45);
            this.btnDetectHeadings.TabIndex = 0;
            this.btnDetectHeadings.Text = "Detect Headings";
            this.btnDetectHeadings.UseVisualStyleBackColor = true;
            this.btnDetectHeadings.Click += new System.EventHandler(this.btnDetectHeadings_Click);
            // 
            // txtOriginalContent
            // 
            this.txtOriginalContent.Location = new System.Drawing.Point(6, 60);
            this.txtOriginalContent.Name = "txtOriginalContent";
            this.txtOriginalContent.Size = new System.Drawing.Size(490, 170);
            this.txtOriginalContent.TabIndex = 1;
            this.txtOriginalContent.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Place Original Content:";
            // 
            // btnGenerateTags
            // 
            this.btnGenerateTags.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateTags.Location = new System.Drawing.Point(770, 287);
            this.btnGenerateTags.Name = "btnGenerateTags";
            this.btnGenerateTags.Size = new System.Drawing.Size(115, 34);
            this.btnGenerateTags.TabIndex = 0;
            this.btnGenerateTags.Text = "Generate Tags";
            this.btnGenerateTags.UseVisualStyleBackColor = true;
            this.btnGenerateTags.Click += new System.EventHandler(this.btnGenerateTags_Click);
            // 
            // btnSearchImagesAndVideos
            // 
            this.btnSearchImagesAndVideos.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchImagesAndVideos.Location = new System.Drawing.Point(338, 236);
            this.btnSearchImagesAndVideos.Name = "btnSearchImagesAndVideos";
            this.btnSearchImagesAndVideos.Size = new System.Drawing.Size(158, 45);
            this.btnSearchImagesAndVideos.TabIndex = 0;
            this.btnSearchImagesAndVideos.Text = "Search Images && Videos";
            this.btnSearchImagesAndVideos.UseVisualStyleBackColor = true;
            this.btnSearchImagesAndVideos.Click += new System.EventHandler(this.btnSearchImagesAndVideos_Click);
            // 
            // dgTable
            // 
            this.dgTable.AllowUserToAddRows = false;
            this.dgTable.AllowUserToDeleteRows = false;
            this.dgTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial,
            this.colDetectedHeadings,
            this.colImageName,
            this.colVideoLinks});
            this.dgTable.Location = new System.Drawing.Point(6, 287);
            this.dgTable.Name = "dgTable";
            this.dgTable.Size = new System.Drawing.Size(758, 235);
            this.dgTable.TabIndex = 3;
            this.dgTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTable_CellMouseClick);
            // 
            // serial
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.serial.DefaultCellStyle = dataGridViewCellStyle1;
            this.serial.HeaderText = "#";
            this.serial.Name = "serial";
            this.serial.ReadOnly = true;
            this.serial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.serial.Width = 45;
            // 
            // colDetectedHeadings
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colDetectedHeadings.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDetectedHeadings.HeaderText = "Detected Headings";
            this.colDetectedHeadings.Name = "colDetectedHeadings";
            this.colDetectedHeadings.ReadOnly = true;
            this.colDetectedHeadings.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDetectedHeadings.Width = 225;
            // 
            // colImageName
            // 
            this.colImageName.HeaderText = "Image Names";
            this.colImageName.Name = "colImageName";
            this.colImageName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImageName.Width = 225;
            // 
            // colVideoLinks
            // 
            this.colVideoLinks.HeaderText = "Youtube Video Links";
            this.colVideoLinks.Name = "colVideoLinks";
            this.colVideoLinks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVideoLinks.Width = 200;
            // 
            // txtUpdatedContent
            // 
            this.txtUpdatedContent.Location = new System.Drawing.Point(502, 60);
            this.txtUpdatedContent.Name = "txtUpdatedContent";
            this.txtUpdatedContent.Size = new System.Drawing.Size(386, 221);
            this.txtUpdatedContent.TabIndex = 1;
            this.txtUpdatedContent.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Updated Content:";
            // 
            // btnClearForm
            // 
            this.btnClearForm.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearForm.Location = new System.Drawing.Point(770, 494);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(115, 59);
            this.btnClearForm.TabIndex = 0;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnCopyUpdatedContent
            // 
            this.btnCopyUpdatedContent.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyUpdatedContent.Location = new System.Drawing.Point(780, 28);
            this.btnCopyUpdatedContent.Name = "btnCopyUpdatedContent";
            this.btnCopyUpdatedContent.Size = new System.Drawing.Size(95, 26);
            this.btnCopyUpdatedContent.TabIndex = 0;
            this.btnCopyUpdatedContent.Text = "Copy Content";
            this.btnCopyUpdatedContent.UseVisualStyleBackColor = true;
            this.btnCopyUpdatedContent.Click += new System.EventHandler(this.btnCopyUpdatedContent_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Article ID:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(773, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 69);
            this.label4.TabIndex = 2;
            this.label4.Text = "* Click on \"Image Names\" Column will save text of selected cell in Cliipboard.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(770, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 84);
            this.label5.TabIndex = 2;
            this.label5.Text = "* Click on \"Youtube Video Links\" Column to set Clipboard\'s data to selected cell." +
    "\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Article Name:";
            // 
            // txtArticleName
            // 
            this.txtArticleName.Location = new System.Drawing.Point(231, 6);
            this.txtArticleName.MaxLength = 500;
            this.txtArticleName.Name = "txtArticleName";
            this.txtArticleName.Size = new System.Drawing.Size(265, 20);
            this.txtArticleName.TabIndex = 4;
            // 
            // BtnCreateFolder
            // 
            this.BtnCreateFolder.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateFolder.Location = new System.Drawing.Point(502, 4);
            this.BtnCreateFolder.Name = "BtnCreateFolder";
            this.BtnCreateFolder.Size = new System.Drawing.Size(86, 26);
            this.BtnCreateFolder.TabIndex = 0;
            this.BtnCreateFolder.Text = "Create Folder";
            this.BtnCreateFolder.UseVisualStyleBackColor = true;
            this.BtnCreateFolder.Click += new System.EventHandler(this.BtnCreateFolder_Click);
            // 
            // txtArticleId
            // 
            this.txtArticleId.Location = new System.Drawing.Point(62, 6);
            this.txtArticleId.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtArticleId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtArticleId.Name = "txtArticleId";
            this.txtArticleId.Size = new System.Drawing.Size(87, 20);
            this.txtArticleId.TabIndex = 5;
            this.txtArticleId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCopyTableContent
            // 
            this.btnCopyTableContent.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyTableContent.Location = new System.Drawing.Point(9, 527);
            this.btnCopyTableContent.Name = "btnCopyTableContent";
            this.btnCopyTableContent.Size = new System.Drawing.Size(140, 26);
            this.btnCopyTableContent.TabIndex = 0;
            this.btnCopyTableContent.Text = "Copy Table Content";
            this.btnCopyTableContent.UseVisualStyleBackColor = true;
            this.btnCopyTableContent.Click += new System.EventHandler(this.btnCopyTableContent_Click);
            // 
            // txtExtraSearchKeywords
            // 
            this.txtExtraSearchKeywords.Location = new System.Drawing.Point(130, 261);
            this.txtExtraSearchKeywords.MaxLength = 500;
            this.txtExtraSearchKeywords.Name = "txtExtraSearchKeywords";
            this.txtExtraSearchKeywords.Size = new System.Drawing.Size(202, 20);
            this.txtExtraSearchKeywords.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Extra Keywords in Search:";
            // 
            // frmTagGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 559);
            this.Controls.Add(this.txtArticleId);
            this.Controls.Add(this.txtExtraSearchKeywords);
            this.Controls.Add(this.txtArticleName);
            this.Controls.Add(this.dgTable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUpdatedContent);
            this.Controls.Add(this.txtOriginalContent);
            this.Controls.Add(this.BtnCreateFolder);
            this.Controls.Add(this.btnCopyTableContent);
            this.Controls.Add(this.btnCopyUpdatedContent);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnGenerateTags);
            this.Controls.Add(this.btnSearchImagesAndVideos);
            this.Controls.Add(this.btnDetectHeadings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTagGenerator";
            this.Text = "HTML Tags Generator";
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticleId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetectHeadings;
        private System.Windows.Forms.RichTextBox txtOriginalContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateTags;
        private System.Windows.Forms.Button btnSearchImagesAndVideos;
        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.RichTextBox txtUpdatedContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnCopyUpdatedContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetectedHeadings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideoLinks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtArticleName;
        private System.Windows.Forms.Button BtnCreateFolder;
        private System.Windows.Forms.NumericUpDown txtArticleId;
        private System.Windows.Forms.Button btnCopyTableContent;
        private System.Windows.Forms.TextBox txtExtraSearchKeywords;
        private System.Windows.Forms.Label label7;
    }
}

