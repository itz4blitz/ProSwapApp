using ProSwap.Data;
using ProSwap.Models;
using ProSwap.Models.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProSwap.Services
{
    public class OfferService
    {
        private readonly Guid _userId;

        public OfferService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOffer(OfferCreate model)
        {
            var entity =
                new Offer()
                {
                    OwnerId = _userId,
                    GameId = model.GameId,
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

        public IEnumerable<OfferListeItem> GetAllOffers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .Offer
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new OfferListeItem
                            {
                                OwnerID = e.OwnerId,
                                Title = e.Title,
                                CreatedOn = e.CreatedUTC
                            }
                    );

                return query.ToArray();
            }
        }

        public OfferDetail GetOfferById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Offer
                        .Single(e => e.OfferId == id && e.OwnerId == _userId);
                return
                    new OfferDetail
                    {
                        ThreadID = entity.OfferId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateOffer(OfferEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Offer
                        .Single(e => e.OfferId == model.OfferId && e.OwnerId == _userId);
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
