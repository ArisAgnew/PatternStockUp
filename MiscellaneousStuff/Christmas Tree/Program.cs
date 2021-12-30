global using static System.Console;

const int branches = 20;

for (int i = 0; i < branches; ++i)
{
    for (int j = 0; j < branches - i; ++j)
    {
        Write(" ");
    }

    for (int k = 0; k < (2 * i + 1); ++k)
    {
        int p = new Random().Next(1, 100);

        if (p < 80)
        {
            ForegroundColor = ConsoleColor.Green;
            Write("\u2660");
        }
        else
        {
            ForegroundColor = ConsoleColor.Red;
            Write("@");
        }
    }

    WriteLine();
}
