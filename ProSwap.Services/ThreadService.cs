using ProSwap.Data;
using ProSwap.Models;
using ProSwap.Models.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProSwap.Services
{
    public class ThreadService
    {
        private readonly Guid _userId;

        public ThreadService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateThread(ThreadCreate model)
        {
            var entity =
                new Threads()
                {
                    OwnerID = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Thread.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ThreadListItem> GetAllThreads()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .Thread
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                            new ThreadListItem
                            {
                                ThreadID = e.ThreadID,
                                Title = e.Title,
                                CreatedOn = e.CreatedUTC
                            }
                    );

                return query.ToArray();
            }
        }

        public ThreadDetail GetThreadById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Thread
                        .Single(e => e.ThreadID == id && e.OwnerID == _userId);
                return
                    new ThreadDetail
                    {
                        ThreadID = entity.ThreadID,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateThread(ThreadEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Thread
                        .Single(e => e.ThreadID == model.ThreadID && e.OwnerID == _userId);
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteThread (int threadID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Thread
                        .Single(e => e.ThreadID == threadID && e.OwnerID == _userId);

                ctx.Thread.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
