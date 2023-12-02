using Day_1;

public class Program
{
    public static void Main()
    {
        //Read file
        try
        {
            StreamReader streamReader = new StreamReader("input.txt");
            //StreamReader streamReader = new StreamReader("sampleInput.txt"); // Should return 142
            LineProcessor processor = new LineProcessor();
            var totalCaculatedValue = 0;

            var line = streamReader.ReadLine();

            while (line != null)
            {
                totalCaculatedValue += processor.CalibrateValue(line);
                line = streamReader.ReadLine();
            }

            Console.WriteLine(totalCaculatedValue);

            streamReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
