# Toy Robot Exercise
Toy Robot Code Challenge by iress

Developer: Christian Gajo
Framework: .NET Core 6.0

# Features
Table - table instance where we place the report
Robot - robot instance where you can place, move or rotate

# Commands
Place - Place the robot in the table
  - Place {X Position}, {Y Poistion}, { Direction: North,East,South,West }
  - Place 0,0,North
Move - Robot will move 1 step facing the direction specified.
Right - Robot will rotate right
Left - Robot will rotate left
Report - It will display the robot current position and direction

# Constraints
The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot. Any
move that would cause the robot to fall must be ignored.
