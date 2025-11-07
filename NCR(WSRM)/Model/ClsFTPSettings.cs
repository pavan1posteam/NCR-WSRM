using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCR_WSRM_.Model
{
    class ClsFTPSettings
    {
        public string StoreID { get; set; }
        public int StockedItems { get; set; }
        public string FtpServer { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public string UpFolder { get; set; }
        public string FtpLocation { get; set; }
        public int UpTime { get; set; }
        public string FtpTax { set; get; }
    }
}
