using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class NotificationRepo : Repo, IRepo<Notification, int, Notification>
    {
        public Notification Add(Notification obj)
        {
            db.Notifications.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Notifications.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Notification> Get()
        {
            return db.Notifications.ToList();
        }

        public Notification Get(int id)
        {
            return db.Notifications.Find(id);
        }

        public Notification Update(Notification obj)
        {
            var dbobj = Get(obj.NotificationId);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}