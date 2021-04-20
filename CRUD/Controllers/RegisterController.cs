using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{

    public class RegisterController : Controller
    {
        private crudEntities mdl = new crudEntities();

        // GET: Register
        public ActionResult SetDataInDatabase()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult SetDataInDatabase(LoginPanel model)
        {
            //LoginPanel tbl = new LoginPanel();
            //tbl.Username = model.Username;
            //tbl.Password = model.Password;
            mdl.LoginPanels.Add(model);
            mdl.SaveChanges();
            return View();
        }

        public ActionResult ShowDatabaseForUser()
        {
            var item = mdl.LoginPanels.ToList();
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = mdl.LoginPanels.Where(x => x.ID == id).FirstOrDefault();
            mdl.LoginPanels.Remove(item);
            mdl.SaveChanges();
            var item2 = mdl.LoginPanels.ToList();
            return View("ShowDatabaseForUser",item2);
        }

        public ActionResult Edit(int id)
        {
            var item = mdl.LoginPanels.Where(x => x.ID == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(LoginPanel model)
        {
            var item = mdl.LoginPanels.Where(x => x.ID == model.ID).FirstOrDefault();
            item.Username = model.Username;
            item.Password = model.Password;
            mdl.SaveChanges();
            return View();
        }
        
    }
}