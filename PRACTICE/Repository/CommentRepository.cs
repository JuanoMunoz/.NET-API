using Microsoft.EntityFrameworkCore;
using PRACTICE.Context;
using PRACTICE.Dto_s.Comment;
using PRACTICE.Interfaces;
using PRACTICE.Models;

namespace PRACTICE.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context) {
            _context = context;
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment?> DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment; 
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDTO commentDTO)
        {
            var Comment = await _context.Comments.FindAsync(id);
            if (Comment == null)
            {
                return null;
            }
            Comment.Title = commentDTO.Title;
            Comment.Content = commentDTO.Content;
            await _context.SaveChangesAsync();
            return Comment;
            
        }
    }
}
