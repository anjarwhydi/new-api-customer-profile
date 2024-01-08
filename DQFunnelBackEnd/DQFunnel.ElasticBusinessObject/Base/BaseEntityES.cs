using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject.Base
{
    public abstract class BaseEntityES
    {
        [Date(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [Number(Name = "CreateUserID")]
        public int CreateUserID { get; set; }

        [Date(Name = "ModifyDate")]
        public DateTime ModifyDate { get; set; }

        [Number(Name = "ModifyUserID")]
        public int? ModifyUserID { get; set; }
    }
}
