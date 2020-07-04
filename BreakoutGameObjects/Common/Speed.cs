namespace BreakOutGame.BreakoutGameObjects.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Speed
    {
        public int XSpeed { get; }
        public int YSpeed { get; }
        public Speed(int xSpeed, int ySpeed)
        {
            XSpeed = xSpeed;
            YSpeed = ySpeed;
        }
    }
}
