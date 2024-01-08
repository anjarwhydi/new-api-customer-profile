﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject.Base
{
    public abstract class BaseTimesEntity:BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
