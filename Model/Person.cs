using System;

public class Person{
    public int Id { get; }
    public bool HasBag { get; private set;}
    public int Zone {get;}
    public Position CurrentPosition { get; private set; }
    public Position TargetPosition { get; }
    public bool Seated { get{
        return CurrentPosition.Seat >= 0;
    }}
    private int penalty;

    public Person(int id, Position targetPosition, bool hasBag, int zone){
        CurrentPosition = new Position{
            Row = -1,
            Seat = -1
        };

        Id = id;
        TargetPosition = targetPosition;
        HasBag = hasBag;
        Zone = zone;
        penalty = 0;
    }

    public bool Step(Airplane airplane){
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
                penalty = SimConfiguration.PenaltyBag;
                return false;
            }

            // Move to seat
            newPosition.Seat = TargetPosition.Seat;
        }
        else{
            newPosition.Row++;
        }

        if (!airplane.Move(this, newPosition)){
            return false;
        }

        CurrentPosition = newPosition;
        return true;
    }

    public override string ToString(){
        return $"{Id.ToString("D3")}-{Zone}";
    }
}