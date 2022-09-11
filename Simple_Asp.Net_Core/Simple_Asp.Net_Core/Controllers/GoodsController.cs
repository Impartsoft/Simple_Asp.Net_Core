using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet]
        public ActionResult<SysMsg> GetAllCommmands()
        {
            var commandItems = _repository.GetAllGoods();

            return SysMsg.Success(_mapper.Map<IEnumerable<GoodsReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetGoodsById")]
        public ActionResult<SysMsg> GetGoodsById(Guid id)
        {
            var commandItem = _repository.GetGoodsById(id);
            if (commandItem != null)
            {
                return SysMsg.Success(_mapper.Map<GoodsReadDto>(commandItem));
            }
            return SysMsg.Fail("未找到该产品！");
        }

        [HttpPost("SearchForPage")]
        public async Task<ActionResult<SysMsg>> SearchForPage(GoodsSearchPageParams searchPageParams)
        {
            var commandItems = await _repository.SearchForPage(searchPageParams);

            return SysMsg.Success(_mapper.Map<IEnumerable<GoodsReadDto>>(commandItems));
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<SysMsg> CreateGoods(GoodsCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Goods>(commandCreateDto);
            _repository.CreateGoods(commandModel);
            _repository.SaveChanges();

            return SysMsg.Success("新增成功！",_mapper.Map<GoodsReadDto>(commandModel));
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult<SysMsg> UpdateGoods(Guid id, GoodsUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetGoodsById(id);
            if (commandModelFromRepo == null)
            {
                return SysMsg.Fail("未找到该产品！");
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateGoods(commandModelFromRepo);

            _repository.SaveChanges();

            return SysMsg.Success("更新成功！");
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult<SysMsg> PartialGoodsUpdate(Guid id, JsonPatchDocument<GoodsUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetGoodsById(id);
            if (commandModelFromRepo == null)
            {
                return SysMsg.Fail("未找到该产品！");
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

            return SysMsg.Success("更新成功！");
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult<SysMsg> DeleteGoods(Guid id)
        {
            var commandModelFromRepo = _repository.GetGoodsById(id);
            if (commandModelFromRepo == null)
            {
                return SysMsg.Fail("未找到该产品！");
            }
            _repository.DeleteGoods(commandModelFromRepo);
            _repository.SaveChanges();

            return SysMsg.Success("删除成功！");
        }
    }
}
