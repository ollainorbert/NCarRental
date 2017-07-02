using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Windows.Input;

namespace NCarRental
{
    public class ProductsViewModel : ObservableObject, IPageViewModel
    {
        #region Fields

        private int _productId;
        private ProductModel _currentProduct;
        private ICommand _getProductCommand;
        private ICommand _saveProductCommand;

        #endregion

        #region Properties/Commands

        public string Name
        {
            get { return "Products"; }
        }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value != _productId)
                {
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }

        public ProductModel CurrentProduct
        {
            get { return _currentProduct; }
            set
            {
                if (value != _currentProduct)
                {
                    _currentProduct = value;
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }

        public ICommand GetProductCommand
        {
            get
            {
                doit();

                if (_getProductCommand == null)
                {
                    _getProductCommand = new RelayCommand(
                        param => GetProduct(),
                        param => ProductId > 0
                    );
                }
                return _getProductCommand;
            }
        }

        public ICommand SaveProductCommand
        {
            get
            {
                if (_saveProductCommand == null)
                {
                    _saveProductCommand = new RelayCommand(
                        param => SaveProduct(),
                        param => (CurrentProduct != null)
                    );
                }
                return _saveProductCommand;
            }
        }

        #endregion

        #region Methods

        private void GetProduct()
        {
            // Usually you'd get your Product from your datastore,
            // but for now we'll just return a new object
            ProductModel p = new ProductModel();
            p.ProductId = ProductId;
            p.ProductName = "Test Product";
            p.UnitPrice = 10;
            CurrentProduct = p;

            Console.WriteLine("asd");

            doit();

        }

        private void SaveProduct()
        {
            // You would implement your Product save here
        }

        public void doit()
        {
            FbConnection c = new FbConnection(@"Server=localhost;User=SYSDBA;Password=admin;Database=C:\Users\Norbert\Documents\Visual Studio 2015\Projects\NCarRental\NCarRental\_Resources\DB.FDB");

            //FbConnection c = new FbConnection(@"Server=localhost;User=SYSDBA;Password=admin;Database=C:\Users\Norbert\Documents\Visual Studio 2015\Projects\NCarRental\NCarRental\resources\TESTDB.FDB");


            FbCommand cmd = new FbCommand();

            //valami
            //FbCommand cmd = new FbCommand("insert into STOCK(item_id, item_name, item_cost, item_quant, item_evjarat, item_gyorsasag) values (@item_id, @item_name, @item_cost, @item_quant, @item_evjarat, @item_gyorsasag);");
            
            /*cmd.CommandText = "insert into STOCK(item_id, item_name, item_cost, item_quant, item_evjarat, item_gyorsasag) values (@item_id, @item_name, @item_cost, @item_quant, @item_evjarat, @item_gyorsasag);";
            cmd.CommandType = CommandType.Text;
            //item_name, item_cost, item_quant, item_evjarat, item_gyorsasag
            cmd.Parameters.Add("@item_id", 8);
            cmd.Parameters.Add("@item_name", "Opel Astra");
            cmd.Parameters.Add("@item_cost", 400000);
            cmd.Parameters.Add("@item_quant", 5);
            cmd.Parameters.Add("@item_evjarat", 2005);
            cmd.Parameters.Add("@item_gyorsasag", 180);

            using (cmd.Connection = new FbConnection(c.ConnectionString))
            {
                
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }*/
            
            using (cmd.Connection = new FbConnection(c.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from STOCK";
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("item_cost"));
                        Console.WriteLine(id);
                        Console.WriteLine(id);
                        Console.WriteLine(id);

                        Console.WriteLine("lekerdezes");
                    }
                }
            }
        }

        #endregion
    }
}
