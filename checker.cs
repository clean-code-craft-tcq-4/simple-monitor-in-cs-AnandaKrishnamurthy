using System;
using System.Diagnostics;

class Checker

{
  
    public static bool temperatureIsOk(float temperature)
    {
      if (temperature< 0 || temperature> 45)
        {
            Console.WriteLine("Temperature is out of range!");
            return false;
        }
            return true;
    }


    public static bool socIsOk(float soc)
    {
        if (soc < 20 || soc > 80)
        {
            Console.WriteLine("State of Charge is out of range!");
            return false;
        }
            return true;
    }

    public static bool chargeRateIsOk(float chargeRate)
    {
        if (chargeRate > 0.8)
        {
            Console.WriteLine("Charge Rate is out of range!");
            return false;
        }
       
            return true;
    }

    static bool batteryIsOk(Func<float, bool> temperatureIsOk, float temperature, Func<float, bool> socIsOk, float soc, Func<float, bool> chargeRateIsOk, float chargeRate)
    {

        return temperatureIsOk(temperature);
        return socIsOk(soc);
        return chargeRateIsOk(chargeRate);
    }


    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main()
    {
        ExpectTrue(batteryIsOk(temperatureIsOk,25,socIsOk, 70, chargeRateIsOk,0.7f));
        ExpectFalse(batteryIsOk(temperatureIsOk,50, socIsOk, 85, chargeRateIsOk, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
}
