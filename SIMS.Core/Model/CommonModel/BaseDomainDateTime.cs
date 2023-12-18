﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Core.Model.CommonModel
{
    public class BaseDomainDateTime
    {
        public bool IsDelete { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
