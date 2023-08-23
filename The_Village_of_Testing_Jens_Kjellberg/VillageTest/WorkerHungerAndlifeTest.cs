using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class WorkerHungerAndlifeTest
    {
        [Fact]
        public void WorkerDoesNotWorkWhenHungry()
        {
            //given
            Village village = new Village();
            //skaper metall arbetare
            village.AddWorker(2);
            //eftersom workers bara kan arbeta när det finns mat så kan resurserna inte överstiga maten
            int expectedMetal = village.Food_Count;

            //when
            //kör igenom 20 dagar vilket är mer än vad det finns mat för
            for (int i = 0; i < 20; i++) village.Day();
            int actualMetal = village.Metal_Count;

            //then
            Assert.Equal(expectedMetal, actualMetal);
        }

        [Fact]
        public void WorkeerCanDieTest()
        {
            //given
            Village village = new Village();
            //worker
            village.AddWorker(1);

            //when
            //det finns mat för 10 dagar och workers dör efter 40 dagar utan mat
            for(int i = 0; i < 50; i++) village.Day();

            //then
            Assert.False(village.Workers[0].Alive);
        }

        [Fact]
        public void DeadWorkerCantEatTest()
        {
            //given
            Village village = new Village();
            village.AddWorker(1);
            //dödar worker
            for(var i = 0; i < 50; i++) village.Day();
            //lägger till 5 mat
            village.AddFood();
            int expectedFood = village.Food_Count;

            //then

            //kör igenom 10 dagar
            for (int i = 0; i < 10; i++) village.Day();
            int actualFood = village.Food_Count;

            //then
            Assert.False(village.Workers[0].Alive);
            Assert.Equal(expectedFood, actualFood);
        }

        [Fact]
        public void BuryDeadTest()
        {
            //given
            Village village = new Village();
            village.Testing = true;
            //skapar några arbetare 
            village.AddWorker(1);
            village.AddWorker(2);
            village.AddWorker(4);

            //when
            //dödar alla workers
            for ( int i = 0; i < 50; i++) village.Day();
            village.BuryDead();

            //then
            Assert.Empty(village.Workers);
        }
    }
}
