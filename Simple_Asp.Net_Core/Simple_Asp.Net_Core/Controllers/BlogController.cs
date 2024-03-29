﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Extensions;
using Simple_Asp.Net_Core.Model.Models;
using System.Security.Claims;

namespace Simple_Asp.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepo _repository;
        private readonly IMapper _mapper;
        public BlogController(IBlogRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/blogs
        [HttpGet]
        public ActionResult<SysMsg> GetAllBlogs()
        {
            var blogItems = _repository.GetAllBlog();

            return SysMsg.Success(_mapper.Map<IEnumerable<BlogReadDto>>(blogItems));
        }

        [HttpGet("GetUserBlogs")]
        public ActionResult<SysMsg> GetUserBlogs(Guid userId)
        {
            var blogItems = _repository.GetBlogsByUserId(userId);

            return SysMsg.Success(_mapper.Map<IEnumerable<BlogReadDto>>(blogItems));
        }

        //GET api/blogs/{id}
        [HttpGet("{id}", Name = "GetBlogById")]
        public ActionResult<SysMsg> GetBlogById(Guid id)
        {
            var blogItem = _repository.GetBlogById(id);
            if (blogItem != null)
            {
                return SysMsg.Success(_mapper.Map<BlogReadDto>(blogItem));
            }
            return SysMsg.Fail("未找到该产品！");
        }

        [HttpGet("GetUserBlogLabels")]
        public ActionResult<SysMsg> GetUserBlogLabels(Guid userId)
        {
            var blogItem = _repository.GetUserBlogLabels(userId);
            if (blogItem != null)
            {
                return SysMsg.Success(blogItem);
            }
            return SysMsg.Fail("未找用户博客的标签列表！");
        }

        /// <summary>
        /// 根据关键词查找博客列表
        /// </summary>
        [HttpGet("GetBlogByKey")]
        public ActionResult<SysMsg> GetBlogByKey(string key)
        {
            var blogItem = _repository.GetBlogByKey(key);
            if (blogItem != null)
            {
                return SysMsg.Success(_mapper.Map<IEnumerable<BlogReadDto>>(blogItem));
            }
            return SysMsg.Fail("未找到产品！");
        }

        /// <summary>
        /// 根据标签查找博客列表
        /// </summary>
        [HttpGet("GetBlogByLabel")]
        public ActionResult<SysMsg> GetBlogByLabel(string label)
        {
            var blogItem = _repository.GetBlogByLabel(label);
            if (blogItem != null)
            {
                return SysMsg.Success(_mapper.Map<IEnumerable<BlogReadDto>>(blogItem));
            }
            return SysMsg.Fail("未找到产品！");
        }

        //GET api/blogs/{id}
        [HttpGet("GetCommentByBlogId")]
        public ActionResult<SysMsg> GetCommentByBlogId(Guid id)
        {
            var comments = _repository.GetCommentByBlogId(id);
            if (comments != null)
            {
                return SysMsg.Success(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
            }
            return SysMsg.Fail("未找到该产品！");
        }

        //POST api/blogs
        [HttpPost("CreateBlog")]
        public ActionResult<SysMsg> CreateBlog(BlogCreateDto blogCreateDto)
        {
            var blogModel = _mapper.Map<Blog>(blogCreateDto);
            _repository.CreateBlog(blogModel, User.GetCurrentUserId());
            _repository.SaveChanges();

            return SysMsg.Success("新增成功！", _mapper.Map<BlogReadDto>(blogModel));
        }

        ////POST api/blogs
        //[HttpPost("CreateBlog")]
        //public ActionResult<SysMsg> CreateBlog(BlogCreateDto blogCreateDto)
        //{
        //    var blogModel = _mapper.Map<Blog>(blogCreateDto);
        //    _repository.CreateBlog(blogModel, User.GetCurrentUserId());
        //    _repository.SaveChanges();

        //    return SysMsg.Success("新增成功！", _mapper.Map<BlogReadDto>(blogModel));
        //}

        //POST api/CreateComment
        [HttpPost("CreateComment")]
        public ActionResult<SysMsg> CreateComment(CommentCreateDto commentCreateDto)
        {
            var blogModel = _mapper.Map<Comment>(commentCreateDto);
            _repository.CreateComment(blogModel, User.GetCurrentUserId());
            _repository.SaveChanges();

            return SysMsg.Success("新增成功！", _mapper.Map<CommentReadDto>(blogModel));
        }

        //PUT api/blogs/{id}
        [HttpPut("{id}")]
        public ActionResult<SysMsg> UpdateBlog(Guid id, BlogUpdateDto blogUpdateDto)
        {
            var blogModelFromRepo = _repository.GetBlogById(id);
            if (blogModelFromRepo == null)
            {
                return SysMsg.Fail("未找到该产品！");
            }
            _mapper.Map(blogUpdateDto, blogModelFromRepo);

            _repository.UpdateBlog(blogModelFromRepo);

            _repository.SaveChanges();

            return SysMsg.Success("更新成功！");
        }

        //PATCH api/blogs/{id}
        [HttpPatch("{id}")]
        public ActionResult<SysMsg> PartialBlogUpdate(Guid id, JsonPatchDocument<BlogUpdateDto> patchDoc)
        {
            var blogModelFromRepo = _repository.GetBlogById(id);
            if (blogModelFromRepo == null)
            {
                return SysMsg.Fail("未找到该产品！");
            }

            var blogToPatch = _mapper.Map<BlogUpdateDto>(blogModelFromRepo);
            patchDoc.ApplyTo(blogToPatch);

            if (!TryValidateModel(blogToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(blogToPatch, blogModelFromRepo);

            _repository.UpdateBlog(blogModelFromRepo);

            _repository.SaveChanges();

            return SysMsg.Success("更新成功！");
        }

        //DELETE api/blogs/{id}
        [HttpDelete("{id}")]
        public ActionResult<SysMsg> DeleteBlog(Guid id)
        {
            var blogModelFromRepo = _repository.GetBlogById(id);
            if (blogModelFromRepo == null)
            {
                return SysMsg.Fail("未找到该产品！");
            }
            _repository.DeleteBlog(blogModelFromRepo);
            _repository.SaveChanges();

            return SysMsg.Success("删除成功！");
        }
    }
}
