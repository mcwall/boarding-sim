namespace ConsoleApplication
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            new ArgResolver().Resolve(args);
            try{
                new SimRunner().Run();
            }
            catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
