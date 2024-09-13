using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadata.CustomAttribute
{
    /*
     * Di sini kita mencoba membuat Custom Attribute tersendiri. Attribute bisa dibuat dengan menggunakan class yang meng-inherit Attribute abstract class
     * yang berasal dari library System.Attribute.
     * 
     * Karena attribute fungsinnya membawa satu atau lebih meta data, maka seluruh metadata itu akan dibawa oleh property.
     * 
     * AttributeUsage adalah attribute yang digunakan untuk membatasi custom attribute bahwa custom attribute ini hanya bisa di implementasi di mana saja.
     * Section implementasi di tunjukan lewat enum AttributeTargets. Dalam kasus ini kita mengimplementasi khusus untuk Property.
     * By default semua akan bisa mendapatkan.
     * 
     * Inherited bernilai false yang artinya attribute ini tidak diturunkan ke class bawahnya.
     */
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidationAttribute : Attribute
    {
        public bool Nullable { get; set; }
        public int CharLength { get; set; }
    }
}
