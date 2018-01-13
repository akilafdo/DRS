using System;
using System.Collections.Generic;
using System.Web;
using DRS.DataBase;
using DRS.Services.DistrictsService;

namespace DRS.ControllerManagers.DistrictsControllerManager
{
    public class DistrictsControllerManager
    {
        private DistrictsService DistrictsService;
        public DistrictsControllerManager()
        {
            DistrictsService = new DistrictsService();
        }

        //select*method
        public List<district> getAllDistricts()
        {
            try
            {
                return DistrictsService.getAllDistrictsDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public district getDistrict(int id)
        {
            try
            {
                return DistrictsService.getDistrictDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveDistrict(district district)
        {
            try
            {
                district.district_created_date = DateTime.Now;
                district.district_created_by = HttpContext.Current.User.Identity.Name;
                district.district_last_modified_date = DateTime.Now;
                district.district_last_modified_by = HttpContext.Current.User.Identity.Name;
                district.district_status = 1;

                return DistrictsService.saveDistrictDB(district);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateDistrict(int id, district district)
        {
            try
            {
                district.district_last_modified_date = DateTime.Now;
                district.district_last_modified_by = HttpContext.Current.User.Identity.Name;

                return DistrictsService.updateDistrictDB(id, district);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete method
        public int deleteDistrict(int id, district district)
        {
            try
            {
                district.district_last_modified_date = DateTime.Now;
                district.district_last_modified_by = HttpContext.Current.User.Identity.Name;
                district.district_status = 0;

                return DistrictsService.deleteDistrictDB(id, district);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}