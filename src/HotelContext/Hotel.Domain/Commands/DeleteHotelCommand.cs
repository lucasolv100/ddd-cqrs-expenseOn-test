using Hotel.Domain.Core.Commands;

namespace Hotel.Domain.Commands
{
    public class DeleteHotelCommand : ICommand
    {
        public DeleteHotelCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        
    }
}