using System;

namespace HelloWorld.Modules
{
    public class Vehicle
    {
        private int vehicleHeight = 0;
        private int vehicleWidth = 0;
        private int vehicleLength = 0;

        public Vehicle()
        {
        }

        public int getVehicleHeight()
        {
            return this.vehicleHeight;
        }

        public void setVehicleHeight(int newHeight)
        {
            this.vehicleHeight = newHeight;
        }

        public int getVehicleWidth()
        {
            return this.vehicleWidth;
        }

        public void setVehicleWidth(int newWidth)
        {
            this.vehicleWidth = newWidth;
        }

        public int getVehicleLength()
        {
            return this.vehicleLength;
        }

        public void setVehicleLength(int newLength)
        {
            this.vehicleLength = newLength;
        }
    }

    public class SmallVehicles : Vehicle
    {
        private char vehicleClass = 'A';
        public SmallVehicles()
        {

        }

        public char getVehicleClass()
        {
            return this.vehicleClass;
        }
    }

    public class MediumVehicles : Vehicle
    {
        private char vehicleClass = 'B';
        public MediumVehicles()
        {

        }
       
        public char getVehicleClass()
        {
            return this.vehicleClass;
        }
    }

    public class LargeVehicles : Vehicle
    {
        private char vehicleClass = 'C';
        public LargeVehicles()
        {

        }

        public char getVehicleClass()
        {
            return this.vehicleClass;
        }
    }

    public class Motorcycle : SmallVehicles
    {
        private string vehicleType = "motorcycle";
        public Motorcycle()
        {

        }

        public string getVehicleType()
        {
            return this.vehicleType;
        }
    }

    public class Private : SmallVehicles
    {
        private string vehicleType = "private";
        public Private()
        {

        }
       
        public string getVehicleType()
        {
            return this.vehicleType;
        }
    }

    public class CrossOver : SmallVehicles
    {
        private string vehicleType = "crossover";
        public CrossOver()
        {

        }

        public string getVehicleType()
        {
            return this.vehicleType;
        }
    }

}
