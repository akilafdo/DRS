using System.Collections.Generic;
using System.Linq;
using DRS.DataBase;
using System.Data.Entity;
using System;

namespace DRS.Services.DistrictsService
{
    public class DistrictsService
    {
        private DRSEntities db;
        public DistrictsService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<district> getAllDistrictsDB()
        {
            try
            {
                using (var DRS_db = new DRSEntities())
                {
                    return DRS_db.districts.OrderBy(d => d.district_code).Where(d => d.district_status == 1).OrderBy(d => d.district_code).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public district getDistrictDB(int id)
        {
            try
            {
                district district = null;
                district = db.districts.Where(d => d.district_id == id && d.district_status == 1).FirstOrDefault();
                if (district == null)
                {
                    district = new district();
                }
                return district;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveDistrictDB(district district)
        {
            try
            {
                int flag = 0;
                district.district_code = district.district_code.ToUpper();  //search funtion in views only accept captal for District code
                if (db.districts.Where(d => d.district_status == 1 && d.district_code.Equals(district.district_code)).FirstOrDefault() == null)
                {
                    db.districts.Add(district);
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
        public int updateDistrictDB(int id, district district)
        {
            try
            {
                int flag = 0;
                district.district_code = district.district_code.ToUpper();  //search funtion in views only accept captal for District code
                var result = db.districts.Where(d => d.district_id == id && d.district_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(district).State = EntityState.Modified;
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
        public int deleteDistrictDB(int id, district district)
        {
            try
            {
                int flag = 0;
                var result = db.districts.Where(d => d.district_id == id && d.district_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(district).State = EntityState.Modified;
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