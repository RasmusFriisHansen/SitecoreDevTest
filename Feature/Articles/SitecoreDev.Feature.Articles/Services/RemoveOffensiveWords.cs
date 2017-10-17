using System;
using System.Collections;
using System.Text;

namespace SitecoreDev.Feature.Articles.Models
{
    public class RemoveOffensiveWords : IHandleOffensiveWords
    {
        public string Handle(string txt)
        {
            string[] OffensiveWords = { "ass", "butt", "fuck" };
            StringBuilder builder = new StringBuilder();

            int length = 0;

            foreach (char letter in txt)
            {
                if (Char.IsLetter(letter))
                {
                    builder.Append(letter);

                }
                else
                {
                    foreach (string offword in OffensiveWords)
                    {
                        if (builder.ToString() == offword)
                        {
                            string stringSubstitude = new string('*', builder.Length);
                            txt = txt.Remove((length - (builder.Length)), builder.Length).Insert((length - (builder.Length)), stringSubstitude);
                            Console.WriteLine(txt);
                        }
                    }

                    builder.Clear();
                }
                length++;
            }

            return txt;
        }
    }
}