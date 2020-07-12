namespace PlayBlazem.BreakoutGame
{
    public class BreakoutLevel
    {
        public int Level { get; private set; }
        public int[][] BrickLayout { get; private set; }


        private BreakoutLevel(int level, int[][] brickLayout)
        {
            Level = level;
            BrickLayout = brickLayout;
        }

        public static BreakoutLevel GetLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return new BreakoutLevel(level, Level1);
                case 2:
                    return new BreakoutLevel(level, Level2);
                default:
                    break;
            }

            return new BreakoutLevel(level, Level1);
        }

        private static int[][] Level1 =>
            new int[][]
            {
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };

        private static int[][] Level2 =>
            new int[][]
            {
                new int[] { 1, 1, 1, 0, 1, 0, 1, 1, 1, 1 },
                new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                new int[] { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
            };
    }
}
