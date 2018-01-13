using System;
using System.Collections.Generic;
using System.Web;
using DRS.DataBase;
using DRS.Services.DistressService;

namespace DRS.ControllerManagers.DistressControllerManager
{
    public class DistressControllerManager
    {
        private DistressService DistressService;

        public DistressControllerManager()
        {
            DistressService = new DistressService();
        }

        //select*method
        public List<distress> getAllDistress()
        {
            try
            {
                return DistressService.getAllDistressDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public distress getDistress(int id)
        {
            try
            {
                return DistressService.getDistressDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveDistress(distress distress)
        {
            try
            {
                distress.distress_created_date = DateTime.Now;
                distress.distress_created_by = HttpContext.Current.User.Identity.Name;
                distress.distress_last_modified_date = DateTime.Now;
                distress.distress_last_modified_by = HttpContext.Current.User.Identity.Name;
                distress.distress_status = 1;

                return DistressService.saveDistressDB(distress);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateDistress(int id, distress distress)
        {
            try
            {
                distress.distress_last_modified_date = DateTime.Now;
                distress.distress_last_modified_by = HttpContext.Current.User.Identity.Name;

                return DistressService.updateDistressDB(id, distress);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteDistress(int id, distress distress)
        {
            try
            {
                distress.distress_last_modified_date = DateTime.Now;
                distress.distress_last_modified_by = HttpContext.Current.User.Identity.Name;
                distress.distress_status = 0;

                return DistressService.deleteDistressDB(id, distress);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}