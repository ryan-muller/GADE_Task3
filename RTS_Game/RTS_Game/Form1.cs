using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RTS_Game
{
    public partial class frmGameWindow : Form
    {
        
        GameEngine game = new GameEngine(8, 4);
        public frmGameWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game.GameBrain();
            lblMap.Text = game.MapData.PopulateMap();

            for (int i = 0; i < game.MapData.Units.Length; i++)
            {
                rtbUnitInfo.Text = rtbUnitInfo.Text + game.MapData.Units[i].ToString();
            }
            for (int i = 0; i < game.MapData.Buildings.Length; i++)
            {
                rtbUnitInfo.Text = rtbUnitInfo.Text + game.MapData.Buildings[i].ToString();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.GameBrain();
            lblRoundCount.Text = "Round: " + Convert.ToString(game.RoundCount);
            lblResourcesTeam1.Text = "Team 1 Gems: " + Convert.ToString(game.Team1Gems);
            lblResourcesTeam2.Text = "Team 2 Gems: " + Convert.ToString(game.Team2Gems);
            lblMap.Text = game.MapData.PopulateMap();
            rtbUnitInfo.Text = "";
            for (int i = 0; i < game.MapData.Units.Length; i++)
            {
                rtbUnitInfo.Text = rtbUnitInfo.Text + game.MapData.Units[i].ToString();
            }
            for (int i = 0; i < game.MapData.Buildings.Length; i++)
            {
                rtbUnitInfo.Text = rtbUnitInfo.Text + game.MapData.Buildings[i].ToString();
            }

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            timerGame.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timerGame.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            FileStream fsUnits = new FileStream("saves/units.game", FileMode.Create, FileAccess.Write);
            StreamWriter writerUnits = new StreamWriter(fsUnits);
            for (int i = 0; i < game.MapData.Units.Length; i++)
            {                                        
                writerUnits.WriteLine(game.MapData.Units[i].Save());              
            }
            writerUnits.Close();
            fsUnits.Close();

            FileStream fsBuildings = new FileStream("saves/buildings.game", FileMode.Create, FileAccess.Write);
            StreamWriter writerBuildings = new StreamWriter(fsBuildings);
            for (int i = 0; i < game.MapData.Buildings.Length; i++)
            {
                writerBuildings.WriteLine(game.MapData.Buildings[i].Save());
            }
            writerBuildings.Close();
            fsBuildings.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            game.MapData.Read();
            lblMap.Text = game.MapData.PopulateMap();
            rtbUnitInfo.Text = "";
            for (int i = 0; i < game.MapData.Units.Length; i++)
            {
                rtbUnitInfo.Text = rtbUnitInfo.Text + game.MapData.Units[i].ToString();
            }
            for (int i = 0; i < game.MapData.Buildings.Length; i++)
            {
                rtbUnitInfo.Text = rtbUnitInfo.Text + game.MapData.Buildings[i].ToString();
            }
        }
    }
}
