using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace TemplateDesignPattern
{
    public class Products : DataAccessObject
    {
        public override void Select() {
            string sql = "select ProductName from Products";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, this.ConnectionString);

            this.DataSet = new DataSet();
            dataAdapter.Fill(this.DataSet, "Products");
        }

        public override void Process() {
            Console.WriteLine("Products ---- ");
            DataTable dataTable = this.DataSet.Tables["Products"];
            foreach (DataRow row in dataTable.Rows) {
                Console.WriteLine(row["ProductName"]);
            }
            Console.WriteLine();
        }
    }
}
