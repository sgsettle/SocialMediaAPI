﻿using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public int PostId { get; set; }
    }
}
