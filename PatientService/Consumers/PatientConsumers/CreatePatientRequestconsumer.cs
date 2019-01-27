using System;
using System.Threading.Tasks;
using MassTransit;
using PatientService.Repositories;
using PatientServiceModels;
using PatientServiceRequestMessages;
using PatientServiceResponseMessages;

namespace PatientService.Consumers.PatientConsumers
{
    public class CreatePatientRequestConsumer : IConsumer<CreatePatientRequest>
    {
        private readonly PatientsRepository _patientsRepository;
        private readonly TopLevelFolderRepository _topLevelFolderRepository;
        
        public CreatePatientRequestConsumer(PatientsRepository repository, TopLevelFolderRepository topLevelFolderRepository)
        {
            _patientsRepository = repository;
            _topLevelFolderRepository = topLevelFolderRepository;
        }


        public async Task Consume(ConsumeContext<CreatePatientRequest> context)
        {
            try
            {
                var folder = await _topLevelFolderRepository.GetOneAsync(context.Message.FolderId);
                var patientToAdd = new Patient(
                    context.Message.Title,context.Message.SocialInsuranceNumber, context.Message.FirstName, context.Message.LastName, context.Message.Gender,
                    context.Message.BirthDate, context.Message.Street, context.Message.ZipCode, context.Message.Town, context.Message.Country, context.Message.GDPRAcceptedId,
                    context.Message.StudyAccepted, folder
                );

                await _patientsRepository.AddAsync(patientToAdd);
                await context.RespondAsync<PatientCreatedResponse>(new { Success = false });
            }
            catch (Exception e)
            {
                Serilog.Log.Error($"Creation of a new patient failed! " +
                                  $" FolderId {context.Message.FolderId} Patient : {context.Message} " +
                                  $" Message ID : {context.MessageId} Sent time: {context.SentTime}" +
                                  $"Exception {e}");

                await context.RespondAsync<PatientCreatedResponse>(new {Success = false});
            }

        }
    }
}
