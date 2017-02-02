using System;

public class SimRunner {
    private SimConfiguration configuration;
    private int simNumber;

    public SimRunner(SimConfiguration configuration){
        this.configuration = configuration;
    }

    public void Run(){
        while(simNumber < configuration.Runs){
            RunNewSim();
        }
    }

    private void RunNewSim(){
        var state = new SimInitializer(configuration).Initialize();
        Console.WriteLine($"Running sim #{simNumber}...");

        do{
            state.Step();
        }
        while(state.Status == SimStatus.InProgress);

        Console.WriteLine($"Sim #{simNumber} completed in{state.CurrentStep} steps");
        simNumber++;
    }
}