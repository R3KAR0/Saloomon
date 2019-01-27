using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientServiceModels.NewApproach;

namespace PatientService.Repositories
{
    public class PatientFoldersRepository : BaseRepository<PatientFolder, PatientsServiceContext>
    {
        public PatientFoldersRepository(PatientsServiceContext serviceContext) : base(serviceContext)
        {
            ServiceContext = serviceContext;
            RepoTable = ServiceContext.PatientFolders;
        }

        public override async Task Update(PatientFolder entity)
        {
             await Task.Run(function: () => RepoTable.Update(entity));
        }
    }
}
