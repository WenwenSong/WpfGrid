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
using System.Data.Entity;

namespace WpfGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.SetInitializer<TestDBContext>(null);
        }

        TestDBContext db = new TestDBContext();
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindDrp();
            GetData();
        }

        protected void GetData()
        {
            List<City> list = db.City.ToList<City>();
            gridCitys.ItemsSource = list;
        }

        public List<Province> ProvinceList { get; set; }
        protected void BindDrp()
        {
            List<Province> list = db.Province.ToList<Province>();
            proID.ItemsSource = list;
            ProvinceList = list;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                City city = (City)gridCitys.SelectedItem;
                city.UpdateDate = DateTime.Now;
                txtMsg.Text = city.proID + "//" + city.cityName;
                City modifyCity = db.City.Find(city.cityID);
                modifyCity = city;
                db.SaveChanges();
                txtMsg.Text += " Save successfully!";
            }
            catch (Exception ex)
            {
                txtMsg.Text += ex.Message;
            }
        }
    }
}
