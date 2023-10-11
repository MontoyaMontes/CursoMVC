using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categories()
        {
            ViewBag.Message = "Página de Categories";
            return View();
        }
        public ActionResult Brands()
        {
            ViewBag.Message = "Página de Brands";
            return View();
        }
        public ActionResult Products()
        {
            ViewBag.Message = "Página de Products";
            return View();
        }

        // ====== Categories functions ====== //
        #region
        [HttpGet]
        public JsonResult ListCategories()
        {

            List<Category> oList = new List<Category>();

            oList = new CN_Categories().GetCategories();

            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveCategory(Category category)
        {
            object result;
            string message;

            if (category.IdCategory == 0)
            {
                result = new CN_Categories().RegisterCategory(category, out message);
            }
            else
            {
                result = new CN_Categories().EditCategory(category, out message);
            }
            return Json(new { result, message }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            bool result;
            string message;

            result = new CN_Categories().DeleteCategory(id, out message);

            return Json(new { result, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // ====== Brands functions ====== //
        #region
        [HttpGet]
        public JsonResult ListBrands()
        {

            List<Brand> oList = new List<Brand>();

            oList = new CN_Brands().GetBrands();

            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveBrand(Brand brand)
        {
            object result;
            string message;

            if (brand.IdBrand == 0)
            {
                result = new CN_Brands().RegisterBrand(brand, out message);
            }
            else
            {
                result = new CN_Brands().EditBrand(brand, out message);
            }
            return Json(new { result, message }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteBrand(int id)
        {
            bool result;
            string message;

            result = new CN_Brands().DeleteBrand(id, out message);

            return Json(new { result, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // ====== Products functions ====== //
        #region
        [HttpGet]
        public JsonResult ListProducts()
        {
            {
                List<Product> oList = new List<Product>();

                oList = new CN_Products().GetProducts();

                return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SaveProduct(string productString, HttpPostedFileBase imageFile)
        {
            string message;
            bool succesfull = true;
            bool save_image_successful = true;

            Product product = new Product();

            product = JsonConvert.DeserializeObject<Product>(productString);

            decimal price;

            if (decimal.TryParse(product.PriceText, System.Globalization.NumberStyles.AllowDecimalPoint, new CultureInfo("es-MX"), out price))
            {
                product.Price = price;
            }else
            {
                return Json(new { successfullOperation = false, message = "Formato del precio debe ser ##.##" }, JsonRequestBehavior.AllowGet);
            }

            if (product.IdProduct == 0)
            {
                int idNewProduct = new CN_Products().RegisterProduct(product, out message);
                if(idNewProduct != 0)
                {
                    product.IdProduct = idNewProduct;
                }
                else
                {
                    succesfull = false;
                }

            }
            else
            {
                succesfull = new CN_Products().EditProduct(product, out message);
            }


            if (succesfull)
            {
                if (imageFile != null)
                {
                    string routeToSave = ConfigurationManager.AppSettings["PhotosServer"];
                    string extension = Path.GetExtension(imageFile.FileName);
                    string imageName = string.Concat(imageFile.FileName.ToString(), extension);
                    System.Diagnostics.Debug.WriteLine("imageFile", imageFile);

                    try
                    {
                        imageFile.SaveAs(Path.Combine(routeToSave, imageName));

                    }
                    catch(Exception ex) 
                    {
                        string msg = ex.Message;
                        save_image_successful = false;
                    }

                    if (save_image_successful)
                    {
                        product.ImageRoute = routeToSave;
                        product.ImageName = imageName;
                        bool rspons = new CN_Products().SaveImageData(product,out message);
                    }
                    else
                    {
                        message = "Se guardó el producto pero hubo problemas con la imagen";
                    }
                }
            }

            return Json(new { successfullOperation = succesfull, id = product.IdProduct, message }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetImageBase64(int id)
        {
            bool conversion = false;
            Product product = new CN_Products().GetProducts().Where(p => p.IdProduct == id).FirstOrDefault();
            string textBase64 = CN_Recursos.GetImageBase64(Path.Combine(product.ImageRoute, product.ImageName), out conversion);

            return Json(new { conversion, textBase64, extension = Path.GetExtension(product.ImageName) }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteProduct (int id)
        {
            bool result;
            string message;

            result = new CN_Products().DeleteProduct(id, out message);

            return Json(new { result, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
