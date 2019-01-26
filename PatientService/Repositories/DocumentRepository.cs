using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientServiceModels;

namespace PatientService.Repositories
{
    public class DocumentRepository : BaseRepository<Document, PatientsServiceContext>
    {
        public DocumentRepository(PatientsServiceContext serviceContext) : base(serviceContext)
        {
            ServiceContext = serviceContext;
            RepoTable = serviceContext.Documents;
        }

        public override async Task Update(Document entity)
        {
            await Task.Run(function: () => RepoTable.Update(entity));
        }
    }
}
