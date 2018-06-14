using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StockView
{
    [ValueConversion(typeof(string), typeof(string))]
    class ColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var color = "White";
            if (values.Length > 1)
            {
                try
                {
                    var aa = values[0];
                    var bb = values[1];
                    var price = System.Convert.ToDecimal(aa);
                    var prevClose = System.Convert.ToDecimal(bb);
                    if (price > prevClose)
                    {
                        color = "Red";
                    }
                    else
                    {
                        color = "Green";
                    }

                }
                catch (Exception)
                {
                    
                }
            }
            return color;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
