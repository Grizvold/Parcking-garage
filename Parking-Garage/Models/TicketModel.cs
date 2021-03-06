﻿using System;
using System.Collections.Generic;
namespace Parking_Garage.Models
{
    public class TicketModel
    {
        public int lots { get; set; }
        public int cost { get; set; }
        public string time { get; set; }
        public int maxHeight { get; set; }
        public int maxWidth { get; set; }
        public int maxlength { get; set; }
        public List<string> vehicleClasses { get; set; }

        public TicketModel(string type)
        {
            vehicleClasses = new List<string>();
            if (type.Equals("vip"))
            {
                initVipTicket();
            }
            else if (type.Equals("value"))
            {
                initValueTicket();
            }
            else if (type.Equals("regular"))
            {
                initTicket();
            }
        }

        private void initVipTicket()
        {
            this.lots = 10;
            this.cost = 200;
            this.time = "no limit";
            this.maxHeight = int.MaxValue;
            this.maxWidth = int.MaxValue;
            this.maxlength = int.MaxValue;
            this.vehicleClasses.Add("A");
            this.vehicleClasses.Add("B");
            this.vehicleClasses.Add("C");
        }

        private void initValueTicket()
        { 
            this.lots = 20;
            this.cost = 100;
            this.time = "72h";
            this.maxHeight = 2500;
            this.maxWidth = 2400;
            this.maxlength = 5000;
            this.vehicleClasses.Add("A");
            this.vehicleClasses.Add("B");
        }

        private void initTicket()
        {
            this.lots = 30;
            this.cost = 50;
            this.time = "24h";
            this.maxHeight = 2000;
            this.maxWidth = 2000;
            this.maxlength = 3000;
            this.vehicleClasses.Add("A");
        }
    }
}
