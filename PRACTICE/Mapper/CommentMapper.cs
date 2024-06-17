using PRACTICE.Dto_s;
using PRACTICE.Dto_s.Comment;
using PRACTICE.Models;

namespace PRACTICE.Mapper
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                Title = comment.Title,
                CreatedDate = comment.CreatedDate,
            };

        }

        public static Comment ToComment(this CreateCommentDTO createCommentDTO, int id)
        {
            return new Comment
            {
                Title = createCommentDTO.Title,
                Content = createCommentDTO.Content,
                StockId = id
            };
        }
    }
}
