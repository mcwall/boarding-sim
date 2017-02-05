using System;

// TODO: Refactor this garbage
public class ArgResolver{
    public void Resolve(string[] args){
        for(var i = 0; i < args.Length; i++){
            var arg = args[i];
            var arg2 = i < args.Length - 1 ? args[i+1] : null;
            switch(arg){
                case "--print":
                    ResolvePrint();
                    break;
                case "--runs":
                    ResolveRuns(arg2);
                    break;
                case "--rows":
                    ResolveRows(arg2);
                    break;
                case "--seats":
                    ResolveSeats(arg2);
                    break;
                case "--bags":
                    ResolveBags(arg2);
                    break;
                case "--strategy":
                    ResolveStrategy(arg2);
                    break;
            }
        }
    }

    private void ResolvePrint(){
        SimConfiguration.Print = true;
    }

    private void ResolveRuns(string runs){
        try{
            SimConfiguration.Runs = int.Parse(runs);
        }
        catch{
            Console.WriteLine($"Invalid value for param --runs. Using default value {SimConfiguration.Runs}");
        }
    }

    private void ResolveRows(string rows){
        try{
            SimConfiguration.Rows = int.Parse(rows);
        }
        catch{
            Console.WriteLine($"Invalid value for param --rows. Using default value {SimConfiguration.Rows}");
        }
    }

    private void ResolveSeats(string seats){
        try{
            SimConfiguration.SeatsPerRow = int.Parse(seats);
        }
        catch{
            Console.WriteLine($"Invalid value for param --seats. Using default value {SimConfiguration.SeatsPerRow}");
        }
    }

    private void ResolveBags(string bags){
        try{
            SimConfiguration.ProbabilityHasBag = double.Parse(bags);
        }
        catch{
            Console.WriteLine($"Invalid value for param --bags. Using default value {SimConfiguration.ProbabilityHasBag}");
        }
    }

    private void ResolveStrategy(string strategy){
        try{
            SimConfiguration.ZoneStrategy = (ZoneStrategy)Enum.Parse(typeof(ZoneStrategy), strategy, true);
        }
        catch{
            Console.WriteLine($"Invalid value for param --strategy. Using default value {SimConfiguration.ZoneStrategy}");
        }
    }
}