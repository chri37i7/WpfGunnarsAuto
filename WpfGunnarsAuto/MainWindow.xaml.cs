using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGunnarsAuto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel;
        Repository repository;

        public MainWindow()
        {
            InitializeComponent();

            repository = new Repository();
            viewModel = new ViewModel();
            DataContext = viewModel;
        }

        private void Button_AddCar_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox_SelectUser.SelectedItem != null)
            {
                if(textBox_CarMaker.Text == "")
                {
                    MessageBox.Show(
                        "Please fill out Car Maker.", 
                        "Missing Car Maker", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
                else if(textBox_CarModel.Text == "")
                {
                    MessageBox.Show(
                        "Please fill out Car Model.", 
                        "Missing Car Model", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
                else if(textBox_CarVin.Text == "")
                {
                    MessageBox.Show(
                        "Please fill out Car VIN.", 
                        "Missing Car VIN", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
                else if(comboBox_CarType.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Please select Car Type.", 
                        "Missing Car Type", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
                else
                {
                    // Car Object - CarId 0 since constructor requires it
                    Car car = new Car(
                        1, 
                        $"{textBox_CarMaker.Text}", 
                        $"{textBox_CarModel.Text}", 
                        $"{textBox_CarVin.Text}", 
                        $"{textBox_RegistrationNumber.Text}", 
                        $"{comboBox_CarType.Text}");

                    // Add car to database
                    repository.InsertCar(car);
                    // Succuess
                    MessageBox.Show(
                        "Successfully added the car to the database", 
                        "Car Added To Database", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a user.", "No User Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
