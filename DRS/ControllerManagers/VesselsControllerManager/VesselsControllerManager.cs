using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DRS.DataBase;
using DRS.Services.VesselsService;

namespace DRS.ControllerManagers.VesselsControllerManager
{
    public class VesselsControllerManager
    {
        private VesselsService VesselsService;
        public VesselsControllerManager()
        {
            VesselsService = new VesselsService();
        }

        //select*method
        public List<vessel> getAllIMULAVessels(string SearchText)
        {
            try
            {
                return VesselsService.getAllIMULAVesselsDB(SearchText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select*Owners
        public List<vessel_owner_ref> getAllOwnersOfTheVessels(int id)
        {
            try
            {
                return VesselsService.getAllOwnersOfTheVesselsDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public vessel_owner_ref getVessel(int id)
        {
            try
            {
                return VesselsService.getVesselDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveVessel(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                //Vessel Data
                vessel_owner_ref.vessel.vessel_created_date = DateTime.Now;
                vessel_owner_ref.vessel.vessel_created_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.vessel.vessel_last_modified_date = DateTime.Now;
                vessel_owner_ref.vessel.vessel_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.vessel.vessel_status = 1;
                //Owner Data
                vessel_owner_ref.owner.owner_created_date = DateTime.Now;
                vessel_owner_ref.owner.owner_created_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_last_modified_date = DateTime.Now;
                vessel_owner_ref.owner.owner_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_status = 1;

                return VesselsService.saveVesselDB(vessel_owner_ref);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert Shared Ownership
        public int saveSharedOwnership(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                vessel_owner_ref.owner.owner_created_date = DateTime.Now;
                vessel_owner_ref.owner.owner_created_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_last_modified_date = DateTime.Now;
                vessel_owner_ref.owner.owner_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_status = 1;

                return VesselsService.saveSharedOwnershipDB(vessel_owner_ref);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateVessel(int id, vessel vessel)
        {
            try
            {
                vessel.vessel_last_modified_date = DateTime.Now;
                vessel.vessel_last_modified_by = HttpContext.Current.User.Identity.Name;

                return VesselsService.updateVesselDB(id, vessel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteVessel(int id)
        {
            try
            {
                vessel_owner_ref vessel_owner_ref = VesselsService.getVesselDB(id);  //get the existing vessel_owner_ref object to modify its status

                vessel_owner_ref.vessel.vessel_last_modified_date = DateTime.Now;
                vessel_owner_ref.vessel.vessel_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.vessel.vessel_status = 0;

                return VesselsService.deleteVesselDB(id, vessel_owner_ref);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select only vessel object for shared ownership page
        public vessel_owner_ref getVesselOnly(int id)
        {
            try
            {
                return VesselsService.getVesselOnlyDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set*Registrations
        public SelectList getRegistrationSelectList()
        {
            try
            {
                return VesselsService.getRegistrationSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set*Districts
        public SelectList getDistrictsSelectList()
        {
            try
            {
                return VesselsService.getDistrictsSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set Application Type
        public SelectList getApplicationSelectList()
        {
            try
            {
                return VesselsService.getApplicationSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}