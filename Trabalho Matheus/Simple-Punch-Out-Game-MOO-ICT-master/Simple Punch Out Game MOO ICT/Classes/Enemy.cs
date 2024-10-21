using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Punch_Out_Game_MOO_ICT.Classes
{
    internal class Enemy
    {
        private static int HpDefault = 100;
        private static bool playerBlock = false;
        private static int playerHealth = 100;
        private static int enemySpeed = HpDefault;

        public static int PlayerHealth { get => playerHealth; set => playerHealth = value; }
        public static bool PlayerBlock { get => playerBlock; set => playerBlock = value; }
        public static int EnemySpeed { get => enemySpeed; set => enemySpeed = value; }
        public static int HpDefault1 { get => HpDefault; set => HpDefault = value; }
    }
}
