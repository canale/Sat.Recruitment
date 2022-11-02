using Sat.Recruitment.Domain.Dtos;

namespace Sat.Recruitment.Api.Responses;

public class CreationResponse<TTarget>
{
    public TTarget Target { get; }

    public CreationResponse(TTarget target)
    {
        Target = target;
    }
}
