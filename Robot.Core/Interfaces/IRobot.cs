using Robot.Core.Models;

namespace Robot.Core.Interfaces
{
    public interface IRobot
    {
        Result Place(Position position);
        Result Move();
        Result Left();
        Result Right();
        Result Report();
        public TableTop? Table { get; set; }
    }
}
