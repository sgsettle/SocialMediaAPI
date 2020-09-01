using SocialMediaAPI.Data;
using SocialMediaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }
    }

    public bool CreatePost(PostCreate model)
    {
        var entity =
            new Post()
            {
                UserId = _userId,
                Title = model.Title,
                Text = model.Text,

            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Post.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
