using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientServiceModels;
using PatientServiceModels.NewApproach;

namespace PatientService.Repositories
{
    
    public class TopLevelFolderRepository : BaseRepository<TopLevelFolder, PatientsServiceContext>
    {
        public TopLevelFolderRepository(PatientsServiceContext serviceContext) : base(serviceContext)
        {
            ServiceContext = serviceContext;
            RepoTable = serviceContext.TopLevelFolders;
        }

        /// <summary>
        /// TODO => CONSITENCY Check 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task Update(TopLevelFolder entity)
        {  
            await Task.Run(function: () => RepoTable.Update(entity));
        }
    }
    
}
