using System;
using System.Collections.Generic;
using System.Web;
using DRS.DataBase;
using DRS.Services.RegistrationsService;

namespace DRS.ControllerManagers.RegistrationsControllerManager
{
    public class RegistrationsControllerManager
    {
        private RegistrationsService RegistrationsService;
        public RegistrationsControllerManager()
        {
            try
            {
                RegistrationsService = new RegistrationsService();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select*method
        public List<registration> getAllRegistrations()
        {
            try
            {
                return RegistrationsService.getAllRegistrationsDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public registration getRegistration(int id)
        {
            try
            {
                return RegistrationsService.getRegistrationDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveRegistration(registration registration)
        {
            try
            {
                registration.registration_created_date = DateTime.Now;
                registration.registration_created_by = HttpContext.Current.User.Identity.Name;
                registration.registration_last_modified_date = DateTime.Now;
                registration.registration_last_modified_by = HttpContext.Current.User.Identity.Name;
                registration.registration_status = 1;

                return RegistrationsService.saveRegistrationDB(registration);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateRegistration(int id, registration registration)
        {
            try
            {
                registration.registration_last_modified_date = DateTime.Now;
                registration.registration_last_modified_by = HttpContext.Current.User.Identity.Name;

                return RegistrationsService.updateRegistrationDB(id, registration);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteRegistration(int id, registration registration)
        {
            try
            {
                registration.registration_last_modified_date = DateTime.Now;
                registration.registration_last_modified_by = HttpContext.Current.User.Identity.Name;
                registration.registration_status = 0;

                return RegistrationsService.deleteRegistrationDB(id, registration);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}