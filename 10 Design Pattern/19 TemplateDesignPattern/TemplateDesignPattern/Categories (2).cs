using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace TemplateDesignPattern
{
    public class Categories : DataAccessObject
    {
        public override void Select() {
            string sql = "select CategoryName from Categories";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, this.ConnectionString);

            this.DataSet = new DataSet();
            dataAdapter.Fill(this.DataSet, "Categories");
        }

        public override void Process() {
            Console.WriteLine("Categories ---- ");

            DataTable dataTable = this.DataSet.Tables["Categories"];
            foreach (DataRow row in dataTable.Rows) {
                Console.WriteLine(row["CategoryName"]);
            }
            Console.WriteLine();
        }
    }
}
