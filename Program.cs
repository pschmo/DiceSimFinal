// Perry Schmoekel

using System;

class DiceSimulator
{
    static void Main()
    {
        Console.WriteLine("This is the dice throwing simulator!");

        // Get the user's input for the number of dice rolls
        Console.Write("How many dice rolls would you like to put in play? ");
        int numRolls = int.Parse(Console.ReadLine());

        // Create an instance of DiceRoller
        DiceRoller diceRoller = new DiceRoller();

        // Simulate dice rolls and get the results
        int[] results = diceRoller.SimulateRolls(numRolls);

        // Display the results as a histogram
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {numRolls}.\n");

        // Display histogram
        for (int i = 2; i <= 12; i++)
        {
            // Calculate the percentage and create a string of '*' based on it
            int percentage = results[i] * 100 / numRolls;
            string asterisks = new string('*', percentage);

            // Display the histogram line
            Console.WriteLine($"{i}: {asterisks}");
        }

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}

class DiceRoller
{
    private Random random;

    // Constructor
    public DiceRoller()
    {
        random = new Random();
    }

    // Simulate dice rolls and return the results
    public int[] SimulateRolls(int numRolls)
    {
        int[] results = new int[13]; // Index 0 is not used, index 2 to 12 represent dice combinations

        // Simulate dice rolls
        for (int i = 0; i < numRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);

            int sum = dice1 + dice2;
            results[sum]++;
        }

        return results;
    }
}
