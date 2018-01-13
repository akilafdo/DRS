using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRS.DataBase;

namespace DRS.Error_Logs
{
    public class AddError
    {
        private DRSEntities db;
        private error_log error;

        public AddError(string controller, string method, string exception)
        {
            db = new DRSEntities();

            error = new error_log();
            error.error_controller_name = controller;
            error.error_method_name = method;
            error.error_exception = exception;
            error.error_remarks = "No Remarks";

            try
            {
                db.error_log.Add(error);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}