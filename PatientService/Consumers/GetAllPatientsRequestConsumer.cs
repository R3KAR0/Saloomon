using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using PatientService.Repositories;
using PatientServiceRequestMessages;
using PatientServiceResponseMessages;

namespace PatientService.Consumers
{
    public class GetAllPatientsRequestConsumer : IConsumer<GetAllPatientsRequest>
    {
        private readonly PatientsRepository _repository;
        public GetAllPatientsRequestConsumer(PatientsRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<GetAllPatientsRequest> context)
        {
            var toReturn = await _repository.GetAllAsync();
            await context.RespondAsync<PatientListResponse>(new {AllPatients = toReturn});
        }
    }
}
