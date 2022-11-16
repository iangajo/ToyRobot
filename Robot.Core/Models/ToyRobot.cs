using Robot.Core.Enums;
using Robot.Core.Interfaces;

namespace Robot.Core.Models
{
    public class ToyRobot : IRobot
    {
        private Position? _position;
        private readonly List<string> _errors = new();

        public TableTop? Table { get; set; }

        /// <summary>
        /// Robot will face left
        /// </summary>
        /// <returns></returns>
        public Result Left()
        {
            if (!Validations()) return Result.BadRequest(_errors);

            _position!.Direction--;
            if ((int)_position.Direction < 0) _position.Direction = Direction.West;

            return Result.Success("Robot faced Left");

        }

        /// <summary>
        /// Robot will move 1 step
        /// </summary>
        /// <returns></returns>
        public Result Move()
        {
            if (!Validations()) return Result.BadRequest(_errors);
            if (!FallValidation(_position!.Direction)) return Result.RobotWillFall(_errors);

            switch (_position!.Direction)
            {
                case Direction.North:
                    _position.Y++;
                    break;
                case Direction.East:
                    _position.X++;
                    break;
                case Direction.South:
                    _position.Y--;
                    break;
                case Direction.West:
                    _position.X--;
                    break;
                default:
                    break;
            }

            return Result.Success("Robot Moved.");
        }

        /// <summary>
        /// set the robot position in the table
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Result Place(Position position)
        {
            _position = position;

            if (!Validations()) return Result.BadRequest(_errors);

            return Result.Success("Robot Placed.");
        }

        /// <summary>
        /// Display current position of the robot
        /// </summary>
        /// <returns></returns>
        public Result Report()
        {
            if (!Validations()) return Result.BadRequest(_errors);

            return Result.Success($"{_position!.X},{_position!.Y},{_position!.Direction}");
        }

        /// <summary>
        /// robot will face right
        /// </summary>
        /// <returns></returns>
        public Result Right()
        {
            if (!Validations()) return Result.BadRequest(_errors);

            _position!.Direction++;
            if ((int)_position!.Direction > 3) _position!.Direction = Direction.North;

            return Result.Success("Robot faced Right");
        }

        /// <summary>
        /// Validate the table and robot position
        /// </summary>
        /// <returns></returns>
        private bool Validations()
        {
            _errors.Clear();

            if (Table == null) _errors.Add("No Table detected.");

            if (_position == null) _errors.Add("Robot should be PLACE in the table first.");

            if (_position?.X > Table?.Length || _position?.Y > Table?.Width) _errors.Add("Robot placement is unacceptable.");



            return !_errors.Any();
        }

        /// <summary>
        /// Fall validation
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool FallValidation(Direction direction)
        {
            var currentX = _position?.X;
            var currentY = _position?.Y;

            switch (direction)
            {
                case Direction.North:
                    currentY++;
                    if (currentY > Table?.Width) _errors.Add("Robot will fall to the table.");
                    break;
                case Direction.South:
                    currentY--;
                    if (currentY < 0) _errors.Add("Robot will fall to the table.");
                    break;
                case Direction.East:
                    currentX++;
                    if (currentX > Table?.Length) _errors.Add("Robot will fall to the table.");
                    break;
                case Direction.West:
                    currentX--;
                    if (currentX < 0) _errors.Add("Robot will fall to the table.");
                    break;

            }

            return !_errors.Any();
        }
    }
}
