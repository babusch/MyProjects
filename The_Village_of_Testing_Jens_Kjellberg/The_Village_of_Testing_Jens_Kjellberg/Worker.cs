using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Village_of_Testing_Jens_Kjellberg
{
    public class Worker
    {
        public delegate void WorkAsignment();

        private string name;
        private string description;
        private bool hungry;
        private int daysHungry = 0;
        private bool alive = true;
        private WorkAsignment wa;

        public Worker(WorkAsignment wa, string name, string dscription)
        {
            this.name = name;
            this.description = dscription;
            this.wa = wa;
        }

        public void DoWork()
        {
            if (!alive) return;
            if(daysHungry >= 40)
            {
                alive = false;
                return;
            }
            if (hungry) return;
            wa();
        }

        public int Feed(int food)
        {
            if(!alive) return food;
            if (food < 1)
            {
                hungry = true;
                daysHungry++;
                return food;
            }
            food--;
            hungry = false;
            daysHungry = 0;
            return food;
        }
        public bool Alive { get { return alive; } }

        public bool Hungry { get { return hungry; } }

        public int DaysHungry { get { return daysHungry; } }

        public string Name { get { return name; } }
        public override string ToString()
        {
            return name + ", " + description + ", hungry: " + hungry + ", alive: " + alive + ", days hungry " + daysHungry;
        }
    }
}
