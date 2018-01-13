using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DRS.ControllerManagers.RegistrationsControllerManager;
using DRS.DataBase;
using DRS.Error_Logs;

namespace DRS.Controllers
{
    public class RegistrationsController : Controller
    {
        private RegistrationsControllerManager RegistrationsControllerManager;
        public RegistrationsController()
        {
            RegistrationsControllerManager = new RegistrationsControllerManager();
        }

        [Authorize(Roles ="Admin")]
        // GET: Registrations
        public ActionResult Index()
        {
            try
            {
                // Try fetching the results from the cache
                var results = HttpContext.Cache["results"] as IEnumerable<registration>;
                if (results == null)
                {
                    // the results were not found in the cache => invoke the expensive 
                    // operation to fetch them
                    results = RegistrationsControllerManager.getAllRegistrations();

                    // store the results into the cache so that on subsequent calls on this action
                    // the expensive operation would not be called
                    HttpContext.Cache["results"] = results;
                }

                // return the results to the view for displaying
                return View(results);
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Index", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RegistrationsController/Index" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Registrations/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(RegistrationsControllerManager.getRegistration(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Details", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RegistrationsController/Details" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Registrations/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RegistrationsController/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Registrations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = RegistrationsControllerManager.saveRegistration(registration);
                    if (flag == 1)
                    {
                        HttpContext.Cache.Remove("results");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["registration_code"] = "This Registration Code is already taken";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/RegistrationsController/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Registrations/Edit/5
        public ActionResult Edit(int id)
        {
           try
            {
                return View(RegistrationsControllerManager.getRegistration(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RegistrationsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Registrations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = RegistrationsControllerManager.updateRegistration(id, registration);
                    if (flag == 1)
                    {
                        HttpContext.Cache.Remove("results");
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/RegistrationsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Registrations/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(RegistrationsControllerManager.getRegistration(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RegistrationsController/Delete" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Registrations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = RegistrationsControllerManager.deleteRegistration(id, registration);
                    if (flag == 1)
                    {
                        HttpContext.Cache.Remove("results");
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RegistrationsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/RegistrationsController/Delete" });
            }
        }
    }
}
