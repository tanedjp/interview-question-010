using interview_question_010.Modules.Test.Models;
using interview_question_010.Modules.Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace interview_question_010.Modules.Test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;
    private readonly ContextDb _context;

    public TestController(ITestService testService,ContextDb context)
    {
        _testService = testService;
        _context = context;
    }

    [HttpGet("generate_test")]
    public async Task<ActionResult<v_test>> GenerateTest()
    {
        var result = await _testService.GenerateTest();
        return result == null ? BadRequest(new
        {
            error = "400",
            description = "Not found any test data."
        }) : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<t_test>> CreateTest([FromBody]t_test model)
    {
        var createdTask = await _testService.CreateTest(model);
        return Ok(createdTask); 
    }
}