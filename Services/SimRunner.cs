using System;
using System.Threading;

public class SimRunner {
    // TODO: Extract to SimResult class
    public void Run(){
        var totalSteps = 0L;
        var nRuns = SimConfiguration.Runs;
        for (var simNumber = 0; simNumber < nRuns; simNumber++){
            totalSteps += RunNewSim();
        }

        Console.WriteLine($"Completed {nRuns} sims with in average of {totalSteps/nRuns} steps.");
    }

    private int RunNewSim(){
        var state = new SimInitializer().Initialize();
        while(!state.Step()){
            if (SimConfiguration.Print){
                Console.Clear();
                Console.WriteLine(state);
                Thread.Sleep(SimConfiguration.StepThrottle);
            }
        }

        // Console.Clear();
        // Console.WriteLine(state);
        return state.CurrentStep;
        //Console.WriteLine($"Sim #{simNumber} completed in {state.CurrentStep} steps");
    }
}