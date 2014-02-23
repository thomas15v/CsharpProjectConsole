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
        int CurrentRow = 0;
         
        public MasterMindGame(int MaxTurns, int Rows) {
            this.HiddenRow = new MasterMindRow(Rows);
            HiddenRow.Fill();
            this.Rows = new MasterMindRow[MaxTurns];
            for (int i = 0; i < MaxTurns; i++ ) this.Rows[i] = new MasterMindRow(Rows);         
        }

        private MasterMindRow GetRow(int index) {
            return Rows[index];
        }

        public void SetColor(int Row, Color color) {
            this.GetCurrentRow().SetColor(Row, color);
        }

        public MasterMindResult EndTry() {
            return GetCurrentRow().CompareWithSecretRow(HiddenRow); ;
        }

        private MasterMindRow GetCurrentRow() {
            return this.Rows[CurrentRow];
        }

        public string GetDebugInfo() {
            return GetCurrentRow() + "\n" + HiddenRow;
        }

    }
}
