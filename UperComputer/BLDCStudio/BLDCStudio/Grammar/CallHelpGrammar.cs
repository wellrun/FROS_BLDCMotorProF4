using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
namespace JohnbeeGrammar
{
    class CallHelpGrammar:TopGrammar
    {
        public CallHelpGrammar(string myName)
        {
            GrammarName = myName;
            GrammarInit();
        }

        private void GrammarInit()
        {
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(TopName_gb);
            gb.Append("寻求帮助");
            RootGrammar = new Grammar(gb);
            RootGrammar_ShowPhrase = gb.DebugShowPhrases;
            RootGrammar.Name = GrammarName;
            RootGrammar.Enabled = true;
          //  RootGrammar.SpeechRecognized += Root_grammar_SpeechRecognized;
        }

        private void Root_grammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if(e.Result.Grammar.Name == RootGrammar.Name)
            {

            }
        }
    }
}
