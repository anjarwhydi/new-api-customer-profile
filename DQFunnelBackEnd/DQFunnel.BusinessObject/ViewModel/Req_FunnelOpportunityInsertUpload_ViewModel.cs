using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_FunnelOpportunityInsertUpload_ViewModel
    {
        public int UserID { get; set; }
        public IFormFile File { get; set; }
    }
}
