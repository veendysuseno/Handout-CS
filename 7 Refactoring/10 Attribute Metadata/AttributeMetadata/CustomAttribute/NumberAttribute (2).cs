using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadata.CustomAttribute
{
    //Inherited bernilai true yang artinya di turunkan ke class bawahnya.
    [AttributeUsage(AttributeTargets.Property)]
    public class NumberAttribute : Attribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}
