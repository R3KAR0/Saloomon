using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientServiceModels;

namespace PatientService.Repositories
{
    public class StudyFolderRepository : BaseRepository<StudyFolder, PatientsServiceContext>
    {
        public StudyFolderRepository(PatientsServiceContext serviceContext) : base(serviceContext)
        {
            ServiceContext = serviceContext;
            RepoTable = serviceContext.StudyFolders;
        }

        /// <summary>
        /// TODO => CONSITENCY Check 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task Update(StudyFolder entity)
        {  
            await Task.Run(function: () => RepoTable.Update(entity));
        }
    }
}
