using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.API.Services;
using ExpenseTracker.API.DTOs;

namespace ExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly TransactionService _service;

    public TransactionsController(TransactionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddTransaction(TransactionRequestDto dto)
    {
        await _service.AddTransactionAsync(dto);
        return Ok(new { message = "Transaction added successfully" });
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserTransactions(Guid userId)
    {
        var result = await _service.GetUserTransactions(userId);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetFiltered(
    [FromQuery] Guid userId,
    [FromQuery] DateTime? startDate,
    [FromQuery] DateTime? endDate)
    {
        var result = await _service.GetFilteredTransactions(userId, startDate, endDate);
        return Ok(result);
    }
}