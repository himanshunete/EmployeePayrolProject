using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class CultureInfo1
    {
        public string Rupee()
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IN");
            string str = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            return str;
        }
    }
}
