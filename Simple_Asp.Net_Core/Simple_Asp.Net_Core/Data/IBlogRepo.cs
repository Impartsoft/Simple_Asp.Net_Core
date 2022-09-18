using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Data
{
    public interface IBlogRepo
    {
        bool SaveChanges();

        IEnumerable<Blog> GetAllBlog();
        Blog GetBlogById(Guid id);
        void CreateBlog(Blog goods, Guid guid);
        void UpdateBlog(Blog goods);
        void DeleteBlog(Blog goods);
        void CreateComment(Comment blogModel, Guid userId);
    }
}
