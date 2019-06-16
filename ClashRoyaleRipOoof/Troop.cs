using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRipOoof
{
    class Troop
    {
        float XPos;
        float YPos;
        int hp = 10;
        int Dmg = 3;
        int MoveSpeed;
        bool hasTarget = false;
        Troop target;

        public Troop(float X, float Y)
        {
            this.XPos = X;
            this.YPos = Y;
        }

        public float X
        { get { return XPos; } }
        public float Y
        { get { return YPos; } }

        public bool HaveTarget
        {
            get { return hasTarget; }
            set { hasTarget = value; }
        }

        public void Find_Target(List<Troop> enemyTroops)
        {
            if (enemyTroops.Count > 0)
            {
                target = enemyTroops[0];
                hasTarget = true;
                float smalest_distance = (float)Math.Sqrt(Math.Pow(enemyTroops[0].X, 2) + Math.Pow(enemyTroops[0].Y, 2));

                foreach (Troop i in enemyTroops.Skip(1))
                {
                    if (smalest_distance > Math.Sqrt((i.X * i.X) + (i.Y * i.Y))) 
                    {
                        smalest_distance = (float)Math.Sqrt((i.X * i.X) + (i.Y * i.Y));
                        target = i;
                    }
                }
            }
        }

        public void Take_Damage(int damage)
        {
            hp = hp - damage;

            if(hp <= 0)
            {

            }
        }
    }
}
