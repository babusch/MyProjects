using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class AddWorkerUnitTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void AddWorkerTest_AddingWorkers(int workerAmount)
        {
            //given
            Village village = new Village();

            //when
            for(int i = 0; i < workerAmount; i++) village.AddWorker(1);
            int actual = village.Workers.Count;

            //then
            Assert.Equal(workerAmount, actual);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        public void AddWorkerTest_AddingWorkerWhenNotEnoughHousing(int workerCount)
        {
            //given
            Village village = new Village();
            //village har 3 hus till än början därför är det maximala antalet workers 6
            int expectedWorkers = 6;

            //when
            for (int i = 0; i < workerCount; i++) village.AddWorker(2);
            int actual = village.Workers.Count;

            //then
            Assert.Equal(expectedWorkers, actual);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 9)]
        [InlineData(4, 2, 8)]
        [InlineData(5, 1, 5)]
        public void WorkerAddsWoodPerDay(int days, int workerAmount, int expectedWood)
        {
            //given
            Village village = new Village();
            for (int i = 0; i < workerAmount; i++) village.AddWorker(1);
            int expectedFood = village.Food_Count - (days * village.Workers.Count);

            //when
            for (int i = 0; i < days; i++) village.Day();
            int actual = village.Wood_Count;

            //then
            Assert.Equal(expectedWood, actual);
            Assert.Equal(expectedFood, village.Food_Count);
        }
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 3, 6)]
        [InlineData(3, 3, 9)]
        [InlineData(4, 1, 4)]
        [InlineData(5, 2, 10)]
        public void WorkerAddsMetalPerDay(int days, int workerAmount, int expectedMetal)
        {
            //given
            Village village = new Village();
            for (int i = 0; i < workerAmount; i++) village.AddWorker(2);
            int expectedFood = village.Food_Count - (days * village.Workers.Count);

            //when
            for (int i = 0; i < days; i++) village.Day();
            int actual = village.Metal_Count;

            //then
            Assert.Equal(expectedMetal, actual);
            Assert.Equal(expectedFood, village.Food_Count);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        [InlineData(4, 1)]
        [InlineData(5, 2)]
        public void WorkerAddsFoodPerDay(int days, int workerAmount)
        {
            //given
            Village village = new Village();
            for (int i = 0; i < workerAmount; i++) village.AddWorker(3);

            int expectedFood = 10+(5*days * workerAmount)-(days*workerAmount);

            //when
            for (int i = 0; i < days; i++) village.Day();
            int actual = village.Food_Count;

            //then
            Assert.Equal(expectedFood, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void WorkerFarmBuildingProgressTest(int days)
        {
            //given
            Village village = new Village();
            //adding a builder 
            village.AddWorker(4);
            //adding 5 wood
            for (int i = 0; i < 5; i++)
            {
                village.AddWood();
                village.AddMetal(); 
            }

            //when
            //startar att bygga en Farm
            village.AddProject(4);
            //loopar igenom alla dagarna det tar att bygga farmen förutom det siste eftersom sista dagen bytar Farmen lista.
            for (int i = 0; i < days; i++) village.Day();
            int actual = village.Buildprojects[0].DaysWorkedOnProject;

            //then
            Assert.Equal(days, actual);
        }
    }
}