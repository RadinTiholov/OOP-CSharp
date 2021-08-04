namespace SimpleSnake.GameObjects
{
    public class Wall:Point
    {
        public Wall(int leftX, int topY):base(leftX, topY)
        {
            InitializeWallBorders();
        }

        private const char WALL_SYMBOl = '\u25A0';
        private void SetHorizontalLine(int topY) 
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(WALL_SYMBOl, leftX, topY);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(WALL_SYMBOl, leftX, topY);
            }
        }
        private void InitializeWallBorders() 
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY);

            SetVerticalLine(0);
            SetVerticalLine(LeftX-1);
        }
        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 || snake.LeftX == this.LeftX || snake.TopY == this.TopY - 1;
        }
    }
}
