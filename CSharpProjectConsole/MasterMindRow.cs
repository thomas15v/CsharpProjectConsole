using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectConsole
{
    public enum Color
    {
        red = 0,
        green = 1,
        blue = 2,
        yellow = 3,
        brown = 4,
        orange = 5,
        black = 6,
        white = 7,
        none = 8
    }
    public class MasterMindRow
    {
        private Random random = new Random();
        private Color[] colors;

        public MasterMindRow(int RowLength)
        {
            colors = new Color[RowLength];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.none;
            }

        }

        public void Fill()
        {
            for (int i = 0; i < colors.Length; i++) SetColor(i, (Color)random.Next(0, 8));
        }

        public Color GetRow(int index)
        {
            return colors[index];
        }

        public void SetColor(int index, Color color)
        {
            colors[index] = color;
        }

        public MasterMindResult CompareWithSecretRow(MasterMindRow SecretRow)
        {
            int ColorMatch = 0;
            int PosMatch = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if (SecretRow.GetRow(i) == GetRow(i)) PosMatch++;
                for (int r = 0; r < colors.Length; r++)
                    if (SecretRow.GetRow(i) == GetRow(r)) ColorMatch++;
            }
            return new MasterMindResult(ColorMatch, PosMatch);
        }

        public override string ToString()
        {
            string returnvalue = "";
            foreach (Color color in colors){
                returnvalue += color + " ";
            }
            return returnvalue;

        }

        //For future, I don't know of this is helpfull yet

        static public Boolean operator ==(MasterMindRow row1, MasterMindRow row2)
        {
            return row1.Equals(row2);
        }

        static public Boolean operator !=(MasterMindRow row1, MasterMindRow row2)
        {
            return !(row1 == row2);
        }

        public override bool Equals(object obj)
        {
            MasterMindRow OtherRow = (MasterMindRow)obj;
            for (int i = 0; i < colors.Length; i++)
            {
                if (OtherRow.GetRow(i) != GetRow(i)) return false;

            }
            return true;
        }

        public override int GetHashCode()
        {
            int returnvalue = 0;
            foreach (Color color in colors)
            {
                returnvalue += (int)color;
                Console.WriteLine((int)color);
            }
            return returnvalue;
        }
    }
}
