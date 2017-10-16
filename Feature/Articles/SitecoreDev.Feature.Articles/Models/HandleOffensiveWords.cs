using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Articles.Models
{
  public class HandleOffensiveWords : IHandleOffensiveWords
  {
    public string Handle(string txt)
    {
      string substitudeLetter = "*";

      // Add any words to the list of offensive words
      ArrayList offensiveWords = new ArrayList();
      offensiveWords.Add("ass");
      offensiveWords.Add("butt");
      offensiveWords.Add("fuck");

      string thisString = txt;

      if (!String.IsNullOrEmpty(txt))
      {
        foreach (string word in offensiveWords)
        {
          string thisWord = word;
          int thisWordLength = 0;

          if (thisWord.Length > 0)
          {
            thisWordLength = thisWord.Length;
            string stringSubstitude = "";

            for (int i = 0; i <= thisWordLength-1; i++)
            {
              stringSubstitude = stringSubstitude + substitudeLetter;
            }

            int wordExsists = thisString.IndexOf(word);
            if (wordExsists > -1)
            {
              string beforeTxt = thisString.Substring(0, wordExsists);
              string afterTxt = thisString.Substring(wordExsists + thisWordLength);
              thisString = beforeTxt + stringSubstitude + afterTxt;
            }
          }    
        }       
      }
      return thisString;
    }
  }
}