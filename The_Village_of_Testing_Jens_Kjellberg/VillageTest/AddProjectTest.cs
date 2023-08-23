using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class AddProjectTest
    {
        [Theory]
        [InlineData(1, 5 , 0, "House")]
        [InlineData(2, 5 , 1, "Woodmill")]
        [InlineData(3, 3 , 5, "Quarry")]
        [InlineData(4, 5 , 2, "Farm")]
        [InlineData(5, 50 , 50, "Castle")]
        public void AddAllProjectsAndMonitorResorcesTest(int buldingType, int woodCost, int MetalCost, string expectedName)
        {
            //given
            Village village = new Village();
            int expectedWood = 0;
            int expectedMetal = 0;

            //when
            for (int i = 0; i < woodCost; i++) village.AddWood();
            for(int i = 0; i < MetalCost; i++) village.AddMetal();
            village.AddProject(buldingType);
            int actualWood = village.Wood_Count;
            int actualMetal = village.Metal_Count;
            string actualName = village.Buildprojects[0].Name;

            //then
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedWood, actualWood);
            Assert.Equal(expectedMetal, actualMetal);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void AddAllProjectsWithoutEnoughResourses(int buldingType)
        {
            //given
            Village village = new Village();

            //when
            village.AddProject(buldingType);

            //Then
            Assert.Empty(village.Buildprojects);
        }
    }
}
