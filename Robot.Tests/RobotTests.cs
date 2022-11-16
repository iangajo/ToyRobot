using Robot.Core.Enums;
using Robot.Core.Interfaces;
using Robot.Core.Models;

namespace Robot.Tests
{
    public class RobotTests
    {
        private readonly ITable _table;
        public RobotTests()
        {
            _table = new Table();
        }

        [Fact]
        public void TestCase1()
        {

            var table = _table.Set(5, 5);

            var robot = new ToyRobot
            {
                Table = table
            };

            Assert.NotNull(robot);

            Result response;
            response = robot.Place(new Position(0, 0, Direction.North));
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Move();
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Report();
            Assert.Equal(ResponseCode.Ok, response.Code);
            Assert.Equal("0,1,North", response.Message);
        }

        [Fact]
        public void TestCase2()
        {

            var table = _table.Set(5, 5);

            var robot = new ToyRobot
            {
                Table = table
            };

            Assert.NotNull(robot);

            Result response;
            response = robot.Place(new Position(0, 0, Direction.North));
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Left();
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Report();
            Assert.Equal(ResponseCode.Ok, response.Code);
            Assert.Equal("0,0,West", response.Message);
        }

        [Fact]
        public void TestCase3()
        {

            var table = _table.Set(5, 5);

            var robot = new ToyRobot
            {
                Table = table
            };

            Assert.NotNull(robot);

            Result response;
            response = robot.Place(new Position(1, 2, Direction.East));
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Move();
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Move();
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Left();
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Move();
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Report();
            Assert.Equal(ResponseCode.Ok, response.Code);
            Assert.Equal("3,3,North", response.Message);
        }

        [Theory]
        [InlineData(ResponseCode.RobotWillFall, 0, 5, Direction.North)]
        [InlineData(ResponseCode.RobotWillFall, 5, 0, Direction.East)]
        [InlineData(ResponseCode.RobotWillFall, 0, 0, Direction.West)]
        [InlineData(ResponseCode.RobotWillFall, 0, 0, Direction.South)]
        public void RobotWillFallTest(ResponseCode expected, int x, int y, Direction direction)
        {

            var table = _table.Set(5, 5);

            var robot = new ToyRobot
            {
                Table = table
            };

            Assert.NotNull(robot);

            Result response;
            response = robot.Place(new Position(x, y, direction));
            Assert.Equal(ResponseCode.Ok, response.Code);

            response = robot.Move();
            Assert.Equal(expected, response.Code);

        }
    }
}