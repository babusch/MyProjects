using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Village_of_Testing_Jens_Kjellberg
{
    public class Village
    {
        private int food_count = 0;
        private int wood_count = 0;
        private int metal_count = 0;
        private List<Building> buildings;
        private List<Building> buildprojects;
        private List<Worker> workers;
        private int day_count = 0;

        private int foodproductivity = 5;
        private int woodproductivity = 1;
        private int metalproductivity = 1;

        private DatabaseConnection dbConnect;

        private bool testing = false;

        public Village()
        {
            dbConnect = new DatabaseConnection();
            food_count = 10;
            buildings = new List<Building>();
            workers = new List<Worker>();
            buildprojects = new List<Building>();
            buildings.Add(new Building("House", true));
            buildings.Add(new Building("House", true));
            buildings.Add(new Building("House", true));
        }
        public bool AddWorker(int type)
        {
            if (!ChackHousing()) return false;
            if(type == 1)
            {
                Worker worker = new Worker(() => AddWood(), "Lumberjack", "Collects wood");
                workers.Add(worker);
            }
            if(type == 2)
            {
                Worker worker = new Worker(() => AddMetal(), "Miner", "Collects metal");
                workers.Add(worker);
            }
            if (type == 3)
            {
                Worker worker = new Worker(() => AddFood(), "Farmer", "Collects food");
                workers.Add(worker);
            }
            if (type == 4)
            {
                Worker worker = new Worker(() => Build(), "Builder", "Builds structures");
                workers.Add(worker);
            }
            return true;
        }

        private bool ChackHousing()
        {
            int house_count = 0;
            foreach (Building building in buildings)
            {
                if(building.Name == "House") house_count++;
            }
            if(house_count*2 <= workers.Count) return false;
            return true;
        }

        public bool AddRandomWorker(RandomClass r)
        {
            bool worker = AddWorker(r.RandomNumber(1, 5));
            return worker;
        }

        public bool AddProject(int type)
        {
            switch (type)
            {
                case 1:
                    if(wood_count < 5) return false;
                    Building house = new Building("House",3, 5, 0);
                    wood_count -= 5;
                    buildprojects.Add(house);
                    break;
                case 2:
                    if(wood_count < 5 || metal_count < 1) return false;
                    Building woodmill = new Building("Woodmill", 5, 5, 1);
                    wood_count -= 5;
                    metal_count -= 1;
                    buildprojects.Add(woodmill);
                    break;
                case 3:
                    if (wood_count < 3 || metal_count < 5) return false;
                    Building quarry = new Building("Quarry", 7, 3, 5);
                    wood_count -= 3;
                    metal_count -= 5;
                    buildprojects.Add(quarry);
                    break;
                case 4:
                    if (wood_count < 5 || metal_count < 2) return false;
                    Building farm = new Building("Farm", 5, 5, 2);
                    wood_count -= 5;
                    metal_count -= 2;
                    buildprojects.Add(farm);
                    break;
                case 5:
                    if (wood_count < 50 || metal_count < 50) return false;
                    Building castle = new Building("Castle", 50, 50, 50);
                    wood_count -= 50;
                    metal_count -= 50;
                    buildprojects.Add(castle);
                    break;
            }
            return true;
        }
        public void Day()
        {
            day_count++;
            foreach(Worker worker in workers)
            {
                food_count = worker.Feed(food_count);
                worker.DoWork();
            }
        }
        public void AddWood()
        {
            wood_count += woodproductivity;
        }
        public void AddMetal()
        {
            metal_count += metalproductivity;
        }
        public void AddFood()
        {
            food_count += foodproductivity;
        }
        public void Build()
        {
            if (buildprojects.Count <= 0) return;
            buildprojects[0].DaysWorkedOnProject += 1;
            if(buildprojects[0].DaysWorkedOnProject >= buildprojects[0].DaysToComplete)
            {
                buildprojects[0].BuildingComplete();
                BuildingBonus(buildprojects[0]);
                buildings.Add(buildprojects[0]);
                buildprojects.Remove(buildprojects[0]);
            }
        }

        private void BuildingBonus(Building b)
        {
            switch (b.Name)
            {
                case "Woodmill":
                    woodproductivity += 2;
                    break;
                case "Quarry":
                    metalproductivity += 2;
                    break;
                case "Farm":
                    foodproductivity += 10;
                    break;
                case "Castle":
                    if (testing) break;
                    Program.GameWon();
                    break;
            }
        }
        public void BuryDead()
        {
            workers.RemoveAll(worker => worker.Alive == false);
            if(testing) return;
            if (workers.Count == 0)
            {
                Program.GameOver();
            }
        }
        public void SaveProgress()
        {
            dbConnect.Save(this);
        }
        public void LoadProgress()
        {
            Village loadVillage = dbConnect.Load();
            day_count = loadVillage.Day_Count;
            wood_count = loadVillage.Wood_Count;
            metal_count = loadVillage.Metal_Count;
            food_count = loadVillage.Food_Count;
            woodproductivity = loadVillage.Woodproductivity;
            foodproductivity = loadVillage.Foodproductivity;
            metalproductivity = loadVillage.Metalproductivity;
            buildings = loadVillage.Buildings;
            buildprojects = loadVillage.Buildprojects;
            workers = loadVillage.Workers;
        }

        public int Food_Count 
        { 
            get { return food_count; } 
            set { food_count = value; }
        }

        public int Wood_Count 
        { 
            get { return wood_count; }
            set { wood_count = value; }
        }

        public int Day_Count 
        { 
            get { return day_count; }
            set { day_count = value; }
        }

        public int Metal_Count 
        { 
            get{ return metal_count; }
            set { metal_count = value; } 
        }

        public List<Building> Buildings 
        { 
            get { return buildings; }
            set { buildings = value; } 
        }

        public List<Building> Buildprojects 
        { 
            get { return buildprojects; }
            set { buildprojects = value; } 
        }

        public List<Worker> Workers 
        { 
            get { return workers; }
            set { workers = value; } 
        }

        public int Foodproductivity 
        { 
            get { return foodproductivity;  }
            set { foodproductivity = value; }
        }

        public int Woodproductivity
        {
            get { return woodproductivity; }
            set { woodproductivity = value; }
        }

        public int Metalproductivity
        {
            get { return metalproductivity; }
            set { metalproductivity = value; }
        }

        public bool Testing { get { return testing;  } set { testing = value; } }

        public DatabaseConnection DbConnect 
        {
            get { return dbConnect; }
            set { dbConnect = value; } 
        }
    }
}
