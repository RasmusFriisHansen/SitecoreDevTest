using System.Collections;

namespace SitecoreDev.Feature.Articles.Models
{
  public class HandleOffensiveWords : IHandleOffensiveWords
  {
    public string Handle(string txt)
    {
      var substitudeLetter = "*";

      // Add any words to the list of offensive words
      var offensiveWords = new ArrayList();
      offensiveWords.Add("ass");
      offensiveWords.Add("butt");
      offensiveWords.Add("fuck");

      var thisString = txt;

      if (string.IsNullOrEmpty(txt))
        return txt;
      foreach (string word in offensiveWords)
      {
        var thisWord = word;
        var thisWordLength = thisWord.Length;

        if (thisWord.Length <= 0)
          continue;

        string stringSubstitude = new string('*',thisWordLength);

        var wordExsists = thisString.IndexOf(word);
        if (wordExsists > -1)
        {
          var beforeTxt = thisString.Substring(0, wordExsists);
          var afterTxt = thisString.Substring(wordExsists + thisWordLength);
          thisString = beforeTxt + stringSubstitude + afterTxt;
        }
      }

      return thisString;
    }
  }
}