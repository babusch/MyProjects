using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class RandomWorkerTest
    {
        [Theory]
        [InlineData(1, "Lumberjack")]
        [InlineData(2, "Miner")]
        [InlineData(3, "Farmer")]
        [InlineData(4, "Builder")]
        public void AddRandomWorkerTest(int workerType, string workerName)
        {
            //given
            Village village = new Village();

            //when
            Mock<RandomClass> RandomMock = new Mock<RandomClass>();
            RandomMock.Setup(mock => mock.RandomNumber(1,5)).Returns(workerType);
            village.AddRandomWorker(RandomMock.Object);

            //then
            Assert.Equal(village.Workers[0].Name, workerName);

        }
    }
}
