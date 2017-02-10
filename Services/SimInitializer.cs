using System;
using System.Linq;
using System.Collections.Generic;

public class SimInitializer
{
    private IZoneStrategy zoneStrategy;
    private static Random rng = new Random();

    public SimInitializer()
    {
        zoneStrategy = new ZoneStrategyResolver().Resolve();
    }

    public SimState Initialize()
    {
        var airplane = new Airplane(
            SimConfiguration.Rows, SimConfiguration.SeatsPerRow
        );

        var numPersons = SimConfiguration.Rows * SimConfiguration.SeatsPerRow;
        var orderedPersons = new List<Person>(numPersons);
        var id = 0;
        for (var iRow = 0; iRow < SimConfiguration.Rows; iRow++)
        {
            for (var iSeat = 0; iSeat < SimConfiguration.SeatsPerRow; iSeat++)
            {
                var target = new Position { Row = iRow, Seat = iSeat };
                var hasBag = rng.NextDouble() < SimConfiguration.ProbabilityHasBag;
                orderedPersons.Add(new Person(id++, target, hasBag, zoneStrategy.AssignZone(target)));
            }
        }

        return new SimState(airplane, ReorderPersonsByZone(orderedPersons));
    }

    private IEnumerable<Person> ReorderPersonsByZone(IEnumerable<Person> persons)
    {
        var newPersons = new List<Person>();
        for (var i = 0; i < SimConfiguration.Zones; i++)
        {
            newPersons.AddRange(persons.Where(p => p.Zone == i).Shuffle());
        }

        return newPersons;
    }
}