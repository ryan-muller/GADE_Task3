using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Game
{
    class FactoryBuilding : Building
    {
        private string unitType;
        public int spawnPoint;
        private int productionSpeed;

        public int ProductionSpeed { get => productionSpeed;}
        public int Xpos { get => base.xpos; }
        public int Ypos { get => base.ypos; }
        public int Hp { get => base.hp; set => base.hp = value; }
        public int Team { get => base.team;}
        public char Symbol { get => base.symbol; set => base.symbol = value; }
        public int MaxHp { get => base.maxHp;}
        public string UnitType { get => unitType;}

        public FactoryBuilding(int xpos, int ypos, string unitType, int hp, int team, char symbol) : base(xpos, ypos, hp, team, symbol)
        {
            productionSpeed = 4;
            this.unitType = unitType;

        }

        public FactoryBuilding(int xpos, int ypos, string unitType, int hp,int maxHp, int team, char symbol) : base(xpos, ypos, hp, team, symbol)
        {
            productionSpeed = 4;
            this.unitType = unitType;
            this.maxHp = maxHp;
        }


        public override void Death()
        {
            this.Symbol = ',';
        }

        public override string ToString()
        {
            return ">Factory Building<" + "\nSymbol: " + this.Symbol + "\nX-Pos: " + this.Xpos + "\nY-Pos: " + this.Ypos + "\nTeam: " + this.Team + "\nMax HP:" + this.MaxHp + "\nCurrent HP: " + this.Hp + "\nUnit Type Created: " + this.unitType + "\nProduction Speed " + this.productionSpeed;
        }

        public Unit SpawnUnit()
        {
            Unit spawnedUnit;
            if (this.Team == 0)
            {
                if (this.unitType == "MeleeUnit")
                {
                    if (this.Ypos == 20)
                    {
                        spawnedUnit = new MeleeUnit("Knight", this.Xpos, this.Ypos - 1, 20, 2, 4, 1, 0, 'M', false);
                    }
                    else
                    {
                        spawnedUnit = new MeleeUnit("Knight", this.Xpos, this.Ypos + 1, 20, 2, 4, 1, 0, 'M', false);
                    }
                }
                else
                {
                    if (this.Ypos == 20)
                    {
                        spawnedUnit = new RangedUnit("Bowman", this.Xpos, this.Ypos - 1, 15, 1, 2, 4, 0, 'R', false);
                    }
                    else
                    {
                        spawnedUnit = new RangedUnit("Bowman", this.Xpos, this.Ypos + 1, 15, 1, 2, 4, 0, 'R', false);
                    }
                }
            } else
            {
                if (this.unitType == "MeleeUnit")
                {
                    if (this.Ypos == 20)
                    {
                        spawnedUnit = new MeleeUnit("Bandit", this.Xpos, this.Ypos - 1, 20, 2, 4, 1, 1, 'm', false);
                    }
                    else
                    {
                        spawnedUnit = new MeleeUnit("Bandit", this.Xpos, this.Ypos + 1, 20, 2, 4, 1, 1, 'm', false);
                    }
                }
                else
                {
                    if (this.Ypos == 20)
                    {
                        spawnedUnit = new RangedUnit("Slinger", this.Xpos, this.Ypos - 1, 15, 1, 2, 4, 1, 'r', false);
                    }
                    else
                    {
                        spawnedUnit = new RangedUnit("Slinger", this.Xpos, this.Ypos + 1, 15, 1, 2, 4, 1, 'r', false);
                    }
                }
            }
            return spawnedUnit;
        }

        public override string Save()
        {
            string savedBuilding;

            /*public int ProductionSpeed { get => productionSpeed; }
        public int Xpos { get => base.xpos; }
        public int Ypos { get => base.ypos; }
        public int Hp { get => base.hp; set => base.hp = value; }
        public int Team { get => base.team; }
        public char Symbol { get => base.symbol; set => base.symbol = value; }
        public int MaxHp { get => base.maxHp; }
        public string UnitType { get => unitType; }*/

            savedBuilding = "FactoryBuilding," + this.Xpos + "," + this.Ypos + "," + this.Hp + "," + this.MaxHp + "," + this.Team + "," + this.Symbol + "," + Convert.ToString(this.UnitType) + "," + this.ProductionSpeed;

            return savedBuilding;
        }
    }
}
