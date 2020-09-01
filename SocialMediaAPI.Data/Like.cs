using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
    public class Like
    {
        public int PostId { get; set; }

        [ForeignKey(nameof(Post))]
        public Post Id { get; set; }
        public virtual Post Post { get; set; }

        public int LikerId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
