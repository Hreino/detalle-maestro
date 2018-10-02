using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaDetalleMaestro.Models;

namespace PruebaDetalleMaestro.Controllers
{
    public class EncabezadoesController : Controller
    {


        private Modelo db = new Modelo();

         static List<DetalleEncabezado> detalleEncabezadosAux = new List<DetalleEncabezado>();//para acumular mientras no se cree la transaccion

        // GET: Encabezadoes
        public ActionResult Index()
        {
            return View(db.Encabezado.ToList());
        }







        //Metodo para cargar la vista parcial

            //Mismo nombre de la vista parcial para que reconozca la que se ha creado antes.
            // debe retornar una vista parcial
        public ActionResult DetallesCrear(int idProducto, int cantidad) //parametros que se mandan con el ajax
        {
            

            if ((idProducto>0 || idProducto!=null) && (cantidad>0 || cantidad!=null))
            {
                DetalleEncabezado item = new DetalleEncabezado(); //se crea un objeto de detalleXXXXXXXXX para luego poder agregarlo 

                item.Producto = db.Producto.Find(idProducto); //Buscamos el item por el id que se recibe

                item.idProducto = idProducto; //referencia del id que se recibe

                item.Cantidad = cantidad; //referencia a la cantidad que se recibe

                item.Total = item.Producto.Precio * cantidad; //calculo


                //Agregar item a la lista

                detalleEncabezadosAux.Add(item);


                return PartialView(detalleEncabezadosAux); //retornando la lista a la vista parcial


            } else
            {
                return PartialView();
            }
            
        }


        //PARA VER LOS DETALLES AGREGADOS

            public ActionResult DetalleVer(int ? id)
        {
            return PartialView("DetallesCrear", db.Encabezado.Find(id).DetalleEncabezado); //detalle crear
        }
















        // GET: Encabezadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encabezado encabezado = db.Encabezado.Find(id);
            if (encabezado == null)
            {
                return HttpNotFound();
            }
            return View(encabezado);
        }

        // GET: Encabezadoes/Create
        public ActionResult Create()
        {

            //Para poder tener acceso a los elementos dentro de la base de datos, en el caso del proyecto, libros
            //se debe pasar esa lista en un viewbags
            ViewBag.ProductsList = db.Producto.ToList();
            return View();
        }

        // POST: Encabezadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Cliente,Fecha")] Encabezado encabezado)
        {

            //AGREGAR DETALLES ANTES AL CREAR 

            foreach (var item in detalleEncabezadosAux)
            {
                encabezado.DetalleEncabezado.Add(new DetalleEncabezado { //se agrega el detalle de la transaccion
                    Cantidad = item.Cantidad, //se utilizan las mismas propiedades que tiene la clase modelo de detalle 
                    idEncabezado = encabezado.id,
                    idProducto = item.idProducto,
                    Total = item.Total
                });

            }


            if (ModelState.IsValid)
            {
                db.Encabezado.Add(encabezado);
                db.SaveChanges();

                //reseteando la lista
                detalleEncabezadosAux = new List<DetalleEncabezado>();
                return RedirectToAction("Index");
            }

            return View(encabezado);
        }

        // GET: Encabezadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encabezado encabezado = db.Encabezado.Find(id);
            if (encabezado == null)
            {
                return HttpNotFound();
            }
            return View(encabezado);
        }

        // POST: Encabezadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Cliente,Fecha")] Encabezado encabezado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encabezado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encabezado);
        }

        // GET: Encabezadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encabezado encabezado = db.Encabezado.Find(id);
            if (encabezado == null)
            {
                return HttpNotFound();
            }
            return View(encabezado);
        }

        // POST: Encabezadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encabezado encabezado = db.Encabezado.Find(id);
            db.Encabezado.Remove(encabezado);
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
