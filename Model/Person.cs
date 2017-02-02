using System;

public class Person{
    public const int PenaltyBag = 10;

    public bool HasBag { get; private set;}
    public int Zone {get;}
    public Position CurrentPosition { get; private set; }
    public Position TargetPosition { get; }
    public bool Seated { get{
        return CurrentPosition.Row == TargetPosition.Row && CurrentPosition.Seat == CurrentPosition.Seat;
    }}
    private int penalty;

    public Person(Position targetPosition, bool hasBag, int zone){
        CurrentPosition = new Position{
            Row = -1,
            Seat = -1
        };

        TargetPosition = targetPosition;
        HasBag = hasBag;
        Zone = zone;
        penalty = 0;
    }

    public bool Move(Airplane airplane){
        if (penalty > 0){
            penalty--;
            return false;
        }

        var newPosition = new Position{
            Row = CurrentPosition.Row,
            Seat = CurrentPosition.Seat
        };

        if (CurrentPosition.Row == TargetPosition.Row){
            if (CurrentPosition.Seat == TargetPosition.Seat){
                throw new Exception("Person already in final seat");
            }

            if (HasBag){
                HasBag = false;
                penalty = PenaltyBag;
                return false;
            }

            // Move to seat
            newPosition.Seat = TargetPosition.Seat;
        }
        else{
            newPosition.Row++;
        }

        int newPenalty;
        if (!airplane.Move(this, newPosition, out newPenalty)){
            penalty = newPenalty;
            return false;
        }

        CurrentPosition = newPosition;
        return true;
    }
}