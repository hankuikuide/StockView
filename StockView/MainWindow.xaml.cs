using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace StockView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer readDataTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            readDataTimer.Tick += new EventHandler(timeCycleAsync);
            readDataTimer.Interval = new TimeSpan(0, 0, 0, 1);
            readDataTimer.Start();

        }

        public void timeCycleAsync(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            StockGrid.AutoGenerateColumns = false;

            var result = GetRemoteResult();
            StockGrid.ItemsSource = GetRemoteResult();

        }

        public List<Stock> GetRemoteResult()
        {
            List<Stock> stocks = new List<Stock>();

            string query = "sz000503,sz300168,sh601360";
            string uri = "https://hq.sinajs.cn/list=" + query;

            string[] lines = GetHttpResult(uri);

            foreach (var item in lines)
            {
                var single = item.Split('"');
                if (single.Length > 1)
                {
                    var stock = GetStock(single);
                    stocks.Add(stock);
                }
            }

            return stocks;
        }

        private static string[] GetHttpResult(string uri)
        {
            HttpClient client = new HttpClient();
            var task = client.GetStringAsync(uri);
            string body = task.Result;
            string[] lines = body.Split(Environment.NewLine.ToCharArray());
            return lines;
        }

        public Stock GetStock(string[] source)
        {
            var s = source[1].Split(',');
            if (s.Length > 1)
            {
                Stock stock = new Stock
                {
                    Symbol = source[0].Substring(13, 6),
                    Name = s[0],
                    Price = s[3],
                    Increase = s[0],
                    PrevClose = s[2],
                    Open = s[1],
                };
                return stock;
            }
            else
            {
                throw new Exception("error");

            }
        }

    }
}
