using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void SaveChanges(Bowler b);

        public void Add(Bowler b);

        public void Delete(int bowlerid);


    }
}
