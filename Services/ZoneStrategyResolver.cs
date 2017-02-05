using System;

public class ZoneStrategyResolver{
    public IZoneStrategy Resolve(){
        switch(SimConfiguration.ZoneStrategy){
            case ZoneStrategy.Area:
                return new AreaZoneStrategy();
            case ZoneStrategy.Random:
                return new RandomZoneStrategy();
            case ZoneStrategy.Aisle:
                return new AisleZoneStragegy();
            case ZoneStrategy.Hybrid:
                return new HybridZoneStrategy();
            default:
                throw new Exception("Unknown zone strategy");
        }
    }
}