using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class BuildingTest
    {
        [Theory]
        [InlineData(0, 6, 0)]
        [InlineData(1, 8, 3)]
        [InlineData(2, 10, 6)]
        [InlineData(3, 12, 9)]
        public void HouseWorkerCapIncreseTest(int addedHouses, int expectedWorkerCap, int daysToCompleteAllHouses)
        {
            //given
            Village village = new Village();
            village.AddWorker(4);

            //when
            for (int i = 0; i < addedHouses*5; i++) village.AddWood();
            for (int i = 0; i < addedHouses; i++) village.AddProject(1);
            for (int i = 0; i < daysToCompleteAllHouses; i++) village.Day();
            for (int i = 0; i < 20; i++) village.AddWorker(1);
            int actualWorkers = village.Workers.Count;

            //then
            Assert.Equal(expectedWorkerCap, actualWorkers);
        }


        [Theory]
        [InlineData(2, 5, 2)]
        [InlineData(3, 7, 2)]
        [InlineData(4, 5, 10)]
        public void AllBuildingsBonusTest(int buildingType, int days, int resourceBonus)
        {
            //given
            Village village = new Village();
            int expectedResource;
            if(buildingType == 2 || buildingType == 3) expectedResource = days + resourceBonus;
            // Farmer ger 5 food per dag * dagar + bonusen för sista dagen +
            // (10 mat från start - antalet dagar * antalet arbetare, eftersom de konsumerar 1 mat var per dag)
            else expectedResource = (days*5)+resourceBonus+(10-days*2);
            //Builder
            village.AddWorker(4);
            //Farmer
            village.AddWorker(3);

            //when
            //adding the resources needed to build the building
            switch (buildingType)
            {
                case 2:
                    village.AddWorker(1);
                    for(int i = 0; i < 5; i++) village.AddWood();
                    for (int i = 0; i < 1; i++) village.AddMetal();
                        break;
                case 3:
                    village.AddWorker(2);
                    for (int i = 0; i < 3; i++) village.AddWood();
                    for (int i = 0; i < 5; i++) village.AddMetal();
                    break;
                case 4:
                    for (int i = 0; i < 5; i++) village.AddWood();
                    for (int i = 0; i < 2; i++) village.AddMetal();
                    break;
            }
            village.AddProject(buildingType);
            for (int i = 0; i < days; i++) village.Day();

            //then
            switch (buildingType)
            {
                case 2:
                    Assert.Equal(expectedResource, village.Wood_Count);
                    break;
                case 3:
                    Assert.Equal(expectedResource, village.Metal_Count);
                    break;
                case 4:
                    Assert.Equal(expectedResource, village.Food_Count);
                    break;
            }


        }

        [Theory]
        [InlineData(1, 3, 3, "House")]
        [InlineData(2, 5, 3, "Woodmill")]
        [InlineData(3, 7, 2, "Quarry")]
        [InlineData(4, 5, 4, "Farm")]
        [InlineData(5, 50, 6, "Castle")]
        public void BuildBuildingsWithMultipleWorkersTest(int buildingType, int workDaysToComplete, int builders, string buildingName)
        {
            //given
            Village village = new Village();
            village.Testing = true;
            int day_count = 0;

            //skapar våra builders 
            for (int i = 0; i < builders; i++) village.AddWorker(4);
            
            //de existerande husen man får plus det vi bygger
            int expectedBuildingsCount = village.Buildings.Count+1;

            // antal gånger vi behöver köra Day() funktionen
            int expectedTimesToRunDay = CalculateExpectedDaysToRun(workDaysToComplete, builders);

            //then
            //Skapar resuerser så att vi kan bygga vad vi vill
            for(int i = 0; i < 50; i++) 
            {
                village.AddWood();
                village.AddMetal();
                village.AddFood();
            }

            //skaper vårt byggprojekt 
            village.AddProject(buildingType);
            while (true)
            {
                village.Day();
                day_count++;
                if(village.Buildings.Count == expectedBuildingsCount) break;
            }

            //then
            Assert.Equal(expectedTimesToRunDay, day_count);
        }

        private int CalculateExpectedDaysToRun(int workdays, int builders) 
        {
            //om det finns fler builders än arbetsdagar tar det bara en dag att slutföra projektet 
            if (workdays < builders) return 1;


            int days = workdays / builders;
            //om det finns en rest som är större än ett betyder det att det tar en dag till
            if (workdays % builders <= workdays && workdays % builders > 0) days++;
            return days;
        }
    }
}
