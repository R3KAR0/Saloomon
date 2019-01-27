using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientServiceModels;

namespace PatientService.Repositories
{
    public class PatientsRepository : BaseRepository<Patient, PatientsServiceContext>
    {
        public PatientsRepository(PatientsServiceContext serviceContext) : base(serviceContext)
        {
            ServiceContext = serviceContext;
            RepoTable = serviceContext.Patients;
        }

        public override async Task Update(Patient entity)
        {
            await Task.Run(function:() => RepoTable.Update(entity));
        }

    }
}
