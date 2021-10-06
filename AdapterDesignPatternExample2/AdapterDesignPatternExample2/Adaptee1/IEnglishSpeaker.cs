using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPatternExample2.Adaptee1
{
  public  interface IEnglishSpeaker
    {
        string AskInEnglish(string words);
        string ReplyInEnglish(string words);
    }
}
