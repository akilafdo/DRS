using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.DataBase;

namespace DRS.Services.UsersService
{
    public class UsersService
    {
        private DRSEntities db;

        public UsersService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<user> getAllUsersDB()
        {
            try
            {
                using (var DRS_db = new DRSEntities())
                {
                    return DRS_db.users.OrderBy(u => u.mcs_id).Where(u => u.user_status == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public user getUserDB(int id)
        {
            try
            {
                user user = null;
                user = db.users.Where(u => u.user_id == id && u.user_status == 1).FirstOrDefault();
                if (user == null)
                {
                    user = new user();
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveUserDB(user user)
        {
            try
            {
                int flag = 0;
                if (db.users.Where(u => u.user_username.Equals(user.user_username) && u.user_status == 1).FirstOrDefault() == null)
                {
                    db.users.Add(user);
                    db.SaveChanges();
                    flag = 1;
                }
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateUserDB(int id, user user)
        {
            try
            {
                int flag = 0;
                var result = db.users.Where(u => u.user_id == id && u.user_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteUserDB(int id, user user)
        {
            try
            {
                int flag = 0;
                var result = db.users.Where(u => u.user_id == id && u.user_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set*Radio Stations
        public SelectList getRadioStationsSelectListDB()
        {
            try
            {
                return new SelectList(db.radio_station.Where(r => r.mcs_status == 1), "mcs_id", "mcs_location");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}