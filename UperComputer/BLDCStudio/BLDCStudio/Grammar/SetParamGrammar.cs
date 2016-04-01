using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace JohnbeeGrammar
{
    class SetParamGrammar:TopGrammar
    {
        List<SemanticResultValue> SRV_Constraint = new List<SemanticResultValue>();
        List<SemanticResultValue> SRV_Subject = new List<SemanticResultValue>();
        List<SemanticResultValue> SRV_Value = new List<SemanticResultValue>();
        public string SRK_Constraint = "Constraint";
        public string SRK_Subject = "Subject";
        public SetParamGrammar(string myName)
        {
            GrammarName = myName;
            GrammarInit();
        }
        /// <summary>
        /// list初始化
        /// </summary>
        private void ListInit()
        {
            SRV_Constraint.Add(new SemanticResultValue(" ", "null"));
            SRV_Constraint.Add(new SemanticResultValue("最大", "Max"));
            SRV_Subject.Add(new SemanticResultValue("速度", "speed"));
            SRV_Subject.Add(new SemanticResultValue("电流", "current"));
            GrammarBuilder distance = new GrammarBuilder(new Choices("路程", "位移"));
            SRV_Subject.Add(new SemanticResultValue(distance, "distance"));
            // SRV_Value.Add()
        }
        /// <summary>
        ///设置(最大)[电流|速度|[路程|位移]]（为）xxxx
        /// </summary>
        private void GrammarInit()
        {
            ListInit();
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(TopName_gb);
            gb.Append("设置");
            Choices ConstranitChoices = new Choices();
            foreach(SemanticResultValue tem in SRV_Constraint)
            {
                ConstranitChoices.Add(tem);
            }
            gb.Append(new SemanticResultKey(SRK_Constraint, ConstranitChoices));
            Choices SubjectChoices = new Choices();
            foreach (SemanticResultValue tem in SRV_Subject)
            {
                SubjectChoices.Add(tem);
            }
            gb.Append(new SemanticResultKey(SRK_Subject, SubjectChoices));
            RootGrammar = new Grammar(gb);
            RootGrammar_ShowPhrase = gb.DebugShowPhrases;
            RootGrammar.Name = GrammarName;
            RootGrammar.Enabled = true;
            //  RootGrammar.SpeechRecognized += Root_grammar_SpeechRecognized;
        }

        private void Root_grammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Grammar.Name == RootGrammar.Name)
            {
            }
        }
    }
}
