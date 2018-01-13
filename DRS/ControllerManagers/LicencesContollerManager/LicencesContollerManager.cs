using System;
using System.Collections.Generic;
using System.Web;
using DRS.DataBase;
using DRS.Services.LicencesService;

namespace DRS.ControllerManagers.LicencesContollerManager
{
    public class LicencesContollerManager
    {
        private LicencesService LicencesService;
        public LicencesContollerManager()
        {
            LicencesService = new LicencesService();
        }

        //select*method
        public List<licence> getAllLicences(string SearchText)
        {
            try
            {
                return LicencesService.getAllLicencesDB(SearchText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public licence getLicence(int id)
        {
            try
            {
                return LicencesService.getLicenceDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveLicence(licence licence)
        {
            try
            {
                licence.licence_created_date = DateTime.Now;
                licence.licence_created_by = HttpContext.Current.User.Identity.Name;
                licence.licence_last_modified_date = DateTime.Now;
                licence.licence_last_modified_by = HttpContext.Current.User.Identity.Name;
                licence.licence_status = 1;

                return LicencesService.saveLicencesDB(licence);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert invoice state method
        public int InvoiceStateCreate(licence licence)  //Callsign = "Pending"
        {
            try
            {
                licence.licence_created_date = DateTime.Now;
                licence.licence_created_by = HttpContext.Current.User.Identity.Name;
                licence.licence_last_modified_date = DateTime.Now;
                licence.licence_last_modified_by = HttpContext.Current.User.Identity.Name;
                licence.licence_status = 1;

                return LicencesService.InvoiceStateCreateDB(licence);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update exist method
        public int updateExistLicence(licence licence, int licence_id)
        {
            try
            {
                licence.licence_created_date = DateTime.Now;
                licence.licence_created_by = HttpContext.Current.User.Identity.Name;
                licence.licence_last_modified_date = DateTime.Now;
                licence.licence_last_modified_by = HttpContext.Current.User.Identity.Name;
                licence.licence_status = 1;

                return LicencesService.updateExistLicenceDB(licence, licence_id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateLicence(int id, licence licence)
        {
            try
            {
                licence.licence_last_modified_date = DateTime.Now;
                licence.licence_last_modified_by = HttpContext.Current.User.Identity.Name;

                return LicencesService.updateLicenceDB(id, licence);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteLicence(int id, licence licence)
        {
            try
            {
                licence.licence_last_modified_date = DateTime.Now;
                licence.licence_last_modified_by = HttpContext.Current.User.Identity.Name;
                licence.licence_status = 0;

                return LicencesService.deleteLicenceDB(id, licence);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get application vessels method
        public List<vessel_owner_ref> getPDFVesselList(string vesselList)
        {
            try
            {
                return LicencesService.getPDFVesselListDB(vesselList);
            }
            catch(Exception)
            {
                throw;
            }
        }

        //get Vessel Id For Renewal
        public licence getVesselIdForRenewal(string SearchText)
        {
            try
            {
                return LicencesService.getVesselIdForRenewalDB(SearchText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get Vessel Id For Invoice State
        public licence getVesselIdForInvoice(string SearchText)
        {
            try
            {
                return LicencesService.getVesselIdForInvoiceDB(SearchText);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}