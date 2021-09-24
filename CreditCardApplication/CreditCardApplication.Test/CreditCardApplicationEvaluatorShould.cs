using System;
using Xunit;
using Moq;

namespace CreditCardApplication.Test
{
    public class CreditCardApplicationEvaluatorShould
    {
        [Fact]
        public void AutoAcceptedHighIncomeApplication()
        {
            Mock<IFrequentFlyerNumberValidator> MockValidator = new Mock<IFrequentFlyerNumberValidator>();
            var sut = new CreditCardApplicationEvaluator(MockValidator.Object);
            var application = new CreditCardApplication()
            {
                GrossAnnualIncome = 100000
            };
            CreditCardApplicationDecision decision = sut.Evaluate(application);
            Assert.Equal(CreditCardApplicationDecision.AutoAccepted,decision);
        }
        [Fact]
        public void ReferYoungAgeApllicationReferToHuman()
        {
            Mock<IFrequentFlyerNumberValidator> MockValidator = new Mock<IFrequentFlyerNumberValidator>();
            MockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
                      var sut = new CreditCardApplicationEvaluator(MockValidator.Object);
            var application = new CreditCardApplication()
            {
                Age = 19
            };
            CreditCardApplicationDecision decision = sut.Evaluate(application);
            Assert.Equal(CreditCardApplicationDecision.RefferedToHuman, decision);
        }
        [Fact]
        public void DeclineLowIncomeApplication()
        {
            var MockValidator = new Mock<IFrequentFlyerNumberValidator>();

            //MockValidator.Setup(x => x.IsValid("y")).Returns(true);
            // MockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);//it will return true if you not  provide frequentflyernumber
            // MockValidator.Setup(x => x.IsValid(It.IsIn<string>("a","b","y"))).Returns(true);
            // MockValidator.Setup(x => x.IsValid(It.IsInRange<string>("a","y",Moq.Range.Inclusive))).Returns(true);
            // MockValidator.Setup(x => x.IsValid(It.Is<string>(exp=>exp.StartsWith("y")))).Returns(true);
            // MockValidator.Setup(x => x.IsValid(It.Is<string>(exp=>exp.EndsWith("y")))).Returns(true);
            MockValidator.Setup(x => x.IsValid(It.IsRegex("[^a-x]"))).Returns(true);


            var sut = new CreditCardApplicationEvaluator(MockValidator.Object);
            var application = new CreditCardApplication()
            {
               GrossAnnualIncome=19999,
               Age=33,
            FrequentFlyerNumber="y"
            };

           


            CreditCardApplicationDecision decision = sut.Evaluate(application);
            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }

        [Fact]
        public void ReferInvalidFrequentFlyerNumberApplication()
        {
            Mock<IFrequentFlyerNumberValidator> MockValidator = 
                new Mock<IFrequentFlyerNumberValidator>();

            MockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var sut = new CreditCardApplicationEvaluator(MockValidator.Object);
            var application = new CreditCardApplication();
            CreditCardApplicationDecision decision = sut.Evaluate(application);
            Assert.Equal(CreditCardApplicationDecision.RefferedToHuman, decision);
        }

        [Fact]
        public void AutoDeclineLowIncomeUsingOutDemo()
        {
            Mock<IFrequentFlyerNumberValidator> MockValidator = new Mock<IFrequentFlyerNumberValidator>();
            bool isValid = true;
            MockValidator.Setup(x => x.IsValid(It.IsAny<string>(),out isValid));
            var sut = new CreditCardApplicationEvaluator(MockValidator.Object);
            var application = new CreditCardApplication()
            {
                GrossAnnualIncome = 19999,
                Age = 42
            };
            CreditCardApplicationDecision decision = sut.EvaluateUsingOut(application);
            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }
        [Fact]

        public void ReferWhenLicenseKeyExpired()
        {
            Mock<IFrequentFlyerNumberValidator> MockValidator = new Mock<IFrequentFlyerNumberValidator>();

            MockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            MockValidator.Setup(x => x.LicenseKey).Returns("EXPIRED");

            var sut = new CreditCardApplicationEvaluator(MockValidator.Object);

            var application = new CreditCardApplication()
            {
                Age = 42
            };
            CreditCardApplicationDecision decision = sut.Evaluate(application);
            Assert.Equal(CreditCardApplicationDecision.RefferedToHuman, decision);

        }
      
    }
}
