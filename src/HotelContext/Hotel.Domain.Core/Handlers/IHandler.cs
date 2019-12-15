using Hotel.Domain.Core.Commands;

namespace Hotel.Domain.Core.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
         ICommandResult Handle(T commad);
    }
}