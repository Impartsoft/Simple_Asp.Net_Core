using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_Asp.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsRepo _repository;
        private readonly IMapper _mapper;
        public GoodsController(IGoodsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<GoodsReadDto>> GetAllCommmands()
        {
            var commandItems = _repository.GetAllGoods();

            return Ok(_mapper.Map<IEnumerable<GoodsReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetGoodsById")]
        public ActionResult<GoodsReadDto> GetGoodsById(int id)
        {
            var commandItem = _repository.GetGoodsById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<GoodsReadDto>(commandItem));
            }
            return NotFound();
        }

        [HttpPost("SearchForPage")]
        public async Task<ActionResult<IEnumerable<GoodsReadDto>>> SearchForPage(GoodsSearchPageParams searchPageParams)
        {
            var commandItems = await _repository.SearchForPage(searchPageParams);

            return Ok(_mapper.Map<IEnumerable<GoodsReadDto>>(commandItems));
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<GoodsReadDto> CreateGoods(GoodsCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Goods>(commandCreateDto);
            _repository.CreateGoods(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<GoodsReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetGoodsById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGoods(int id, GoodsUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetGoodsById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateGoods(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialGoodsUpdate(int id, JsonPatchDocument<GoodsUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetGoodsById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<GoodsUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateGoods(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGoods(int id)
        {
            var commandModelFromRepo = _repository.GetGoodsById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteGoods(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
