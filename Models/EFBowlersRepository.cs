using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFBowlersRepository(BowlersDbContext jotaro)
        {
            _context = jotaro;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;


        public void SaveChanges(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void Add(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void Delete(int bowlerid)
        {
            var b = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            _context.Remove(b);
            _context.SaveChanges();
        }


    }


}
