using BreakOutGame.BreakoutGame.Common;

namespace BreakOutGame.BreakoutGame.Base
{
    public abstract class MovableGameObject : GameObject
    {
        public abstract void Update();
        protected Speed Speed { get; set; } = new Speed(0, 0);
    }
}
