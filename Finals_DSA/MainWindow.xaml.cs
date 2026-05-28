using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finals_DSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Products { get; }
        public List<Product> Productss { get; } = new List<Product>();
      
        public class Product
        {

            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            //Initialize data

            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Ballpen", Description = "Permanent Ballpen with Black Ink", Price = 20},
                new Product { Id = 2, Name = "Notebook", Description = "Durable and High quality 80 sheets paper", Price = 40},
                new Product { Id = 3, Name = "Pencil", Description = "Smooth texture of Pencil", Price = 15 },
                new Product { Id = 4, Name = "Pen", Description = "Broad not smudge proof of Pen", Price = 25 },
                new Product { Id = 5, Name = "Eraser", Description = "Effective Flexible Eraser and Durable", Price = 10 }
            };

            this.DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text != "" && txtDescription.Text != "" && txtPrice.Text != "")
                {
                    Products.Add(new Product
                    {
                        Id = int.Parse(txtId.Text),
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        Price = decimal.Parse(txtPrice.Text)
                    });

                    myGridData.Items.Refresh();

                    txtId.Text = "";
                    txtName.Text = "";
                    txtDescription.Text = "";
                    txtPrice.Text = "";


                }
            }

            catch
            {
                MessageBox.Show("Please fill in all fields correctly");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (myGridData.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
                myGridData.Items.Refresh();
                MessageBox.Show("Product removed successfully");
            }
            else
            {
                MessageBox.Show("Please select an product to remove");
            }
        }

        private void btnAddtoCart_Click(object sender, RoutedEventArgs e)
        {
            if (myGridData.SelectedItem is Product selectedProduct)
            {
            Product newItem = new Product
            {
                Id = selectedProduct.Id,
                Name = selectedProduct.Name,
                Description = selectedProduct.Description,
                Price = selectedProduct.Price
            };
            Productss.Add(newItem);
            myGridData.Items.Refresh();
            myGridData2.Items.Refresh();
            MessageBox.Show("Product added to cart successfully");
            }
            else
            {
                MessageBox.Show("Please select a product to add to cart");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (myGridData.SelectedItem is Product selectedProduct)
            {
                txtId.Text = selectedProduct.Id.ToString();
                txtName.Text = selectedProduct.Name;
                txtDescription.Text = selectedProduct.Description;
                txtPrice.Text = selectedProduct.Price.ToString();
            }
        }







    }
}
