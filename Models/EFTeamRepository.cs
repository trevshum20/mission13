//using System;
//using System.Linq;

//namespace Mission13.Models
//{
//    public class EFTeamRepository : ITeamsRepository
//    {
//        private TeamsDbContext TeamContext { get; set; }

//        public EFTeamRepository(TeamsDbContext temp)
//        {
//            TeamContext = temp;
//        }

//        public IQueryable<Team> Teams => TeamContext.Teams;
//    }
//}
