using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Game
{
    public abstract class Unit
    {
        protected string name;
        protected int xPos, yPos, hp, maxHp, speed, atk, atkRange, team;
        protected char symbol;
        protected bool attacking;


        protected Unit(string name, int xpos, int ypos, int hp, int speed, int atk, int atkRange, int team, char symbol, bool attacking)
        {
            this.name = name;
            this.xPos = xpos;
            this.yPos = ypos;
            this.hp = hp;
            this.maxHp = hp;
            this.speed = speed;
            this.atk = atk;
            this.atkRange = atkRange;
            this.team = team;
            this.symbol = symbol;
            this.attacking = attacking;
        }

        public abstract int MoveUnit(Unit u);

        public abstract void Attack(Unit u);

        public abstract bool CheckRange(Unit u);

        public abstract int ClosestUnit(Unit[] u);

        public abstract void Death();

        public abstract override string ToString();

        public abstract string Save();

    }
}
