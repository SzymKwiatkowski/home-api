using CSharpFunctionalExtensions;

namespace HomeApi.Application.Common.Requests;

public interface IRequestCommand<Tout> : IRequest<Result<Tout>>
{

}
