using System;
using System.Threading;

public class SimRunner
{
    // TODO: Extract to SimResult class

    private bool paused;

    public void Run()
    {
        paused = false;
        var totalSteps = 0L;
        var nRuns = SimConfiguration.Runs;
        for (var simNumber = 0; simNumber < nRuns; simNumber++)
        {
            totalSteps += RunNewSim();
        }

        Console.WriteLine($"Completed {nRuns} sims with in average of {totalSteps / nRuns} steps.");
    }

    private int RunNewSim()
    {
        var state = new SimInitializer().Initialize();

        while (!state.Step())
        {
            // TODO: This should be the concern of the Program, not SimRunner
            if (SimConfiguration.Print)
            {
                Console.Clear();
                Console.WriteLine(state);
                CheckForPause();
            }
        }

        return state.CurrentStep;
    }

    private void CheckForPause()
    {
        do
        {
            // TODO: This actually allows the P to print, try to fix that
            Thread.Sleep(SimConfiguration.StepThrottle);
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.P)
            {
                paused = !paused;
            }
        } while (paused);
    }
}