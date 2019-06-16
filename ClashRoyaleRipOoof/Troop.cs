using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRipOoof
{
    class Troop
    {
        float x;
        float y;
        float attackRange = 5;
        float size = 4;
        int hp = 10;
        int dmg = 3;
        float moveSpeed = 0.1f;
        bool hasTarget = false;
        bool isAttaking = false;
        Troop target;

        public Troop(float X, float Y, List<Troop> t)
        {
            this.x = X;
            this.y = Y;
            Find_Target(t);
        }

        public float X
        { get { return x; } }
        public float Y
        { get { return y; } }
        public float Health
        { get { return hp; } }
        public float Damage
        { get { return y; } }
        public float AttackRange
        { get { return y; } }
        public float Hitbox
        { get { return size; } }

        public bool HaveTarget
        {
            get { return hasTarget; }
            set { hasTarget = value; }
        }

        public Troop CurrentTarget
        {
            get { return target; }
            set { target = value; }
        }

        public void Find_Target(List<Troop> enemyTroops)
        {
            if (enemyTroops.Count > 0)
            {
                target = enemyTroops[0];
                hasTarget = true;
                float smalest_distance = (float)Math.Sqrt(Math.Pow(x - enemyTroops[0].X, 2) + Math.Pow(y - enemyTroops[0].Y, 2));

                foreach (Troop i in enemyTroops.Skip(1))
                {
                    if (smalest_distance > Math.Sqrt(Math.Pow(x - i.X, 2) + Math.Pow(y - i.Y, 2))) 
                    {
                        smalest_distance = (float)Math.Sqrt(Math.Pow(x - i.X, 2) + Math.Pow(y - i.Y, 2));
                        target = i;
                    }
                }
            }
        }

        public void Attack()
        {
            if (hasTarget)
            {
                if(attackRange > (float)Math.Sqrt(Math.Pow(x - target.X, 2) + Math.Pow(y - target.Y, 2)))
                {
                    target.Take_Damage(dmg);
                }
            }
        }

        public void Push()
        {

        }

        public void Move(List<Troop> p1, List<Troop> p2)
        {

        }

        public void Take_Damage(int damage)
        { hp = hp - damage; }
    }
}
