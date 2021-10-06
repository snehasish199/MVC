using AdapterDesignPatternExample2.Adaptee1;
using AdapterDesignPatternExample2.Adaptee2;
using System;

namespace AdapterDesignPatternExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            string replyFromDavid = new EnglishSpeaker().AskInEnglish("how are you?");
            Console.WriteLine("Reply From David [French Speaker can Speak and Understand only French] :  " + replyFromDavid);
            Console.WriteLine();
            string replyFromJohn = new FrenchSpeaker().AskInFrench("où êtes-vous?");
            Console.WriteLine("Reply From John [English Speaker can Speak and Understand only English] :  " + replyFromJohn);

            Console.Read();
        }
    }
}
