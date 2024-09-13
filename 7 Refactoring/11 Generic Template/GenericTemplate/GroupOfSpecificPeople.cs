using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTemplate
{
    /* Pemakaian Generic Class juga bisa menggunakan inheritance seperti biasa.
     */
    public class GroupOfSpecificPeople<Template> : GroupOfSomething<Template>
    {
        public List<string> MethodsName { get; set; }

        public GroupOfSpecificPeople(List<Template> items) : base(items) {
            SetMethodsName();
        }

        public void SetMethodsName() {
            this.MethodsName = new List<string>();
            var type = typeof(Template);
            var methodInfos = type.GetMethods();
            foreach (var methodInfo in methodInfos) {
                this.MethodsName.Add(methodInfo.Name);
            }
        }

        public void PrintAllMethodsName() {
            foreach (var name in this.MethodsName) {
                Console.WriteLine($"Method Name: {name}");
            }
        }
    }
}
