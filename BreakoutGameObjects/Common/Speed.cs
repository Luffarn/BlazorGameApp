namespace BreakOutGame.BreakoutGameObjects.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Speed
    {
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }
        public Speed(int xSpeed, int ySpeed)
        {
            XSpeed = xSpeed;
            YSpeed = ySpeed;
        }
    }
}
