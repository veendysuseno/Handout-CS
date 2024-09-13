using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTemplate
{
    /* Pemakaian Generic juga bisa untuk deklarasi sebuah Class.
     * Pemakaian generic pada sebuah class yang biasa digunakan untuk menulis sebuah collection generic.
     */
    public class GroupOfSomething<Template> {
        public List<Template> Items { get; set; }
        public List<string> PropertiesName { get; set; }

        public GroupOfSomething(List<Template> items) {
            Items = items;
            SetPropertiesName();
        }

        public void SetPropertiesName() {
            this.PropertiesName = new List<string>();
            var type = typeof(Template);
            var propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos) {
                this.PropertiesName.Add(propertyInfo.Name);
            }
        }

        public void PrintAllSelectedProperty(string propertyName) {
            foreach (var item in this.Items) {
                var type = typeof(Template);
                Console.WriteLine($"{propertyName} : {type.GetProperty(propertyName).GetValue(item)}");
            }
        }

        public void PrintAllPropertiesName() {
            foreach (var name in this.PropertiesName) {
                Console.WriteLine($"Property Name: {name}");
            }
        }
    }
}
