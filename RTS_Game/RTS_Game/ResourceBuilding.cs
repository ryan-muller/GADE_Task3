using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Game
{
    class ResourceBuilding : Building
    {
        private string type;
        private int remainingPool;
        private int generated;
        private int genPerRound;

        public int Xpos { get => base.xpos;}
        public int Ypos { get => base.ypos;}
        public int Hp { get => base.hp; set => base.hp = value; }
        public int MaxHp { get => base.maxHp;}
        public int Team { get => base.team;}
        public char Symbol { get => base.symbol; set => base.symbol = value; }
        public string Type { get => type;}
        public int RemainingPool { get => remainingPool; set => remainingPool = value; }
        public int Generated { get => generated; set => generated = value; }
        public int GenPerRound { get => genPerRound; set => genPerRound = value; }

        public ResourceBuilding(int xpos, int ypos, int hp, int team, char symbol) : base(xpos, ypos, hp, team, symbol)
        {
        }

        public ResourceBuilding(int xpos, int ypos, int hp,int maxHp, int team, char symbol,string resourceType,int generated,int genPerRound,int remainingPool) : base(xpos, ypos, hp, team, symbol)
        {
        }

        public override void Death()
        {
            this.Symbol = ',';
        }

        public override string ToString()
        {
            return ">Resource Building<" + "\nSymbol: " + this.Symbol + "\nX-Pos: " + this.Xpos + "\nY-Pos: " + this.Ypos + "\nTeam: " + this.Team + "\nMax HP:" + this.MaxHp + "\nCurrent HP: " + this.Hp + "\nResource Type: " + this.type + "\nResources Generated " + this.generated + "\nResources Per Round" + this.genPerRound + "\nResource Pool " + this.remainingPool + "\n";
        }

        public void GenerateResources()
        {
            if (this.Hp > 0 && this.remainingPool >= this.genPerRound)
            {
                this.generated = this.generated + this.genPerRound;
                this.remainingPool = this.remainingPool - this.genPerRound;
            }
        }

        public override string Save()
        {
            string savedBuilding = "";
              /* public int Xpos { get => base.xpos; }
        public int Ypos { get => base.ypos; }
        public int Hp { get => base.hp; set => base.hp = value; }
        public int MaxHp { get => base.maxHp; }
        public int Team { get => base.team; }
        public char Symbol { get => base.symbol; set => base.symbol = value; }
        public string Type { get => type; }
        public int RemainingPool { get => remainingPool; set => remainingPool = value; }
        public int Generated { get => generated; set => generated = value; }
        public int GenPerRound { get => genPerRound; set => genPerRound = value; }*/


        savedBuilding = "ResourceBuilding," + this.Xpos + "," + this.Ypos + "," + this.Hp + "," + this.MaxHp + "," + this.Team + "," + this.Symbol + "," + this.Type + "," + this.Generated + "," + this.GenPerRound + "," + this.RemainingPool;

            return savedBuilding;
        }
    }
}
