using System.Data;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Windows.Forms;

namespace iptv_playlist_editor
{
    public partial class Form1 : Form
    {
        string fileName = "pl.m3u";
        string fileName_ = "pl_.m3u";
        string saved = "latest.m3u";

        public List<ChannelData> Channels = new List<ChannelData>();

        public Form1()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Bind the DataGridView controls to the BindingSource
            // components and load the data from the database.
            if(File.Exists("cfg"))
                using (var reader = new System.IO.StreamReader("cfg"))
                {
                    var line = reader.ReadLine();
                    txtUrl.Text = line;
                }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text.Trim()))
                return;

            using (var writer = new System.IO.StreamWriter("cfg"))
            {
                writer.Write(txtUrl.Text.Trim());
            }

            using (var myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(txtUrl.Text.Trim(), fileName);

                StringBuilder sbText = new StringBuilder();
                using (var reader = new System.IO.StreamReader(fileName))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Substring(1).Contains('#'))
                            sbText.AppendLine(line.Substring(0,1) + line.Substring(0).Replace("#", "") );
                        else
                            sbText.AppendLine(line);
                    }
                }

                using (var writer = new System.IO.StreamWriter(fileName_))
                {
                    writer.Write(sbText.ToString());
                }

            }

            var simpleVodM3u = M3U.ParseFromFile(fileName_);

            Channels = simpleVodM3u.Medias.Select(m => new ChannelData {
                Group = m.Attributes.GroupTitle,
                Logo = GetChannelText(m.Attributes.Logo, m.Attributes.TvgLogo),
                MediaFile = m.MediaFile,
                TvgId = GetChannelText(m.Attributes.TvgId, m.Attributes.Id),
                Title = GetChannelText(GetChannelText(GetChannelText(m.Title.InnerTitle, m.Title.RawTitle), m.Attributes.GuideIdentifierTV), m.Attributes.TvgName)
            }).Where(x=> !x.Title.Contains("====")).ToList();

            dgvGroup.AutoGenerateColumns = false;
            dgvGroupChannels.AutoGenerateColumns = false;
            gridSummary.AutoGenerateColumns = false;

            BindMasterGrid(true);
        }

        void BindMasterGrid(bool preBind)
        {
            List<string> okGroups = new List<string> { "GameStation", "EXXEN SPOR", "beIN SPORTS", "NETFLIX FILM", "YERLI FILM", "BEIN FILM", "BluTV FILMS", "GAIN FILMS", "VOD ALTYAZILI", "COCUK SERISI", "KOLEKSIYON", "TURKCE VOD", "MUBI FILMS", "ExxeN FILM",
                "VOD 4K", "ARSIV YERLI FILMLER", "ARSIV TURKVOD", "NETFLÝX SERIES", "BLU TV DÝZÝLER", "ExxeN DÝZÝLER", "GaiN DÝZÝLER", "BEIN DIZILER", "Apple TV Dizileri", "Originals"};

            selectedGroups.Clear();

            var groups = Channels.GroupBy(x => x.Group).Select(x=> new GroupData { Group = x.Key, Del = (preBind ? !okGroups.Contains(x.Key): false) }).ToList();
            if (preBind)
                selectedGroups.AddRange(groups.Where(x=>x.Del).Select(s=>s.Group));

            dgvGroup.DataSource = groups;
            dgvGroup.Refresh();

            //dgvGroup.AutoResizeColumns();
        }

        void BindSummaryGrid()
        {
            var detailChannels = Channels.Where(x => x.Group == selectedGroup).ToList();
            var seriesNames = detailChannels.Where(x => x.Title.Contains("S01 E01")).Select(s=>new SeriesData { SeriesTitle = s.Title.Substring(0, s.Title.IndexOf("S01")).Trim() }).ToList();

            gridSummary.DataSource = seriesNames;
            gridSummary.Refresh();
        }

        void BindDetailGrid()
        {
            //dgvGroupChannels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var channels = Channels.Where(x => x.Group == selectedGroup).ToList();
            dgvGroupChannels.DataSource = channels;

            dgvGroupChannels.Refresh();


            //dgvGroup.AutoResizeColumns();
        }

        string GetChannelText(string t1, string t2)
        {
            if (string.IsNullOrWhiteSpace(t1))
                return t2.Replace("#", "").Replace("Movie:", "").Replace("Yerli_", "").Trim();
            if (string.IsNullOrWhiteSpace(t2))
                return t1.Replace("#", "").Replace("Movie:", "").Replace("Yerli_", "").Trim();
            if (t1.Trim() == t1.Trim())
                return t1.Replace("#", "").Replace("Movie:", "").Replace("Yerli_", "").Trim();

            return t1.Replace("#", "").Replace("Movie:", "").Replace("Yerli_", "").Trim() + " " + t2.Replace("#", "").Replace("Movie: ", "").Replace("Yerli_", "").Trim();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder playlist = new StringBuilder();
            //var groups = Channels.GroupBy(x => x.Group).Select(x => new GroupData { Group = x.Key }).ToList();

            foreach (var channel in Channels)
            {
                playlist.AppendLine($"#EXTINF:-1 tvg-id=\"{channel.TvgId}\" tvg-name=\"{channel.Title}\" tvg-logo=\"{channel.Logo}\" group-title=\"{channel.Group}\",{channel.Title}");
                playlist.AppendLine(channel.MediaFile);
            }

            using (var writer = new System.IO.StreamWriter(saved))
            {
                writer.Write(playlist.ToString());
            }
        }

        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        List<string> selectedGroups = new List<string>();
        string selectedGroup = "";
        private void dgvGroup_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                DataGridViewCell c = (sender as DataGridView)["Group", e.RowIndex];

                string tmp = c.Value.ToString();
                if(tmp != selectedGroup)
                {
                    selectedGroup = tmp;
                    BindDetailGrid();
                    BindSummaryGrid();
                }
            }
        }

        private void dgvGroup_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvGroup_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        }

        private void dgvGroup_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Channels = Channels.Where(x => !selectedGroups.Contains(x.Group)).ToList();
            //var tmp = Channels.Where(x => selectedGroups.Contains(x.Group));
            //for (int i = 0; i < tmp.Count(); i++)
            //{
            //    Channels.Remove(tmp.ElementAt(i));
            //    i--;
            //}
            BindMasterGrid(false);
            selectedGroups.Clear();

        }

        private void dgvGroup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewCell c = (sender as DataGridView)["Group", e.RowIndex];

                string tmp = c.Value.ToString();
                if (tmp != selectedGroup)
                {
                    selectedGroup = tmp;
                    BindDetailGrid();
                    BindSummaryGrid();
                }
            }

        }

        private void dgvGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 0)
            {
                DataGridViewCell delcell = (sender as DataGridView)["Del", e.RowIndex];

                DataGridViewCell groupcell = (sender as DataGridView)["Group", e.RowIndex];

                bool b = Convert.ToBoolean(delcell.Value);
                string grp = groupcell.Value.ToString();

                if (b)
                    selectedGroups.Add(grp);
                else if (selectedGroups.Contains(grp))
                    selectedGroups.Remove(grp);
            }

        }

        private void dgvGroup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGroup_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvGroup.IsCurrentCellDirty)
            {
                dgvGroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnSAll_Click(object sender, EventArgs e)
        {
            selectedGroups.Clear();

            var groups = Channels.GroupBy(x => x.Group).Select(x => new GroupData { Group = x.Key, Del = true }).ToList();
            selectedGroups.AddRange(groups.Where(x => x.Del).Select(s => s.Group));

            dgvGroup.DataSource = groups;
            dgvGroup.Refresh();
        }

        private void bSNone_Click(object sender, EventArgs e)
        {
            selectedGroups.Clear();

            var groups = Channels.GroupBy(x => x.Group).Select(x => new GroupData { Group = x.Key, Del = false }).ToList();

            dgvGroup.DataSource = groups;
            dgvGroup.Refresh();
        }
    }

    public class GroupData
    {
        public string Group { get; set; }
        public bool Del { get; set; } = false;

    }

    public class SeriesData
    {
        public string SeriesTitle { get; set; }
    }

    public class ChannelData
    {
        public string TvgId { get; set; }
        public string Title { get; set; }
        public string MediaFile { get; set; }
        public string Group { get; set; }
        public string Logo { get; set; }
    }
}