using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectConsole
{

    public enum Color
    {
        red = 1,
        green = 2,
        blue = 3,
        yellow = 4,
        brown = 5,
        orange = 6,
        black = 7,
        white = 8,
        none = 0
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
            for (int i = 0; i < colors.Length; i++) SetColor(i, (Color)random.Next(1, 9));
        }

        public Color GetColor(int index)
        {
            return colors[index];
        }

        public void SetColor(int index, Color color)
        {
            colors[index] = color;
        }

        private Color[] GetRow() {
            return colors;
        }

        public MasterMindResult CompareWithSecretRow(MasterMindRow SecretRow)
        {
            int ColorMatch = 0;
            int PosMatch = 0;
            Color[] RowToCompare = SecretRow.GetRow();

            for (int i = 0; i < colors.Length; i++)
            {
                if ((SecretRow.GetColor(i) == GetColor(i)))
                {
                    PosMatch++;
                }

                for (int r = 0; r < colors.Length; r++)
                    if (ColorInArray(RowToCompare, GetColor(i)))
                    {
                        ColorMatch++;
                        RemoveColorInArray(RowToCompare, GetColor(i));
                    }

            }
            return new MasterMindResult(ColorMatch, PosMatch);
        }

        private Boolean ColorInArray(Color[] colors, Color color)
        {
            foreach (Color Colorin in colors) if (Colorin == color) return true;
            return false;
        }

        private void RemoveColorInArray(Color[] RowToCompare, Color color) {
            for (int i = 0; i < RowToCompare.Length; i++) {
                if (RowToCompare[i] == color) RowToCompare[i] = Color.none;
            }
        }

        public override string ToString()
        {
            string returnvalue = "";
            foreach (Color color in colors)
            {
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
                if (OtherRow.GetColor(i) != GetColor(i)) return false;

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
