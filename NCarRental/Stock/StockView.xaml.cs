using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace NCarRental.Stock
{
    /// <summary>
    /// Interaction logic for StockView.xaml
    /// </summary>
    public partial class StockView : UserControl
    {
        public StockView()
        {
            InitializeComponent();
            FillTHeGrid();
        }

        private void ListProducts(object sender, RoutedEventArgs e)
        {
            FillTHeGrid();
        }

        public void FillTHeGrid()
        {
            FbConnection c = new FbConnection(@"Server=localhost;User=SYSDBA;Password=admin;Database=C:\Users\Norbert\Documents\Visual Studio 2015\Projects\NCarRental\NCarRental\_Resources\DB.FDB");
            FbCommand cmd = new FbCommand();

            using (cmd.Connection = new FbConnection(c.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from STOCK";

                FbDataAdapter fda = new FbDataAdapter(cmd);
                DataTable dt = new DataTable("STOCK");
                fda.Fill(dt);
                CarListGrid.ItemsSource = dt.DefaultView;
            }
        }

    }
}
