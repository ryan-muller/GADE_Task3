using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RTS_Game
{
    class Map
    {
        private const int mAX_WIDTH = 30;
        private const int mAX_HEIGHT = 30;
        char[,] arrMap;
        int unitCount;
        int buildingCount;
        Building[] buildings;
        Unit[] units;
        public Map(int numUnits, int numBuildings)
        {
            unitCount = numUnits;
            units = new Unit[unitCount];
            buildingCount = numBuildings;
            buildings = new Building[buildingCount];
        }

        public Unit[] Units { get => units; set => units = value; }
        public Building[]  Buildings { get => buildings; set => buildings = value; }

        public static int MAX_HEIGHT => mAX_HEIGHT;

        public static int MAX_WIDTH => mAX_WIDTH;

        public void GenerateBattlefield()
        {
            arrMap = new char[MAX_HEIGHT,MAX_WIDTH];

            Random rand = new Random();
            
            for (int i = 0; i < units.Length; i++)
            {
                int type = rand.Next(0, 2);
                int team = rand.Next(0, 2);
                int xPos = rand.Next(0, MAX_WIDTH);
                int yPos = rand.Next(0, MAX_HEIGHT);
                
                switch (type)
                {
                    case 0:
                        switch (team)
                        {
                            case 0:
                                for (int j = 0; j < i; j++)
                                {
                                    string unitType = units[j].GetType().ToString();
                                    string[] arr = unitType.Split('.');
                                    unitType = arr[arr.Length - 1];

                                    if (unitType == "MeleeUnit")
                                    {
                                        MeleeUnit temp = (MeleeUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }
                                    else
                                    {
                                        RangedUnit temp = (RangedUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }                                   
                                }
                                units[i] = new MeleeUnit("Knight" ,xPos, yPos, 20, 2, 4, 1, 0, 'M', false);                
                                break;
                            case 1:
                                for (int j = 0; j < i; j++)
                                {
                                    string unitType = units[j].GetType().ToString();
                                    string[] arr = unitType.Split('.');
                                    unitType = arr[arr.Length - 1];

                                    if (unitType == "MeleeUnit")
                                    {
                                        MeleeUnit temp = (MeleeUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }
                                    else
                                    {
                                        RangedUnit temp = (RangedUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }
                                }
                                units[i] = new MeleeUnit("Bandit",xPos, yPos, 20, 2, 4, 1, 1, 'm', false);
                                break;
                        }
                        break;
                    case 1:
                        switch (team)
                        {
                            case 0:
                                for (int j = 0; j < i; j++)
                                {
                                    string unitType = units[j].GetType().ToString();
                                    string[] arr = unitType.Split('.');
                                    unitType = arr[arr.Length - 1];

                                    if (unitType == "MeleeUnit")
                                    {
                                        MeleeUnit temp = (MeleeUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }
                                    else
                                    {
                                        RangedUnit temp = (RangedUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }
                                }
                                units[i] = new RangedUnit("Bowman",xPos, yPos, 15, 1, 2, 4, 0, 'R', false);
                                break;
                            case 1:
                                for (int j = 0; j < i; j++)
                                {
                                    string unitType = units[j].GetType().ToString();
                                    string[] arr = unitType.Split('.');
                                    unitType = arr[arr.Length - 1];

                                    if (unitType == "MeleeUnit")
                                    {
                                        MeleeUnit temp = (MeleeUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }
                                    else
                                    {
                                        RangedUnit temp = (RangedUnit)units[j];
                                        while (xPos == temp.XPos && yPos == temp.YPos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            j = 0;
                                        }
                                    }
                                }
                                units[i] = new RangedUnit("Slinger",xPos, yPos, 15, 1, 2, 4, 1, 'r', false);
                                break;
                        }
                        break;
                }
                
            }
            for (int y = 0; y < MAX_HEIGHT; y++)
            {
                for (int x = 0; x < MAX_WIDTH; x++)
                {
                    arrMap[y, x] = '.';
                }
            }
            for (int i = 0; i < units.Length; i++)
            {
                string unitType = units[i].GetType().ToString();
                string[] arr = unitType.Split('.');
                unitType = arr[arr.Length - 1];

                if (unitType == "MeleeUnit")
                {
                    MeleeUnit temp = (MeleeUnit)units[i];
                    arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                }
                else
                {
                    RangedUnit temp = (RangedUnit)units[i];
                    arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                }
            }

            for (int k = 0; k < buildings.Length; k++)
            {
                int team = rand.Next(0, 2);
                int type = rand.Next(0, 2);
                int xPos = rand.Next(0, MAX_WIDTH);
                int yPos = rand.Next(0, MAX_HEIGHT);

                switch (type)
                {
                    case 0:
                        int producedUnitID = rand.Next(0, 2);
                        string factoryUnit;
                        if (producedUnitID == 0)
                        {
                            factoryUnit = "MeleeUnit";
                        }else
                        {
                            factoryUnit = "RangedUnit";
                        }
                        switch (team)
                        {
                            case 0:
                                for (int p = 0; p < k; p++)
                                {
                                    string buldingType = buildings[p].GetType().ToString();
                                    string[] arr = buldingType.Split('.');
                                    buldingType = arr[arr.Length - 1];

                                    if (buldingType == "FactoryBuilding")
                                    {
                                        FactoryBuilding temp = (FactoryBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                    else
                                    {
                                        ResourceBuilding temp = (ResourceBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                }
                                buildings[k] = new FactoryBuilding(xPos, yPos, factoryUnit, 30, 0, 'F');
                                break;
                            case 1:
                                for (int p = 0; p < k; p++)
                                {
                                    string buldingType = buildings[p].GetType().ToString();
                                    string[] arr = buldingType.Split('.');
                                    buldingType = arr[arr.Length - 1];

                                    if (buldingType == "FactoryBuilding")
                                    {
                                        FactoryBuilding temp = (FactoryBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                    else
                                    {
                                        ResourceBuilding temp = (ResourceBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                }
                                buildings[k] = new FactoryBuilding(xPos, yPos, factoryUnit, 30, 1, 'f');
                                break;
                        }
                        break;
                    case 1:
                        switch (team)
                        {
                            case 0:
                                for (int p = 0; p < k; p++)
                                {
                                    string buldingType = buildings[p].GetType().ToString();
                                    string[] arr = buldingType.Split('.');
                                    buldingType = arr[arr.Length - 1];

                                    if (buldingType == "FactoryBuilding")
                                    {
                                        FactoryBuilding temp = (FactoryBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                    else
                                    {
                                        ResourceBuilding temp = (ResourceBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                }
                                buildings[k] = new ResourceBuilding(xPos, yPos, 40, 0, 'X');
                                break;
                            case 1:
                                for (int p = 0; p < k; p++)
                                {
                                    string buldingType = buildings[p].GetType().ToString();
                                    string[] arr = buldingType.Split('.');
                                    buldingType = arr[arr.Length - 1];

                                    if (buldingType == "FactoryBuilding")
                                    {
                                        FactoryBuilding temp = (FactoryBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                    else
                                    {
                                        ResourceBuilding temp = (ResourceBuilding)buildings[p];
                                        while (xPos == temp.Xpos && yPos == temp.Ypos)
                                        {
                                            xPos = rand.Next(0, MAX_WIDTH);
                                            yPos = rand.Next(0, MAX_HEIGHT);
                                            p = 0;
                                        }
                                    }
                                }
                                buildings[k] = new ResourceBuilding(xPos, yPos, 40, 1, 'x');
                                break;
                        }
                        break;
                }               
            }
            for (int i = 0; i < buildings.Length; i++)
            {
                string buildingType = buildings[i].GetType().ToString();
                string[] arr = buildingType.Split('.');
                buildingType = arr[arr.Length - 1];
                if (buildingType == "FactoryBuilding")
                {
                    FactoryBuilding temp = (FactoryBuilding)buildings[i];
                    arrMap[temp.Ypos, temp.Xpos] = temp.Symbol;
                }
                else
                {
                    ResourceBuilding temp = (ResourceBuilding)buildings[i];
                    arrMap[temp.Ypos, temp.Xpos] = temp.Symbol;
                }
            }
        }

        public string PopulateMap()
        {
            string output="";
            for (int y = 0; y < MAX_HEIGHT; y++)
            {
                for (int x = 0; x < MAX_WIDTH; x++)
                {
                    output = output + arrMap[y, x];
                }
                output = output + "\n";
            }
            return output;
        }

        public void updatePosition(Unit u, int direction)
        {
            string unitType = u.GetType().ToString();
            string[] arr = unitType.Split('.');
            unitType = arr[arr.Length - 1];

            if (unitType == "MeleeUnit")
            {
                MeleeUnit temp = (MeleeUnit)u;
                switch (direction)
                {
                    case 1:
                        arrMap[temp.YPos + 1, temp.XPos] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 2:
                        arrMap[temp.YPos, temp.XPos - 1] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 3:
                        arrMap[temp.YPos - 1, temp.XPos] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 4:
                        arrMap[temp.YPos, temp.XPos + 1] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 5:
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                }                   
            }
            else
            {
                RangedUnit temp = (RangedUnit)u;
                switch (direction)
                {
                    case 1:
                        arrMap[temp.YPos + 1, temp.XPos] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 2:
                        arrMap[temp.YPos, temp.XPos - 1] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 3:
                        arrMap[temp.YPos - 1, temp.XPos] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 4:
                        arrMap[temp.YPos, temp.XPos + 1] = '.';
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                    case 5:
                        arrMap[temp.YPos, temp.XPos] = temp.Symbol;
                        break;
                }
            }
        }
        public void Read()
        {
            for (int y = 0; y < MAX_HEIGHT; y++)
            {
                for (int x = 0; x < MAX_WIDTH; x++)
                {
                    arrMap[y, x] = '.';
                }
            }

            FileStream fsBuilding = new FileStream("saves/buildings.game", FileMode.Open, FileAccess.Read);
            StreamReader readerBuilding = new StreamReader(fsBuilding);
            int buildingCount = File.ReadAllLines("saves/buildings.game").Length;
            int index = 0;
            string line = readerBuilding.ReadLine();
            buildings = new Building[buildingCount];
            while (line != null)
            {
                string[] lineArr = line.Split(',');
                if (lineArr[0] == "FactoryBuilding")
                {
                    int xPos = Convert.ToInt32(lineArr[1]);
                    int yPos = Convert.ToInt32(lineArr[2]);
                    int hp = Convert.ToInt32(lineArr[3]);
                    int maxHp = Convert.ToInt32(lineArr[4]);
                    int team = Convert.ToInt32(lineArr[5]);
                    char symbol = Convert.ToChar(lineArr[6]);
                    string unitType = Convert.ToString(lineArr[7]);
                    int productionSpeed = Convert.ToInt32(lineArr[8]);

                    buildings[index] = new FactoryBuilding(xPos, yPos, unitType, hp, maxHp, team, symbol);
                    arrMap[yPos, xPos] = symbol;
                } else 
                if (lineArr[0] == "ResourceBuilding")
                {
                    int xPos = Convert.ToInt32(lineArr[1]);
                    int yPos = Convert.ToInt32(lineArr[2]);
                    int hp = Convert.ToInt32(lineArr[3]);
                    int maxHp = Convert.ToInt32(lineArr[4]);
                    int team = Convert.ToInt32(lineArr[5]);
                    char symbol = Convert.ToChar(lineArr[6]);
                    string resourceType = Convert.ToString(lineArr[7]);
                    int generated = Convert.ToInt32(lineArr[8]);
                    int genPerRound = Convert.ToInt32(lineArr[9]);
                    int remainingPool = Convert.ToInt32(lineArr[10]);

                    buildings[index] = new ResourceBuilding(xPos, yPos, hp, maxHp, team, symbol, resourceType, generated, genPerRound, remainingPool);
                    arrMap[yPos, xPos] = symbol;
                }
                index++;
                line = readerBuilding.ReadLine();
            }
            fsBuilding.Close();

            FileStream fsUnit = new FileStream("saves/units.game", FileMode.Open, FileAccess.Read);
            StreamReader readerUnit = new StreamReader(fsUnit);
            int unitCount = File.ReadAllLines("saves/units.game").Length;
            index = 0;
            line = readerUnit.ReadLine();
            units = new Unit[unitCount];

            while (line != null)
            {
                string[] lineArr = line.Split(',');
                if (lineArr[0] == "MeleeUnit")
                {
                    string name = Convert.ToString(lineArr[1]);
                    int xPos = Convert.ToInt32(lineArr[2]);
                    int yPos = Convert.ToInt32(lineArr[3]);
                    int hp = Convert.ToInt32(lineArr[4]);
                    int maxHp = Convert.ToInt32(lineArr[5]);
                    int team = Convert.ToInt32(lineArr[6]);
                    char symbol = Convert.ToChar(lineArr[7]);
                    int speed = Convert.ToInt32(lineArr[8]);
                    int atk = Convert.ToInt32(lineArr[9]);
                    int atkRange = Convert.ToInt32(lineArr[10]);
                    bool attacking = Convert.ToBoolean(lineArr[11]);

                    units[index] = new MeleeUnit(name, xPos, yPos, hp, maxHp, speed,atk, atkRange, team, symbol, attacking );
                    arrMap[yPos, xPos] = symbol;
                }
                else if (lineArr[0] == "RangedUnit")
                {
                    string name = Convert.ToString(lineArr[1]);
                    int xPos = Convert.ToInt32(lineArr[2]);
                    int yPos = Convert.ToInt32(lineArr[3]);
                    int hp = Convert.ToInt32(lineArr[4]);
                    int maxHp = Convert.ToInt32(lineArr[5]);
                    int team = Convert.ToInt32(lineArr[6]);
                    char symbol = Convert.ToChar(lineArr[7]);
                    int speed = Convert.ToInt32(lineArr[8]);
                    int atk = Convert.ToInt32(lineArr[9]);
                    int atkRange = Convert.ToInt32(lineArr[10]);
                    bool attacking = Convert.ToBoolean(lineArr[11]);

                    units[index] = new RangedUnit(name, xPos, yPos, hp, maxHp, speed, atk, atkRange, team, symbol, attacking);
                    arrMap[yPos, xPos] = symbol;
                }
                index++;
                line = readerUnit.ReadLine();
            }
            fsUnit.Close();

            
            
        }
    }
}
