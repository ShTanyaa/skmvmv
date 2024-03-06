using Microsoft.EntityFrameworkCore;
using recipts.Models;
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

namespace recipts
{
    /// <summary>
    /// Логика взаимодействия для ReceiptsPage.xaml
    /// </summary>
    public partial class ReceiptsPage : Page
    {
        public ReceiptsPage()
        {
            InitializeComponent();
            var context = new ReceiptsShumkovaContext();
            receiptsItemsControl.ItemsSource = context
                .Receipts
                .Include(p => p.ReceiptIngridients)
                .ThenInclude(ri => ri.IngridientNavigation)
                .ToList();

            receiptsItemsControl.ItemsSource = LoadData();
           
        }
        private List<Receipt> LoadData()
        {
            using (var context = new ReceiptsShumkovaContext())
            {
                var productList = context
                    .Receipts
                    .Include(p => p.ReceiptIngridients)
                     .ThenInclude(ri => ri.IngridientNavigation)
                    .ToList();

                return productList;
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e) => Collaboration();

        private void Collaboration()
        {
            using (var context = new ReceiptsShumkovaContext())
            {
                var query=context.Receipts.Where(r => r.Name.Contains(searchString));
                var filteredList = query.ToList();
                receiptsItemsControl.ItemsSource = filteredList;
            }
        }
    }
}
