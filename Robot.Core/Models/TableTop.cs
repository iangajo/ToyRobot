namespace Robot.Core.Models
{
    public class TableTop
    {
        public int Length { get; init; }
        public int Width { get; init; }

        public TableTop(int length, int width)
        {
            Length = length;
            Width = width;
        }

    }
}
