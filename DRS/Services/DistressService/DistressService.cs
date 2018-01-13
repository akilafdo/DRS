using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DRS.DataBase;

namespace DRS.Services.DistressService
{
    public class DistressService
    {
        private DRSEntities db;

        public DistressService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<distress> getAllDistressDB()
        {
            try
            {
                return db.distresses.OrderBy(d => d.distress_name).Where(d => d.distress_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public distress getDistressDB(int id)
        {
            try
            {
                return db.distresses.Where(d => d.distress_id == id && d.distress_status == 1).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveDistressDB(distress distress)
        {
            int flag = 0;
            try
            {
                if (distress != null)
                {
                    db.distresses.Add(distress);
                    db.SaveChanges();
                    flag = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //update method
        public int updateDistressDB(int id, distress distress)
        {
            int flag = 0;
            try
            {
                var result = db.distresses.Where(d => d.distress_id == id && d.distress_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(distress).State = EntityState.Modified;
                    flag = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //delete method
        public int deleteDistressDB(int id, distress distress)
        {
            int flag = 0;
            try
            {
                var result = db.distresses.Where(d => d.distress_id == id && d.distress_status == 1);
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(distress).State = EntityState.Modified;
                    flag = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }
    }
}