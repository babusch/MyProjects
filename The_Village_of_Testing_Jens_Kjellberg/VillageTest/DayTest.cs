using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class DayTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void RunDayWhithoutWorkers(int expecteDays)
        {
            //testar att ingenting förutom day_count förändras när det inte finns några workers
            //given
            Village village = new Village();
            int expectedWood = 0;
            int expectedMetal = 0;
            int expectedFood = 10;
            List<Building> expectedBuildings = village.Buildings;
            List<Building> expectedBuildprojects = village.Buildprojects;
            List<Worker> expectedWorkers = village.Workers;

            //when
            for (int i = 0; i < expecteDays; i++) village.Day();
            int actual = village.Day_Count;

            //then
            Assert.Equal(expecteDays, actual);
            Assert.Equal(expectedWood, village.Wood_Count);
            Assert.Equal(expectedMetal, village.Metal_Count);
            Assert.Equal(expectedFood, village.Food_Count);
            Assert.Equal(expectedBuildings, village.Buildings);
            Assert.Equal(expectedBuildprojects, village.Buildprojects);
            Assert.Equal(expectedWorkers, village.Workers);
        }

        [Theory]
        [InlineData(2, 3, 4)]
        [InlineData(5, 2, 0)]
        [InlineData(10, 1, 0)]
        [InlineData(3, 3, 1)]
        [InlineData(4, 1, 6)]
        public void RunDayAndCheckFoodCountWithWorkers(int days, int workers, int expectedFood)
        {
            //given
            Village village = new Village();
            for (int i = 0; i < workers; i++) village.AddWorker(1);

            //when
            for (int i = 0; i < days; i++) village.Day();
            int actual = village.Food_Count;

            //then
            Assert.Equal(expectedFood, actual);
        }

        [Fact]
        public void RunDayWithoutFoodForWorker()
        {
            //given
            Village village = new Village();
            int days = 30;
            // 20
            int expectedDaysHungry = days - village.Food_Count;
            village.AddWorker(1);

            //when
            for(int i = 0; i < days; i++) village.Day();
            bool actualHungry = village.Workers[0].Hungry;
            int actualDaysHungry = village.Workers[0].DaysHungry;

            //then
            Assert.Equal(expectedDaysHungry, actualDaysHungry);
            Assert.True(actualHungry);
        }
        [Fact]
        public void RunDayWithoutFoodForWorkers()
        {
            //given
            Village village = new Village();
            village.AddWorker(1);
            village.AddWorker(2);
            village.AddWorker(4);
            int days = 4;
            //eftersom det bara finns 10 food så borde det bara finnas met till en worker dag 4 när de är 3 st
            bool expectedW1Hungry = false;
            bool expectedW2Hungry = true;
            bool expectedW3Hungry = true;



            //when
            for (int i = 0; i < days; i++) village.Day();
            bool actualW1Hungry = village.Workers[0].Hungry;
            bool actualW2Hungry = village.Workers[1].Hungry;
            bool actualW3Hungry = village.Workers[2].Hungry;

            //then
            Assert.False(actualW1Hungry);
            Assert.True(actualW2Hungry);
            Assert.True(actualW3Hungry);
        }
    }
}
