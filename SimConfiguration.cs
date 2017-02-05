// TODO: Refactor to use json config
public class SimConfiguration{

    #region Sim

    public static ZoneStrategy ZoneStrategy = ZoneStrategy.Random;
    public static int Runs = 1;
    public static bool Print = false;
    public static int StepThrottle = 50;
    

    #endregion
    

    #region Airplane
    
    public static int Rows = 30;
    public static int SeatsPerRow = 6;
    public static int Zones = 3;
    
    #endregion


    #region Person

    public static int DefaultTimeToStand = 10;
    public static int DefaultTimeToSit = 20;
    public static int PenaltyBag = 10;
    public static double ProbabilityHasBag = 0.9;

    #endregion
}