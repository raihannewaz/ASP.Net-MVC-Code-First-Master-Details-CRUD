using Newaz_1271713_Code_First.DAL;
using Newaz_1271713_Code_First.Models;
using Newaz_1271713_Code_First.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Newaz_1271713_Code_First.Controllers
{
    public class OrderPlaceController : Controller
    {
        public OrderContext db = new OrderContext();
        // GET: OrderPlace
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getProductCategories()
        {
            List<Category> categories = new List<Category>();
            categories = db.Categories.OrderBy(a => a.CategoryName).ToList();

            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult getProducts(int categoryID)
        {
            List<Product> products = new List<Product>();

            products = db.Products.Where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();

            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult save(OrderMaster order, HttpPostedFileBase file)
        {
            bool status = false;


            if (file != null)
            {
                string folderPath = Server.MapPath("~/Images/");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                file.SaveAs(filePath);

                order.AddressProofImage = filePath;
            }

            var isValidModel = TryUpdateModel(order);

            if (isValidModel)
            {
                db.OrderMasters.Add(order);
                db.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            OrderMaster orderMaster = db.OrderMasters.Include(o => o.OrderDetails).SingleOrDefault(o => o.OrderID == id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }

            return View(orderMaster);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderMaster orderMaster, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string folderPath = Server.MapPath("~/Images/");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(folderPath, fileName);
                    file.SaveAs(filePath);

                    orderMaster.AddressProofImage = filePath;
                }

                db.Entry(orderMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(orderMaster);
        }




        public ActionResult List()
        {

            var orderDetails = db.OrderDetails.Include("OrderMaster").ToList();


            var orderVMs = orderDetails.Select(o => new OrderVM
            {
                OrderDetailID = o.OrderDetailID,
                ProductID = o.ProductID,
                OrderID = o.OrderID,
                Quantity = o.Quantity,
                Rate = o.Rate,
                OrderDate = o.OrderMaster.OrderDate,
                OrderNote = o.OrderMaster.OrderNote,
                AddressProofImage = o.OrderMaster.AddressProofImage,
                Terms = o.OrderMaster.Terms
            }).ToList();

            return View(orderVMs);
        }


        public ActionResult Delete(int id)
        {
            OrderMaster orderMaster = db.OrderMasters.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }

            return View(orderMaster);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            OrderMaster orderMaster = db.OrderMasters.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }

            db.OrderMasters.Remove(orderMaster);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}