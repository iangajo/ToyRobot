using Robot.Core.Enums;

namespace Robot.Core.Models
{
    public class Result
    {
        public ResponseCode Code { get; init; }
        public string[]? Errors { get; init; }
        public string? Message { get; init; }

        internal Result(ResponseCode responseCode, IEnumerable<string> errors)
        {
            Code = responseCode;
            Errors = errors.ToArray();
        }

        internal Result(ResponseCode responseCode, string message)
        {
            Code = responseCode;
            Message = message;
        }

        public static Result Success(string message)
        {
            Console.WriteLine($"{ResponseCode.Ok}: {message}");
            return new Result(ResponseCode.Ok, message);
        }

        public static Result BadRequest(IEnumerable<string> errors)
        {
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    Console.WriteLine($"{ResponseCode.BadRequest}: {error}");
                }
            }

            return new Result(ResponseCode.BadRequest, errors);
        }

        public static Result RobotWillFall(IEnumerable<string> errors)
        {
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    Console.WriteLine($"{ResponseCode.RobotWillFall}: {error}");
                }
            }

            return new Result(ResponseCode.RobotWillFall, errors);
        }
    }
}
