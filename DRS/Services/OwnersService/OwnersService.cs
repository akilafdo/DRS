using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.DataBase;
using DRS.Enums;

namespace DRS.Services.OwnersService
{
    public class OwnersService
    {
        private DRSEntities db;

        public OwnersService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<vessel_owner_ref> getAllOwnersDB()   //get all owners and related vessels
        {
            List<vessel_owner_ref> ownerList = new List<vessel_owner_ref>();
            try
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    ownerList = db.vessel_owner_ref.Where(o => o.owner.owner_status == 1).Distinct().ToList();
                }
                else
                {
                    ownerList = db.vessel_owner_ref.Where(o => o.owner.owner_status == 1 &&
                    o.vessel.registration.registration_code.Equals("IMUL-A-")).Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ownerList;
        }

        //get Owner using Owner Name 
        public List<vessel_owner_ref> getOwnerUsingOwnerName(string searchText)
        {
            List<vessel_owner_ref> Owners = new List<vessel_owner_ref>();
            try
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Owners = db.vessel_owner_ref.Where(o => o.owner.owner_name.Equals(searchText) && o.owner.owner_status == 1).Distinct().ToList();
                }
                else
                {
                    Owners = db.vessel_owner_ref.Where(o => o.owner.owner_name.Equals(searchText) && o.owner.owner_status == 1 &&
                    o.vessel.registration.registration_code.Equals("IMUL-A-")).Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Owners;
        }

        //get Owner using Owner NIC
        public List<vessel_owner_ref> getOwnerUsingOwnerNIC(string searchText)
        {
            List<vessel_owner_ref> Owners = new List<vessel_owner_ref>();
            try
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Owners = db.vessel_owner_ref.Where(o => o.owner.owner_nic.Equals(searchText) && o.owner.owner_status == 1).Distinct().ToList();
                }
                else
                {
                    Owners = db.vessel_owner_ref.Where(o => o.owner.owner_nic.Equals(searchText) && o.owner.owner_status == 1 &&
                    o.vessel.registration.registration_code.Equals("IMUL-A-")).Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Owners;
        }

        //get Owner using Owner Tel
        public List<vessel_owner_ref> getOwnerUsingOwnerTel(string searchText)
        {
            List<vessel_owner_ref> Owners = new List<vessel_owner_ref>();
            try
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Owners = db.vessel_owner_ref.Where(o => o.owner.owner_tele.Equals(searchText) && o.owner.owner_status == 1).Distinct().ToList();
                }
                else
                {
                    Owners = db.vessel_owner_ref.Where(o => o.owner.owner_tele.Equals(searchText) && o.owner.owner_status == 1 &&
                    o.vessel.registration.registration_code.Equals("IMUL-A-")).Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Owners;
        }

        //select*Vessels
        public List<vessel_owner_ref> getAllVesselsDB(int id)   //get all owners and related vessels
        {
            try
            {
                return db.vessel_owner_ref.Where(o => o.owner_id == id && o.vessel.vessel_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public vessel_owner_ref getOwnerDB(int id)
        {
            vessel_owner_ref vessel_owner_ref = null;
            try
            {
                vessel_owner_ref = db.vessel_owner_ref.Where(o => o.owner_id == id && o.owner.owner_status == 1).FirstOrDefault();
                if (vessel_owner_ref == null)
                {
                    vessel_owner_ref = new vessel_owner_ref();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vessel_owner_ref;
        }

        //insert method
        public int saveOwnerDB(vessel_owner_ref vessel_owner_ref)
        {
            int flag = 0;
            try
            {
                var result = db.vessel_owner_ref.Where(o => o.owner.owner_nic == vessel_owner_ref.owner.owner_nic && o.owner.owner_status == 1).FirstOrDefault();
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

        //insert Multiple Vessel
        public int saveMultipleVesselDB(vessel_owner_ref vessel_owner_ref)
        {
            int flag = 0;
            try
            {
                var result = db.vessel_owner_ref.Where(o => o.owner_id == vessel_owner_ref.owner_id && o.owner.owner_status == 1).FirstOrDefault();
                if (result != null)
                {
                    var resultForUniqueVessel = db.vessel_owner_ref.Where(v => v.vessel.registration_id == vessel_owner_ref.vessel.registration_id
                    && v.vessel.vessel_no.Equals(vessel_owner_ref.vessel.vessel_no) && v.vessel.district_id == vessel_owner_ref.vessel.district_id && v.vessel.vessel_status == 1 && v.owner_id == vessel_owner_ref.owner_id).FirstOrDefault();
                    if(resultForUniqueVessel == null)
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
        public int updateOwnerDB(int id, owner owner)
        {
            int flag = 0;
            try
            {
                var result = db.owners.Where(v => v.owner_id == id).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(owner).State = EntityState.Modified;
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
        public int deleteOwnerDB(int id, vessel_owner_ref vessel_owner_ref)
        {
            int flag = 0;
            try
            {
                var result = db.vessel_owner_ref.Where(o => o.owner_id == id).FirstOrDefault();
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
        
        //select only owner object for Multiple Vessel page
        public vessel_owner_ref getOwnerOnlyDB(int id)
        {
            vessel_owner_ref vesselOwnerRef = new vessel_owner_ref();
            try
            {
                vessel_owner_ref owner = db.vessel_owner_ref.Where(o => o.owner_id == id && o.owner.owner_status == 1).FirstOrDefault();
                if (owner != null)
                {
                    vesselOwnerRef.owner = owner.owner;
                    vesselOwnerRef.owner_id = owner.owner_id;
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

        //set Search Owner Type
        public SelectList getSearchOwnerTypeDB()
        {
            try
            {
                EnumsForViews EnumsForViews = new EnumsForViews();
                return EnumsToSelectList.ToSelectList(typeof(EnumsForViews.OwnerSearchType), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}