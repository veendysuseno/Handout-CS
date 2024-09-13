using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTemplate
{
    /* Berikut ini adalah contoh penggunaan lebih dari satu Generic Template pada sebuah class.
     */
    public class GroupOfHeaderDetails<TemplateHeader, TemplateDetail>
    {
        public TemplateHeader Header { get; set; }
        public IEnumerable<TemplateDetail> Details { get; set; }
        public List<string> HeaderColumns { get; set; }
        public List<string> DetailColumns { get; set; }
        public GroupOfHeaderDetails(TemplateHeader header, IEnumerable<TemplateDetail> details) {
            this.Header = header;
            this.Details = details;
            SetHeaderColumns();
            SetDetailColumns();
        }

        public void SetHeaderColumns() {
            var headerType = typeof(TemplateHeader);
            var propertyInfos = headerType.GetProperties();
            this.HeaderColumns = new List<string>();
            foreach (var propertyInfo in propertyInfos) {
                HeaderColumns.Add(propertyInfo.Name);
            }
        }

        public void SetDetailColumns() {
            var detailType = typeof(TemplateDetail);
            var propertyInfos = detailType.GetProperties();
            this.DetailColumns = new List<string>();
            foreach (var propertyInfo in propertyInfos) {
                DetailColumns.Add(propertyInfo.Name);
            }
        }

        public void PrintHeader() {
            var headerType = typeof(TemplateHeader);
            Console.WriteLine($"===Header: {headerType.Name}===");
            foreach (var column in this.HeaderColumns) {
                var value = headerType.GetProperty(column).GetValue(this.Header);
                Console.WriteLine($"{column}: {value}");
            }
        }

        public void PrintDetails() {
            var detailType = typeof(TemplateDetail);
            Console.WriteLine($"===Details: {detailType.Name}===");
            foreach (var detail in this.Details) {
                foreach (var column in this.DetailColumns) {
                    var value = detailType.GetProperty(column).GetValue(detail);
                    Console.WriteLine($"{column}: {value}");
                }
                Console.WriteLine("--------------------------------------");
            }
        }

        public void PrintHeaderAndDetails() {
            PrintHeader();
            PrintDetails();
        }
    }
}
