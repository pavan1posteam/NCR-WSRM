using NCR_WSRM_.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCR_WSRM_
{
    class ClsSettings
    {
        public ClsSettings()
        {
            LoadSettings();
        }
        public string ConnectionString = "";
        public string StoreId { get; set; }
        public string FTPServer { get; set; }
        public string FTPUserName { get; set; }
        public string FTPPwd { get; set; }
        public string FTPUpFolder { get; set; }
        public string FTPLocation { get; set; }
        public int StockedItems { get; set; }
        public static int UpTime { set; get; }
        public string DbServer { set; get; }
        public string DbUserName { set; get; }
        public string DbPassword { set; get; }
        public string DbDatabase { set; get; }
        public bool DbIntegratedSecurity { get; set; }
        public bool IntegratedSecurity { get; internal set; }
        public string FtpTax { set; get; }

        public void LoadSettings()
        {
            string jsoncats;
            if (File.Exists("config\\dbsettings.txt") & File.Exists("config\\ftpsettings.txt"))
            {
                var FileStream = new FileStream(@"config\dbsettings.txt", FileMode.Open, FileAccess.Read);
                using (var StreamReader = new StreamReader(FileStream, Encoding.UTF8))
                {
                    jsoncats = StreamReader.ReadToEnd();
                }
                ClsDbSettings clsdb = JsonConvert.DeserializeObject<ClsDbSettings>(jsoncats);
                if (clsdb != null)
                {
                    DbServer = clsdb.Server;
                    DbUserName = clsdb.UserName;
                    DbPassword = clsdb.Password;
                    DbDatabase = clsdb.Database;
                    DbIntegratedSecurity = clsdb.IntegratedSecurity;
                }
                if (DbIntegratedSecurity)
                {
                    ConnectionString = "Server=" + DbServer + "; Database=" + DbDatabase + "; Integrated Security=True;";
                }
                else
                {
                    ConnectionString = "Data Source=" + DbServer + ";Initial Catalog=" + DbDatabase + ";User Id=" + DbUserName + ";Password=" + DbPassword + ";";
                }
                FileStream = new FileStream(@"config\ftpsettings.txt", FileMode.Open, FileAccess.Read);
                using (var StreamReader = new StreamReader(FileStream, Encoding.UTF8))
                {
                    jsoncats = StreamReader.ReadToEnd();
                }

                ClsFTPSettings clsftp = JsonConvert.DeserializeObject<ClsFTPSettings>(jsoncats);
                if (clsftp != null)
                {
                    StoreId = clsftp.StoreID;
                    FTPServer = clsftp.FtpServer;
                    FTPUserName = clsftp.FtpUserName;
                    FTPPwd = clsftp.FtpPassword;
                    FTPUpFolder = clsftp.UpFolder;
                    FTPLocation = clsftp.FtpLocation;
                    StockedItems = clsftp.StockedItems;
                    UpTime = clsftp.UpTime;
                    FtpTax = clsftp.FtpTax;
                }
            }
        }
    }
}
