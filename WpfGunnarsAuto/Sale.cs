using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfGunnarsAuto
{
    class Sale
    {
        // Constructor
        public Sale(int saleId, int transactionAmount, string saleType, int salesPersonId, int carId)
        {
            SaleId = saleId;
            TransactionAmount = transactionAmount;
            SaleType = saleType;
            SalesPersonId = salesPersonId;
            CarId = carId;
        }

        // Properties
        [StringLength(7)]
        public int SaleId { get; set; }

        [StringLength(7)]
        public int TransactionAmount { get; set; }

        [StringLength(20)]
        public string SaleType { get; set; }

        [StringLength(7)]
        public int SalesPersonId { get; set; }

        [StringLength(7)]
        public int CarId { get; set; }
    }
}