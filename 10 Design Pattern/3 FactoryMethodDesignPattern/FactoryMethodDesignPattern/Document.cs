using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodDesignPattern
{
    public abstract class Document
    {
        public List<Page> Pages { get; set; }

        public Document() {
            this.Pages = new List<Page>();
            this.CreatePages();
        }

        public abstract void CreatePages();
    }
}
