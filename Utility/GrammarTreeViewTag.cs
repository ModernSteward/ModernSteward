using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
    public class GrammarTreeViewTag
    {

        public GrammarTreeViewTag()
        {

        }

        public GrammarTreeViewTag(bool aIsDictation, string aDictationContext, bool aOptional) {
            IsDictation = aIsDictation;
            DictationContext = aDictationContext;
            Optional = aOptional;
        }

        public bool IsDictation { get; set; }
        public string DictationContext { get; set; }
        public bool Optional { get; set; }
    }
}
