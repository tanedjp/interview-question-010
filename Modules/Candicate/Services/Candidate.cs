using interview_question_010.Modules.Candicate.Models;
using Microsoft.EntityFrameworkCore;

namespace interview_question_010.Modules.Candicate.Services;

public interface ICandidateService
{
    Task<t_candidate> SendTest(t_candidate candidate);
}

public class CandidateService :ICandidateService
{
    private readonly ContextDb _context;

    public CandidateService(ContextDb context)
    {
        _context = context;
    }
    public async Task<t_candidate> SendTest(t_candidate candidate)
    {
        var candidate_choices = candidate.candidate_questions!
            .SelectMany(c => c.candidate_choices!)
            .Where(c=>c.is_selected == true).ToList();
        var choices = await _context.v_choice.Where(c=>
            candidate_choices.Any(d=> c.choice_uid == d.choice_uid) 
            && c.is_corrent == true).ToListAsync();
        candidate.score = choices.Count;
        // var question_count = candidate.candidate_questions?.Count??0;
        // candidate.score = question_count == 0 || choices.Count == 0 ? 0m : Math.Round(((decimal)question_count / choices.Count) * 100m, 2);
        await _context.t_candidate.AddAsync(candidate);
        await _context.SaveChangesAsync();
        return candidate;
    }
}