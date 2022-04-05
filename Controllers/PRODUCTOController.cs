using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcuaDeliveryV3;

namespace EcuaDeliveryV3.Controllers
{
    public class PRODUCTOController : Controller
    {
        private BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();

        // GET: PRODUCTO
        public ActionResult Index()
        {
            var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(pRODUCTOS.ToList());
        }

        // GET: PRODUCTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Create
        public ActionResult Create()
        {
            ViewBag.CAT_ID = new SelectList(db.CATEGORIAs, "CAT_ID", "CAT_NOMBRE");
            ViewBag.PRV_ID = new SelectList(db.PROVEEDORs, "PRV_ID", "PRV_NOMBRE");
            return View();
        }

        // POST: PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRO_NOM,PRO_PRECIO,PRO_DESCRIPCION,PRO_STOCK,PRO_FECHA_IN,PRO_ID,CAT_ID,PRV_ID")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CAT_ID = new SelectList(db.CATEGORIAs, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDORs, "PRV_ID", "PRV_NOMBRE", pRODUCTO.PRV_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIAs, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDORs, "PRV_ID", "PRV_NOMBRE", pRODUCTO.PRV_ID);
            return View(pRODUCTO);
        }

        // POST: PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRO_NOM,PRO_PRECIO,PRO_DESCRIPCION,PRO_STOCK,PRO_FECHA_IN,PRO_ID,CAT_ID,PRV_ID")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIAs, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDORs, "PRV_ID", "PRV_NOMBRE", pRODUCTO.PRV_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
