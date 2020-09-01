using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }




        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

    }
    //public class Like
    //{
    //    public int Id { get; set; }
    //    public Posts LikedPost { get; set; }
    //    public int LikerId { get; set; }
    //    public User Liker { get; set; }
    //}

    //public class Comment
    //{
    //    public int Id { get; set; }
    //    public string Text { get; set; }
    //    public User Author { get; set; }
    //    public Posts CommentPost { get; set; }
    //}


}
