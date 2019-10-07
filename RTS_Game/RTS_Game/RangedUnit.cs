﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Game
{
    class RangedUnit : Unit
    {
        public string Name { get => base.name; set => base.name = value; }
        public int XPos { get => base.xPos; set => base.xPos = value; }
        public int YPos { get => base.yPos; set => base.yPos = value; }
        public int Hp { get => base.hp; set => base.hp = value; }
        public int MaxHP { get => base.maxHp; }
        public int Speed { get => base.speed; }
        public int Atk { get => base.atk; }
        public int AtkRange { get => base.atkRange; }
        public int Team { get => base.team; }
        public char Symbol { get => base.symbol; set => base.symbol = value; }
        public bool Attacking { get => base.attacking; set => base.attacking = value; }

        public RangedUnit(string name, int xpos, int ypos, int hp, int speed, int atk, int atkRange, int team, char symbol, bool attacking) : base(name, xpos, ypos, hp, speed, atk, atkRange, team, symbol, attacking)
        {
            this.hp = 15;
            this.speed = 1;
            this.atk = 2;
            this.atkRange = 4;
            this.maxHp = hp;
        }

        public RangedUnit(string name, int xpos, int ypos, int hp, int maxHp,int speed, int atk, int atkRange, int team, char symbol, bool attacking) : base(name, xpos, ypos, hp, speed, atk, atkRange, team, symbol, attacking)
        {
            this.hp = 15;
            this.speed = 1;
            this.atk = 2;
            this.atkRange = 4;
            this.maxHp = hp;
        }

        public override string ToString()
        {
            return "Name: " + this.Name + "\nSymbol: " + this.Symbol + "\nX-Pos: " + this.XPos + "\nY-Pos: " + this.YPos + "\nTeam: " + this.Team + "\nMax HP:" + this.MaxHP + "\nCurrent HP: " + this.Hp + "\nSpeed: " + this.Speed + "\nAtk Damage: " + this.Atk + "\nAtk Range: " + this.AtkRange + "\nIs Attacking: " + this.Attacking + "\nType: " + this.GetType() + "\n";
        }

        public override void Attack(Unit u)
        {
            string unitType = u.GetType().ToString();
            string[] arr = unitType.Split('.');
            unitType = arr[arr.Length - 1];

            if (unitType == "MeleeUnit")
            {
                MeleeUnit temp = (MeleeUnit)u;
                temp.Hp = temp.Hp - this.Atk;
            }
            else
            {
                RangedUnit temp = (RangedUnit)u;
                temp.Hp = temp.Hp = this.Atk;
            }
        }

        public override bool CheckRange(Unit u)
        {
            string unitType = u.GetType().ToString();
            string[] arr = unitType.Split('.');
            unitType = arr[arr.Length - 1];

            if (unitType == "MeleeUnit")
            {
                MeleeUnit temp = (MeleeUnit)u;
                if (Math.Abs(this.XPos - temp.XPos) <= this.atkRange && Math.Abs(this.YPos - temp.YPos) <= this.atkRange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                RangedUnit temp = (RangedUnit)u;
                if (Math.Abs(this.XPos - temp.XPos) <= this.atkRange && Math.Abs(this.YPos - temp.YPos) <= this.atkRange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override int ClosestUnit(Unit[] u)
        {
            int distX = 20, distY = 20;
            int count = 0;
            int targetId = 0;
            while (count < u.Length)
            {
                string unitType = u[count].GetType().ToString();
                string[] arr = unitType.Split('.');
                unitType = arr[arr.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit temp = (MeleeUnit)u[count];
                    if ((this.XPos - temp.XPos) < distX && (this.YPos - temp.YPos) < distY && (this.XPos - temp.XPos) > 0 && (this.YPos - temp.YPos) > 0)
                    {
                        distX = (this.XPos - temp.XPos);
                        distY = (this.YPos - temp.YPos);
                        targetId = count;
                    }
                }
                else
                {
                    RangedUnit temp = (RangedUnit)u[count];
                    if ((this.XPos - temp.XPos) < distX && (this.YPos - temp.YPos) < distY && (this.XPos - temp.XPos) > 0 && (this.YPos - temp.YPos) > 0)
                    {
                        distX = (this.XPos - temp.XPos);
                        distY = (this.YPos - temp.YPos);
                        targetId = count;
                    }
                }
                count++;
            }
            return targetId;
        }

        public override void Death()
        {
            this.Symbol = ',';
        }

        public override int MoveUnit(Unit u)
        {
            int runMark = this.Hp * (25 / 100);
            if (this.Hp < runMark)
            {
                Random random = new Random();
                int direction = random.Next(1, 5);
                switch (direction)
                {
                    case 1:
                        this.YPos--;
                        break;
                    case 2:
                        this.XPos++;
                        break;
                    case 3:
                        this.YPos++;
                        break;
                    case 4:
                        this.XPos--;
                        break;
                }
                return direction;
            }
            else
            {
                int targetX, targetY;
                string unitType = u.GetType().ToString();
                string[] arr = unitType.Split('.');
                unitType = arr[arr.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit temp = (MeleeUnit)u;
                    targetX = temp.XPos;
                    targetY = temp.YPos;

                }
                else
                {
                    RangedUnit temp = (RangedUnit)u;
                    targetX = temp.XPos;
                    targetY = temp.YPos;

                }

                if ((this.XPos - targetX) < (this.YPos - targetY))
                {
                    if (this.XPos - targetX < 0)
                    {
                        this.XPos++;
                        return 2;
                    }
                    else
                    {
                        this.XPos--;
                        return 4;
                    }
                }
                else
                {
                    if (this.YPos - targetY < 0)
                    {
                        this.YPos++;
                        return 3;
                    }
                    else
                    {
                        this.YPos--;
                        return 1;
                    }
                }
            }
        }
        public override string Save()
        {
            string savedUnit;

            savedUnit = "RangedUnit," + this.Name + "," + this.XPos + "," + this.YPos + "," + this.Hp + "," + this.MaxHP + "," + this.Team + "," + this.Symbol + "," + this.Speed + "," + this.Atk + "," + this.AtkRange + "," + this.Attacking;

            return savedUnit;
        }
    }

}
