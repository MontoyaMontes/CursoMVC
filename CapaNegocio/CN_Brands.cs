using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Brands
    {
        private CD_Brands objCapaDato = new CD_Brands();

        public List<Brand> GetBrands()
        {
            return objCapaDato.ListBrands();
        }

        public int RegisterBrand(Brand newBrand, out string Message)
        {
            Message = string.Empty;
            if (string.IsNullOrEmpty(newBrand.Description) || string.IsNullOrWhiteSpace(newBrand.Description))
            {
                Message = "La descripción de la marca no debe ser vacía.";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.RegisterBrand(newBrand, out Message);
            }
            else
            {
                return 0;
            }

        }

        public bool EditBrand(Brand brandToEdit, out string Message)
        {
            Message = string.Empty;
            if (string.IsNullOrEmpty(brandToEdit.Description) || string.IsNullOrWhiteSpace(brandToEdit.Description))
            {
                Message = "La descripción de la marca no debe ser vacía.";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.EditBrand(brandToEdit, out Message);
            }
            return false;
        }

        public bool DeleteBrand(int idBrandToDelete, out string Message)
        {
            return objCapaDato.DeleteBrand(idBrandToDelete, out Message);
        }

    }
}
