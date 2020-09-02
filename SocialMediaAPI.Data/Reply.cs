using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
    public class Reply : Comment
    {       
        public string ReplyComment { get; set; }
        
    }
}
