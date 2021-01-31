using Filmozor.DAL.EF;
using Filmozor.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Filmozor.DAL.Repositories
{
    public class RatingRep
    {
        public static ApplicationContext Database = new ApplicationContext();
        public static int RatingInDB(Rating rating)
        {
            Rating old_rat = Database.Ratings.Where(r => r.FilmId == rating.FilmId && r.UserId == rating.UserId).FirstOrDefault();
            
            if (old_rat != null)
            {
                int old_value = old_rat.Value; 
                old_rat.Value = rating.Value;
                Database.Entry<Rating>(old_rat).State = EntityState.Modified;
                Database.SaveChanges();
                return old_value;
            }
            else
            {
                Database.Ratings.Add(rating);
                Database.SaveChanges();
                return -1;
            }
        }

        public static int GetRatingFromDB(Rating rating)
        {
            Rating rat = Database.Ratings.Where(r => r.FilmId == rating.FilmId && r.UserId == rating.UserId).FirstOrDefault();

            if (rat != null) return rat.Value;
            else
            return 0;
        }
    }
}
