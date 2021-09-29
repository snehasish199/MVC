using BookReading.Business;
using System;
using Xunit;

namespace BookReading.Test
{
   public class CheckEmailValidity
    {
        [Fact]
        public void EmailValidityShould()
        {
            //arrange
            var sut = new EmailValidityCheck();
            //act
            bool result = sut.isEmailValid("abc@gmail.com");
            //assert
            Assert.True(result);
        }
    }
}
