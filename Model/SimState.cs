using System.Collections.Generic;
using System;

public class SimState{
    public int CurrentStep { get; private set; }
    public SimStatus Status { get; private set; }
    private Queue<Person> personQueue;
    private Airplane airplane;

    public SimState(Airplane airplane, IEnumerable<Person> persons){
        personQueue = new Queue<Person>(persons);
        this.airplane = airplane;

        Status = SimStatus.Ready;
    }

    public bool Step(){
        Status = SimStatus.InProgress;
        if (personQueue.Count == 0){
            Status = SimStatus.Done;
            return true;
        }

        var newQueue = new Queue<Person>();
        while (personQueue.Count > 0){
            var person = personQueue.Dequeue();
            if (person.Seated){
                continue;
            }

            person.Step(airplane);
            newQueue.Enqueue(person);
        }

        airplane.Step();
        personQueue = newQueue;
        CurrentStep++;
        return false;
        // Console.WriteLine($"Count: {personQueue.Count}");
        // Console.WriteLine(airplane);
        // throw new Exception();
    }

    public override string ToString(){
        return airplane.ToString()
                + $"{Environment.NewLine} Step: {CurrentStep}"
                + $"{Environment.NewLine}{GetConfigString()}";
    }

    // TODO: this doesn't belong here
    private string GetConfigString(){
        return $"{Environment.NewLine} Zone Strategy: {SimConfiguration.ZoneStrategy}"
             + $"{Environment.NewLine} Zones: {SimConfiguration.Zones}";
    }
}

public enum SimStatus{
    Ready,
    InProgress,
    Done
}