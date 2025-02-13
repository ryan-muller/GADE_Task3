﻿using System;
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
        int team1Gems=0, team2Gems=0;
        Unit[] units;
        Building[] buildings;
        Map mapData;

        public GameEngine(int numUnits, int numBuildings)
        {
            mapData = new Map(numUnits, numBuildings);
            this.mapData.GenerateBattlefield();
            units = this.mapData.Units;
            buildings = this.mapData.Buildings;
        }

        public int RoundCount { get => roundCount;}
        public int Team1Gems { get => team1Gems;}
        public int Team2Gems { get => team2Gems;}
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
                int targetId;
                if ((hpTeam0>0 && hpTeam1>0))
                {
                    
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
                else
                {
                    string unitType = units[k].GetType().ToString();
                    string[] arr = unitType.Split('.');
                    unitType = arr[arr.Length - 1];

                    if (unitType == "MeleeUnit")
                    {
                        MeleeUnit tempUnit = (MeleeUnit)units[k];
                        targetId = tempUnit.ClosestBuilding(buildings);
                        if (tempUnit.Attacking == false && tempUnit.CheckRange(buildings[targetId]) == false)
                        {
                            mapData.updatePosition(tempUnit, tempUnit.MoveUnit(buildings[targetId]));
                        }
                        else if (tempUnit.CheckRange(buildings[targetId]))
                        {
                            tempUnit.Attacking = true;
                            tempUnit.Attack(buildings[targetId]);
                        }                        
                    }
                    else
                    {
                        RangedUnit tempUnit = (RangedUnit)units[k];
                        targetId = tempUnit.ClosestBuilding(buildings);
                        if (tempUnit.Attacking == false && tempUnit.CheckRange(buildings[targetId]) == false)
                        {
                            mapData.updatePosition(tempUnit, tempUnit.MoveUnit(buildings[targetId]));
                        }
                        else if (tempUnit.CheckRange(buildings[targetId]))
                        {
                            tempUnit.Attacking = true;
                            tempUnit.Attack(buildings[targetId]);
                        }
                    }               
                }
                
            }
            

            for (int p = 0; p < buildings.Length; p++)
            {
                string buldingType = buildings[p].GetType().ToString();
                string[] arr = buldingType.Split('.');
                buldingType = arr[arr.Length - 1];

                if (buldingType == "FactoryBuilding")
                {
                    FactoryBuilding temp = (FactoryBuilding)buildings[p];
                    if (temp.Team == 0)
                    {
                        if (team1Gems >= 5)
                        {
                            Array.Resize(ref units, units.Length + 1);

                            units[units.Length - 1] = temp.SpawnUnit();
                            mapData.updatePosition(units[units.Length - 1], 5);
                            team1Gems -= 5;
                        }
                    }
                    else
                    {
                        if (team2Gems >= 5)
                        {
                            Array.Resize(ref units, units.Length + 1);

                            units[units.Length - 1] = temp.SpawnUnit();
                            mapData.updatePosition(units[units.Length - 1], 5);
                            team2Gems -= 5;
                        }
                    }
                }
                else
                {
                    ResourceBuilding temp = (ResourceBuilding)buildings[p];
                    temp.GenerateResources();
                    if (temp.Team == 0)
                    {
                        team1Gems += temp.GenPerRound;
                    }
                    else
                    {
                        team2Gems += temp.GenPerRound;
                    }
                    
                }
            }
            roundCount++;
        }
    }

    
}
