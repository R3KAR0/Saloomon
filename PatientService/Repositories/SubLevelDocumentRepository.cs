using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientServiceModels.NewApproach;

namespace PatientService.Repositories
{

    public class SubLevelDocumentRepository : BaseRepository<SubLevelDocument, PatientsServiceContext>
    {
        public SubLevelDocumentRepository(PatientsServiceContext serviceContext) : base(serviceContext)
        {
            ServiceContext = serviceContext;
            RepoTable = serviceContext.SubDocuments;
        }

        public override async Task Update(SubLevelDocument entity)
        {
            await Task.Run(function: () => RepoTable.Update(entity));
        }
    }
}
