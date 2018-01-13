using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DRS.DataBase;

namespace DRS.Services.RegistrationsService
{
    public class RegistrationsService
    {
        private DRSEntities db;
        public RegistrationsService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<registration> getAllRegistrationsDB()
        {
            try
            {
                using (var DRS_db = new DRSEntities())
                {
                    return DRS_db.registrations.OrderBy(r => r.registration_code).Where(r => r.registration_status == 1).OrderBy(r => r.registration_code).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public registration getRegistrationDB(int id)
        {
            try
            {
                registration registration = null;
                registration = db.registrations.Where(r => r.registration_id == id && r.registration_status == 1).FirstOrDefault();
                if (registration == null)
                {
                    registration = new registration();
                }
                return registration;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveRegistrationDB(registration registration)
        {
            try
            {
                int flag = 0;
                registration.registration_code = registration.registration_code.ToUpper();  //search fuction in views only accept Capital letters for vessel Registration
                if (db.registrations.Where(r => r.registration_code.Equals(registration.registration_code) && r.registration_status == 1).FirstOrDefault() == null)
                {
                    db.registrations.Add(registration);
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
        public int updateRegistrationDB(int id, registration registration)
        {
            try
            {
                int flag = 0;
                registration.registration_code = registration.registration_code.ToUpper();  //search fuction in views only accept Capital letters for vessel Registration
                var result = db.registrations.Where(r => r.registration_id == id && r.registration_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(registration).State = EntityState.Modified;
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
        public int deleteRegistrationDB(int id, registration registration)
        {
            try
            {
                int flag = 0;
                var result = db.registrations.Where(r => r.registration_id == id && r.registration_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(registration).State = EntityState.Modified;
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
    }
}