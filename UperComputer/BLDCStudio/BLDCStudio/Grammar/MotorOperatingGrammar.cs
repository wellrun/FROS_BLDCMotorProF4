using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace JohnbeeGrammar
{
    class MotorOperatingGrammar:TopGrammar
    {
        List<SemanticResultValue> SRV_Operating = new List<SemanticResultValue>();
        public string SRK_Operating = "Operating";

        public MotorOperatingGrammar(string myName)
        {
            GrammarName = myName;
            GrammarInit();
        }
        /// <summary>
        /// [打开|关闭|停止] 电机
        /// </summary>
        private void GrammarInit()
        {
            ListInit();
            Choices OperatingChoices = new Choices();
            foreach(SemanticResultValue tem in SRV_Operating)
            {
                OperatingChoices.Add(tem);
            }
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(TopName_gb);
            gb.Append(new SemanticResultKey(SRK_Operating, OperatingChoices));
            gb.Append("电机");
            RootGrammar = new Grammar(gb);
            RootGrammar_ShowPhrase = gb.DebugShowPhrases;
            RootGrammar.Name = GrammarName;
            RootGrammar.Enabled = true;
            //  RootGrammar.SpeechRecognized += Root_grammar_SpeechRecognized;
        }
        /// <summary>
        /// list初始化
        /// </summary>
        private void ListInit()
        {
            SRV_Operating.Add(new SemanticResultValue("打开", "On"));
            SRV_Operating.Add(new SemanticResultValue("关闭", "Off"));
            SRV_Operating.Add(new SemanticResultValue("停止", "Stop"));
        }

        private void Root_grammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Grammar.Name == RootGrammar.Name)
            {

            }
        }
    }
}
