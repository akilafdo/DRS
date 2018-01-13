using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DRS.ControllerManagers.DistrictsControllerManager;
using DRS.DataBase;
using DRS.Error_Logs;

namespace DRS.Controllers
{
    public class DistrictsController : Controller
    {
        private DistrictsControllerManager DistrictsControllerManager;
        public DistrictsController()
        {
            DistrictsControllerManager = new DistrictsControllerManager();
        }

        [Authorize(Roles ="Admin")]
        // GET: Districts
        public ActionResult Index()
        {
            try
            {
                // Try fetching the results from the cache
                var results = HttpContext.Cache["results"] as IEnumerable<district>;
                if (results == null)
                {
                    // the results were not found in the cache => invoke the expensive 
                    // operation to fetch them
                    results = DistrictsControllerManager.getAllDistricts();

                    // store the results into the cache so that on subsequent calls on this action
                    // the expensive operation would not be called
                    HttpContext.Cache["results"] = results;
                }

                // return the results to the view for displaying
                return View(results);
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("DistrictsController", "Index", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/DistrictsController/Index" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Districts/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(DistrictsControllerManager.getDistrict(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("DistrictsController", "Details", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/DistrictsController/Details" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Districts/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("DistrictsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/DistrictsController/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Districts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(district district)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistrictsControllerManager.saveDistrict(district);
                    if (flag == 1)
                    {
                        HttpContext.Cache.Remove("results");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["district_code"] = "This District is already taken";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("DistrictsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/DistrictsController/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Districts/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(DistrictsControllerManager.getDistrict(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("DistrictsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/DistrictsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Districts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, district district)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistrictsControllerManager.updateDistrict(id, district);
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
                AddError AddError = new AddError("DistrictsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/DistrictsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Districts/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(DistrictsControllerManager.getDistrict(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("DistrictsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/DistrictsController/Delete" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Districts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, district district)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistrictsControllerManager.deleteDistrict(id, district);
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
                AddError AddError = new AddError("DistrictsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/DistrictsController/Delete" });
            }
        }
    }
}
