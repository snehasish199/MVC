using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardApplication
{
    public interface IFrequentFlyerNumberValidator
    {
        bool IsValid(string FrequentFlyerNumber);
        void IsValid(string FrequentFlyerNumber, out bool isValid);
        string LicenseKey { get; }
    }
}
