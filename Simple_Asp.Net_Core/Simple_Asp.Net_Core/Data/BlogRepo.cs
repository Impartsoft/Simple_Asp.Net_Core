using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Controllers;
using Simple_Asp.Net_Core.Model.DBContext;
using Simple_Asp.Net_Core.Model.Models;
using Simple_Asp.Net_Core.Models;
using Simple_Asp.Net_Core.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Asp.Net_Core.Data;

public class BlogRepo : IBlogRepo
{
    private readonly CommanderContext _context;

    public BlogRepo(CommanderContext context)
    {
        _context = context;
    }

    public void CreateBlog(Blog blog, Guid userId)
    {
        if (blog == null)
        {
            throw new ArgumentNullException(nameof(blog));
        }

        blog.UserId = userId;
        blog.SetCreateInfo();

        _context.Blogs.Add(blog);
    }

    public void UpdateBlog(Blog blog)
    {
        if (blog == null)
        {
            throw new ArgumentNullException(nameof(blog));
        }

        blog.SetModifyInfo();

        _context.Blogs.Update(blog);
    }

    public void CreateComment(Comment comment, Guid userId)
    {
        if (comment == null)
        {
            throw new ArgumentNullException(nameof(comment));
        }
        comment.UserId = userId;
        comment.CreateTime = DateTime.Now;

        _context.Comments.Add(comment);
    }

    public void DeleteBlog(Blog blog)
    {
        if (blog == null)
        {
            throw new ArgumentNullException(nameof(blog));
        }
        _context.Blogs.Remove(blog);
    }

    public IEnumerable<Blog> GetAllBlog()
    {
        return _context.Blogs.Include(v => v.Comments).ToList();
    }

    public IEnumerable<Blog> GetBlogsByUserId(Guid userId)
    {
        return _context.Blogs.Where(v => v.UserId == userId).Include(v => v.Comments).ToList();
    }

    public Blog GetBlogById(Guid id)
    {
        return _context.Blogs.Include(v => v.User).Include(v => v.Comments).ThenInclude(v=>v.User).FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Comment> GetCommentByBlogId(Guid id)
    {
        return _context.Comments.Include(v => v.User).Where(p => p.BlogId == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

}
