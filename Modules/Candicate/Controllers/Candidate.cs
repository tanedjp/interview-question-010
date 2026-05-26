using interview_question_010.Modules.Candicate.Models;
using interview_question_010.Modules.Candicate.Services;
using interview_question_010.Modules.Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace interview_question_010.Modules.Candicate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _candidateService;
    private readonly ContextDb _context;

    public CandidateController(ICandidateService candidateService,ContextDb context)
    {
        _candidateService = candidateService;
        _context = context;
    }

    [HttpPost("generate_test")]
    public async Task<ActionResult<v_test>> GenerateTest([FromBody] t_candidate candidate)
    {
        try
        {
            var result = await _candidateService.SendTest(candidate);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}