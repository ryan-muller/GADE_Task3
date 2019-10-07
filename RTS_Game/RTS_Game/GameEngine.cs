using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Game
{
    public class GameEngine
    {
        const int NUM_UNITS = 8;
        int roundCount = 0;
        Unit[] units;
        Building[] buildings;
        Map mapData;

        public GameEngine(int numUnits, int numBuildings)
        {
            mapData = new Map(numUnits, numBuildings);
            this.mapData.GenerateBattlefield();
            units = this.mapData.Units;
        }

        public int RoundCount { get => roundCount;}
        internal Map MapData { get => mapData; }

        

        public void GameBrain()
        {                     
            
            int hpTeam0=0, hpTeam1=0;
            for (int i = 0; i < units.Length; i++)
            {
                string unitType = units[i].GetType().ToString();
                string[] arr = unitType.Split('.');
                unitType = arr[arr.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit temp = (MeleeUnit)units[i];
                    if (temp.Team == 0)
                    {
                        hpTeam0 = hpTeam0 + temp.Hp;
                    }
                    else
                    {
                        hpTeam1 = hpTeam1 + temp.Hp;
                    }
                }
                else
                {
                    RangedUnit temp = (RangedUnit)units[i];
                    if (temp.Team == 0)
                    {
                        hpTeam0 = hpTeam0 + temp.Hp;
                    }
                    else
                    {
                        hpTeam1 = hpTeam1 + temp.Hp;
                    }
                }
            }

            for (int k = 0; k < units.Length; k++)
            {
                if ((hpTeam0>0 && hpTeam1>0))
                {
                    int targetId;
                    int runMark;

                    string unitType = units[k].GetType().ToString();
                    string[] arr = unitType.Split('.');
                    unitType = arr[arr.Length - 1];

                    if (unitType == "MeleeUnit")
                    {
                        MeleeUnit temp = (MeleeUnit)units[k];
                        targetId = temp.ClosestUnit(units);
                        runMark = temp.Hp * (25 / 100);
                        if (temp.Hp < runMark)
                        {
                            
                            mapData.updatePosition(temp, temp.MoveUnit(units[targetId]));
                        }
                        else if (temp.Attacking == false && temp.CheckRange(units[targetId])==false)
                        {
                            mapData.updatePosition(temp, temp.MoveUnit(units[targetId]));
                        }
                        else if (temp.CheckRange(units[targetId]))
                        {
                            temp.Attacking = true;
                            temp.Attack(units[targetId]);
                        }
                    }
                    else
                    {
                        RangedUnit temp = (RangedUnit)units[k];
                        targetId = temp.ClosestUnit(units);
                        runMark = temp.Hp * (25 / 100);
                        if (temp.Hp < runMark)
                        {
                            mapData.updatePosition(temp, temp.MoveUnit(units[targetId]));
                        }
                        else if (temp.Attacking == false && temp.CheckRange(units[targetId]) == false)
                        {
                            mapData.updatePosition(temp, temp.MoveUnit(units[targetId]));
                        }
                        else if (temp.CheckRange(units[targetId]))
                        {
                            temp.Attacking = true;
                            temp.Attack(units[targetId]);
                        }
                    }
                }
                
            }
            buildings = this.mapData.Buildings;

            for (int p = 0; p < buildings.Length; p++)
            {
                string buldingType = buildings[p].GetType().ToString();
                string[] arr = buldingType.Split('.');
                buldingType = arr[arr.Length - 1];

                if (buldingType == "FactoryBuilding")
                {
                    FactoryBuilding temp = (FactoryBuilding)buildings[p];
                    if ( roundCount%temp.ProductionSpeed == 0 && roundCount != 0)
                    {
                        Array.Resize( ref units,units.Length + 1);
                        
                        units[units.Length - 1] = temp.SpawnUnit();
                        mapData.updatePosition(units[units.Length - 1], 5);
                    }
                }
                else
                {
                    ResourceBuilding temp = (ResourceBuilding)buildings[p];
                    temp.GenerateResources();
                }
            }
            roundCount++;
        }
    }

    
}
