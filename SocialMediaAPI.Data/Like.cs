using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
    class Like
    {
        public int PostId { get; set; }
        public Post LikedPost { get; set; }
        public int LikerId { get; set; }
        public User Liker { get; set; }
    }
}
