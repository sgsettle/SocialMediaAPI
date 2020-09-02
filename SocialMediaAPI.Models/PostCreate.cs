using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Models
{
    public class PostCreate
    {
       // [Key]
      //  public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Text { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //[ForeignKey(nameof(User))]
        //public Guid Author { get; set; }
        //public virtual User User { get; set; }

    }
}
