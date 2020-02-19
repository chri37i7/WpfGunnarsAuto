using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfGunnarsAuto
{
    class ViewModel
    {
        private readonly Repository repository;

        public ViewModel()
        {
            repository = new Repository();

            // Lists
            List<Car> cars = repository.GetAllCars();
            List<Sale> sales = repository.GetAllSales();
            List<SalesPerson> salesPersons = repository.GetAllSalesPersons();

            // Collections
            Cars = new ObservableCollection<Car>(cars);
            Sales = new ObservableCollection<Sale>(sales);
            SalesPersons = new ObservableCollection<SalesPerson>(salesPersons);
        }

        // Collections
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<Sale> Sales { get; set; }
        public ObservableCollection<SalesPerson> SalesPersons { get; set; }

        // Selected
        public Car SelectedCar { get; set; }
        public Sale SelectedSale { get; set; }
        public SalesPerson SalesPerson { get; set; }
    }
}
