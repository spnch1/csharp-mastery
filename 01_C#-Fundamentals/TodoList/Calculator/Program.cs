using System.Globalization;

Console.WriteLine("Hello!");
Console.WriteLine("Input the first number:");
var a = int.Parse(Console.ReadLine());
Console.WriteLine("Input the second number:");
var b = int.Parse(Console.ReadLine());

Console.WriteLine("What do you want to do with those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");

string op = Console.ReadLine().ToUpper();

string message = op switch
{
    "A" => $"{a} + {b} = {Add(a, b)}",
    "S" => $"{a} - {b} = {Subtract(a, b)}",
    "M" => $"{a} * {b} = {Multiply(a, b)}",
    _ => "Invalid option"
};
Console.WriteLine(message);

Console.WriteLine("Press any key to close.");
Console.ReadKey(true);

int Add(int a, int b) => a + b;
int Subtract(int a, int b) => a - b;
int Multiply(int a, int b) => a * b;

