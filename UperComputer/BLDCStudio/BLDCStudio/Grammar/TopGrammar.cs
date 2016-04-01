using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
namespace JohnbeeGrammar
{
    class TopGrammar
    {
        public string GrammarName = null;
        public Grammar RootGrammar = null;/*根规则*/
        protected GrammarBuilder TopName_gb = new GrammarBuilder("冰娜，"); //顶级开头,相当于名字
        public string RootGrammar_ShowPhrase { set; get; }/*语法的text属性*/
    }
}
