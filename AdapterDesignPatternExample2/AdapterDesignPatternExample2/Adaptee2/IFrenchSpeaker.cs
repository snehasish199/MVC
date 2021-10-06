using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPatternExample2.Adaptee2
{
  public  interface IFrenchSpeaker
    {

        string AskInFrench(string words);
        string ReplyInFrench(string words);
    }
}
