using Flunt.Notifications;
using Hotel.Domain.Commands;
using Hotel.Domain.Core.Commands;
using Hotel.Domain.Core.Handlers;
using Hotel.Domain.Repositories;
using Hotel.Domain.ValueObjects;
using System.Linq;

namespace Hotel.Domain.Handlers
{
    public class HotelCommandHandler : Notifiable, IHandler<InsertHotelCommand>,
    IHandler<UpdateHotelCommand>,
    IHandler<DeleteHotelCommand>
    {
        private IHotelRepository _repository;

        public HotelCommandHandler(IHotelRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(InsertHotelCommand command)
        {
            //gerar objeto de valores
            var address = new Address(command.Street, command.Number, command.ZipCode, command.State, command.City);

            //Gerar as entidades
            var Hotel = new Domain.Entites.Hotel(
                command.Name,
                command.Description,
                command.Rating,
                address,
                command.FeatureDescriptions
            );

            //Aplica as validações
            AddNotifications(Hotel);

            //verifica as validações
            if (Invalid)
            {
                return new CommandResult(false, "Não foi possivel cadastrar o hotel!");
            }

            //Salvar
            _repository.Save(Hotel);

            //Devolve o retorno
            return new CommandResult(true, "Hotel cadastrado com sucesso!");
        }

        public ICommandResult Handle(UpdateHotelCommand command)
        {
            //Fazer as validações em reposiório
            if (!_repository.IsHotelExists(command.Id))
            {
                AddNotification("Hotel.Id", "O id informado não consta na base de dados");
            }

            //Gerar os objetos de valor
            var address = new Address(command.Street, command.Number, command.ZipCode, command.State, command.City);
            
            //Gerar as entidade
            var Hotel = _repository.GetById(command.Id);

            //Update da entidade
            Hotel.UpdateHotel(
               command.Name,
                command.Description,
                command.Rating,
                address,
                command.FeatureDescriptions
            );

            //Aplicar as validações
            AddNotifications(Hotel);

            //verificar as validações
            if (Invalid)
            {
                return new CommandResult(false, "Não foi possivel atualizar o hotel!");
            }

            //Salvar
            _repository.Update(Hotel);

            //Devolver o retorno
            return new CommandResult(true, "Hotel atualizado com sucesso!");
        }

        public ICommandResult Handle(DeleteHotelCommand command)
        {
            //Fazer as validações em reposiório
            if (!_repository.IsHotelExists(command.Id))
            {
                AddNotification("Hotel.Id", "O id informado não consta na base de dados");
            }

            //Gerar as entidade
            var Hotel = _repository.GetById(command.Id);

            //Soft Delete da entidade
            Hotel.DeleteHotel();

            //Aplicar as validações
            AddNotifications(Hotel);

            //verificar as validações
            if (Invalid)
            {
                return new CommandResult(false, "Não foi possivel excluir o hotel!");
            }

            //Salvar
            _repository.Delete(Hotel);

            //Devolver o retorno
            return new CommandResult(true, "Hotel excluir com sucesso!");
        }
    }
}