using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class LikeCreate
    {

        public int PostId { get; set; }

        public Guid UserId { get; set; }
    }
}
