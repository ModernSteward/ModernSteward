using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;

namespace ModernSteward
{
    static public class SemanticsToDict
    {
        static public List<KeyValuePair<string, string>> Convert(SemanticValue aSemantics)
        {
            List<KeyValuePair<string, string>> semanticsToDict = new List<KeyValuePair<string, string>>();
            foreach (var s in aSemantics)
            {
                semanticsToDict.Add(new KeyValuePair<string, string>(s.Key.ToString(), s.Value.Value.ToString()));
            }
            return semanticsToDict;
        }
    }
}
