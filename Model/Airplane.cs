using System;

public class Airplane{
    private int numRows;
    private int numSeatsPerRow;
    private Seat[,] seats;
    private Person[] aisle;

    public Airplane(int numRows, int numSeatsPerRow){
        this.numRows = numRows;
        this.numSeatsPerRow = numSeatsPerRow;
        this.aisle = new Person[numRows];
        this.numRows = numRows;

        this.seats = new Seat[numRows, numSeatsPerRow];
        for (var iRow = 0; iRow < numRows; iRow++){
            for (var iSeat = 0; iSeat < numSeatsPerRow; iSeat++){
                seats[iRow,iSeat] = new Seat();
            }
        }        
    }

    public void Step(){
        foreach (var seat in seats){
            seat.Step();
        }
    }

    public bool Move(Person person, Position position){
        if (position.Row < 0){
            throw new Exception("Invalid move with negative row");
        }
        
        if (position.Seat == -1){
            // move in aisle
            if (aisle[position.Row] != null){
                return false;
            }

            aisle[position.Row] = person;
            if (person.CurrentPosition.Row >= 0)
                aisle[person.CurrentPosition.Row] = null;
            return true;
        }
        else{
            // move in Seat
            if (!ResolveObstructionsForSeat(position)){
                seats[position.Row, position.Seat].Sit(person);
                aisle[position.Row] = null;
                return true;
            }

            return false;
        }
    }

    private bool ResolveObstructionsForSeat(Position position){
        var hasObstruction = false;
        var divider = numSeatsPerRow / 2;
        if (position.Seat < divider){
            for(var i = position.Seat + 1; i < divider; i++){
                hasObstruction |= seats[position.Row,i].ResolveObstruction();
            }
        }
        else{
            for(var i = divider; i < position.Seat; i++){
                hasObstruction |= seats[position.Row,i].ResolveObstruction();
            }
        }

        return hasObstruction;
    }

    public override string ToString(){
        var termLine = new string('=', 12 * numSeatsPerRow + 9) + Environment.NewLine;
        var output = termLine;
        for(var iRow = numRows-1; iRow >= 0; iRow--){
            for(var iSeat = 0; iSeat < numSeatsPerRow/2; iSeat++){
                output += $"|{seats[iRow,iSeat]}|";
            }
            
            output += $"| {aisle[iRow]?.ToString() ?? "-----"} |";

            for(var iSeat = numSeatsPerRow/2; iSeat < numSeatsPerRow; iSeat++){
                output += $"|{seats[iRow,iSeat]}|";
            }

            output += Environment.NewLine;
        }

        return output + termLine;
    }
}