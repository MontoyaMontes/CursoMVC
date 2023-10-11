using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Products
    {
        private CD_Products objCapaDato = new CD_Products();

        public List<Product> GetProducts()
        {
            return objCapaDato.ListProducts();

        }

        public int RegisterProduct(Product newProduct, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(newProduct.NameProduct) || string.IsNullOrWhiteSpace(newProduct.NameProduct))
            {
                Message = "El nombre del producto no debe ser vacío.";
            }
            else if (string.IsNullOrEmpty(newProduct.Description) || string.IsNullOrWhiteSpace(newProduct.Description))
            {
                Message = "La descripción del producto no debe ser vacía.";
            }
            else if (newProduct.objBrand.IdBrand == 0)
            {
                Message = "Debes selecciona una marca.";
            }
            else if (newProduct.objCategory.IdCategory == 0)
            {
                Message = "Debes selecciona una categoría.";
            }
            else if (newProduct.Price == 0)
            {
                Message = "El precio no puede ser vacío.";
            }
            else if (newProduct.Stock == 0)
            {
                Message = "El stock no puede ser vacío.";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.RegisterProduct(newProduct, out Message);
            }
            else
            {
                return 0;
            }

        }

        public bool EditProduct(Product productToEdit, out string Message)
        {
            Message = string.Empty;
            if (string.IsNullOrEmpty(productToEdit.NameProduct) || string.IsNullOrWhiteSpace(productToEdit.NameProduct))
            {
                Message = "El nombre del producto no debe ser vacío.";
            }
            else if (string.IsNullOrEmpty(productToEdit.Description) || string.IsNullOrWhiteSpace(productToEdit.Description))
            {
                Message = "La descripción del producto no debe ser vacía.";
            }
            else if (productToEdit.objBrand.IdBrand == 0)
            {
                Message = "Debes selecciona una marca.";
            }
            else if (productToEdit.objCategory.IdCategory == 0)
            {
                Message = "Debes selecciona una categoría.";
            }
            else if (productToEdit.Price == 0)
            {
                Message = "El precio no puede ser vacío.";
            }
            else if (productToEdit.Stock == 0)
            {
                Message = "El stock no puede ser vacío.";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.EditProduct(productToEdit, out Message);
            }
            return false;
        }

        public bool DeleteProduct(int idProductToDelete, out string Message)
        {
            return objCapaDato.DeleteProduct(idProductToDelete, out Message);
        }

        public bool SaveImageData(Product newImage, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(newImage.ImageRoute) || string.IsNullOrWhiteSpace(newImage.ImageRoute))
            {
                Message = "El nombre de la imagen no debe ser vacío.";
            }
            else if (string.IsNullOrEmpty(newImage.ImageName) || string.IsNullOrWhiteSpace(newImage.ImageName))
            {
                Message = "La URL de la imagen no debe ser vacía.";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.SaveImageData(newImage, out Message);
            }
            return false;


        }
    }
}
