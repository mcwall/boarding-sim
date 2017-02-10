public interface IZoneStrategy
{
    int AssignZone(Position position);
}

public enum ZoneStrategy
{
    Random,
    Area,
    Aisle,
    Hybrid
}