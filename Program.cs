namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new SimConfiguration{
                Runs = 1,
                Rows = 30,
                SeatsPerRow = 6,
                Zones = 3,
                ProbabilityHasBag = 1.0
            };

            new SimRunner(config).Run();
        }
    }
}
