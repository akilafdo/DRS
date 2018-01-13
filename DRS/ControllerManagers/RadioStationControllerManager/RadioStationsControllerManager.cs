using System;
using System.Collections.Generic;
using System.Web;
using DRS.DataBase;
using DRS.Services.RadioStationService;

namespace DRS.ControllerManagers.RadioStationControllerManager
{
    public class RadioStationsControllerManager
    {
        private RadioStationsService RadioStationsService;

        public RadioStationsControllerManager()
        {
            RadioStationsService = new RadioStationsService();
        }

        //select*method
        public List<radio_station> getAllRadioStations()
        {
            try
            {
                return RadioStationsService.getAllRadioStationsDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public radio_station getRadioStation(int id)
        {
            try
            {
                return RadioStationsService.getRadioStationDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveRadioStation(radio_station radio_station)
        {
            try
            {
                radio_station.mcs_created_date = DateTime.Now;
                radio_station.mcs_created_by = HttpContext.Current.User.Identity.Name;
                radio_station.mcs_last_modified_date = DateTime.Now;
                radio_station.mcs_last_modified_by = HttpContext.Current.User.Identity.Name;
                radio_station.mcs_status = 1;

                return RadioStationsService.saveRadioStationDB(radio_station);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateRadioStation(int id, radio_station radio_station)
        {
            try
            {
                radio_station.mcs_last_modified_date = DateTime.Now;
                radio_station.mcs_last_modified_by = HttpContext.Current.User.Identity.Name;

                return RadioStationsService.updateRadioStationDB(id, radio_station);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteRadioStation(int id, radio_station radio_station)
        {
            try
            {
                radio_station.mcs_last_modified_date = DateTime.Now;
                radio_station.mcs_last_modified_by = HttpContext.Current.User.Identity.Name;
                radio_station.mcs_status = 0;

                return RadioStationsService.deleteRadioStationDB(id, radio_station);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}