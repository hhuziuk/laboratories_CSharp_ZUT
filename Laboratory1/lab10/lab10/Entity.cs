using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab10
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }

        public virtual ICollection<InvoicePos> InvoicePosCollection { get; set; }

        public override string ToString()
        {
            return $"Id: {InvoiceId}, Name: {Number}, Value: {Value}";
        }
    }

    public class InvoicePos
    {
        public int InvoicePosId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
