public class AreaZoneStrategy : IZoneStrategy{

    public int AssignZone(Position position){
        var nRows = SimConfiguration.Rows;
        var nZones = SimConfiguration.Zones;
        var zoneSize = nRows / nZones;

        return nZones - 1 - position.Row / zoneSize;
    }
}