using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDestructor {

    /*
     * Berikut ini adalah contoh menggunakan IDisposable dengan pattern yang disarankan microsoft
     */

    public class Task : IDisposable {
        public string ActivityName { get; set; }
        public string Category { get; set; }
        private bool isDisposed = false;

        public Task(string activityName, string category) {
            this.ActivityName = activityName;
            this.Category = category;
        }

        private void DisposeValue() {
            if (!this.isDisposed) { 
                //set semuanya null secara manual.
                this.ActivityName = null;
                this.Category = null;
                this.isDisposed = true;
            }
        }

        ~Task() {
            Console.WriteLine($"Task using destruct on {this.ActivityName}");
            DisposeValue();
        }

        public void Dispose() {
            DisposeValue();
            GC.SuppressFinalize(this); //Digunakan untuk memberitahukan Garbage Collection kalau object ini sudah di Dispose, tidak perlu di Finalize lagi.
        }
    }
}
