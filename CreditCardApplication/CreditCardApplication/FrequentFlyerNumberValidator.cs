using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardApplication
{
    public class FrequentFlyerNumberValidator : IFrequentFlyerNumberValidator
    {
        public string LicenseKey => throw new NotImplementedException("Not Implemented yet");

        //Contact an external service to validate a frequent flyer number
        public bool IsValid(string FrequentFlyerNumber)
        {
            throw new NotImplementedException("Simulate this real dependency hard to use");
        }

        public void IsValid(string FrequentFlyerNumber, out bool isValid)
        {
            throw new NotImplementedException("Simulate this real dependency hard to use");
        }
    }
}
