
using Day_2;
public class Program
{
    public static void Main()
    {
        //Read file
        try
        {
            StreamReader streamReader = new StreamReader("input.txt");
            //StreamReader streamReader = new StreamReader("sampleInput.txt"); // Should return 8; Min Cubes Required should return 2286

            var sumOfPossibleGames = 0;
            var sumOfPowerSets = 0;
            CubeGame cubeGame = new CubeGame(12, 13, 14); // Part 1 static values


            var line = streamReader.ReadLine();

            while (line != null)
            {
                // Part one
                // Returns - 1 if not possible, otherwise game number
                int gamePossible = cubeGame.GamePossible(line);
                if (gamePossible != -1)
                    sumOfPossibleGames += gamePossible;


                // Part two
                sumOfPowerSets += CubeGame.findMinAmountOfCubesRequired(line);

                line = streamReader.ReadLine();
            }

            Console.WriteLine("Day Two Part 1 - Sum of possible games: " +  sumOfPossibleGames);
            Console.WriteLine("Day Two Part 2 - Sum of power sets: " + sumOfPowerSets);

            streamReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
