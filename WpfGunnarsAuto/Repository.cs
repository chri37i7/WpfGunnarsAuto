using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WpfGunnarsAuto
{
    class Repository
    {
        // Lists for sql table data
        private List<Car> cars;
        private List<Sale> sales;
        private List<SalesPerson> salesPersons;

        // Sql connection path
        private const string connectionString = @"
            Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=GunnarsAutoDB;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        public Repository()
        {
            // Initialize lists
            cars = new List<Car>();
            sales = new List<Sale>();
            salesPersons = new List<SalesPerson>();

            // Load data from sql tables
            LoadCarsFromDB();
            LoadSalesFromDB();
            LoadSalesPersonsFromDB();
        }

        /*
         * Get Methods
         */

        public List<Car> GetAllCars()
        {
            return cars;
        }

        public List<Sale> GetAllSales()
        {
            return sales;
        }

        public List<SalesPerson> GetAllSalesPersons()
        {
            return salesPersons;
        }

        /*
         * Add to database methods
         */

            // Add methods



        /*
         * Load from database methods
         */

        private void LoadCarsFromDB()
        {
            string sql = "SELECT * FROM Cars";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int carId = (int)reader["PK_CarId"];
                string make = (string)reader["Make"];
                string model = (string)reader["Model"];
                string vin = (string)reader["VIN"];
                string registrationNumber = (string)reader["RegistrationNumber"];
                string carType = (string)reader["CarType"];

                Car car = new Car(
                    carId, 
                    make, 
                    model, 
                    vin, 
                    registrationNumber, 
                    carType);

                cars.Add(car);
            }
            connection.Close();
        }

        private void LoadSalesFromDB()
        {
            string sql = "SELECT * FROM Sales";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int saleId = (int)reader["PK_SaleId"];
                int transactionAmount = (int)reader["TransactionAmount"];
                string saleType = (string)reader["SaleType"];
                int salesPersonId = (int)reader["FK_SalesPersonId"];
                int carId = (int)reader["FK_CarId"];

                Sale sale = new Sale(
                    saleId,
                    transactionAmount,
                    saleType,
                    salesPersonId,
                    carId);

                sales.Add(sale);
            }
            connection.Close();
        }

        private void LoadSalesPersonsFromDB()
        {
            string sql = "SELECT * FROM SalesPersons";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int salesPersonId = (int)reader["PK_SalesPersonId"];
                string firstname = (string)reader["Firstname"];
                string lastname = (string)reader["Lastname"];
                string initials = (string)reader["Initials"];

                SalesPerson salesPerson = new SalesPerson(
                    salesPersonId,
                    firstname,
                    lastname,
                    initials);

                salesPersons.Add(salesPerson);
            }
            connection.Close();
        }
    }
}