using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Dtos;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Requests;
using Sat.Recruitment.Api.Responses;
using System.Net;

namespace Sat.Recruitment.Api.Controllers
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Errors { get; set; }
    }

    [ApiController]
    [Route("api/v2/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;


        public UsersController(IUserApplicationService userApplicationService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userApplicationService = userApplicationService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser(UserCreationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UserCreationDto dto = _mapper.Map<UserCreationDto>(request);
            IActionResult result = _userApplicationService
                .CreateUser(dto)
                .Transform<IActionResult>(
                    onSuccess:result =>
                         CreatedAtAction(
                             nameof(CreateUser),
                             new { email = result.Value.Email },
                             new CreationResponse<UserCreationDto> (result.Value)
                        ),
                    onFail:result =>
                        Conflict(new ResponseBuilder()
                                    .FromError(result.Errors.First())
                                    .FromHttpContext(HttpContext)
                                    .AddStatusCode(HttpStatusCode.Conflict)
                                    .Build()
                      ) );

            return result;
        }
    }
}
