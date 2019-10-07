using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Game
{
    public abstract class Building
    {
        protected int team;
        protected char symbol;
        protected int xpos;
        protected int ypos;
        protected int hp;
        protected int maxHp;

        protected Building(int xpos, int ypos, int hp, int team, char symbol)
        {
            this.xpos = xpos;
            this.ypos = ypos;
            this.hp = hp;
            this.maxHp = hp;
            this.team = team;
            this.symbol = symbol;
        }

        public abstract void Death();

        public abstract override string ToString();

        public abstract string Save();
    }
}
