using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoviewer
{
    class data
    {
        //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb;Persist Security Info=False;";
        OleDbConnection connection = new OleDbConnection();
        string conn_string = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=pictures.accdb;Persist Security Info=False;";
        private string descriptionpic;
        private string picname;

        public data()
        {
            //
        }

        public data(string picname, string descriptionpic)
        {
            //this.picname = picname;
            //this.descriptionpic = descriptionpic;
        }

        public void add(string picname, string descriptionpic)
        {
            connection = new OleDbConnection(conn_string);
            connection.Open();
            String query = "INSERT INTO Table1 (pictures,description) values ( '" + picname + "', '" + descriptionpic + "')";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
