namespace PlayBlazem.BreakoutGame.Common
{
    public interface IRectangularCollidableObject
    {
        int Height { get; }
        int Width { get; }
        Position Position { get; set; }
    }
}
