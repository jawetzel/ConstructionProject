using System;
using System.Collections.Generic;
using System.Text;
using ConstructionDatabaseRepo.dataModels;
using ConstructionDatabaseRepo.dataRequests;

namespace ConstructionDatabaseRepo
{
    public class ConstructionRepository
    {
        public UserDataRequests UserDataRequests;

        public ConstructionRepository(Data.ConstructionContext contex)
        {
            UserDataRequests = new UserDataRequests(contex);
        }
    }
}
