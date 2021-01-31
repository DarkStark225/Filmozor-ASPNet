using Filmozor.BLL.DTO;
using Filmozor.DAL.EF;
using Filmozor.DAL.Entities;
using Filmozor.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmozor.BLL.Services
{
    public class NewService
    {
        public static NewDTO GetNew(int id)
        {
            New buffnew = NewRep.GetNewFromDB(id);
            if (buffnew != null)
            {
                NewDTO _new = new NewDTO
                {
                    NewID = buffnew.NewID,
                    avatar = buffnew.avatar,
                    description = buffnew.description,
                    date_of_publication=buffnew.date_of_publication,
                    title=buffnew.title
                };
                return _new;
            }
            return null;
        }

        public static List<NewDTO> GetNews()
        {
            IEnumerable<New> buffnews = NewRep.GetNewsFromDB();
            List<NewDTO> news = new List<NewDTO>();
            foreach (var buff_new in buffnews)
            {
                NewDTO _new = new NewDTO
                {
                    avatar = buff_new.avatar,
                    date_of_publication = buff_new.date_of_publication,
                    description = buff_new.description,
                    NewID = buff_new.NewID,
                    title = buff_new.title
                };
                news.Add(_new);
            }
            return news;
        }

        public static void DeleteNew(int id)
        {
            NewRep.DeleteNewFromDB(id);
        }
    }
}
