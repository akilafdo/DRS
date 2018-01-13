using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.DataBase;
using DRS.Services.UsersService;

namespace DRS.ControllerManagers.UsersControllerManager
{
    public class UsersControllerManager
    {
        private UsersService UsersService;

        public UsersControllerManager()
        {
            UsersService = new UsersService();
        }

        //select*method
        public List<user> getAllUsers()
        {
            try
            {
                return UsersService.getAllUsersDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public user getUser(int id)
        {
            try
            {
                return UsersService.getUserDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveUser(user user)
        {
            try
            {
                user.user_created_date = DateTime.Now;
                user.user_created_by = HttpContext.Current.User.Identity.Name;
                user.user_last_modified_date = DateTime.Now;
                user.user_last_modified_by = HttpContext.Current.User.Identity.Name;
                user.user_status = 1;

                return UsersService.saveUserDB(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateUser(int id, user user)
        {
            try
            {
                user.user_last_modified_date = DateTime.Now;
                user.user_last_modified_by = HttpContext.Current.User.Identity.Name;

                return UsersService.updateUserDB(id, user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteUser(int id, user user)
        {
            try
            {
                user.user_last_modified_date = DateTime.Now;
                user.user_last_modified_by = HttpContext.Current.User.Identity.Name;
                user.user_status = 0;

                return UsersService.deleteUserDB(id, user);
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
                return UsersService.getRadioStationsSelectListDB();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}