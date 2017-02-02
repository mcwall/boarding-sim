using System.Collections.Generic;

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

    public void Step(){
        Status = SimStatus.InProgress;
        if (personQueue.Count == 0){
            Status = SimStatus.Done;
            return;
        }

        var newQueue = new Queue<Person>();
        while (personQueue.Count > 0){
            var person = personQueue.Dequeue();
            if (person.Seated){
                continue;
            }

            person.Move(airplane);
            newQueue.Enqueue(person);
        }

        personQueue = newQueue;
    }
}

public enum SimStatus{
    Ready,
    InProgress,
    Done
}