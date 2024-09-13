using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TemplateDesignPattern
{
    public abstract class DataAccessObject
    {
        protected string ConnectionString { get; set; }
        protected DataSet DataSet { get; set; }

        public virtual void Connect() {
            this.ConnectionString = "provider=Microsoft.JET.OLEDB.4.0; data source=..\\..\\..\\db1.mdb";
        }

        public abstract void Select();
        public abstract void Process();

        public virtual void Disconnect() {
            this.ConnectionString = "";
        }

        public void Run() {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }
}
