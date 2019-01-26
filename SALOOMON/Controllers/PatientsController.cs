using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HTTPRequestModels;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientServiceRequestMessages;
using PatientServiceResponseMessages;
using UserServiceModels;
using UserServiceRequestMessages;
using UserServiceResponseMessages;

namespace GatewayService.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// TODO Implement everything , Inject bus for sending e.g. CreateOnePatient
    /// </summary>
    [Route("saloomon/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {

        //private readonly IRequestClient<GetAllPatientsRequest, GetAllPatientsResponse> _getAllPatientsClient;

        //private readonly IRequestClient<GetOnePatientRequest, GetOnePatientResponse> _getOnePatientClient;

        //Get one
        //Get by Folders
        //Create
        //Update
        //Delete -> Marked as deleted
        //Delete as Administrator -> Clear all 
        //Delete as Administrator -> clear one

        private readonly IRequestClient<GetAllPatientsRequest, PatientListResponse> _getAllPatientsClient;
        private readonly IRequestClient<UserAuthorizedRequest, UserAuthorizedResponse> _authorizeClient;

        public PatientsController(IRequestClient<GetAllPatientsRequest, PatientListResponse> getAllPatientsClient, IRequestClient<UserAuthorizedRequest, UserAuthorizedResponse> authorizeClient)
        {
            _getAllPatientsClient = getAllPatientsClient;
            _authorizeClient = authorizeClient;
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientModel patientRequest)
        {
            var currentUser = new CurrentUser(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            Serilog.Log.Information($"CreatePatient was requested by {currentUser}");

            throw new NotImplementedException();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)] 
        [Authorize(Policy = "AdministratorsOnly")]
        public async Task<IActionResult> GetAllPatients()
        {
            var currentUser = new CurrentUser(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            Serilog.Log.Information($"GetAllPatients was requested by {currentUser}");

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = await _getAllPatientsClient.Request(new { UserId = userId });
            if (res != null) return Ok(res);
            return StatusCode(500);
        }

        [HttpGet("/folder/{folderId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPatientsFromFolder(int folderId)
        {
            var currentUser = new CurrentUser(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            Serilog.Log.Information($"GetAllPatientsFromFolder was requested by {currentUser}");

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
            if (!_authorizeClient.Request(new {UserId = userId, FolderId = folderId}).Result.IsAuthorized) return StatusCode(407);

            var res = await _getAllPatientsClient.Request(new { UserId = userId });
            if (res != null) return Ok(res);
            return StatusCode(500);
        }



        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Authorize(Policy = "AdministratorsOnly")]
        public async Task<IActionResult> DeletePatient()
        {
            var currentUser = new CurrentUser(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            Serilog.Log.Information($"DeletePatient was requested by {currentUser}");

            throw new NotImplementedException();
        }
    }
}
