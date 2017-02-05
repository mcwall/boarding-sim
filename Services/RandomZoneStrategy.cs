using System;

public class RandomZoneStrategy : IZoneStrategy{
    private static Random rng = new Random();

    public int AssignZone(Position position){
        return rng.Next(SimConfiguration.Zones);
    }
}