using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatentransformationsServiceMessages;
using DatentransformationsServiceMessages.findingType;
using DatentransformationsServiceModels.Findings;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace GatewayService.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// TODO Fehlerhafte schnittstellen 1.1.4, 1.1.6 
    /// TODO GetAllFindings -&gt;int pages
    /// </summary>
    [Route("saloomon/[controller]")]
    [ApiController]
    [Authorize]
    public class DataTransformationController : ControllerBase
    {
        private readonly TimeSpan _timeout;
        private readonly Policy _pollyPolicy;


        private readonly IRequestClient<GeneralIdDTO, GetFindingTypeDTO> _getFindingTypeByIdClient;
        private readonly IRequestClient<CreateFindingTypeDTO, GeneralIdDTO> _createFindingTypeClient;
        private readonly IRequestClient<GeneralIdDTO, GeneralBoolDTO> _deleteFindingTypeClient;
        //1.1.4
        //1.1.6


        private readonly IRequestClient<CreateGroupTypeDTO, GeneralIdDTO> _createValueGroupTypeClient;
        // 1.2.2
        private readonly IRequestClient<GeneralIdDTO, GeneralBoolDTO> _deleteValueGroupClient;


        private readonly IRequestClient<CreateValueTypeDTO, GeneralIdDTO> _createValueTypeClient;
        //1.3.2
        private readonly IRequestClient<GeneralIdDTO, GeneralBoolDTO> _deleteValueTypeClient;


        //1.4.1
        //1.4.2
        private readonly IRequestClient<GeneralIdDTO, GeneralBoolDTO> _deleteFindingByIdClient;



        public DataTransformationController(IRequestClient<GeneralIdDTO, GetFindingTypeDTO> getFindingTypeByIdClient, IRequestClient<CreateFindingTypeDTO, GeneralIdDTO> createFindingTypeClient, IRequestClient<CreateGroupTypeDTO, GeneralIdDTO> createGroupTypeClient,
            IRequestClient<CreateValueTypeDTO, GeneralIdDTO> createValueTypeClient, Policy pollyPolicy, IBus bus, TimeSpan timeout)
        {
            _getFindingTypeByIdClient = getFindingTypeByIdClient;
            _createFindingTypeClient = createFindingTypeClient;
            _createValueGroupTypeClient = createGroupTypeClient;
            _createValueTypeClient = createValueTypeClient;
            _pollyPolicy = pollyPolicy;
            _timeout = timeout;

            //Not injectable due to definition of the data transformation interfaces
            _deleteFindingTypeClient = new MessageRequestClient<GeneralIdDTO, GeneralBoolDTO>
                (bus, new Uri(Startup.Configuration["RabbitMqUri"] + "/" + Startup.Configuration["DeleteFindingTypeQueue"]), _timeout);
            _deleteValueGroupClient = new MessageRequestClient<GeneralIdDTO, GeneralBoolDTO>
                (bus, new Uri(Startup.Configuration["RabbitMqUri"] + "/" + Startup.Configuration["DeleteValueGroupQueue"]), _timeout);
            _deleteValueTypeClient = new MessageRequestClient<GeneralIdDTO, GeneralBoolDTO>
                (bus, new Uri(Startup.Configuration["RabbitMqUri"] + "/" + Startup.Configuration["DeleteValueTypeQueue"]), _timeout);
            _deleteFindingByIdClient = new MessageRequestClient<GeneralIdDTO, GeneralBoolDTO>
                (bus, new Uri(Startup.Configuration["RabbitMqUri"] + "/" + Startup.Configuration["DeleteFindingById"]), _timeout);
        }


        #region FindingType

        [HttpGet("findingType/{id}")]
        [ProducesResponseType(200, Type = typeof(FindingType))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetFindingTypeById(long id)
        {
            var res = await _pollyPolicy.ExecuteAsync(() => _getFindingTypeByIdClient.Request(new { requestId = id }));
            if (res == null) { return StatusCode(500); }

            return Ok(res);
        }

        [HttpPost("findingType")]
        [ProducesResponseType(200, Type = typeof(GeneralIdDTO))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateFindingType([FromBody] string name)
        {
            var res = await _pollyPolicy.ExecuteAsync(() => _createFindingTypeClient.Request(new { name = name }));
            if (res == null) { return StatusCode(204); }

            return Ok(res);
        }

        [HttpDelete("findingType")]
        [ProducesResponseType(200, Type = typeof(GeneralBoolDTO))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteFindingTypeById(long id)
        {
            var res = await _pollyPolicy.ExecuteAsync(() => _deleteFindingTypeClient.Request(new { requestId = id }));
            if (res == null) { return StatusCode(204); }

            return Ok(res);
        }

        #endregion

        #region ValueGroup

        [HttpPost("valueGroup")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateValueGroup([FromBody] CreateGroupTypeDTO valueGroupToCreate)
        {
            var res = await _pollyPolicy.ExecuteAsync(() => _createValueGroupTypeClient.Request(valueGroupToCreate));
            if (res == null) { return StatusCode(204); }

            return Ok(res);
        }
        

        #endregion
    }
}
