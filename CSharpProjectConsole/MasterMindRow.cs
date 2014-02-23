using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectConsole
{
    class MasterMindRow
    {
        Color[] colors;

        enum Color { 
            red=0,
            green=1,
            blue=2,
            yellow=3,
            brown=4,
            orange=5,
            black=6,
            white=7,
            none=8
        }

        

        public MasterMindRow(int RowLength) {
            colors = new Color[RowLength];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.none;
            }

        }

        public Color GetRow(int index){
            return colors[index];
        }

        public override bool Equals(object obj)
        {
            MasterMindRow OtherRow = (MasterMindRow)obj;
            for (int i = 0; i < colors.Length; i++) {
                if (OtherRow.GetRow(i) != GetRow(i)) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
