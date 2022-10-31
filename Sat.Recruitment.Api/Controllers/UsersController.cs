using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AutoMapper;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Dtos;

namespace Sat.Recruitment.Api.Controllers
{
    public class Result
    {
        public bool IsSuccess { get; set; }

        public string Errors { get; set; }
    }

    [ApiController]
    [Route("api/v2/[controller]")]
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

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(UserCreationRequest request)
        {
            var errors = "";

            ValidateErrors(request, ref errors);

            if (errors != null && errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            UserCreationDto dto = _mapper.Map<UserCreationDto>(request);
            var result = _userApplicationService.CreateUser(dto);

            return new Result
            {
                IsSuccess = result.IsSuccess,
                Errors = result.Errors
            };
        }

        //Validate errors
        private void ValidateErrors(UserCreationRequest request, ref string errors)
        {
            if (string.IsNullOrEmpty(request.name))
                //Validate if Name is null
                errors = "The Name is required";

            if (string.IsNullOrEmpty(request.email))
                //Validate if Email is null
                errors = errors + " The Email is required";

            if (string.IsNullOrEmpty(request.address))
                //Validate if Address is null
                errors = errors + " The Address is required";

            if (string.IsNullOrEmpty(request.phone))
                //Validate if Phone is null
                errors = errors + " The Phone is required";
        }
    }
}
