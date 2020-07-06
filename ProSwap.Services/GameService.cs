using ProSwap.Data;
using ProSwap.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSwap.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    GameId = model.GameID,
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Game.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Game
                        //  .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    Name = e.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Game
                        .Single(e => e.GameId == id);
                return
                    new GameDetail
                    {
                        GameId = entity.GameId,
                        Name = entity.Name
                    };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Game
                        .Single(e => e.GameId == model.GameId);
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
