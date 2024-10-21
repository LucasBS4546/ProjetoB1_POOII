using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Punch_Out_Game_MOO_ICT.Classes
{
    internal class Player
    {
        private static int defaultHP = 100;
        private static bool playerBlock = false;
        private static int playerHealth = defaultHP;
        private static int coins = 0;
        private static int vidas = 1;
        private static int victory = 0;
        private static int danoExtra = 0;

        public static int PlayerHealth { get => playerHealth; set => playerHealth = value; }
        public static bool PlayerBlock { get => playerBlock; set => playerBlock = value; }
        public static int Coins { get => coins; set => coins = value; }
        public static int Vidas { get => vidas; set => vidas = value; }
        public static int DefaultHP { get => defaultHP; set => defaultHP = value; }
        public static int DanoExtra { get => danoExtra; set => danoExtra = value; }
        public static int Victory { get => victory; set => victory = value; }
    }
}
