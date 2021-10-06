using AdapterDesignPatternExample2.Adaptee1;
using AdapterDesignPatternExample2.Adaptee2;
using AdapterDesignPatternExample2.Target;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPatternExample2.Adapter
{
    public class Translator : ITranslator
    {

        static Dictionary<string, string> EnglishFrenchDictionary = new Dictionary<string, string>();
        static Dictionary<string, string> FrenchEnglishDictionary = new Dictionary<string, string>();
        EnglishSpeaker englishSpeaker = new EnglishSpeaker();
        FrenchSpeaker frenchSpeaker = new FrenchSpeaker();

        static Translator()
        {
            EnglishFrenchDictionary.Add("how are you?", "comment allez-vous?");
            EnglishFrenchDictionary.Add("I am in India", "Je suis aux Etats-Unis");
            FrenchEnglishDictionary.Add("Je suis très bien", "I am fine");
            FrenchEnglishDictionary.Add("où êtes-vous?", "where are you?");

        }





        public string EnglishToFrench(string words)
        {
            string FrenchConverted = ConvertToFrench(words);



                Console.WriteLine("\nTranslator Converted \"" + words +
                    " \" to \"" + FrenchConverted+ " and send the question to French man");

            string FrenchReply = frenchSpeaker.ReplyInFrench(FrenchConverted);

            Console.WriteLine("Translator Got reply from John in French : " + "\"" + FrenchReply + "\"");

            string EnglishConverted = ConvertToEnglish(FrenchReply);

            Console.WriteLine("Translator Converted " + "\"" + FrenchReply + "\"" +
                " to " + "\"" + EnglishConverted + "\"" + " and send back to English man\n");
            return EnglishConverted;
        }

        public string FrenchToEnglish(string words)
        {
            string EnglishConverted = ConvertToEnglish(words);
            Console.WriteLine("\nTranslator Converted \"" + words +
                      " \" to \"" + EnglishConverted + " and send the question to English man");

            string EnglishReply = englishSpeaker.ReplyInEnglish(EnglishConverted);

            Console.WriteLine("Translator Got reply  in English : " + "\"" + EnglishReply + "\"");

            string FrenchConverted = ConvertToFrench(EnglishReply);

            Console.WriteLine("Translator Converted " + "\"" + EnglishReply + "\"" +
                " to " + "\"" + FrenchConverted + "\"" + " and send back to English man\n");
            return FrenchConverted;
        }

        public string ConvertToFrench(string Words)
        {
            return EnglishFrenchDictionary[Words];
        }
        public string ConvertToEnglish(string Words)
        {
            return FrenchEnglishDictionary[Words];
        }
    }
}
