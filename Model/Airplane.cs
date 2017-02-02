using System;

public class Airplane{
    public const int PenaltyObstruction = 15;

    private int numRows;
    private int numSeatsPerRow;
    private bool[,] seats;
    private bool[] aisle;

    public Airplane(int numRows, int numSeatsPerRow){
        this.numRows = numRows;
        this.numSeatsPerRow = numSeatsPerRow;
        this.seats = new bool[numRows, numSeatsPerRow*2];
        this.aisle = new bool[numRows];
        this.numRows = numRows;
    }

    public bool Move(Person person, Position position, out int penalty){
        penalty = 0;
        if (position.Seat == -1){
            // move in aisle
            if (aisle[position.Row]){
                return false;
            }

            aisle[position.Row] = true;
            return true;
        }
        else{
            // move in Seat
            var obstructions = GetObstructionsForSeat(position);
            if (obstructions == 0){
                seats[position.Row, position.Seat] = true;
                return true;
            }

            penalty = PenaltyObstruction * obstructions;
            return false;
        }
    }

    private int GetObstructionsForSeat(Position position){
        var obstructionCount = 0;
        if (position.Seat < numSeatsPerRow){
            for(var i = position.Seat + 1; i < numSeatsPerRow; i++){
                obstructionCount += seats[position.Row,i] ? 1 : 0;
            }
        }
        else{
            for(var i = numSeatsPerRow; i < position.Seat; i++){
                obstructionCount += seats[position.Row, i] ? 1 : 0;
            }
        }

        return obstructionCount;
    }
}