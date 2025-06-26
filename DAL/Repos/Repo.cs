using DAL.EF;
using System;

namespace DAL.Repos
{
    public class Repo
    {
        protected WMSContext db;
        protected Repo()
        {
            db = new WMSContext();
        }
    }
}