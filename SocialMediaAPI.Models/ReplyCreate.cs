﻿using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class ReplyCreate : Comment
    {
        public string ReplyComment { get; set; }
    }
}
