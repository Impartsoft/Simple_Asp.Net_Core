using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Model.DBContext;
using Simple_Asp.Net_Core.Model.Models;

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

        blog.Id = Guid.NewGuid();
        blog.UserId = userId;
        blog.SetCreateInfo();
        _context.Blogs.Add(blog);

        AddBlogLabels(blog);
    }

    private void AddBlogLabels(Blog blog)
    {
        if (blog.BlogLabels != null)
        {
            foreach (var label in blog.BlogLabels)
            {
                label.Id = blog.Id;
                _context.BlogLabels.Add(label);
            }
        }
    }

    public void UpdateBlog(Blog blog)
    {
        if (blog == null)
        {
            throw new ArgumentNullException(nameof(blog));
        }

        blog.SetModifyInfo();

        _context.Blogs.Update(blog);

        //var dbBlog = GetBlogById(blog.Id);
        //if (dbBlog.BlogLabels != null)
        //    _context.BlogLabels.RemoveRange(dbBlog.BlogLabels);

        //AddBlogLabels(blog);
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

    public IEnumerable<Blog> GetBlogByKey(string key)
    {
        return _context.Blogs.Where(v => v.Title.Contains(key));
    }

    public IEnumerable<Blog> GetBlogByLabel(string label)
    {
        return _context.Blogs.Where(v => v.BlogLabels != null && v.BlogLabels.Any(b => b.Label.Equals(label)));
    }

    public IEnumerable<string> GetUserBlogLabels(Guid userId)
    {
       var blogs = _context.Blogs.Where(v => v.UserId == userId).Include(v => v.BlogLabels);
        foreach (var blog in blogs)
        {
            foreach (var blogLabel in blog.BlogLabels)
            {
                yield return blogLabel.Label;
            }
        }
    }

    public Blog GetBlogById(Guid id)
    {
        return _context.Blogs.Include(v => v.User).Include(v => v.BlogLabels).Include(v => v.Comments).ThenInclude(v => v.User).FirstOrDefault(p => p.Id == id);
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
