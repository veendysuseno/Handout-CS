using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTemplate
{
    /* Generic class juga bisa bersifat static.
     * Sehingga setiap tipe data yang menempati Template generic ini akan menjadi satu independent static class.
     * 
     * Percobaan pada static class generic bisa dilihat di dalam Program class.
     */
    public static class IndependentEntity<Template>
    {
        public static Template Entity { get; set; }

        public static object GetSelectedProperty(string propertyName) {
            var type = typeof(Template);
            return type.GetProperty(propertyName).GetValue(Entity);
        }
    }
}
