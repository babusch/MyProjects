using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class LoadProgressTest
    {
        [Fact]
        public void LoadVillageTest()
        {
            //given
            Village village = new Village();
            Village loadVillage = new Village();
            //fyller loadVillage med data
            for (int i = 1; i <= 4; i++) loadVillage.AddWorker(i);

            for (int i = 0; i < 30; i++) loadVillage.Day();

            for (int i = 1; i <= 4; i++) loadVillage.AddProject(i);

            for (int i = 0; i < 5; i++) loadVillage.Day();

            // when
            Mock<DatabaseConnection> dbmock = new Mock<DatabaseConnection>();
            village.DbConnect = dbmock.Object;
            dbmock.Setup(mock => mock.Load()).Returns(loadVillage);

            village.LoadProgress();

            //then
            Assert.Equal(loadVillage.Day_Count, village.Day_Count);
            Assert.Equal(loadVillage.Metal_Count, village.Metal_Count);
            Assert.Equal(loadVillage.Food_Count, village.Food_Count);
            Assert.Equal(loadVillage.Wood_Count, village.Wood_Count);
            Assert.Equal(loadVillage.Foodproductivity, village.Foodproductivity);
            Assert.Equal(loadVillage.Woodproductivity, village.Woodproductivity);
            Assert.Equal(loadVillage.Metalproductivity, village.Metalproductivity);
            Assert.Equal(loadVillage.Buildings, village.Buildings);
            Assert.Equal(loadVillage.Buildprojects, village.Buildprojects);
            Assert.Equal(loadVillage.Workers, village.Workers);
        }
    }
}
