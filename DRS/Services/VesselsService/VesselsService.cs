using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.DataBase;
using DRS.Enums;

namespace DRS.Services.VesselsService
{
    public class VesselsService
    {
        private DRSEntities db;

        public VesselsService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<vessel> getAllIMULAVesselsDB(string SearchText)
        {
            try
            {
                List<vessel> Vessels = new List<vessel>();

                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    if (!string.IsNullOrEmpty(SearchText))
                    {
                        Vessels = db.vessels.Where(v => v.vessel_status == 1 && v.registration.registration_code.Equals(SearchText.Substring(0, 7))
                        && v.vessel_no.Contains(SearchText.Substring(7, 4)) && v.district.district_code.Contains(SearchText.Substring(11, 3))).ToList();
                    }
                    else
                    {
                        Vessels = db.vessels.Where(v => v.vessel_status == 1).OrderBy(v => v.registration.registration_code).ToList();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(SearchText))
                    {
                        Vessels = db.vessels.Where(v => v.vessel_status == 1 && v.registration.registration_code.Equals("IMUL-A-")
                        && v.vessel_no.Contains(SearchText.Substring(7, 4)) && v.district.district_code.Contains(SearchText.Substring(11, 3))).ToList();
                    }
                    else
                    {
                        Vessels = db.vessels.Where(v => v.vessel_status == 1 && v.registration.registration_code.Equals("IMUL-A-")).OrderBy(v => v.vessel_no).ToList();
                    }
                }

                return Vessels;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select*Owners
        public List<vessel_owner_ref> getAllOwnersOfTheVesselsDB(int id)
        {
           try
            {
                return db.vessel_owner_ref.Where(v => v.vessel_id == id && v.owner.owner_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public vessel_owner_ref getVesselDB(int id)
        {
            vessel_owner_ref vessel_owner_ref = null;
            try
            {
                vessel_owner_ref = db.vessel_owner_ref.Where(v => v.vessel_id == id).FirstOrDefault();
                if (vessel_owner_ref == null)
                {
                    vessel_owner_ref = new vessel_owner_ref();
                }
                return vessel_owner_ref;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveVesselDB(vessel_owner_ref vessel_owner_ref)
        {
            int flag = 0;
            try
            {
                var result = db.vessel_owner_ref.Where(v => v.vessel.registration_id == vessel_owner_ref.vessel.registration_id
                && v.vessel.vessel_no.Equals(vessel_owner_ref.vessel.vessel_no) && v.vessel.district_id == vessel_owner_ref.vessel.district_id && v.vessel.vessel_status == 1).FirstOrDefault();

                if (result == null)
                {
                    db.vessel_owner_ref.Add(vessel_owner_ref);
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

        //insert Shared Ownership
        public int saveSharedOwnershipDB(vessel_owner_ref vessel_owner_ref)
        {
            int flag = 0;
            try
            {
                var result = db.vessel_owner_ref.Where(v => v.vessel_id == vessel_owner_ref.vessel_id && v.vessel.vessel_status == 1).FirstOrDefault();
                if (result != null)
                {
                    var resultForUniqueOwner = db.vessel_owner_ref.Where(o => o.owner.owner_nic == vessel_owner_ref.owner.owner_nic && o.owner.owner_status == 1 && o.vessel_id == vessel_owner_ref.vessel_id).FirstOrDefault();
                    if (resultForUniqueOwner == null)
                    {
                        db.vessel_owner_ref.Add(vessel_owner_ref);
                        db.SaveChanges();
                        flag = 1;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //update method
        public int updateVesselDB(int id, vessel vessel)
        {
            int flag = 0;
            try
            {
                var result = db.vessels.Where(v => v.vessel_id == id).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(vessel).State = EntityState.Modified;
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
        public int deleteVesselDB(int id, vessel_owner_ref vessel_owner_ref)
        {
            int flag = 0;
            try
            {
                var result = db.vessel_owner_ref.Where(v => v.vessel_id == id).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(vessel_owner_ref).State = EntityState.Modified;
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

        //select only vessel object for shared ownership page
        public vessel_owner_ref getVesselOnlyDB(int id)
        {
            vessel_owner_ref vesselOwnerRef = new vessel_owner_ref();
            try
            {
                vessel_owner_ref vessel = db.vessel_owner_ref.Where(v => v.vessel_id == id && v.vessel.vessel_status == 1).FirstOrDefault();
                if (vessel != null)
                {
                    //This will map only vessel object to new vessel_owner_ref
                    vesselOwnerRef.vessel = vessel.vessel;
                    vesselOwnerRef.vessel_id = vessel.vessel_id;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vesselOwnerRef;
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
                return EnumsToSelectList.ToSelectList(typeof(EnumsForViews.VesselApplicationType), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}