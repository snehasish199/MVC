using AdapterDesignPatternExample2.Adapter;
using AdapterDesignPatternExample2.Target;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPatternExample2.Adaptee1
{
    public class EnglishSpeaker : IEnglishSpeaker
    {
        public string AskInEnglish(string words)
        {
            Console.WriteLine("Question Asked by John [English Speaker and Can understand only English] : " + words);
            ITranslator pam = new Translator();
            string replyFromDavid = pam.EnglishToFrench(words);
            return replyFromDavid;
        }

        public string ReplyInEnglish(string words)
        {
            string reply = null;
            if (words.Equals("where are you?", StringComparison.InvariantCultureIgnoreCase))
            {
                reply = "I am in India";
            }
            return reply;
        }
    }
}
