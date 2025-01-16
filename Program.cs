using System;

public class mission2
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.Write("How many dice rolls would you like to simulate? ");

        // Get user input for the number of rolls
        if (int.TryParse(Console.ReadLine(), out int numRolls) && numRolls > 0)
        {
            DiceRollSimulator simulator = new DiceRollSimulator();

            // Simulate the dice rolls
            int[] results = simulator.SimulateRolls(numRolls);

            // Display the results
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numRolls}.\n");

            for (int i = 2; i <= 9; i++)
            {
                int percentage = (int)Math.Round((results[i] / (double)numRolls) * 100);
                Console.WriteLine($" {i} : {new string('*', percentage)}");
            }
            for (int i = 10; i <= 12; i++)
            {
                int percentage = (int)Math.Round((results[i] / (double)numRolls) * 100);
                Console.WriteLine($"{i} : {new string('*', percentage)}");
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }
}

class DiceRollSimulator
{
    private Random random;

    public DiceRollSimulator()
    {
        random = new Random();
    }

    // Method to simulate dice rolls
    public int[] SimulateRolls(int numRolls)
    {
        // Array to store counts of each dice roll sum (2 to 12)
        int[] rollCounts = new int[13];

        for (int i = 0; i < numRolls; i++)
        {
            int die1 = random.Next(1, 7); // Roll first die (1 to 6)
            int die2 = random.Next(1, 7); // Roll second die (1 to 6)

            int sum = die1 + die2;
            rollCounts[sum]++;
        }

        return rollCounts;
    }
}