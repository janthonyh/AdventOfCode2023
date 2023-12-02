using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Line Processor to process a given line and return the calibration value (two-digit number)
 */
namespace Day_1
{
    public class LineProcessor
    {

        Dictionary<string, char> wordNumberPairs = new Dictionary<string, char>()
        {
            { "one", '1' },
            { "two", '2' },
            { "three", '3' },
            { "four", '4' },
            { "five", '5' },
            { "six", '6' },
            { "seven", '7' },
            { "eight", '8' },
            { "nine", '9' },
        };

        public LineProcessor() { }

        public int CalibrateValue(string line)
        {
            char? firstDigit = CalibrateFirstDigit(line);
            char? lastDigit = CalibrateLastDigit(line);

            char? firstDigitWord = firstDigit.HasValue ? CalibrateFirstDigitWord(line.Substring(0, line.IndexOf(firstDigit.Value))) : CalibrateFirstDigitWord(line);
            char? lastDigitWord = lastDigit.HasValue ? CalibrateLastDigitWord(line.Substring(line.LastIndexOf(lastDigit.Value))) : CalibrateLastDigitWord(line);

            var firstCalibratedValue = firstDigitWord != null ? firstDigitWord : firstDigit;
            var lastCalibratedValue = lastDigitWord != null ? lastDigitWord : lastDigit;

            string calibratedValue = firstCalibratedValue + "" + lastCalibratedValue;

            return int.Parse(calibratedValue);
        }

        private char? CalibrateFirstDigit(string line)
        {
            // Start at beginning of line
            foreach (var c in line)
            {
                if (Char.IsDigit(c))
                    return c;
            }

            // return last char to be used in substring
            return null;
        }


        private char? CalibrateFirstDigitWord(string line)
        {
            int index = line.Length;
            char? num = null;

            foreach(var key in wordNumberPairs.Keys)
            {
                var tempIndex = line.IndexOf(key);
                if (tempIndex != -1 && tempIndex < index)
                {
                    num = wordNumberPairs[key];
                    index = tempIndex;
                }
            }

            return num;
        }


        private char? CalibrateLastDigitWord(string line)
        {
            int index = -1;
            char? num = null;

            foreach (var key in wordNumberPairs.Keys)
            {
                var tempIndex = line.LastIndexOf(key);
                if (tempIndex != -1 && tempIndex > index)
                {
                    num = wordNumberPairs[key];
                    index = tempIndex;
                }
            }

            return num;
        }

        private char? CalibrateLastDigit(string line)
        {
            
            for (int i = line.Length - 1; i >= 0; i-- )
            {
                char c = line[i];
                if (Char.IsDigit(c))
                    return c;
            }
            return null;
        }
    }
}
