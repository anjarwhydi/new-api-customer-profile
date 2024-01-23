﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_CustomerSettingGetProjectHistoryEnvelope_ViewModel
    {
        public long FunnelID { get; set; }
        public string SO { get; set; }
        public string ProjectName { get; set; }
        public string CustomerName { get; set; }
        public string SalesName { get; set; }
        public string SalesDept { get; set; }
        public string SOCloseDate { get; set; }
        public float SOAmount { get; set; }
        public string SuccessStory { get; set; }
        public List<Req_CustomerSettingGetModifySuccessStories_ViewModel> ModifiedStoryBy { get; set; }
    }
}
