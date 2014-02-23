using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectConsole
{
    public class MasterMindResult
    {
        public int ColorMatch
        {
            get;
            private set;
        }
        public int PosMatch
        {
            get;
            private set;
        }
        public MasterMindResult(int ColorMatch, int PosMatch) {
            this.ColorMatch = ColorMatch;
            this.PosMatch = PosMatch;
        }


    }
}
