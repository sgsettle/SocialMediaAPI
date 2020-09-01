using SocialMediaAPI.Data;
using SocialMediaAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public bool CreatePost(PostCreate model) // make this Post, not User. Create a User Service for those methods
        {
            var entity =
                new Post()
                {
                    UserId = _userId,
                   // Id = model.Id,
                    Title = model.Title,
                    Text = model.Text,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserProfiles
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new PostListItem
                            {
                                Id = e.Id,
                                Title = e.Title
                            }
                            );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserProfiles
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text
                    };
            }
        }
    }
}
