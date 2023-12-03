using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_2
{
    public class CubeGame
    {

        private readonly int numOfRedCubes;
        private readonly int numOfGreenCubes;
        private readonly int numOfBlueCubes;

        public CubeGame(int numOfRedCubes, int numOfGreenCubes, int numOfBlueCubes)
        {
            this.numOfRedCubes = numOfRedCubes;
            this.numOfGreenCubes = numOfGreenCubes;
            this.numOfBlueCubes = numOfBlueCubes;
        }


        /**
         * With the given set of colors
         * Returns negative 1 if game is not possible
         * Returns game number if possible
         */
        public int GamePossible(string line)
        {
            //Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            string gameNumberString = line.Substring(0, line.IndexOf(':'));
            int gameNumber = int.Parse(Regex.Match(gameNumberString, @"\d+").Value);

            // Delete first part of string (game number:) 
            line = line.Substring(line.IndexOf(':'));
            //  3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green

            string[] gameSets = line.Split(';');
            //3 blue, 4 red;
            //1 red, 2 green, 6 blue;
            //2 green

            foreach (string gameSet in gameSets)
            {
                string[] cubeColors = gameSet.Split(',');
                // 3 blue
                // 4 red

                int numOfRed = 0;
                int numOfGreen = 0;
                int numOfBlue = 0;

                foreach (string cubeColor in cubeColors)
                {
                    string cube = cubeColor;
                    if (cube.Contains("red"))
                    {
                        numOfRed = int.Parse(Regex.Match(cube, @"\d+").Value);
                    }

                    if (cube.Contains("green"))
                    {
                        numOfGreen = int.Parse(Regex.Match(cube, @"\d+").Value);
                    }

                    if (cube.Contains("blue"))
                    {
                        numOfBlue = int.Parse(Regex.Match(cube, @"\d+").Value);
                    }
                }

                if (!IsGameSetPossible(numOfRed, numOfGreen, numOfBlue))
                    return -1;
            }

            return gameNumber;
        }

        /**
         * Returns the power of a set of cubes equal to red, green, and blue
         * i.e 4 red, 2 green, 6 blue = 4 * 2 * 6 = 48
         */
        public static int findMinAmountOfCubesRequired(string line)
        {
            // Track the max number of color cubes needed
            int maxRedCubes = 0;
            int maxGreenCubes = 0;
            int maxBlueCubes = 0;


            // Delete first part of string (game number:) 
            line = line.Substring(line.IndexOf(':'));

            string[] gameSets = line.Split(';');

            foreach (string gameSet in gameSets)
            {
                string[] cubeColors = gameSet.Split(',');

                int numOfRed = 0;
                int numOfGreen = 0;
                int numOfBlue = 0;

                foreach (string cubeColor in cubeColors)
                {
                    string cube = cubeColor;
                    if (cube.Contains("red"))
                    {
                        numOfRed = int.Parse(Regex.Match(cube, @"\d+").Value);

                        if (numOfRed > maxRedCubes) maxRedCubes = numOfRed;
                    }

                    if (cube.Contains("green"))
                    {
                        numOfGreen = int.Parse(Regex.Match(cube, @"\d+").Value);

                        if (numOfGreen > maxGreenCubes) maxGreenCubes = numOfGreen;
                    }

                    if (cube.Contains("blue"))
                    {
                        numOfBlue = int.Parse(Regex.Match(cube, @"\d+").Value);

                        if (numOfBlue > maxBlueCubes) maxBlueCubes = numOfBlue;
                    }
                }
            }

            return maxRedCubes * maxGreenCubes * maxBlueCubes;
        } 

        // Process a singluar set
        private bool IsGameSetPossible(int numOfRedCubes, int numOfGreenCubes, int numOfBlueCubes)
        {
            if (numOfRedCubes > this.numOfRedCubes ||
                numOfGreenCubes > this.numOfGreenCubes ||
                numOfBlueCubes > this.numOfBlueCubes)
            {
                return false;
            }
            return true;
        }
    }
}
