using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Project
{
    public enum alienState { Normal,Weakened}
    class Aliens
    {

        public int lives { get; set; }
       
        public alienState state {get;set;}
        public List<boosters> powerUps { get; set; } // keeps track of how many boosters are active

        public Aliens()
        {
            lives = 2;
            
            state = alienState.Normal;
            powerUps = new List<boosters>();

        }

        

    }
}
