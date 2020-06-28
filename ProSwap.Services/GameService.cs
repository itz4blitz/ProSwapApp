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
                    GameId = model.GameId,
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Game.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
