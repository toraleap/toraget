namespace toraget
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.tbxBlogUrl = new System.Windows.Forms.TextBox();
            this.btnParseBlog = new System.Windows.Forms.Button();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.imgFileType = new System.Windows.Forms.ImageList(this.components);
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.tbxCaptcha = new System.Windows.Forms.TextBox();
            this.btnParseLink = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnCheckInverse = new System.Windows.Forms.Button();
            this.btnCheckSelected = new System.Windows.Forms.Button();
            this.bgwRequest = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFold = new System.Windows.Forms.Button();
            this.webLinks = new System.Windows.Forms.WebBrowser();
            this.btnSwitch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxBlogUrl
            // 
            this.tbxBlogUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxBlogUrl.Location = new System.Drawing.Point(12, 188);
            this.tbxBlogUrl.Name = "tbxBlogUrl";
            this.tbxBlogUrl.Size = new System.Drawing.Size(367, 21);
            this.tbxBlogUrl.TabIndex = 0;
            this.tbxBlogUrl.Text = "输入博客文章地址，形如“http://tora.to/blog/000000.htm”";
            this.tbxBlogUrl.GotFocus += new System.EventHandler(this.tbxBlogUrl_GotFocus);
            // 
            // btnParseBlog
            // 
            this.btnParseBlog.Location = new System.Drawing.Point(385, 188);
            this.btnParseBlog.Name = "btnParseBlog";
            this.btnParseBlog.Size = new System.Drawing.Size(93, 21);
            this.btnParseBlog.TabIndex = 1;
            this.btnParseBlog.Text = "解析博客文章";
            this.btnParseBlog.UseVisualStyleBackColor = true;
            this.btnParseBlog.Click += new System.EventHandler(this.btnParseBlog_Click);
            // 
            // lvwFiles
            // 
            this.lvwFiles.CheckBoxes = true;
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwFiles.LargeImageList = this.imgFileType;
            this.lvwFiles.Location = new System.Drawing.Point(0, 218);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(550, 174);
            this.lvwFiles.SmallImageList = this.imgFileType;
            this.lvwFiles.TabIndex = 3;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwFiles_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 328;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件ID";
            this.columnHeader2.Width = 56;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "文件大小";
            this.columnHeader3.Width = 72;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "下载链接";
            this.columnHeader4.Width = 72;
            // 
            // imgFileType
            // 
            this.imgFileType.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imgFileType.ImageSize = new System.Drawing.Size(16, 16);
            this.imgFileType.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picCaptcha
            // 
            this.picCaptcha.Location = new System.Drawing.Point(350, 393);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(60, 20);
            this.picCaptcha.TabIndex = 3;
            this.picCaptcha.TabStop = false;
            // 
            // tbxCaptcha
            // 
            this.tbxCaptcha.Location = new System.Drawing.Point(416, 392);
            this.tbxCaptcha.Name = "tbxCaptcha";
            this.tbxCaptcha.Size = new System.Drawing.Size(38, 21);
            this.tbxCaptcha.TabIndex = 4;
            this.tbxCaptcha.GotFocus += new System.EventHandler(this.tbxCaptcha_GotFocus);
            // 
            // btnParseLink
            // 
            this.btnParseLink.Enabled = false;
            this.btnParseLink.Location = new System.Drawing.Point(457, 392);
            this.btnParseLink.Name = "btnParseLink";
            this.btnParseLink.Size = new System.Drawing.Size(93, 21);
            this.btnParseLink.TabIndex = 5;
            this.btnParseLink.Text = "解析下载链接";
            this.btnParseLink.UseVisualStyleBackColor = true;
            this.btnParseLink.Click += new System.EventHandler(this.btnParseLink_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(0, 393);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 20);
            this.btnCheckAll.TabIndex = 7;
            this.btnCheckAll.Text = "全部勾选";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnCheckInverse
            // 
            this.btnCheckInverse.Location = new System.Drawing.Point(81, 394);
            this.btnCheckInverse.Name = "btnCheckInverse";
            this.btnCheckInverse.Size = new System.Drawing.Size(75, 20);
            this.btnCheckInverse.TabIndex = 8;
            this.btnCheckInverse.Text = "反向勾选";
            this.btnCheckInverse.UseVisualStyleBackColor = true;
            this.btnCheckInverse.Click += new System.EventHandler(this.btnCheckInverse_Click);
            // 
            // btnCheckSelected
            // 
            this.btnCheckSelected.Location = new System.Drawing.Point(162, 394);
            this.btnCheckSelected.Name = "btnCheckSelected";
            this.btnCheckSelected.Size = new System.Drawing.Size(75, 20);
            this.btnCheckSelected.TabIndex = 9;
            this.btnCheckSelected.Text = "勾上选中项";
            this.btnCheckSelected.UseVisualStyleBackColor = true;
            this.btnCheckSelected.Click += new System.EventHandler(this.btnCheckSelected_Click);
            // 
            // bgwRequest
            // 
            this.bgwRequest.WorkerReportsProgress = true;
            this.bgwRequest.WorkerSupportsCancellation = true;
            this.bgwRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRequest_DoWork);
            this.bgwRequest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRequest_RunWorkerCompleted);
            this.bgwRequest.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwRequest_ProgressChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 219);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnFold
            // 
            this.btnFold.Location = new System.Drawing.Point(521, 188);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(23, 21);
            this.btnFold.TabIndex = 2;
            this.btnFold.Text = "↑";
            this.btnFold.UseVisualStyleBackColor = true;
            this.btnFold.Click += new System.EventHandler(this.btnFold_Click);
            // 
            // webLinks
            // 
            this.webLinks.Location = new System.Drawing.Point(0, 218);
            this.webLinks.MinimumSize = new System.Drawing.Size(20, 20);
            this.webLinks.Name = "webLinks";
            this.webLinks.Size = new System.Drawing.Size(550, 197);
            this.webLinks.TabIndex = 13;
            this.webLinks.Visible = false;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(484, 188);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(31, 21);
            this.btnSwitch.TabIndex = 14;
            this.btnSwitch.Text = "< >";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 414);
            this.Controls.Add(this.webLinks);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.btnFold);
            this.Controls.Add(this.btnCheckSelected);
            this.Controls.Add(this.btnCheckInverse);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.btnParseLink);
            this.Controls.Add(this.tbxCaptcha);
            this.Controls.Add(this.picCaptcha);
            this.Controls.Add(this.lvwFiles);
            this.Controls.Add(this.btnParseBlog);
            this.Controls.Add(this.tbxBlogUrl);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "toraget v0.1 alpha";
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxBlogUrl;
        private System.Windows.Forms.Button btnParseBlog;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.TextBox tbxCaptcha;
        private System.Windows.Forms.Button btnParseLink;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnCheckInverse;
        private System.Windows.Forms.Button btnCheckSelected;
        private System.ComponentModel.BackgroundWorker bgwRequest;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFold;
        private System.Windows.Forms.WebBrowser webLinks;
        private System.Windows.Forms.ImageList imgFileType;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnSwitch;
    }
}

