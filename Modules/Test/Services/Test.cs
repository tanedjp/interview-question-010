using interview_question_010.Modules.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace interview_question_010.Modules.Test.Services;

public interface ITestService
{
    Task<v_test?> GenerateTest();
    Task<t_test> CreateTest(t_test task);
}
public class TestService : ITestService
{
    private readonly ContextDb _context;

    public TestService(ContextDb context)
    {
        _context = context;
    }

    public async Task<t_test> CreateTest(t_test model)
    {
        await _context.t_test.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }
    

    public async Task<v_test?> GenerateTest()
    {
        return await  _context.v_test
            .OrderBy(x => EF.Functions.Random())
            .Include(c=>c.questions)!
            .ThenInclude(c=>c.choices)
            .FirstOrDefaultAsync();
    }
}