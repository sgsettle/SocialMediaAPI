﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class CommentCreate
    {
        public string Text { get; set; }

        public int PostId { get; set; }
    }
}
