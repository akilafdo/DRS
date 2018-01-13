using System;
using System.Web.Mvc;
using DRS.ControllerManagers.VesselsControllerManager;
using DRS.DataBase;
using DRS.Error_Logs;

namespace DRS.Controllers
{
    public class VesselsController : Controller
    {
        private VesselsControllerManager VesselsControllerManager;

        public VesselsController()
        {
            VesselsControllerManager = new VesselsControllerManager();
        }

        [Authorize(Roles ="Admin,Officer")]
        // GET: Vessels
        public ActionResult Index(string SearchText)
        {
           try
            {
                return View(VesselsControllerManager.getAllIMULAVessels(SearchText));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Index", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/VesselsController/Index" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Vessels/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(VesselsControllerManager.getVessel(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Details", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/VesselsController/Details" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //GET: Vessels/Owners
        public ActionResult Owners(int id)
        {
            try
            {
                return View(VesselsControllerManager.getAllOwnersOfTheVessels(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Owners", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/VesselsController/Owners" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //GET: Vessels/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Registration = VesselsControllerManager.getRegistrationSelectList();
                ViewBag.Districts = VesselsControllerManager.getDistrictsSelectList();
                ViewBag.Applications = VesselsControllerManager.getApplicationSelectList();
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/VesselsController/Create" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //POST: Vessels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int status = VesselsControllerManager.saveVessel(vessel_owner_ref);
                    if (status == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["vessel_no"] = "This Vessel is already taken";
                        ViewBag.Registration = VesselsControllerManager.getRegistrationSelectList();
                        ViewBag.Districts = VesselsControllerManager.getDistrictsSelectList();
                        ViewBag.Applications = VesselsControllerManager.getApplicationSelectList();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Create", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/VesselsController/Create" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //GET: Vessels/SharedOwnership
        public ActionResult SharedOwnership(int id)
        {
            try
            {
                return View(VesselsControllerManager.getVesselOnly(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "SharedOwnership", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/VesselsController/SharedOwnership" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //POST: Vessels/SharedOwnership
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SharedOwnership(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int status = VesselsControllerManager.saveSharedOwnership(vessel_owner_ref);
                    if (status == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["owner_nic"] = "This Owner is already assign for this vessel";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "SharedOwnership", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/VesselsController/SharedOwnership" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //GET: Vessel/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Registration = VesselsControllerManager.getRegistrationSelectList();
                ViewBag.Districts = VesselsControllerManager.getDistrictsSelectList();
                ViewBag.Applications = VesselsControllerManager.getApplicationSelectList();
                return View(VesselsControllerManager.getVessel(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/VesselsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //POST: Vessel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, vessel vessel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int status = VesselsControllerManager.updateVessel(id, vessel);
                    if (status == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Registration = VesselsControllerManager.getRegistrationSelectList();
                ViewBag.Districts = VesselsControllerManager.getDistrictsSelectList();
                ViewBag.Applications = VesselsControllerManager.getApplicationSelectList();

                return View();
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Edit", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/VesselsController/Edit" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Vessels/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(VesselsControllerManager.getVessel(id));
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "GET/VesselsController/Delete" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // POST: Vessels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int status = VesselsControllerManager.deleteVessel(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                AddError AddError = new AddError("VesselsController", "Delete", ex.ToString());
                return RedirectToAction("Error", "Home", new { error = "POST/VesselsController/Delete" });
            }
        }
    }
}