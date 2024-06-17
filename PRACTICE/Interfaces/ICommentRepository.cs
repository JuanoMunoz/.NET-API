using PRACTICE.Dto_s.Comment;
using PRACTICE.Models;

namespace PRACTICE.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync();
        public Task<Comment?> GetByIdAsync(int id);

        public Task CreateCommentAsync(Comment comment);

        public Task<Comment?> UpdateAsync(int id, UpdateCommentDTO comment);

        public Task<Comment?> DeleteCommentAsync(int id);
    }
}
