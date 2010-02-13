using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace toraget
{
    public partial class fMain : Form
    {
        private enum WorkTypes
        {
            None,
            ParseBlog,
            ParseLink
        }

        private class FileItem
        {
            public string Name = string.Empty;
            public int Id = 0;
            public int Size = 0;
            public string Link = string.Empty;
            public string Group = string.Empty;
            public bool Checked = false;
        }

        static Regex regexBlogUrl = new Regex(@"^(?:http://)?tora\.to/blog/(\d+?)\.htm$");
        static Regex regexFileItem = new Regex(@"\[file id=""(?<fileid>\d+)""(?: size=""(?<size>\d+)"")?\](?<filename>[^\x00]+?)\[/file\]");
        static Regex regexIpAddr = new Regex(@"UbbHtmlUtil\.secret = '(?<ipaddr>[0-9A-F]+?)'");
        static Regex regexDownloadLink = new Regex(@"var address = '(?<link>.+?)';");
        List<FileItem> FileItems = new List<FileItem>();
        Dictionary<FileItem, ListViewItem> ListItems = new Dictionary<FileItem,ListViewItem>();
        CookieContainer cc = new CookieContainer();
        WorkTypes WorkType = WorkTypes.None;
        string IpAddr = String.Empty;

        public fMain()
        {
            InitializeComponent();
        }

        private void btnParseBlog_Click(object sender, EventArgs e)
        {
            if (!regexBlogUrl.IsMatch(tbxBlogUrl.Text))
            {
                MessageBox.Show("您可能填入了错误或不支持的网址，请检查。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnParseBlog.Enabled = false;
            btnParseLink.Enabled = false;
            webLinks.Visible = false;
            FileItems.Clear();
            lvwFiles.Items.Clear();

            WorkType = WorkTypes.ParseBlog;
            bgwRequest.RunWorkerAsync();
        }

        private void btnParseLink_Click(object sender, EventArgs e)
        {
            if (lvwFiles.CheckedItems.Count == 0)
            {
                MessageBox.Show("请在列表中至少勾选一项！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem lvi in lvwFiles.Items)
                (lvi.Tag as FileItem).Checked = lvi.Checked;

            btnParseBlog.Enabled = false;
            btnParseLink.Enabled = false;
            webLinks.Visible = false;

            WorkType = WorkTypes.ParseLink;
            bgwRequest.RunWorkerAsync();
        }

        private string GetUrlContent(string url)
        {
            HttpWebRequest request = null;
            StreamReader reader = null;
            HttpWebResponse response = null;
            string responseText = String.Empty;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = cc;
                request.Timeout = 10000;
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                responseText = reader.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                if (reader != null) reader.Close();
                if (response != null) response.Close();
            }
            return responseText;
        }

        private Stream GetUrlStream(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string responseText = String.Empty;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = cc;
                request.Timeout = 10000;
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
            }
            finally
            {
            }
            return response.GetResponseStream();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwFiles.Items)
                lvi.Checked = true;
        }

        private void btnCheckInverse_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwFiles.Items)
                lvi.Checked = !lvi.Checked;
        }

        private void btnCheckSelected_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwFiles.SelectedItems)
                lvi.Checked = true;
        }

        private void tbxCaptcha_GotFocus(object sender, EventArgs e)
        {
            tbxCaptcha.SelectAll();
        }

        private void tbxBlogUrl_GotFocus(object sender, EventArgs e)
        {
            tbxBlogUrl.SelectAll();
        }

        private void btnFold_Click(object sender, EventArgs e)
        {
            if (btnFold.Text == "↑")
            {
                btnFold.Text = "↓";
                tbxBlogUrl.Top -= 176;
                btnParseBlog.Top -= 176;
                btnSwitch.Top -= 176;
                btnFold.Top -= 176;
                lvwFiles.Top -= 176;
                lvwFiles.Height += 176;
                webLinks.Top -= 176;
                webLinks.Height += 176;
            }
            else
            {
                btnFold.Text = "↑";
                tbxBlogUrl.Top += 176;
                btnParseBlog.Top += 176;
                btnSwitch.Top += 176;
                btnFold.Top += 176;
                lvwFiles.Top += 176;
                lvwFiles.Height -= 176;
                webLinks.Top += 176;
                webLinks.Height -= 176;
            }
        }

        private void bgwRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (WorkType)
            {
                case WorkTypes.ParseBlog:
                    ParseBlog();
                    break;
                case WorkTypes.ParseLink:
                    ParseLink();
                    break;
            }
        }

        private void ParseBlog()
        {
            string responseText = GetUrlContent(tbxBlogUrl.Text);
            MatchCollection mc = regexFileItem.Matches(responseText);
            IpAddr = regexIpAddr.Match(responseText).Groups["ipaddr"].Value;
            foreach (Match m in mc)
            {
                FileItem fi = new FileItem();
                fi.Name = m.Groups["filename"].Value;
                int.TryParse(m.Groups["fileid"].Value, out fi.Id);
                int.TryParse(m.Groups["size"].Value, out fi.Size);
                FileItems.Add(fi);
            }
        }

        const string urlCaptcha = @"http://hidamari.tora.to:8381/downloadserver/pages/testCheck.jsp?_s={0}";
        const string urlDownFile = @"http://hidamari.tora.to:8381/downloadserver/discutter/pagination.htm?r={0}&dispatch=normaldownlaod&fileId={1}&ip={2}&tid=1&captcha={3}&_={4}";
        private void ParseLink()
        {
            StringBuilder sb = new StringBuilder(@"<html><body style='font-size:12px;font-family:Tahoma'><h2>下载指南</h2>迅雷已被官方封锁，建议使用FlashGet1.x版本进行下载。<br>全部下载:点击右键->使用某下载工具下载全部链接<br>部分下载:选中要下载的链接拖入下载工具的悬浮窗<br><br>");
            foreach (FileItem fi in FileItems)
            {
                if (!fi.Checked) continue;
                string url = String.Format(urlDownFile,
                    new Random().NextDouble(),
                    fi.Id,
                    IpAddr,
                    tbxCaptcha.Text,
                    Math.Floor((DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds));
                fi.Link = "获取中";
                bgwRequest.ReportProgress(0, fi);

                string responseText = GetUrlContent(url);
                if (responseText.Contains(@"<div class=\""popup_title\"">验证码</div>"))
                {
                    picCaptcha.Image = Image.FromStream(GetUrlStream(String.Format(urlCaptcha, Math.Floor((DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds))));
                    fi.Link = "需要验证码";
                    bgwRequest.ReportProgress(0, fi);
                    return;
                }
                else
                {
                    fi.Link = regexDownloadLink.Match(responseText).Groups["link"].Value;// "http://down.tora.to/user/userAction.do?method=download&urlpath=" + HttpUtility.UrlEncode(regexDownloadLink.Match(responseText).Groups["link"].Value);
                    bgwRequest.ReportProgress(0, fi);
                    sb.Append(String.Format(@"<a href=""{0}"">{1}</a> {2} K<br>", fi.Link, fi.Name, fi.Size));
                }
            }
            sb.Append("<h2>注意事项</h2>1.由于启用了基于流量控制的防盗链机制，此生成的下载链接只提供一位用户下载一次。如果有多人同时下载此链接，将会造成所有下载此链接的用户都无法完整下载此文件。<br><br>2.带有盗链机制的P2SP软件(迅雷, Flashget2)也会造成文件无法完整下载。建议正在使用此类软件的用户使用 FlashGet v1.7.3 （http://hidamari.tora.to:8381/downloadserver/tools/JetCar-v1.73.rar）或其他正常的下载软件进行下载。<br><br>3.如果因为以上原因导致用户无法下载完成，请点击生成一个新的唯一下载链接替代下载软件中原有的链接即可续传。</body></html>");
            bgwRequest.ReportProgress(100, sb.ToString());
        }

        private void bgwRequest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (WorkType)
            {
                case WorkTypes.ParseLink:
                    if (e.UserState is FileItem)
                    {
                        FileItem fi = e.UserState as FileItem;
                        ListItems[fi].SubItems[3].Text = fi.Link;
                    }
                    else if (e.UserState is string)
                    {
                        webLinks.DocumentText = e.UserState as string;
                        webLinks.Visible = true;
                    }
                    break;
            }
        }

        private void bgwRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (WorkType)
            {
                case WorkTypes.ParseBlog:
                    foreach (FileItem fi in FileItems)
                    {
                        string fileExt = Path.GetExtension(fi.Name);
                        if (!imgFileType.Images.ContainsKey(fileExt))
                            imgFileType.Images.Add(fileExt, FileIcon.GetIconForFileExtension(fileExt, false, false));

                        ListViewItem lvi = new ListViewItem(new string[]{fi.Name,
                            fi.Id.ToString(), 
                            fi.Size == 0 ? "未知大小" : (fi.Size + " K"),
                            "尚未解析"}, fileExt);
                        lvi.Tag = fi;
                        lvwFiles.Items.Add(lvi);
                        ListItems.Add(fi, lvi);
                    }
                    btnParseBlog.Enabled = true;
                    if (lvwFiles.Items.Count > 0) btnParseLink.Enabled = true;
                    break;
                case WorkTypes.ParseLink:
                    btnParseBlog.Enabled = true;
                    btnParseLink.Enabled = true;
                    break;
            }
        }

        private void lvwFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo lvhti = lvwFiles.HitTest(e.Location);
                try
                {
                    if (lvhti.Item != null) Clipboard.SetText(lvhti.Item.SubItems[3].Text);
                }
                catch (Exception expection){ }
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            webLinks.Visible = !webLinks.Visible;
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            webLinks.DocumentText = "<html><body style='font-size:12px;font-family:Tahoma'><h2>下载指南</h2>迅雷已被官方封锁，建议使用FlashGet1.x版本进行下载。<br>全部下载:点击右键->使用某下载工具下载全部链接<br>部分下载:选中要下载的链接拖入下载工具的悬浮窗<br><br><h2>注意事项</h2>1.由于启用了基于流量控制的防盗链机制，此生成的下载链接只提供一位用户下载一次。如果有多人同时下载此链接，将会造成所有下载此链接的用户都无法完整下载此文件。<br><br>2.带有盗链机制的P2SP软件(迅雷, Flashget2)也会造成文件无法完整下载。建议正在使用此类软件的用户使用 FlashGet v1.7.3 （http://hidamari.tora.to:8381/downloadserver/tools/JetCar-v1.73.rar）或其他正常的下载软件进行下载。<br><br>3.如果因为以上原因导致用户无法下载完成，请点击生成一个新的唯一下载链接替代下载软件中原有的链接即可续传。</body></html>";
        }
    }
}
