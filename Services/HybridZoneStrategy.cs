using System;

public class HybridZoneStrategy : IZoneStrategy{
    public int AssignZone(Position position){
        return Math.Min(new AisleZoneStragegy().AssignZone(position), new AreaZoneStrategy().AssignZone(position));
    }
}