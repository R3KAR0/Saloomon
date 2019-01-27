using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientServiceModels;
using PatientServiceModels.NewApproach;

namespace PatientService.Repositories
{
    
    public class TopLevelDocumentRepository : BaseRepository<TopLevelDocument, PatientsServiceContext>
    {
        public TopLevelDocumentRepository(PatientsServiceContext serviceContext) : base(serviceContext)
        {
            ServiceContext = serviceContext;
            RepoTable = serviceContext.TopDocuments;
        }

        public override async Task Update(TopLevelDocument entity)
        {
            await Task.Run(function: () => RepoTable.Update(entity));
        }
    }

}
