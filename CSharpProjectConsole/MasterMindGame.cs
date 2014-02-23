using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectConsole
{
    class MasterMindGame
    {
        private MasterMindRow HiddenRow;
        private MasterMindRow[] Rows;
        int MaxTurns;
        int CurrentRow = 0;
        int RowLength;
        public bool GameWon
        {
            private set;
            get;
        }
        public bool GameFinished{
            private set;
            get;
        }
         
        public MasterMindGame(int MaxTurns, int RowLength) {
            this.RowLength = RowLength;
            this.MaxTurns = MaxTurns;
            this.HiddenRow = new MasterMindRow(RowLength);
            HiddenRow.Fill();
            this.Rows = new MasterMindRow[MaxTurns];
            for (int i = 0; i < MaxTurns; i++ ) this.Rows[i] = new MasterMindRow(RowLength);         
        }

        private MasterMindRow GetRow(int index) {
            return Rows[index];
        }

        public void SetColor(int Row, Color color) {
            this.GetCurrentRow().SetColor(Row, color);
        }

        public MasterMindResult EndTry()
        {
            MasterMindResult result = GetCurrentRow().CompareWithSecretRow(HiddenRow);
            if (result.PosMatch == RowLength)
            {
                GameWon = true;
                GameFinished = true;
            }
            if (MaxTurns < CurrentRow)
            {
                GameFinished = true;     
            }
            return result;
        }

        

        private MasterMindRow GetCurrentRow() {
            return this.Rows[CurrentRow];
        }

        public string GetDebugInfo() {
            return GetCurrentRow() + "\n" + HiddenRow;
        }

    }
}
