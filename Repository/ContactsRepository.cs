using ContactsManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagement.Repository
{
    public class ContactsRepository
    {
        private SqlConnection sqlConnection;

        public ContactsRepository() {
            string connectionString = ConfigurationManager.ConnectionStrings["ContactsManagementDB"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        public bool InsertContact(Contacts contacts) {
            bool isSuccess = false;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertContacts", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", contacts.Name);
                sqlCommand.Parameters.AddWithValue("@Address", contacts.Address);
                sqlCommand.Parameters.AddWithValue("@PhoneNo", contacts.PhoneNo);
                sqlConnection.Open();
                int noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (noOfRowsAffected >= 1) {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
            }

            return isSuccess;
        }

        public bool UpdateContactById(Contacts contacts)
        {
            bool isSuccess = false;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateContact", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", contacts.Name);
                sqlCommand.Parameters.AddWithValue("@Address", contacts.Address);
                sqlCommand.Parameters.AddWithValue("@PhoneNo", contacts.PhoneNo);
                sqlCommand.Parameters.AddWithValue("@Id", contacts.Id);
                sqlConnection.Open();
                int noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (noOfRowsAffected >= 1)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
            }

            return isSuccess;
        }

        public Contacts GetContactById(Int64 contactId)
        {
            DataTable dataTable = new DataTable();
            Contacts contact = new Contacts();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("GetContactById", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", contactId);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                if (dataTable.Rows.Count >= 1)
                {
                    contact.Address = Convert.ToString(dataTable.Rows[0]["Address"]);
                    contact.Id = Convert.ToInt64(dataTable.Rows[0]["Id"]);
                    contact.Name= Convert.ToString(dataTable.Rows[0]["Name"]);
                    contact.PhoneNo= Convert.ToString(dataTable.Rows[0]["PhoneNo"]);
                }
            }
            catch (Exception ex)
            {
            }

            return contact;
        }

        public List<Contacts> GetAllContacts()
        {
            DataTable dataTable = new DataTable();
            List<Contacts> contacts = new List<Contacts>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("GetAllContacts", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                if (dataTable.Rows.Count >= 1)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        Contacts contact = new Contacts();
                        contact.Address = Convert.ToString(dataRow["Address"]);
                        contact.Id = Convert.ToInt64(dataRow["Id"]);
                        contact.Name = Convert.ToString(dataRow["Name"]);
                        contact.PhoneNo = Convert.ToString(dataRow["PhoneNo"]);
                        contacts.Add(contact);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return contacts;
        }

        public bool DeleteContactById(Int64 contactId)
        {
            bool isSuccess = false;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("DeleteContactById", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", contactId);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlConnection.Open();
                int noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (noOfRowsAffected >= 1)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
            }

            return isSuccess;
        }
    }
}
