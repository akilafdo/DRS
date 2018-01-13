using DRS.Services.OwnersService;
using System.Collections.Generic;
using DRS.DataBase;
using System.Web.Mvc;
using System;
using System.Web;

namespace DRS.ControllerManagers.OwnersControllerManager
{
    public class OwnersControllerManager
    {
        private OwnersService OwnersService;

        public OwnersControllerManager()
        {
            OwnersService = new OwnersService();
        }

        //select*method for Index page without search type and search string
        public List<vessel_owner_ref> getOwnersICollection()
        {
            try
            {
                return OwnersService.getAllOwnersDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select*method for Index page with search type and search string
        public List<vessel_owner_ref> getAllOwners(string SearchType, string SearchText)
        {
            List<vessel_owner_ref> Owners = null;
            try
            {
                if (SearchType.Equals("1"))
                {
                    Owners = OwnersService.getOwnerUsingOwnerName(SearchText);
                }
                else if (SearchType.Equals("2"))
                {
                    Owners = OwnersService.getOwnerUsingOwnerNIC(SearchText);
                }
                else if (SearchType.Equals("3"))
                {
                    Owners = OwnersService.getOwnerUsingOwnerTel(SearchText);
                }
                else
                {
                    Owners = OwnersService.getAllOwnersDB();    //if url parameter contains user-modified value this will return all owners
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Owners;
        }

        //select*Vessels
        public List<vessel_owner_ref> getAllVessels(int id)
        {
            try
            {
                return OwnersService.getAllVesselsDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public vessel_owner_ref getOwner(int id)
        {
            try
            {
                return OwnersService.getOwnerDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveOwner(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                vessel_owner_ref.owner.owner_created_date = DateTime.Now;
                vessel_owner_ref.owner.owner_created_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_last_modified_date = DateTime.Now;
                vessel_owner_ref.owner.owner_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_status = 1;

                return OwnersService.saveOwnerDB(vessel_owner_ref);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert Multiple Vessel
        public int saveMultipleVessel(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                vessel_owner_ref.vessel.vessel_created_date = DateTime.Now;
                vessel_owner_ref.vessel.vessel_created_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.vessel.vessel_last_modified_date = DateTime.Now;
                vessel_owner_ref.vessel.vessel_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.vessel.vessel_status = 1;

                return OwnersService.saveMultipleVesselDB(vessel_owner_ref);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateOwner(int id, owner owner)
        {
            try
            {
                owner.owner_last_modified_date = DateTime.Now;
                owner.owner_last_modified_by = HttpContext.Current.User.Identity.Name;

                return OwnersService.updateOwnerDB(id, owner);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteOwner(int id)
        {
            try
            {
                vessel_owner_ref vessel_owner_ref = OwnersService.getOwnerDB(id);  //get the existing vessel_owner_ref object to modify its status

                vessel_owner_ref.owner.owner_last_modified_date = DateTime.Now;
                vessel_owner_ref.owner.owner_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_status = 0;

                return OwnersService.deleteOwnerDB(id, vessel_owner_ref);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select only owner object for Multiple Vessel page
        public vessel_owner_ref getOwnerOnly(int id)
        {
            try
            {
                return OwnersService.getOwnerOnlyDB(id);
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
                return OwnersService.getRegistrationSelectListDB();
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
                return OwnersService.getDistrictsSelectListDB();
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
                return OwnersService.getApplicationSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set Search OwnerType
        public SelectList getSearchOwnerTypeSelectList()
        {
            try
            {
                return OwnersService.getSearchOwnerTypeDB();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}