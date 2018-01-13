using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.ControllerManagers.RadioStationControllerManager;
using DRS.DataBase;
using DRS.Error_Logs;

namespace DRS.Controllers
{
    public class RadioStationsController : Controller
    {
        private RadioStationsControllerManager RadioStationsControllerManager;

        public RadioStationsController()
        {
            RadioStationsControllerManager = new RadioStationsControllerManager();
        }

        [Authorize(Roles = "Admin,User")]
        // GET: RadioStations
        public ActionResult Index()
        {
            try
            {
                return View(RadioStationsControllerManager.getAllRadioStations());
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Index", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStationsController/Index" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        // GET: RadioStations/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(RadioStationsControllerManager.getRadioStation(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Details", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStationsController/Details" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: RadioStations/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStationsController/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: RadioStations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(radio_station radio_station)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = RadioStationsControllerManager.saveRadioStation(radio_station);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["mcs_callsign"] = "This MCS Center Callsign is already taken";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/RadioStationsController/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: RadioStations/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(RadioStationsControllerManager.getRadioStation(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStationsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: RadioStations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, radio_station radio_station)
        {
            try
            {
                int flag = RadioStationsControllerManager.updateRadioStation(id, radio_station);
                if (flag == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/RadioStationsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: RadioStations/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(RadioStationsControllerManager.getRadioStation(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStationsController/Delete" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: RadioStations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, radio_station radio_station)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RadioStationsControllerManager.deleteRadioStation(id, radio_station);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("RadioStationsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/RadioStationsController/Delete" });
            }
        }
    }
}
