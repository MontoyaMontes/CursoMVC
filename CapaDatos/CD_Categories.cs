﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Categories
    {
        public List<Category> ListCategories()
        {
            List<Category> newList = new List<Category>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.cn))
                {
                    string query = "SELECT IdCategory,Description,Active from CATEGORY";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.Text;

                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            newList.Add(
                                new Category()
                                {
                                    IdCategory = Convert.ToInt32(dr["IdCategory"]),
                                    Description = dr["Description"].ToString(),
                                    Active = Convert.ToBoolean(dr["Active"])
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                newList = new List<Category>();
            }
            return newList;
        }


        public int RegisterCategory(Category newCategory, out string Message)
        {
            int idAutoGenerated = 0;
            Message = string.Empty;
            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegisterCategory", oconnection); 
                    cmd.Parameters.AddWithValue("Description", newCategory.Description);
                    cmd.Parameters.AddWithValue("Active", newCategory.Active);
                    cmd.Parameters.Add("Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    idAutoGenerated = Convert.ToInt32(cmd.Parameters["Result"].Value);
                    Message = cmd.Parameters["Message"].ToString() == "Message" ? "Error de servidor" : cmd.Parameters["Message"].ToString();
                }

            }
            catch (Exception e)
            {
                idAutoGenerated = 0;
                Message = e.Message;
            }
            return idAutoGenerated;
        }

        public bool EditCategory(Category categoryToEdit, out string Message)
        {
            bool result = false;
            Message = string.Empty;
            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditCategory", oconnection);
                    cmd.Parameters.AddWithValue("IdCategory", categoryToEdit.IdCategory);
                    cmd.Parameters.AddWithValue("Description", categoryToEdit.Description);
                    cmd.Parameters.AddWithValue("Active", categoryToEdit.Active);
                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    Message = cmd.Parameters["Message"].ToString();
                }
            }
            catch (Exception e)
            {
                result = false;
                Message = e.Message;
            }
            return result;
        }

        public bool DeleteCategory(int idCategoryToDelete, out string Message)
        {
            bool result = false;
            Message = string.Empty;
            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteCategory", oconnection);
                    cmd.Parameters.AddWithValue("IdCategory", idCategoryToDelete);
                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    Message = cmd.Parameters["Message"].ToString();
                }
            }
            catch (Exception e)
            {
                result = false;
                Message = e.Message;
            }
            return result;
        }

    }
}