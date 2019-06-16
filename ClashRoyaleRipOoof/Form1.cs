using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashRoyaleRipOoof
{
    public partial class Form1 : Form
    {
        int[,] map = new int[45,15];
        List<Troop> p1_Troops = new List<Troop>();
        List<Troop> p2_Troops = new List<Troop>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush brushi = new SolidBrush(Color.Green);

            g.FillRectangle(brushi, 100.5f, 100, 100, 0.1f) ;


        }

        private void PlaceNewTroop()
        {

        }

        private void TimerTick_Tick(object sender, EventArgs e)
        {
            AttackingTroops();
            RemoveKilledTroops();
            FindNewTargets();
            MovingTroops();
        }

        private void AttackingTroops()
        {
            for (int i = 0; i < p1_Troops.Count; i++)
            {
                p1_Troops[i].Attack();
            }

            for (int i = 0; i < p2_Troops.Count; i++)
            {
                p2_Troops[i].Attack();
            }
        }

        private void FindNewTargets()
        {
            for(int i = 0; i < p1_Troops.Count; i++)
            {
                if(!p1_Troops[i].HaveTarget)
                    p1_Troops[i].Find_Target(p2_Troops);
            }

            for (int i = 0; i < p2_Troops.Count; i++)
            {
                if (!p2_Troops[i].HaveTarget)
                    p2_Troops[i].Find_Target(p1_Troops);
            }
        }

        private void RemoveKilledTroops()
        {
            for (int i = 0; i < p1_Troops.Count; i++)
            {
                if(p1_Troops[0].Health <= 0)
                {
                    p1_Troops.RemoveAt(i);
                }
            }

            for (int i = 0; i < p2_Troops.Count; i++)
            {
                if (p2_Troops[0].Health <= 0)
                {
                    p2_Troops.RemoveAt(i);
                }
            }
        }

        private void MovingTroops()
        {

        }
    }
}
