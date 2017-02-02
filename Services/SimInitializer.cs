using System;
using System.Linq;
using System.Collections.Generic;

public class SimInitializer{
    private SimConfiguration configuration;

    public SimInitializer(SimConfiguration configuration){
        this.configuration = configuration;
    }

    public SimState Initialize(){
        if (configuration.SeatsPerRow % 2 == 1){
            // TODO: implement odd SeatsPerRow
            throw new Exception("Only even SeatsPerRow allowed");
        }

        var airplane = new Airplane(
            configuration.Rows, configuration.SeatsPerRow
        );

        var numPersons = configuration.Rows * configuration.SeatsPerRow;
        var orderedPersons = new List<Person>(numPersons);
        for (var iRow = 0; iRow < configuration.Rows; iRow++){
            for (var iSeat = 0; iSeat < configuration.SeatsPerRow * 2; iSeat++){
                var target = new Position { Row = iRow, Seat = iSeat };
                // TODO: implement bag probability and zone strategy
                orderedPersons.Add(new Person(target, true, 1));
            }
        }

        return new SimState(airplane, ReorderPersonsByZone(orderedPersons));
    }

    private IEnumerable<Person> ReorderPersonsByZone(IEnumerable<Person> persons){
        var newPersons = new List<Person>();
        for (var i = 0; i < configuration.Zones; i ++){
            newPersons.AddRange(persons.Where(p => p.Zone == i).Shuffle());
        }

        return persons;
    }
}