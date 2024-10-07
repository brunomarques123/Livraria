using Library.Application.Commands.AddBookCommand;
using Library.Application.Commands.RemoveBookCommand;
using Library.Application.Commands.UpdateBookCommand;
using Library.Application.Models;
using Library.Application.Queries.GetAllBooksQuery;
using Library.Application.Queries.GetBookByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id));
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] CreateBookInputModel request)
        {
            var result = await _mediator.Send(new AddBookCommand(request.Title, request.Author, request.PublicationYear));
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookInputModel request)
        {
            var result = await _mediator.Send(new UpdateBookCommand(id, request.Title, request.Author, (int)request.PublicationYear));
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await _mediator.Send(new RemoveBookCommand(id));
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Message);
        }
    }
}
