using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PRACTICE.Context;
using PRACTICE.Dto_s;
using PRACTICE.Dto_s.Comment;
using PRACTICE.Helpers;
using PRACTICE.Interfaces;
using PRACTICE.Mapper;
using PRACTICE.Models;

namespace PRACTICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IRepository _stockRepo;

        public CommentsController(ICommentRepository commentRepo, IRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            var CommentsDto = comments.Select(comment=>comment.ToCommentDTO()).ToList();
            return Ok(CommentsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null) {
                return NoContent();
            }
            return Ok(comment.ToCommentDTO());
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create([FromRoute]int id,CreateCommentDTO commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _stockRepo.StockExistsAsync(id))
            {
                return BadRequest("The stock you are trynna comment does not exist ");
            }
            var comment = commentDto.ToComment(id);
            await _commentRepo.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetById), new {id = comment.Id}, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCommentDTO commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Comment = await _commentRepo.UpdateAsync(id, commentDto);
            if (Comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var comment = await _commentRepo.DeleteCommentAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
          