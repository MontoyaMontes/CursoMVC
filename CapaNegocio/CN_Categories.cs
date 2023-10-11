using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Categories
    {
        private CD_Categories objCapaDato = new CD_Categories();

        public List<Category> GetCategories()
        {
            return objCapaDato.ListCategories();
        }

        public int RegisterCategory(Category newCategory, out string Message)
        {
            Message = string.Empty;
            if (string.IsNullOrEmpty(newCategory.Description) || string.IsNullOrWhiteSpace(newCategory.Description))
            {
                Message = "La descripción de la categoria no debe ser vacía.";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.RegisterCategory(newCategory, out Message);
            }
            else
            {
                return 0;
            }

        }

        public bool EditCategory(Category categoryToEdit, out string Message)
        {
            Message = string.Empty;
            if (string.IsNullOrEmpty(categoryToEdit.Description) || string.IsNullOrWhiteSpace(categoryToEdit.Description))
            {
                Message = "La descripción de la categoria no debe ser vacía.";
            }
            
            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.EditCategory(categoryToEdit, out Message);
            }
            return false;
        }

        public bool DeleteCategory(int idCategoryToDelete, out string Message)
        {
            return objCapaDato.DeleteCategory(idCategoryToDelete, out Message);
        }

    }
}
