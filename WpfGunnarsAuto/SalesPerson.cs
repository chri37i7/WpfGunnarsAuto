using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfGunnarsAuto
{
    class SalesPerson
    {
        // Constructor
        public SalesPerson(int salesPersonId, string firstname, string lastname, string initials)
        {
            SalesPersonId = salesPersonId;
            Firstname = firstname;
            Lastname = lastname;
            Initials = initials;
        }

        // Properties
        [StringLength(5)]
        public int SalesPersonId { get; set; }

        [StringLength(69)]
        public string Firstname { get; set; }

        [StringLength(420)]
        public string Lastname { get; set; }

        [StringLength(4)]
        public string Initials { get; set; }
    }
}