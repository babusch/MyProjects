using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Village_of_Testing_Jens_Kjellberg;

namespace VillageTest
{
    public class GameTest
    {
        [Fact]
        // att köra igenom spelet med 1 av varje arbetare och bygga en av varje building borde ta 
        // det sammalagda dagarna det tar att bygga varje byggnad plus dagarna det tar att samla in resurserna för den
        // första byggnaden

        // för att bygga ett hus kostar det 5 ved vilket kommer ta 3 dagar att samla ihop
        // Börjar bygga Dag 5 (wood = 0, metal = 5), Klar dag 8 (wood = 3, metal = 8)
        // för att bygga en woodmill kostar det 5 ved och 1 metal och det kommar att ta 5 dagar att samla ihop veden
        // Börjar bygga Dag 10 (wood = 0, metal = 9), Kar dag 15 (wood = 5, metal = 14) 
        // för att bygga en Quarry kostar det 3 ved och 5 metal och tar 7 dagar att bygga
        // Börjar bygga Dag 15 (wood = 2, metal = 9) klar dag 22 (wood = 23, metal = 16)
        // för att bygga en Farm kommer det 5 dagar och vid den här punkten kommer vi ha mer än tillräckligt för att börja bygga
        // Börjar bygga Dag 22 (wood = 18, metal = 14), klar Dag 27 (wood = 33, metal = 29)
        // för att börja bygga Castle krävs det 50 ved och 50 metal vilket tar ett tag att samla ihop
        // Börjar bygga 34, klar Dag 84
        // Dagar det borde ta att vinna är 83 st
        public void GameFunctionTest()
        {
            //given 
            Village village = new Village();
            village.Testing = true;
            //skapar en av varje worker
            for (int i = 1; i < 5; i++) village.AddWorker(i);
            int expectedDaysToWin = 84; 

            //when
            RunDays(5, village);
            //börjar bygga ett hus
            village.AddProject(1);

            RunDays(5, village);
            //börjar bygga en woodmill
            village.AddProject(2);

            RunDays(5,village);
            //börjar bygga en Quarry
            village.AddProject(3);

            RunDays(7, village);
            //börjar bygga en farm
            village.AddProject(4);

            RunDays(12, village);
            //börjar bygga ett Castle
            village.AddProject(5);
            RunDays(50, village);

            //then
            Assert.True(CheckIfCastleIsDone(village.Buildings));
            Assert.Equal(expectedDaysToWin, village.Day_Count);
        }

        private void RunDays(int days, Village v)
        {
            for(int i = 0; i < days; i++) v.Day();
        }
        /*
        public void GameFunctionTest()
        {
            //given 
            Village village = new Village();
            village.Testing = true;
            //skapar en av varje worker
            for(int i = 1; i < 5; i++) village.AddWorker(i);
            int expectedDaysToWin = 84;

            //when
            //skapar en loop som loppar igenom alla dagarna
            int projectType = 1;
            bool activeProject = false;

            while (true)
            {
                if (village.Day_Count >= 5)
                {
                    if (!activeProject)
                    {
                        if (projectType < 6) village.AddProject(projectType);
                        projectType++;
                        if (village.Buildprojects.Count > 0) activeProject = true;
                    }
                }
                village.Day();

                if (village.Buildprojects.Count == 0) activeProject = false;

                if (CheckIfCastleIsDone(village.Buildings)) break;

            }
            bool castle = CheckIfCastleIsDone(village.Buildings);

            Assert.True(castle);
            Assert.Equal(expectedDaysToWin, village.Day_Count);
        }
         */
        private bool CheckIfCastleIsDone(List<Building> buildings)
        {
            foreach (Building building in buildings)
            {
                if (building.Name == "Castle") return true;
            }
            return false;
        }
    }
}
