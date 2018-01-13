using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DRS.DataBase;
using DRS.Enums;

namespace DRS.Services.DistressReportService
{
    public class DistressReportService
    {
        private DRSEntities db;

        public DistressReportService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<d_detail> getAllDistressReportsDB(string SearchText)
        {
            List<d_detail> distressReport = new List<d_detail>();
            try
            {
                if (!string.IsNullOrEmpty(SearchText))
                {
                    distressReport = db.d_detail.Where(d => d.vessel.registration.registration_code.Contains(SearchText.Substring(0, 7))
                    && d.vessel.vessel_no.Contains(SearchText.Substring(7, 4)) && d.vessel.district.district_code.Contains(SearchText.Substring(11, 3))
                    && d.d_detail_status == 1).ToList();
                }
                else
                {
                    distressReport = db.d_detail.OrderBy(d => d.d_detail_last_modified_date).Where(d => d.d_detail_created_date.Year.Equals(DateTime.Now.Year) && d.d_detail_status == 1 || d.d_detail_remarks.Equals("No Remarks")).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return distressReport;
        }

        //select method
        public d_detail getDistressReportDB(int id)
        {
            d_detail d_detail = null;
            try
            {
                d_detail = db.d_detail.Where(d => d.d_detail_id == id && d.d_detail_status == 1).FirstOrDefault();
                if (d_detail == null)
                {
                    d_detail = new d_detail();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return d_detail;
        }

        //create vessel
        public int createVesselDB(vessel_owner_ref vessel_owner_ref)
        {
            int vessel_id = 0;
            try
            {
                vessel getVesselObject = db.vessels.Where(v => v.registration_id == vessel_owner_ref.vessel.registration_id
                && v.vessel_no.Equals(vessel_owner_ref.vessel.vessel_no) && v.district_id == vessel_owner_ref.vessel.district_id
                && v.vessel_status == 1).FirstOrDefault();

                //Vessel is not exist
                if (getVesselObject == null) 
                {
                    db.vessel_owner_ref.Add(vessel_owner_ref);  //Save vessel and owner
                    db.SaveChanges();

                    vessel getAboveVesselObject = db.vessels.Where(v => v.registration_id == vessel_owner_ref.vessel.registration_id
                    && v.vessel_no.Equals(vessel_owner_ref.vessel.vessel_no) && v.district_id == vessel_owner_ref.vessel.district_id
                    && v.vessel_status == 1).FirstOrDefault();

                    vessel_id = getAboveVesselObject.vessel_id;  //return vessel id after the inserted
                }
                //Vessel is exist
                else
                {
                    vessel_id = getVesselObject.vessel_id;  //return vessel id that already created                
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vessel_id;
        }

        //insert method
        public int saveDistressReportDB(d_detail d_detail)
        {
            int flag = 0;
            try
            {
                db.d_detail.Add(d_detail);
                db.SaveChanges();
                flag = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //update method
        public int updateDistressReportDB(int id, d_detail d_detail)
        {
            int flag = 0;
            try
            {
                var result = db.d_detail.Where(d => d.d_detail_id == id && d.d_detail_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(d_detail).State = EntityState.Modified;
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

        //delete method
        public int deleteDistressReportDB(int id, d_detail d_detail)
        {
            int flag = 0;
            try
            {
                var result = db.d_detail.Where(d => d.d_detail_id == id && d.d_detail_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(d_detail).State = EntityState.Modified;
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

        //get Vessel
        public vessel_owner_ref getVesselDB(string SearchText)
        {
            vessel_owner_ref vesselOwner = null;
            try
            {
                vesselOwner = db.vessel_owner_ref.Where(v => v.vessel.vessel_status == 1 && v.vessel.registration.registration_code.Equals(SearchText.Substring(0, 7))
                && v.vessel.vessel_no.Contains(SearchText.Substring(7, 4)) && v.vessel.district.district_code.Contains(SearchText.Substring(11, 3))).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return vesselOwner; 
        }

        //set*Distress
        public SelectList getDistressSelectListDB()
        {
            try
            {
                return new SelectList(db.distresses.Where(d => d.distress_status == 1), "distress_id", "distress_name");
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

        //set Lattitude Directions
        public SelectList getLattitudeDirectionsDB()
        {
            try
            {
                EnumsForViews EnumsForViews = new EnumsForViews();
                return EnumsToSelectList.ToSelectList(typeof(EnumsForViews.LattitudeDirections), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set Longitude Directions
        public SelectList getLongitudeDirectionsDB()
        {
            try
            {
                EnumsForViews EnumsForViews = new EnumsForViews();
                return EnumsToSelectList.ToSelectList(typeof(EnumsForViews.LongDirections), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set*Registrations
        public SelectList getRegistrationSelectListDB()
        {
            try
            {
                return new SelectList(db.registrations.Where(r => r.registration_status == 1), "registration_id", "registration_code");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set*Districts
        public SelectList getDistrictsSelectListDB()
        {
            try
            {
                return new SelectList(db.districts.Where(d => d.district_status == 1), "district_id", "district_code");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set Application Type
        public SelectList getApplicationSelectListDB()
        {
            try
            {
                EnumsForViews EnumsForViews = new EnumsForViews();
                return EnumsToSelectList.ToSelectList(typeof(EnumsForViews.DistressVesselApplicationType), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}