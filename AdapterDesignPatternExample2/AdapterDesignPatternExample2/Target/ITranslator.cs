using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPatternExample2.Target
{
  public  interface ITranslator
    {
        string EnglishToFrench(string words);
        string FrenchToEnglish(string words);
    }
}
