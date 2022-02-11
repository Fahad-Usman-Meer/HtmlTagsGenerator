using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlTagGenerator
{
    public partial class frmTagGenerator : Form
    {
        public frmTagGenerator()
        {
            InitializeComponent();
            this.InitializeInnerComponent();
			//*** to Add Dummy Data ***
            //for (int i = 1; i <= 25 ; i++)
            //{
            //    string[] row = { $"{i}", $"{i} heading", $"{i}-image-name", $"{i}_video_link" };
            //    dgTable.Rows.Add(row);
            //}
        }

        private void InitializeInnerComponent()
        {
            _headingsToIgnore = SettingsTemp.Default.HeadingsToIgnore.ToLower().Split(',').ToList();
        }

        private void btnDetectHeadings_Click(object sender, EventArgs e)
        {
            if (ValidateAndThrow())
            {
                ClearVariables();

                var tempLines = txtOriginalContent.Text.Split('\n');

                foreach (var tempLine in tempLines)
                {
                    string line = tempLine.Trim();

                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Contains("<h2>") && line.Contains("</h2>"))
                        {
                            if (_tocIndex == -1) // 1st h2 tag found
                            {
                                _tocIndex = _allLines.Count;
                            }
                            short isHeadingToIgnore = (short)_headingsToIgnore.FindIndex(x => line.ToLower().Contains(x));

                            //_headingsToIgnore.ForEach(h => {
                            //    if(line.ToLower().Contains(h))
                            //    {
                            //        isHeadingToIgnore = true;
                            //        return;
                            //    }
                            //});

                            if (isHeadingToIgnore < 0) // (!isHeadingToIgnore) //!line.ToLower().Contains("conclusion") && !line.ToLower().Contains("final thoughts") && !line.ToLower().Contains("final verdict") )  //remove last conclusion headings
                            {
                                line = GenerateHeadingTags(line);
                            }
                        }

                        _allLines.Add(line);
                    }
                }

                for (int i = 0; i < _detectedHeadings.Count; i++)
                {
                    string[] row = { (i+1).ToString() , _detectedHeadings[i], _imageNames[i], TXT_ENTER_VIDEO_LINK };
                    dgTable.Rows.Add(row);
                }
            }
        }
        
        private void btnCopyTableContent_Click(object sender, EventArgs e)
        {
            //asdasd
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dgTable.Rows.Count; i++)
            {
                string row = dgTable.Rows[i].Cells[0]?.Value?.ToString() 
                    + "\t"
                    + dgTable.Rows[i].Cells[1]?.Value?.ToString()
                    + "\t"
                    + dgTable.Rows[i].Cells[2]?.Value?.ToString()
                    + "\t"
                    + dgTable.Rows[i].Cells[3]?.Value?.ToString();

                sb.AppendLine(row);
            }
            if (sb.Length > 0)
            {
                Clipboard.SetText(sb.ToString());
                MessageBox.Show("All Table Data Copied to Clipboard");
            }
            else
            {
                MessageBox.Show("Table is empty! Nothing copied!");
            }
        }

        private void ClearVariables()
        {
            dgTable.Rows.Clear();
            _allLines.Clear();
            _tocList.Clear();
            _imageNames.Clear();
            _detectedHeadings.Clear();
            _youtubeVideosTags.Clear();

            //_newArticleFolderPath = "";

            _tocIndex = -1;
        }

        private string GenerateHeadingTags(string line)
        {
            var headingName = line.Replace("<h2>", "").Replace("</h2>", "").Replace("\"", "'");
            _detectedHeadings.Add(headingName);

            var headingId = Regex.Replace(headingName, @"['?,():\]\[;!]", "");
            headingId = Regex.Replace(headingId, @"[ ./]", "-").ToLower();
            headingId = headingId.Replace("  ", " ").Replace("--", "-").Replace("\"", "'");
            var h2Id = "<h2 id=\"" + headingId + "\">" + headingName + "</h2>";

            var imageName = txtArticleId.Text.Trim() + "-" + headingId;// "420-image-name";
            if(imageName.Length > 60)
            {
                imageName = imageName.Substring(0, 60);   // because large file name cause problem in saving after resize.
            }
            imageName = imageName + ".jpg";// "420-image-name.jpg";

            _imageNames.Add(imageName);

            var tableOfContentRow = "<li><a href=\"#" + headingId + "\" title=\"" + headingName + "\">" + headingName + "</a></li>";
            _tocList.Add(tableOfContentRow);
            var imageTag = "<p><img src=\"/img-temp/" + imageName + "\" style=\"width:100%;\" title=\"" + headingName + "\" alt=\"" + headingName + "\"></p>";

            return $"{h2Id}\n{imageTag}";
        }

        private bool ValidateAndThrow()
        {
            bool validatedFlag = false;

            if (string.IsNullOrEmpty(txtArticleId.Text.Trim()))
            {
                MessageBox.Show("Article ID is Missing!");
            }
            else if (string.IsNullOrEmpty(txtArticleName.Text.Trim()))
            {
                MessageBox.Show("Article Name is Missing!");
            }
            else if (string.IsNullOrEmpty(txtOriginalContent.Text.Trim()))
            {
                MessageBox.Show("Content is Missing!");
            }
            else
            {
                validatedFlag = true;
            }

            return validatedFlag;
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            //txtArticleId.Text = "";
            txtOriginalContent.Text = "";
            txtUpdatedContent.Text = "";
            txtArticleName.Text = "";
            txtExtraSearchKeywords.Text = "";
            dgTable.Rows.Clear();
            _newArticleFolderPath = "";

            this.BtnCreateFolder.Enabled = this.btnGenerateTags.Enabled = true; ;
        }

        private void btnSearchImagesAndVideos_Click(object sender, EventArgs e)
        {
            if (_detectedHeadings?.Count > 0)
            {
                string extraKeywordsInSearch = string.Empty;

                if (!string.IsNullOrWhiteSpace(txtExtraSearchKeywords.Text))
                {
                    extraKeywordsInSearch = Regex.Replace(txtExtraSearchKeywords.Text.Trim(), Constants.RegexReplaceForSearch, "+").ToLower();
                }

                foreach (var heading in _detectedHeadings)
                {
                    var headingName = Regex.Replace(heading, Constants.RegexReplaceForSearch, "+").ToLower();

                    if(!string.IsNullOrWhiteSpace(extraKeywordsInSearch))
                    {
                        headingName += $"+{extraKeywordsInSearch}";
                    }

                    string googleImageUrl = string.Format(GOOGLE_IMAGE_URL, headingName);
                    string youtubeUrl = string.Format(YOUTUBE_URL, headingName);

                    //Process process = new Process();
                    //process.StartInfo.UseShellExecute = true;
                    //process.StartInfo.FileName = "chrome";
                    //
                    //process.StartInfo.Arguments = googleImageUrl; // @"https://www.google.com.pk/search?q=plane+wallpaper&hl=en-GB&tbm=isch&source=hp&biw=1366&bih=636&ei=wGBrYMuzGrCNlwTMrpLgAg&oq=plane+wallpaper&gs_lcp=CgNpbWcQA1CIOFiaSmDAS2gAcAB4AIABAIgBAJIBAJgBC6ABAaoBC2d3cy13aXotaW1n&sclient=img&ved=0ahUKEwjLk8Go5-fvAhWwxoUKHUyXBCwQ4dUDCAY&uact=5";
                    //process.Start();
                    //process.StartInfo.Arguments = youtubeUrl; // @"https://www.google.com.pk/search?q=plane+wallpaper&hl=en-GB&tbm=isch&source=hp&biw=1366&bih=636&ei=wGBrYMuzGrCNlwTMrpLgAg&oq=plane+wallpaper&gs_lcp=CgNpbWcQA1CIOFiaSmDAS2gAcAB4AIABAIgBAJIBAJgBC6ABAaoBC2d3cy13aXotaW1n&sclient=img&ved=0ahUKEwjLk8Go5-fvAhWwxoUKHUyXBCwQ4dUDCAY&uact=5";
                    //process.Start();


                    Process pFireFox = new Process();
                    pFireFox.StartInfo.FileName = "firefox.exe";
                    pFireFox.StartInfo.Arguments = googleImageUrl;
                    pFireFox.Start();

                    Thread.Sleep(300);

                    pFireFox.StartInfo.Arguments = youtubeUrl; // @"https://www.google.com.pk/search?q=plane+wallpaper&hl=en-GB&tbm=isch&source=hp&biw=1366&bih=636&ei=wGBrYMuzGrCNlwTMrpLgAg&oq=plane+wallpaper&gs_lcp=CgNpbWcQA1CIOFiaSmDAS2gAcAB4AIABAIgBAJIBAJgBC6ABAaoBC2d3cy13aXotaW1n&sclient=img&ved=0ahUKEwjLk8Go5-fvAhWwxoUKHUyXBCwQ4dUDCAY&uact=5";
                    pFireFox.Start();
                    Thread.Sleep(300);

                    //Process.Start("firefox.exe", "-private http://www.google.com"); //Opens Firefox and displays Google homepage in a private window
                }
            }
            else
            {
                MessageBox.Show("Cannot Search because No Heading Detected!");
            }
        }

        private void btnCopyUpdatedContent_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtUpdatedContent.Text);
        }

        private void btnGenerateTags_Click(object sender, EventArgs e)
        {
            try
            {
                _youtubeVideosTags.Clear();
                if (dgTable.Rows.Count <= 0)
                {
                    MessageBox.Show("Cannot Generate Tags because No Heading Detected!");
                }
                else
                {
                    // Generate youtube videos tags
                    for (int rows = 0; rows < dgTable.Rows.Count; rows++)
                    {
                        string youtubeVideo = dgTable.Rows[rows].Cells[3]?.Value?.ToString();
                        string youtubeVideoId = "";

                        if (!string.IsNullOrWhiteSpace(youtubeVideo) && youtubeVideo.Contains("watch?v=")) // user added complete URL of video.
                        {
                            youtubeVideoId = youtubeVideo.Replace("https://www.youtube.com/watch?v=", ""); //https://www.youtube.com/watch?v=ZXCqUeUc3d8
                        }
                        else
                        {
                            youtubeVideoId = youtubeVideo;
                        }

                        string youtubeTag = string.Empty;

                        if (string.IsNullOrWhiteSpace(youtubeVideoId) || youtubeVideoId.Contains($"{TXT_ENTER_VIDEO_LINK}"))
                        {
                            youtubeTag = "";
                        }
                        else
                        {
                            youtubeTag = "<p><iframe width=\"100%\" height=\"415\" src=\"https://youtube.com/embed/" + youtubeVideoId + "\" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen=\"\"></iframe></p>";
                        }
                        _youtubeVideosTags.Add(youtubeTag);
                    }

                    // Insert Youtube videos Tags in updated content

                    if (_allLines.Any(x => x.Contains("</h2>")))
                    {
                        bool isfirstHeadingFound = false;
                        int videoIndex = 0;// _youtubeVideosTags.Count - 1;

                        for (int i = 0; i < _allLines.Count; i++)
                        {
                            var line = _allLines[i];

                            if (line.Contains("</h2>"))
                            {
                                if (!isfirstHeadingFound)
                                {
                                    isfirstHeadingFound = true;
                                    continue;
                                }
                                else if (videoIndex < _youtubeVideosTags.Count()) // insert before next h2 tag.
                                {
                                    _allLines.Insert(i, _youtubeVideosTags[videoIndex++]);
                                    i++;
                                }
                            }
                        }
                        if (isfirstHeadingFound && _youtubeVideosTags.Count() != videoIndex)
                        {
                            _allLines.Add(_youtubeVideosTags[videoIndex++]);
                        }
                    }

                    //Insert Table Of Content Tags
                    _tocList.Insert(0, TOC_START_TEMPLATE); // add to start
                    _tocList.Add(TOC_END_TEMPLATE);  // add to End
                    _allLines.InsertRange(_tocIndex, _tocList);

                    txtUpdatedContent.Text = string.Join("\n", _allLines);

                    CreateBackupContentFiles();

                    this.btnGenerateTags.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message}\n\n Trace: {ex.StackTrace}");
            }
        }

        private void CreateBackupContentFiles()
        {
            string originalContentPath = $"{_newArticleFolderPath}\\{_filePreviousOriginalContentName}";
            string updatedContentPath = $"{_newArticleFolderPath}\\{_fileUpdateContentName}";

            var tempLines = txtOriginalContent.Text.Split('\n');

            var fs = File.Create(originalContentPath);
            fs.Dispose();
            File.WriteAllLines(originalContentPath, tempLines);

            var fs2 = File.Create(updatedContentPath);
            fs2.Dispose();
            File.WriteAllLines(updatedContentPath, _allLines);
        }

        private void txtArticleId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

		
        private void dgTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2 && dgTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Clipboard.SetText(dgTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
            else if (e.ColumnIndex == 3)
            {
                dgTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Clipboard.GetText();
            }
        }


        private void BtnCreateFolder_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtArticleId.Text.Trim()) || string.IsNullOrEmpty(txtArticleName.Text.Trim()))
            {
                MessageBox.Show("Article Id or Name is missing!");
                return;
            }

            string articleName = Regex.Replace(txtArticleName.Text, "[\\/\":*?<>|]", "");
            articleName = articleName.Replace("\\", "");
            
            string pathMainFolder = SettingsTemp.Default.FolderPathForSaveText;
            int directoryCount = System.IO.Directory.GetDirectories($@"{pathMainFolder}").Length + 1;

            _newArticleFolderPath = $@"{pathMainFolder}\{directoryCount.ToString("D3")} {articleName} (id {txtArticleId.Text})";
            
            Directory.CreateDirectory(_newArticleFolderPath);

            MessageBox.Show($"Folder Created Successfully!\n\n{_newArticleFolderPath}");

            this.BtnCreateFolder.Enabled = false;
        }

        #region PrivateMembers

        private string GOOGLE_IMAGE_URL = "https://www.google.com.pk/search?q={0}+black+%26+white+wallpaper&hl=en-GB&tbm=isch&source=hp&biw=1366&bih=636&ei=wGBrYMuzGrCNlwTMrpLgAg&oq={0}+wallpaper&gs_lcp=CgNpbWcQA1CIOFiaSmDAS2gAcAB4AIABAIgBAJIBAJgBC6ABAaoBC2d3cy13aXotaW1n&sclient=img&ved=0ahUKEwjLk8Go5-fvAhWwxoUKHUyXBCwQ4dUDCAY&uact=5";
        private string YOUTUBE_URL = "https://www.youtube.com/results?search_query={0}";
        private const string LINE_SEPARATOR = "ABC@123";
        private const string TOC_START_TEMPLATE = "<nav>\n<ul class=\"ez-toc-list\" style=\"display: block;\">"; // Table Of Content - Start Tags
        private const string TOC_END_TEMPLATE = "</ul>\n</nav>";  // Table Of Content - End Tags

        private int _tocIndex = -1;

        private const string TXT_ENTER_VIDEO_LINK = "ENTER_VIDEO_LINK";

        private List<string> _allLines = new List<string>();
        private List<string> _detectedHeadings = new List<string>();
        private List<string> _imageNames = new List<string>();
        private List<string> _tocList = new List<string>();
        private List<string> _youtubeVideosTags = new List<string>();
        private List<string> _headingsToIgnore = new List<string>();
        private string _newArticleFolderPath = "";
        private string _filePreviousOriginalContentName = "Previous Original Content.html";
        private string _fileUpdateContentName = "Updated Content.html";


        #endregion

    }
}
