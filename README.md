# Rectangles.API

Rectangles
Practicalities
Your take-home coding exercise is designed to take about two to three hours to complete.
You are under no obligation to take any specific amount of time to complete the task.
The rules
The code you write should be your own and should be written without direct assistance.
However, feel free to use as many reference resources (Stack Overflow, MSDN, Google,
textbooks) as you like. The task should be completed in C# or F#, and include unit tests to
demonstrate the requirements have been met.
Please submit your solution as a link to GitHub / BitBucket project. Ideally, it will contain
project definitions, e.g. if using Visual Studio, provide a project that can easily be loaded and
run. If any specific instructions are required, please include a readme.
The task
The task is to implement a system to track the position of a collection of rectangles on
a grid that must support the following actions:
● Create a grid
● Place rectangles on the grid
● Find a rectangle based on a given position
● Remove a rectangle from the grid by specifying any point within the rectangle
● [Optional] Display the grid and rectangles as ASCII art - this might help you with
testing!
Constraints
● A grid must have a width and height of no less than 5 and no greater than 25
● Positions on the grid are non-negative integer coordinates starting at 0
● Rectangles must not extend beyond the edge of the grid
● Rectangles must not overlap

Examples
Valid: 3 valid rectangles on a grid

Invalid: Overlapping rectangles

Invalid: Rectangle extending beyond grid
