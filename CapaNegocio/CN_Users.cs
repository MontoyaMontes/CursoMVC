using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Users
    {
        private CD_Users objCapaDato = new CD_Users();

        public List<User> GetUsers() {
            return objCapaDato.GetUsers();
        }
        
        public int RegisterUser(User newUser, out string Message)
        {
            Message = string.Empty;
            if(string.IsNullOrEmpty(newUser.Names) || string.IsNullOrWhiteSpace(newUser.Names))
            {
                Message = "El nombre del usuario no debe ser vacío.";
            }
            else if(string.IsNullOrEmpty(newUser.LastName) || string.IsNullOrWhiteSpace(newUser.LastName))
            {
                Message = "El apelido del usuario no debe ser vacío.";

            }
            else if (string.IsNullOrEmpty(newUser.Email) || string.IsNullOrWhiteSpace(newUser.Email))
            {
                Message = "El correo del usuario no debe ser vacío.";
            }

            if(string.IsNullOrEmpty(Message))
            {
                string key = CN_Recursos.GenerateKey();
                string subject = "Binvenido a tu nueva cuenta";
                string messageEmail = "<h1>La cuenta ha sido creada correctamente</h1></hr><p>Su nueva contraseña para acceder es: [key]</p>";
                messageEmail = messageEmail.Replace("[key]", key);

                bool response = CN_Recursos.SendEmail(newUser.Email, subject, messageEmail);
                if (response)
                {
                    newUser.Pass = CN_Recursos.ConvertToSHA256(key);
                    return objCapaDato.RegisterUser(newUser, out Message);
                }
                else
                {
                    Message = "No se pudo enviar el correo.";
                    return 0;

                }


            }

            return 0;
        }

        public bool EditUser(User userToEdit, out string Message)
        {
            Message = string.Empty;
            if (string.IsNullOrEmpty(userToEdit.Names) || string.IsNullOrWhiteSpace(userToEdit.Names))
            {
                Message = "El nombre del usuario no debe ser vacío.";
            }
            else if (string.IsNullOrEmpty(userToEdit.LastName) || string.IsNullOrWhiteSpace(userToEdit.LastName))
            {
                Message = "El apelido del usuario no debe ser vacío.";

            }
            else if (string.IsNullOrEmpty(userToEdit.Email) || string.IsNullOrWhiteSpace(userToEdit.Email))
            {
                Message = "El correo del usuario no debe ser vacío.";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objCapaDato.EditUser(userToEdit, out Message);
            }
            //Message = "Error de servidor.";
            return false;
        }

        public bool DeleteUser(int idUserToDelete, out string Message) 
        {
            return objCapaDato.DeleteUser(idUserToDelete, out Message);
        }

    }
}
