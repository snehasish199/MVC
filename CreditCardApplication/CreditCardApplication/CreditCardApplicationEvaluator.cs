using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardApplication
{
   public class CreditCardApplicationEvaluator
    {
        private readonly IFrequentFlyerNumberValidator _validator;
        private const int AutoRefferalMaxAge = 20;
        private const int HighIncomeThreshold = 100000;
        private const int LowIncomeThreshold = 20000;
        public CreditCardApplicationEvaluator(IFrequentFlyerNumberValidator validator)
        {
            _validator = validator??throw new ArgumentException(nameof(validator));
        }
        public CreditCardApplicationDecision Evaluate(CreditCardApplication application)
        {
            if (application.GrossAnnualIncome >= HighIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoAccepted;
            }
            if (_validator.LicenseKey == "EXPIRED")
            {
                return CreditCardApplicationDecision.RefferedToHuman;
            }

            var IsValidFrequentFlyerNumber = _validator.IsValid(application.FrequentFlyerNumber);
            if (!IsValidFrequentFlyerNumber)
            {
                return CreditCardApplicationDecision.RefferedToHuman;
            }
            if (application.Age <= AutoRefferalMaxAge)
            {
                return CreditCardApplicationDecision.RefferedToHuman;
            }
            if (application.GrossAnnualIncome < LowIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoDeclined;
            }
            return CreditCardApplicationDecision.RefferedToHuman;
        }


        public CreditCardApplicationDecision EvaluateUsingOut(CreditCardApplication application)
        {
            if (application.GrossAnnualIncome >= HighIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoAccepted;
            }
           
             _validator.IsValid(application.FrequentFlyerNumber,out var isValidFrequentFlyerNumber);
            if (!isValidFrequentFlyerNumber)
            {
                return CreditCardApplicationDecision.RefferedToHuman;
            }
            if (application.Age <= AutoRefferalMaxAge)
            {
                return CreditCardApplicationDecision.RefferedToHuman;
            }
            if (application.GrossAnnualIncome < LowIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoDeclined;
            }
            return CreditCardApplicationDecision.RefferedToHuman;
        }

    }

}
