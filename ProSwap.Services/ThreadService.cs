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
                new Offer()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Offer.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ThreadListItem> GetAllOffers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .Offer
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new ThreadListItem
                            {
                                OwnerID = e.OwnerId,
                                Title = e.Title,
                                CreatedOn = e.CreatedUTC
                            }
                    );

                return query.ToArray();
            }
        }

        public ThreadDetail GetOfferById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Offer
                        .Single(e => e.OfferId == id && e.OwnerId == _userId);
                return
                    new ThreadDetail
                    {
                        ThreadID = entity.OfferId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateOffer(ThreadEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Offer
                        .Single(e => e.OfferId == model.ThreadID && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOffer(int offerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Offer
                        .Single(e => e.OfferId == offerId && e.OwnerId == _userId);

                ctx.Offer.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
