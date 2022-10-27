// See https://aka.ms/new-console-template for more information
using GameOfLife;

Console.WriteLine("Hello, this is the implementation of....");
Console.WriteLine(GetTitle());
Console.WriteLine("... ta daaaaa!");

Console.WriteLine("This is the starting grid status");
Grid grid = new Grid(5, 5);

Console.WriteLine(grid.ToString());
Console.WriteLine();
Console.WriteLine("Press any key to see the next generation...");

while (true)
{
    Console.ReadLine();
    grid.NextGeneration();
    Console.WriteLine(grid.ToString());
}




static string GetTitle()
                        => @"
                          ____   ____  ___ ___    ___       ___   _____      _      ____  _____  ___ 
                         /    | /    ||   |   |  /  _]     /   \ |     |    | |    |    ||     |/  _]
                        |   __||  o  || _   _ | /  [_     |     ||   __|    | |     |  | |   __/  [_ 
                        |  |  ||     ||  \_/  ||    _]    |  O  ||  |_      | |___  |  | |  |_|    _]
                        |  |_ ||  _  ||   |   ||   [_     |     ||   _]     |     | |  | |   _]   [_ 
                        |     ||  |  ||   |   ||     |    |     ||  |       |     | |  | |  | |     |
                        |___,_||__|__||___|___||_____|     \___/ |__|       |_____||____||__| |_____|";