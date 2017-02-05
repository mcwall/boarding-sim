public class AisleZoneStragegy : IZoneStrategy{
    public int AssignZone(Position position){
        var nZones = SimConfiguration.Zones;
        var nSeatsPerRow = SimConfiguration.SeatsPerRow;
        var divider = nSeatsPerRow / 2;
        var nZonesPerSection = (divider+1) / nZones;

        if (position.Seat < divider){
            return position.Seat / nZonesPerSection;
        }
        else{
            return (nSeatsPerRow - position.Seat-1) / nZonesPerSection;
        }
    }
}