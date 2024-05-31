using System;

namespace TDVF2_29849_22530;

public static class Program
{
    [STAThread]
    private static void Main()
    {
        using var game = new Game1();
        game.Run();
    }
}