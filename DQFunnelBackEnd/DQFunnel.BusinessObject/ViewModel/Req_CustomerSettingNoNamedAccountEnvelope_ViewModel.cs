using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_CustomerSettingNoNamedAccountEnvelope_ViewModel
    {
        public int TotalRows { get; set; }
        public string Column { get; set; }
        public string Sorting { get; set; }
        public List<Req_CustomerSettingNoNamedAccount_ViewModel> Rows { get; set; }
    }
}
