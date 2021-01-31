using Filmozor.DAL.EF;
using Filmozor.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Filmozor.DAL.Repositories
{
    public class NewRep
    {
        public static ApplicationContext Database = new ApplicationContext();
        public static IEnumerable<New> GetNewsFromDB()
        {
            IEnumerable<New> news = Database.News;
            return news;
        }

        public static New GetNewFromDB(int id)
        {
            return Database.News.Where(n => n.NewID == id).FirstOrDefault();
        }
        public static void DeleteNewFromDB(int id)
        {
            New _new = Database.News.Where(n => n.NewID == id).FirstOrDefault();

            if (_new != null)
            {
                Database.Entry<New>(_new).State = EntityState.Deleted;
                Database.SaveChanges();
            }
        }

        public static void PasteNew(New _new)
        {
            New n_new = Database.News.Where(n => n.NewID == _new.NewID).FirstOrDefault();

            if (n_new != null)
            {
                Database.Entry<New>(n_new).State = EntityState.Modified;
                Database.SaveChanges();
            }
        }
    }
}
