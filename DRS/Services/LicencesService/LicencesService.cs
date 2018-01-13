using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DRS.DataBase;

namespace DRS.Services.LicencesService
{
    public class LicencesService
    {
        private DRSEntities db;

        public LicencesService()
        {
            db = new DRSEntities();
        }

        //select*method
        public List<licence> getAllLicencesDB(string SearchText)   //get all vessels and related owners
        {
            List<licence> License = new List<licence>();
            try
            {
                if (!string.IsNullOrEmpty(SearchText))
                {
                    License = db.licences.Where(l => l.licence_status == 1 && l.vessel.registration.registration_code.Equals("IMUL-A-")
                    && l.vessel.vessel_no.Contains(SearchText.Substring(7, 4)) && l.vessel.district.district_code.Contains(SearchText.Substring(11, 3))).ToList();
                }
                else
                {
                    License = db.licences.Where(l => l.licence_status == 1 && l.vessel.registration.registration_code.Equals("IMUL-A-")).OrderBy(l => l.licence_date_to).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return License;
        }

        //select method
        public licence getLicenceDB(int id)
        {
            licence licence = null;
            try
            {
                licence = db.licences.Where(l => l.licence_status == 1 && l.licence_id == id).FirstOrDefault();
                if (licence == null)
                {
                    licence = new licence();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return licence;
        }

        //insert method
        public int saveLicencesDB(licence licence)
        {
            int flag = 0;
            try
            {
                var result = db.licences.Where(l => l.licence_callsign.Equals(licence.licence_callsign) || l.licence_trc_fileno.Equals(licence.licence_trc_fileno) && l.licence_status == 1).FirstOrDefault();

                if (result == null)
                {
                    db.licences.Add(licence);
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

        //insert invoice state method
        public int InvoiceStateCreateDB(licence licence)
        {
            int flag = 0;
            try
            {
                var result = db.licences.Where(l => l.licence_trc_fileno.Equals(licence.licence_trc_fileno) && l.licence_status == 1).FirstOrDefault();

                if (result == null)
                {
                    db.licences.Add(licence);
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

        //update exist method
        public int updateExistLicenceDB(licence licence, int licence_id)
        {
            int flag = 0;
            try
            {
                var updateResult = db.licences.Where(l => l.licence_callsign.Equals(licence.licence_callsign) && l.licence_status == 1).FirstOrDefault();
                //Update license Date from and Date to using adding new license record
                if (updateResult != null)
                {
                    db.licences.Add(licence);
                    db.SaveChanges();
                    flag = 1;
                }

                licence existLicence = db.licences.Where(l => l.vessel_id == licence.vessel_id && l.licence_id == licence_id && l.licence_status == 1).FirstOrDefault();
                //The previous license status will change to '0' using 'license_id' to avoid displaying two or more license for one vessel
                if (existLicence != null)
                {
                    existLicence.licence_status = 0;

                    db.licences.Attach(existLicence);
                    db.Entry(existLicence).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = flag + 1;    //Controller will return '2' as int value to prove that the license status has been change to '0'
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //update method
        public int updateLicenceDB(int id, licence licence)
        {
            int flag = 0;
            try
            {
                var result = db.licences.Where(l => l.licence_id == id && l.licence_status == 1);
                if (result != null)
                {
                    var callsignOrTrcNo = db.licences.Where(l => l.licence_callsign.Equals(licence.licence_callsign) && l.licence_status == 1).FirstOrDefault();
                    if(callsignOrTrcNo == null)
                    {
                        db.Entry(result).State = EntityState.Detached;
                        db.Entry(licence).State = EntityState.Modified;
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

        //delete method
        public int deleteLicenceDB(int id, licence licence)
        {
            int flag = 0;
            try
            {
                var result = db.licences.Where(l => l.licence_id == id && l.licence_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(licence).State = EntityState.Modified;
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

        //get PDF method
        public List<vessel_owner_ref> getPDFVesselListDB(string vesselList)
        {
            vessel_owner_ref vessel_owner_ref = null;
            List<vessel_owner_ref> VesselList = new List<vessel_owner_ref>();
            try
            {
                if (!string.IsNullOrEmpty(vesselList))
                {
                    List<string> vessels = vesselList.Split(',').ToList<string>();
                    foreach (string item in vessels)
                    {
                        if (item.Length == 14)
                        {
                            vessel_owner_ref = db.vessel_owner_ref.Where(v => v.vessel.registration.registration_code.Equals("IMUL-A-") && v.vessel.vessel_no.Equals(item.Substring(7, 4))
                            && v.vessel.district.district_code.Equals(item.Substring(11, 3).ToUpper())).FirstOrDefault();
                            if (vessel_owner_ref != null)
                            {
                                VesselList.Add(vessel_owner_ref);
                            }
                        }
                    }
                    VesselList.Sort((x, y) => x.vessel.vessel_pending_approval.CompareTo(y.vessel.vessel_pending_approval));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return VesselList;
        }

        //get Vessel Id For Renewal
        public licence getVesselIdForRenewalDB(string SearchText)
        {
            licence licence = new licence();
            try
            {
                vessel Vessel = db.vessels.Where(v => v.vessel_status == 1 && v.registration.registration_code.Equals("IMUL-A-")
                && v.vessel_no.Contains(SearchText.Substring(7, 4)) && v.district.district_code.Contains(SearchText.Substring(11, 3))).FirstOrDefault();
                //get the vessel object according to the searchText and that vessel_id will set to a new licence's vessel_id
                if (Vessel != null)
                {
                    if (Vessel.vessel_id != 0)
                    {
                        licence.vessel_id = Vessel.vessel_id;    //return vessel_id fixed licence object to the view
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return licence;
        }

        //get Vessel Id For Invoice State
        public licence getVesselIdForInvoiceDB(string SearchText)
        {
            licence licence = new licence();
            try
            {
                vessel Vessel = db.vessels.Where(v => v.vessel_status == 1 && v.registration.registration_code.Equals("IMUL-A-")
                && v.vessel_no.Contains(SearchText.Substring(7, 4)) && v.district.district_code.Contains(SearchText.Substring(11, 3))).FirstOrDefault();
                //get the vessel object according to the searchText and that vessel_id will set to a new licence's vessel_id
                if (Vessel != null)
                {
                    if (Vessel.vessel_id != 0)
                    {
                        licence.vessel_id = Vessel.vessel_id;    //return vessel_id fixed licence object to the view
                        licence.licence_callsign = "Pending";   //This is only for InvoiceState
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return licence;
        }
    }
}