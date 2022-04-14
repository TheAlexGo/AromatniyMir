using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AromatniyMir.Models;

namespace AromatniyMir.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public int quantityInCart { get; set; }
        public decimal costWithQuantity { get; set; }
        public OrderProduct? orderProduct { get; set; }

        public CartPage(List<Product> products)
        {
            InitializeComponent();
            dataGridProducts.ItemsSource = products.OrderBy(p => p.ProductName).Distinct();
            foreach (var p in products.OrderBy(p => p.ProductName).Distinct())
            {
                orderProduct = new OrderProduct
                {
                    ProductArticle = p.ProductArticleNumber,
                    ProductAmount = products.Where(e => e == p).Count()
                };
            }
        }

        private void buttonQuantityPlus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonQuantityMinus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
