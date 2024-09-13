using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public interface IStakeholder
    {
        public string Company { get; set; }
        public string Business { get; set; }
        public void PrintCompanyInfo();
    }
}
