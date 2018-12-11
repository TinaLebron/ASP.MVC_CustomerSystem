using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjMvcDemo2.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Update(int qq)
        {
            dbDemoDataContext db = new dbDemoDataContext();
            tCustomer cust = db.tCustomer.FirstOrDefault(m => m.fId == qq);
            if (cust != null)
            {
                 return View(cust);
            }
            return RedirectToAction("List");

        }
        [HttpPost]
        public ActionResult Update(tCustomer p)
        {
            dbDemoDataContext db = new dbDemoDataContext();
            tCustomer cust = db.tCustomer.FirstOrDefault(m => m.fId == p.fId);
            if (cust != null)
            {
                cust.fName = p.fName;
                cust.fPhone = p.fPhone;
                cust.fEmail = p.fEmail;
                cust.fAddress = p.fAddress;
                db.SubmitChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(tCustomer p)
        {
            dbDemoDataContext db = new dbDemoDataContext();
            db.tCustomer.InsertOnSubmit(p);
            db.SubmitChanges();

            return RedirectToAction("List");
        }
        public ActionResult Delete(int qq)
        {
            dbDemoDataContext db = new dbDemoDataContext();
            tCustomer cust = db.tCustomer.FirstOrDefault(m=>m.fId== qq);
            if (cust != null)
            {
                db.tCustomer.DeleteOnSubmit(cust);
                db.SubmitChanges();
            }

            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            dbDemoDataContext db = new dbDemoDataContext();
            var table = from c in db.tCustomer
                        select c;
            return View(table);
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}
