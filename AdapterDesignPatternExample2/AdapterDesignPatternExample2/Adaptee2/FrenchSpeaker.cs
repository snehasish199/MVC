using AdapterDesignPatternExample2.Adapter;
using AdapterDesignPatternExample2.Target;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPatternExample2.Adaptee2
{
    public class FrenchSpeaker : IFrenchSpeaker
    {
        public string AskInFrench(string words)
        {
            Console.WriteLine("Question Asked by David [French Speaker and Can understand only French] : " + words);
            ITranslator pam = new Translator();
            string replyFromJohn = pam.FrenchToEnglish(words);
            return replyFromJohn;
        }

        public string ReplyInFrench(string words)
        {
            string reply = null;
            if (words.Equals("comment allez-vous?", StringComparison.InvariantCultureIgnoreCase))
            {
                reply = "Je suis très bien";
            }
            return reply;
        }
    }
}
