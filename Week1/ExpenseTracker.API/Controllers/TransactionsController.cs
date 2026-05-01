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
}