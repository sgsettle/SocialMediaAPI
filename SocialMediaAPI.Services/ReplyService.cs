using SocialMediaAPI.Data;
using SocialMediaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Services
{
    public class ReplyService 
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    UserId = _userId,
                    PostId = model.PostId,
                    ReplyComment = model.ReplyComment
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new ReplyListItem
                            {
                                CommentId = e.CommentId,
                                ReplyComment = e.ReplyComment
                            }
                            );
                return query.ToArray();
            }
        }
    }
}
