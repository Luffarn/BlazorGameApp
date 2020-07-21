namespace PlayBlazem.BreakoutGame.Base
{
    using PlayBlazem.BreakoutGame.Common;

    public abstract class MovableGameObject : GameObject
    {
        public abstract void Update(GameState gameState);
        protected Speed Speed { get; set; } = new Speed(0, 0);
    }
}
