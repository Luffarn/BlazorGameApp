namespace PlayBlazem.BreakoutGame.Helpers
{
    using PlayBlazem.BreakoutGame.Common;
    using PlayBlazem.BreakoutGame.GameObjects;

    public class CollisionDetector
    {
        public static bool CollideWithGameObject(Ball ball, IRectangularCollidableObject obj)
        {
            var topOfBall = ball.Position.Y - ball.Size;
            var bottomOfBall = ball.Position.Y + ball.Size;
            
            var bottomOfObj = obj.Position.Y + obj.Height;
            var topOfObj = obj.Position.Y;

            if ((topOfBall <= bottomOfObj && bottomOfBall >= topOfObj) && isInsideXBoundery(ball, obj))
            {
                System.Diagnostics.Debug.WriteLine(topOfBall <= bottomOfObj);
                return true;
            }
            return false;
        }

        private static bool isInsideXBoundery(Ball ball, IRectangularCollidableObject obj)
        {
            var rightSideOfBall = ball.Position.X + ball.Size / 2;
            var leftSideOfBall = ball.Position.X - ball.Size / 2;
            var rightSideOfObj = obj.Position.X + obj.Width;
            var leftSideOfObj = obj.Position.X;

            if (leftSideOfBall >= leftSideOfObj &&
                rightSideOfBall <= rightSideOfObj)
            {
                return true;
            }
            return false;
        }
    }
}
