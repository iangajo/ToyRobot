// See https://aka.ms/new-console-template for more information
using Robot.Core.Enums;
using Robot.Core.Interfaces;
using Robot.Core.Models;


Console.WriteLine("Commands: PLACE, MOVE, RIGHT, LEFT and REPORT");
Console.WriteLine(">examples:");
Console.WriteLine(">PLACE 0,0, NORTH");
Console.WriteLine(">MOVE");
Console.WriteLine(">RIGHT");
Console.WriteLine(">LEFT");
Console.WriteLine(">REPORT");
Console.WriteLine(">Print EXIT to close the application.");

Console.WriteLine(Environment.NewLine);

IRobot robot = new ToyRobot();
ITable table = new Table();

var tableTop = table.Set(5, 5);
robot.Table = tableTop;

var isRunning = true;

while (isRunning)
{
    Console.WriteLine("Waiting for command.");
    var command = Console.ReadLine();

    try
    {
        switch (command?.ToLower())
        {
            case "move":
                robot.Move();
                break;
            case "left":
                robot.Left();
                break;
            case "right":
                robot.Right();
                break;
            case "report":
                robot.Report();
                break;
            case var cmd when command!.Contains("place"):
                var placeCommands = cmd!.Replace("place", string.Empty).Split(',');

                var x = Convert.ToInt32(placeCommands[0]);
                var y = Convert.ToInt32(placeCommands[1]);
                var direction = (Direction)Enum.Parse(typeof(Direction), placeCommands[2], true);

                robot.Place(new Position(x, y, direction));
                break;
            case "exit":
                isRunning = false; break;
            default:
                Console.WriteLine("Invalid Command.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}