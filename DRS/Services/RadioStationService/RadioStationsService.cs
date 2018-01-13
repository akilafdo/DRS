using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DRS.DataBase;

namespace DRS.Services.RadioStationService
{
    public class RadioStationsService
    {
        private DRSEntities db;

        public RadioStationsService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<radio_station> getAllRadioStationsDB()
        {
            List<radio_station> radioStations = new List<radio_station>();
            try
            {
                radioStations = db.radio_station.Where(r => r.mcs_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return radioStations;
        }

        //select method
        public radio_station getRadioStationDB(int id)
        {
            radio_station radioStation = null;
            try
            {
                radioStation = db.radio_station.Where(r => r.mcs_id == id && r.mcs_status == 1).FirstOrDefault();
                if (radioStation == null)
                {
                    radioStation = new radio_station();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return radioStation;
        }

        //insert method
        public int saveRadioStationDB(radio_station radio_station)
        {
            int flag = 0;
            try
            {
                var result = db.radio_station.Where(r => r.mcs_status == 1 && r.mcs_callsign.Equals(radio_station.mcs_callsign)).FirstOrDefault();
                if (result == null)
                {
                    db.radio_station.Add(radio_station);
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

        //update method
        public int updateRadioStationDB(int id, radio_station radio_station)
        {
            int flag = 0;
            try
            {
                var result = db.radio_station.Where(r => r.mcs_id == id && r.mcs_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(radio_station).State = EntityState.Modified;
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
        public int deleteRadioStationDB(int id, radio_station radio_station)
        {
            int flag = 0;
            try
            {
                var result = db.radio_station.Where(r => r.mcs_id == id && r.mcs_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(radio_station).State = EntityState.Modified;
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
    }
}