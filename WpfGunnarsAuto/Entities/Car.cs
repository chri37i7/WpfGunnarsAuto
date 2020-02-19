using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfGunnarsAuto
{
    class Car
    {
        // Constructor
        public Car(int carId, string make, string model, string vin, string registrationNumber, string carType)
        {
            CarId = carId;
            Make = make;
            Model = model;
            Vin = vin;
            RegistrationNumber = registrationNumber;
            CarType = carType;
        }

        // Properties
        [StringLength(7)]
        public int CarId { get; set; }

        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Vin { get; set; }

        [StringLength(20)]
        public string RegistrationNumber { get; set; }

        [StringLength(10)]
        public string CarType { get; set; }
    }
}