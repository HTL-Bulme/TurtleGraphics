# Platform Independent Turtle Graphics for .Net 

**TurtleGraphics** is a platform independent library
that provides turtle graphics for the .Net Platform.

## Example

```csharp
Turtle.SetPenWidth(5);
Turtle.SetColor("blue");
for (int i = 0; i < 4; i++)
{
    Turtle.Forward(50);
    Turtle.TurnRight(90);
}
Turtle.ShowTurtle();
```

# ![example](https://raw.githubusercontent.com/HTL-Bulme/TurtleGraphics/master/docs/Screenshot.png)

## All Examples
Comming Soon

## Provided Functionality

### Turtle.Forward
Moves the turtle x steps forward.
### Turtle.Back
Moves the turtle x steps backwards.
### Turtle.TurnRight
Moves the turtle turn right by x degrees.
### Turtle.TurnLeft
Moves the turtle turn left by x degrees.
### Turtle.PenUp 
Lifts the pen.
### Turtle.PenDown 
Puts the pen down again.
### Turtle.Dot 
Paints a dot at the current position with a given diameter.
### Turtle.SetColor 
Sets the current color for fills or lines.
Valid colors are listed here: [All Colors](https://raw.githubusercontent.com/HTL-Bulme/TurtleGraphics/refs/heads/master/docs/DotNetColorTable.svg)
### Turtle.SetPenWidth 
Sets the current line width.
### Turtle.BeginFill 
Call this Function to start filling a polygon.
### Turtle.EndFill 
Call this Function to end to filling.
### Turtle.Print
Prints the given number of text on the console.
### Turtle.InputDouble 
Asks the user to input a double number.
### Turtle.InputFloat
Asks the user to input a float number.
### Turtle.InputInt
Asks the user to input a int number.
### Turtle.InputLong
Asks the user to input a long number.
### Turtle.InputString
Asks the user to input a string value.

## Dependencies
+ .Net Standard 2.0
+ Avalonia
+ Avalonia.Desktop
+ Avalonia.Themes.Fluent
