using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Business.Entities;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //const string consKeyDefaultCnnString = "ConnStringExpress";

        protected SqlConnection sqlConn;

        protected void OpenConnection()
        {
            /*
            string conn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            sqlConn = new SqlConnection(conn);*/

            sqlConn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=academia;Integrated Security=true;");
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
