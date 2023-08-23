using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Village_of_Testing_Jens_Kjellberg
{
    public class Building
    {
        private string name;
        private bool projectComplete = false;
        private int daysToComplete;
        private int daysWorkedOnProject = 0;
        private int woodCost;
        private int metalCost;

        public Building(string name, int dtc, int woodCost, int metalCost)
        {
            this.name = name;
            this.daysToComplete = dtc;
            this.woodCost = woodCost;
            this.metalCost = metalCost;
        }
        public Building(string name, bool complete)
        {
            this.name = name;
            projectComplete = complete;
        }

        public void BuildingComplete()
        {
            projectComplete = true;
        }
        public int DaysToComplete { get{ return daysToComplete; } }

        public int DaysWorkedOnProject 
        { 
            get{ return daysWorkedOnProject; } 
            set { daysWorkedOnProject = value; } 
        }
        public string Name { get { return name; } }

        public override string ToString()
        {
            return name + ", complete: " + projectComplete + ", dtc: " + daysToComplete + ", dwop: " + daysWorkedOnProject + ", wood cost: " + woodCost + ", metal cost: " + metalCost;
        }
    }
}
