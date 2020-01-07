using System.Collections.Generic;
using System.Linq;
using Hotel.API.ViewModels;
using Hotel.Domain.Commands;
using Hotel.Domain.Handlers;
using Hotel.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _repository;

        public HotelController(
            IHotelRepository repository
        )
        {
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        [Route("hotel")]
        public ActionResult<IEnumerable<GetHotelVM>> GetHotels()
        {
            var query = _repository.GetAll();
            
            if (query != null)
            {
                var resp = query.Select(q => new GetHotelVM
                {
                    Id = q.Id,
                    Name = q.Name,
                    Description = q.Description,
                    Rating = q.Rating,
                    Street = q.Address.Street,
                    Number = q.Address.Number,
                    ZipCode = q.Address.ZipCode,
                    State = q.Address.State,
                    City = q.Address.City,
                    FeatureDescriptions = q.Features
                });
                return Ok(resp);
            }

            return NotFound();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("hotel/{id}")]
        public ActionResult<GetHotelVM> Get(int id)
        {
            var query = _repository.GetById(id);

            if (query != null)
            {
        
                var resp = new GetHotelVM
                {
                    Id = query.Id,
                    Name = query.Name,
                    Description = query.Description,
                    Rating = query.Rating,
                    Street = query.Address.Street,
                    Number = query.Address.Number,
                    ZipCode = query.Address.ZipCode,
                    State = query.Address.State,
                    City = query.Address.City,
                    FeatureDescriptions = query.Features
                };

                return Ok(resp);
            }

            return NotFound();
        }

        // POST api/values
        [HttpPost]
        [Route("hotel")]
        public ActionResult Post([FromBody] RegisterHotelVM model)
        {
            var handler = new HotelCommandHandler(_repository);
            var command = new InsertHotelCommand(
                model.Name,
                model.Description,
                model.Rating,
                model.Street,
                model.Number,
                model.ZipCode,
                model.State,
                model.City,
                model.FeatureDescriptions
            );

            handler.Handle(command);

            if (!handler.Valid)
            {
                List<string> errorMessages = new List<string>();

                foreach (var erro in handler.Notifications)
                {
                    errorMessages.Add(erro.Message);
                }

                return BadRequest(new
                {
                    success = false,
                    errors = errorMessages
                });
            }

            return Ok(new
            {
                success = true,
                message = "Cadastro de hotel feito com sucesso"
            });
        }

        // PUT api/values/5
        [HttpPut]
        [Route("hotel/{id}")]
        public ActionResult Put(int id, [FromBody] RegisterHotelVM model)
        {
            var handler = new HotelCommandHandler(_repository);
            var command = new UpdateHotelCommand(
                id,
                model.Name,
                model.Description,
                model.Rating,
                model.Street,
                model.Number,
                model.ZipCode,
                model.State,
                model.City,
                model.FeatureDescriptions
            );

            handler.Handle(command);

            if (!handler.Valid)
            {
                List<string> errorMessages = new List<string>();

                foreach (var erro in handler.Notifications)
                {
                    errorMessages.Add(erro.Message);
                }

                return BadRequest(new
                {
                    success = false,
                    errors = errorMessages
                });
            }

            return Ok(new
            {
                success = true,
                message = "Atualização do hotel feito com sucesso"
            });
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("hotel/{id}")]
        public ActionResult Delete(int id)
        {
            var handler = new HotelCommandHandler(_repository);
            var command = new DeleteHotelCommand(
                id
            );

            handler.Handle(command);

            if (!handler.Valid)
            {
                List<string> errorMessages = new List<string>();

                foreach (var erro in handler.Notifications)
                {
                    errorMessages.Add(erro.Message);
                }

                return BadRequest(new
                {
                    success = false,
                    errors = errorMessages
                });
            }

            return Ok(new
            {
                success = true,
                message = "Exclusão de hotel feito com sucesso"
            });
        }
    }
}
