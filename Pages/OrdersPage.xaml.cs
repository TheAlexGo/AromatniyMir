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
using AromatniyMir.Models;

namespace AromatniyMir.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            if (App.CurrentUser?.UserRole == 3)
                btnShowProductsInOrder.Visibility = Visibility.Collapsed;
            List<Order> ordersList = App.db.Orders.ToList();
            dataGridOrders.ItemsSource = ordersList;
        }

        private void btnShowProductsInOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridOrders.SelectedIndex == -1)
                MessageBox.Show("Выберите заказ, который хотите просмотреть", "Ошибка при просмотре заказа",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                var row = dataGridOrders.SelectedItem as Order;
                if (row != null)
                {
                    int result = row.OrderId;
                    NavigationService.Navigate(new OrderProductListPage(result));
                }
            }
        }
    }
}
