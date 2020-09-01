using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
<<<<<<< HEAD
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
       // public Guid UserId { get; set; }
        [ForeignKey(nameof(User))]
        public User Author { get; set; }

        
    }
=======
    //public class Post
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Text { get; set; }
    //   // [ForeignKey(nameof(User))]
    //    public Guid UserId { get; set; }
    //    public virtual User User { get; set; }
    //}
>>>>>>> a92f08566db109b911b9b6dc0e776bc0059c8b6b
}
