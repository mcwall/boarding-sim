using System;

public class Seat{
    private Person person;
    private SeatStatus status;
    private int transitionTime;

    public Seat(){
        status = SeatStatus.Empty;
    }

    public void Step(){
        if (person == null){
            transitionTime = 0;
            status = SeatStatus.Empty;
        }

        if (status == SeatStatus.PrepareToStand){
            if (transitionTime == 0){
                status = SeatStatus.Standing;
                transitionTime = SimConfiguration.DefaultTimeToSit;
            }
            else{
                transitionTime--;
            }
        }
        else if(status == SeatStatus.Standing){
            if (transitionTime == 0){
                status = SeatStatus.Sitting;
                transitionTime = 0;
            }
            else{
                transitionTime--;
            }
        }
    }

    public void Sit(Person person){
        if (this.person != null){
            throw new Exception("Seat conflict");
        }

        this.person = person;
        status = SeatStatus.Sitting;
        transitionTime = 0;
    }

    public bool ResolveObstruction(){
        if (person == null || status == SeatStatus.Standing){
            return false;
        }

        if (status == SeatStatus.Sitting){
            status = SeatStatus.PrepareToStand;
            transitionTime = SimConfiguration.DefaultTimeToStand;
        }

        return true;
    }

    public override string ToString(){
        string statusString;
        switch(status){
            case SeatStatus.Sitting:
                statusString = "SIT";
                break;
            case SeatStatus.PrepareToStand:
                statusString = "PTS";
                break;
            case SeatStatus.Standing:
                statusString = "STA";
                break;
            default:
                statusString = "---";
                break;
        }
        return $"{person?.ToString() ?? "-----"}({statusString})";
    }


}

public enum SeatStatus{
    Empty,
    Sitting,
    PrepareToStand,
    Standing
}