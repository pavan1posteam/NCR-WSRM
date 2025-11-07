using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCR_WSRM_.Model
{
    class ClsDbSettings
    {
        public string Server { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Database { set; get; }
        public bool IntegratedSecurity { get; set; }
    }
}
