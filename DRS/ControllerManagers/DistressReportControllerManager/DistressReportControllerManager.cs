using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DRS.DataBase;
using DRS.Services.DistressReportService;

namespace DRS.ControllerManagers.DistressReportControllerManager
{
    public class DistressReportControllerManager
    {
        private DistressReportService DistressReportService;

        public DistressReportControllerManager()
        {
            DistressReportService = new DistressReportService();
        }

        //select*method
        public List<d_detail> getAllDistressReports(string SearchText)
        {
            try
            {
                return DistressReportService.getAllDistressReportsDB(SearchText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public d_detail getDistressReport(int id)
        {
            try
            {
                return DistressReportService.getDistressReportDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //create vessel
        public int createVessel(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                vessel_owner_ref.vessel.vessel_created_date = DateTime.Now;
                vessel_owner_ref.vessel.vessel_created_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.vessel.vessel_last_modified_date = DateTime.Now;
                vessel_owner_ref.vessel.vessel_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.vessel.vessel_status = 1;

                vessel_owner_ref.owner.owner_created_date = DateTime.Now;
                vessel_owner_ref.owner.owner_created_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_last_modified_date = DateTime.Now;
                vessel_owner_ref.owner.owner_last_modified_by = HttpContext.Current.User.Identity.Name;
                vessel_owner_ref.owner.owner_status = 1;

                return DistressReportService.createVesselDB(vessel_owner_ref);  //this method will not return flag but vessel_id
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveDistressReport(d_detail d_detail)
        {
            try
            {
                d_detail.d_detail_created_date = DateTime.Now;
                d_detail.d_detail_created_by = HttpContext.Current.User.Identity.Name;
                d_detail.d_detail_last_modified_date = DateTime.Now;
                d_detail.d_detail_last_modified_by = HttpContext.Current.User.Identity.Name;
                d_detail.d_detail_status = 1;

                return DistressReportService.saveDistressReportDB(d_detail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateDistressReport(int id, d_detail d_detail)
        {
            try
            {
                d_detail.d_detail_last_modified_date = DateTime.Now;
                d_detail.d_detail_last_modified_by = HttpContext.Current.User.Identity.Name;

                return DistressReportService.updateDistressReportDB(id, d_detail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteDistressReport(int id, d_detail d_detail)
        {
            try
            {
                d_detail.d_detail_last_modified_date = DateTime.Now;
                d_detail.d_detail_last_modified_by = HttpContext.Current.User.Identity.Name;
                d_detail.d_detail_status = 0;

                return DistressReportService.deleteDistressReportDB(id, d_detail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get Vessel
        public vessel_owner_ref getVessel(string SearchText)
        {
            try
            {
                return DistressReportService.getVesselDB(SearchText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get owner data to Fax Message
        public owner getgetOwnerForFax(int distressReportId)
        {
            try
            {
                return DistressReportService.getOwnerForFaxDB(distressReportId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set*Distress
        public SelectList getDistressSelectList()
        {
            try
            {
                return DistressReportService.getDistressSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set*Radio Stations
        public SelectList getRadioStationsSelectList()
        {
            try
            {
                return DistressReportService.getRadioStationsSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set Lattitude Directions
        public SelectList getLattitudeDirectionsSelectList()
        {
            try
            {
                return DistressReportService.getLattitudeDirectionsDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //set Longitude Directions
        public SelectList getLongitudeDirectionsSelectList()
        {
            try
            {
                return DistressReportService.getLongitudeDirectionsDB();
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
                return DistressReportService.getRegistrationSelectListDB();
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
                return DistressReportService.getDistrictsSelectListDB();
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
                return DistressReportService.getApplicationSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}