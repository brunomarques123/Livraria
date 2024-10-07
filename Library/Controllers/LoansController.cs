using Library.Application.Commands.AddLoanCommand;
using Library.Application.Commands.ReturnLoanCommand;
using Library.Application.Models;
using Library.Application.Queries.CheckLoanDelayQuery;
using Library.Application.Queries.GetLoansByUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanInputModel request)
        {
            var command = new AddLoanCommand(request.UserId, request.BookId, request.LoanDate, request.DueDate);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("return")]
        public async Task<IActionResult> RegisterReturn(int loanId, DateTime returnDate)
        {
            var command = new ReturnLoanCommand(loanId, returnDate);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("check-delay/{loanId}")]
        public async Task<IActionResult> CheckForDelay(int loanId)
        {
            var query = new CheckLoanDelayQuery(loanId);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetLoansByUser(int userId)
        {
            var query = new GetLoansByUserQuery { UserId = userId };
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }
    }
}
