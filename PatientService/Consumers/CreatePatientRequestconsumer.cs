using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using PatientService.Repositories;
using PatientServiceRequestMessages;

namespace PatientService.Consumers
{
    public class CreatePatientRequestConsumer : IConsumer<CreatePatientRequest>
    {
        private readonly PatientsRepository _repository;
        public CreatePatientRequestConsumer(PatientsRepository repository)
        {
            _repository = repository;
        }


        public Task Consume(ConsumeContext<CreatePatientRequest> context)
        {
            throw new NotImplementedException();
        }
    }
}
