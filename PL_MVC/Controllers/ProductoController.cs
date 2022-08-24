using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAllEF();
            if (result.Correct)
            {
                producto.Productos = result.Objects.ToList();
                return View(producto);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return View();
            }


        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            ML.Result resultProveedor = BL.Proveedor.GetAll();
            ML.Result resultDepartamento = BL.Departamento.GetAll();

            if (IdProducto == null)
            {
                ViewBag.Titulo = "Agregar un producto";
                ViewBag.Accion = "Agregar";

                producto.Proveedor = new ML.Proveedor();
                producto.Departamento = new ML.Departamento();

                producto.Proveedor.Proveedores = resultProveedor.Objects.ToList();
                producto.Departamento.Departamentos = resultDepartamento.Objects.ToList();


                return View(producto);
            }
            else
            {
                ViewBag.Titulo = "Actualizar un producto";
                ViewBag.Accion = "Actualizar";

                ML.Result result = BL.Producto.GetIdEF(IdProducto.Value);


                if (result.Correct)
                {
                    producto = (ML.Producto)result.Object;
                    producto.Proveedor.Proveedores = resultProveedor.Objects.ToList();
                    producto.Departamento.Departamentos = resultDepartamento.Objects.ToList();
                    return View(producto);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return View();
                }

            }
        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            if (producto.IdProducto == 0)
            {
                ML.Result result = BL.Producto.AddEF(producto);

                if (result.Correct)
                {

                    ViewBag.Message = "Se ha agregado correctamente";
                    return PartialView("Modal");

                }

                else
                {

                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");

                }

            }
            else
            {
                ML.Result result = BL.Producto.UpdateEF(producto);

                if (result.Correct)
                {
                    ViewBag.Message = " se actualizo Correctamente";
                    return PartialView("Modal");
                }

                else
                {
                    ViewBag.Message = " No se ha podido actualizar";
                    return PartialView("Modal");


                }

            }

        }
        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {

            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;


            ML.Result result = BL.Producto.DeleteEF(producto);
            if (result.Correct)
            {
                ViewBag.Message = "se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Message = "Error al eliminar ";

            }
            return PartialView("Modal");

        }
    }
}