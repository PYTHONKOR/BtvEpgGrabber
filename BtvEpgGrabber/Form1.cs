using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace BtvEpgGrabber
{

    public partial class Form1 : Form
    {
        IniFile mIni;
        BtvChannelInfo.BtvChannelList mCurrentChannelsData;

        public Form1()
        {
            InitializeComponent();

            mIni = new IniFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Config.ini");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadConfig();

            if (checkBoxAutoSearch.Checked == true)
            {
                AppendLog("자동 검색 시작");
                new Thread(() => Save()).Start();
            }
        }

        private void LoadConfig()
        {
            if (mIni.IniReadValue("Config", checkBoxAutoSearch.Name) == "true")
                checkBoxAutoSearch.Checked = true;

            if (mIni.IniReadValue("Config", checkBoxAutoExit.Name) == "true")
                checkBoxAutoExit.Checked = true;

            if (mIni.IniReadValue("Config", checkBoxAutoCopy.Name) == "true")
                checkBoxAutoCopy.Checked = true;

            string CopyPath = mIni.IniReadValue("Config", textBoxCopyPath.Name);

            if (CopyPath != null && CopyPath.Length > 0)
                textBoxCopyPath.Text = CopyPath;

            if (mIni.IniReadValue("Config", checkBoxAddTime.Name) == "true")
                checkBoxAddTime.Checked = true;

            string daystr = mIni.IniReadValue("Config", numericUpDownDay.Name);
            numericUpDownDay.Value = daystr.Length == 0 ? 1 : Convert.ToInt32(daystr);


        }

        private void MakeChannelBtn_Click(object sender, EventArgs e)
        {
            new Thread(() => LoadChannelInfo()).Start();
        }

        private void buttonMakeEpg_Click(object sender, EventArgs e)
        {
            new Thread(() => Save()).Start();
        }

        private void Save()
        {
            if (File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + mIni.IniReadValue("Config", "Channel_Info")) == false)
            {
                AppendLog("채널 정보 생성을 먼저 해주세요.");
                return;
            }

            LoadChannelInfo();

            if (mCurrentChannelsData == null || mCurrentChannelsData.ChannelList.Count == 0)
            {
                AppendLog("채널 정보 파일 깨짐");
                return;
            }

            AppendLog("작업 시작");

            BtvEpgData.BtvEpg epg = new BtvEpgData.BtvEpg();


            for (int i = 0; i < mCurrentChannelsData.ChannelList.Count; i++)
            {
                BtvChannelJsonData.BtvChannelData result;

                using (WebClient client = new WebClient())
                {
                    string url = @"http://m.btvplus.co.kr/common/inc/IFGetData.do?variable=IF_LIVECHART_DETAIL&pcode=|^|svc_id=";

                    url += mCurrentChannelsData.ChannelList[i].ServiceId;
                    url += @"|^|start_time=" + GetStartTimeStr() + "|^|end_time=" + GetEndTimeStr();

                    try
                    {
                        Thread.Sleep(500);

                        var htmlData = client.DownloadData(url);
                        var htmlCode = Encoding.UTF8.GetString(htmlData);

                        result = JsonConvert.DeserializeObject<BtvChannelJsonData.BtvChannelData>(htmlCode);
                    }
                    catch (WebException e)
                    {
                        AppendLog("서버 연결중에 오류가 발생했습니다. - " + e.ToString());
                        return;
                    }
                }

                BtvEpgData.ChannelInfo channel = new BtvEpgData.ChannelInfo();
                channel.id = mCurrentChannelsData.ChannelList[i].ChannelId;
                channel.DisplayName = result.channel.channelName;
                epg.ChannelList.Add(channel);

                AppendLog(String.Format("[{0} / {1}] {2} 처리 중...", i, mCurrentChannelsData.ChannelList.Count, mCurrentChannelsData.ChannelList[i].ChannelName));

                for (int j = 0; j < result.channel.programs.Count; j++)
                {
                    BtvEpgData.ProgramInfo program = new BtvEpgData.ProgramInfo();

                    program.channel = mCurrentChannelsData.ChannelList[i].ChannelId;
                    program.start = EpochTostring(result.channel.programs[j].startTime);
                    program.stop = EpochTostring(result.channel.programs[j].endTime);
                    program.title.Desc = result.channel.programs[j].programName;
                    program.desc.Desc = result.channel.programs[j].programName + "\n" + result.channel.programs[j].mainGenreName + "\n" + result.channel.programs[j].actorName;
                    program.category.Desc = result.channel.programs[j].mainGenreName;
                    program.credits.actor = result.channel.programs[j].actorName;
                    program.credits.director = result.channel.programs[j].directorName;
                    program.rating.value = result.channel.programs[j].ratingCd;

                    epg.ProgramList.Add(program);
                }
            }

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");


            XmlSerializer serializer = new XmlSerializer(typeof(BtvEpgData.BtvEpg));

            Encoding utf8WithoutBom = new UTF8Encoding(false);
            StreamWriter sw = new StreamWriter(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + mIni.IniReadValue("Config", "Default_Save_File"), false, utf8WithoutBom);

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };

            XmlWriter xw = XmlWriter.Create(sw, xmlWriterSettings);

            xw.WriteDocType("tv", null, "xmltv.dtd", null);

            serializer.Serialize(xw, epg, ns);

            xw.Close();
            sw.Close();

            AppendLog("채널 데이터 저장 완료");

            if (checkBoxAutoCopy.Checked == true)
            {
                FileInfo file = new FileInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + mIni.IniReadValue("Config", "Default_Save_File"));

                if (file.Exists)
                {
                    file.CopyTo(textBoxCopyPath.Text, true);

                    AppendLog("자동 복사 완료");
                }
            }

            if (checkBoxAutoExit.Checked == true)
            {
                Application.Exit();
                Environment.ExitCode = 0;
            }
        }

        public void AppendLog(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendLog), new object[] { value });
                return;
            }

            textBoxLog.Text = value;
        }

        private string EpochTostring(string epoch)
        {
            double sec = Convert.ToDouble(epoch);

            string timestr = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(sec).ToString("yyyyMMddHHmmss");

            if (checkBoxAddTime.Checked == true)
            {
                timestr += " +0900";
            }

            return timestr;
        }

        void LoadChannelInfo()
        {
            mCurrentChannelsData = null;

            XmlSerializer serializer = new XmlSerializer(typeof(BtvChannelInfo.BtvChannelList));

            StreamReader reader = new StreamReader(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + mIni.IniReadValue("Config", "Channel_Info"));
            mCurrentChannelsData = (BtvChannelInfo.BtvChannelList)serializer.Deserialize(reader);
            reader.Close();
        }

        void SaveChannelInfo()
        {
            BtvAllJsonData.BtvAllData result;
            BtvChannelInfo.BtvChannelList ChannelsData = new BtvChannelInfo.BtvChannelList();

            ChannelsData.ChannelList = new List<BtvChannelInfo.ChannelInfo>();

            using (WebClient client = new WebClient())
            {
                string url = mIni.IniReadValue("Config", "Channel_URL");

                var htmlData = client.DownloadData(url);
                var htmlCode = Encoding.UTF8.GetString(htmlData);

                result = JsonConvert.DeserializeObject<BtvAllJsonData.BtvAllData>(htmlCode);
            }


            for (int i = 0; i < result.channels.Count; i++)
            {
                BtvChannelInfo.ChannelInfo info = new BtvChannelInfo.ChannelInfo();

                info.ChannelName = result.channels[i].channelName;
                info.ChannelNo = result.channels[i].channelNo;
                info.ServiceId = result.channels[i].serviceId;
                info.ChannelId = result.channels[i].serviceId;

                ChannelsData.ChannelList.Add(info);
            }

            XmlSerializer ser = new XmlSerializer(typeof(BtvChannelInfo.BtvChannelList));

            using (FileStream fs = new FileStream(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + mIni.IniReadValue("Config", "Channel_Info"), FileMode.Create))
            {
                ser.Serialize(fs, ChannelsData);
            }

            MessageBox.Show("채널 데이터 저장 완료");
        }

        string GetStartTimeStr()
        {
            return DateTime.Now.ToString("yyyyMMdd") + "00";
        }

        string GetEndTimeStr()
        {
            DateTime EdnDay = DateTime.Now.AddDays(Convert.ToInt32(numericUpDownDay.Value));
            return EdnDay.ToString("yyyyMMdd" + "24");
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbox = (CheckBox)sender;

            if (chkbox.Checked == true)
                mIni.IniWriteValue("Config", chkbox.Name, "true");
            else
                mIni.IniWriteValue("Config", chkbox.Name, "false");
        }

        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            string fileName;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장 경로를 지정하세요";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "XML File(*.xml)|*.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;

                mIni.IniWriteValue("Config", textBoxCopyPath.Name, fileName);
                textBoxCopyPath.Text = fileName;
            }
        }

        private void numericUpDownDay_ValueChanged(object sender, EventArgs e)
        {
            mIni.IniWriteValue("Config", numericUpDownDay.Name, numericUpDownDay.Value.ToString());
        }
    }
}
