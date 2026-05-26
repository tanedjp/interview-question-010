using interview_question_010.Modules.Candicate.Models;
using interview_question_010.Modules.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace interview_question_010.Modules.Test.Services;

public interface ITestService
{
    Task<t_candidate?> GenerateTest();
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
    

    public async Task<t_candidate?> GenerateTest()
    {
        var test = await  _context.v_test
            .OrderBy(x => EF.Functions.Random())
            .Include(c=>c.questions)!
            .ThenInclude(c=>c.choices)
            .FirstOrDefaultAsync();
        var test_candidate = new t_candidate()
        {
            test_name =  test!.test_name??"-",
            test_uid =  test.test_uid,
            candidate_questions = test.questions!.Select(c =>
            {
                var question = new t_candidate_question()
                {
                    question_name =  c.question_name,
                    question_uid =  c.question_uid,
                    candidate_choices = c.choices!.Select(d =>
                    {
                        var choice = new t_candidate_choice()
                        {
                            choice_name =  d.choice_name,
                            choice_uid =  d.choice_uid,
                        };
                        return choice;
                    }).ToList()
                };
                return question;
            }).ToList()
        };
        return test_candidate;
    }
}