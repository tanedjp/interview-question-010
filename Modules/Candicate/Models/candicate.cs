using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using interview_question_010.Modules.Common.Models;

namespace interview_question_010.Modules.Candicate.Models;

public class candidate : base_table
{
    [Key]
    public Guid? candidate_uid { get; set; }
    public string? candidate_fullname { get; set; }
    public Guid? test_uid { get; set; }
    public string? test_name { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? score { get; set; }
}

public class t_candidate : candidate
{
    public List<t_candidate_question>? candidate_questions { get; set; }
}

public class v_candidate : candidate
{
    public List<v_candidate_question>? candidate_questions { get; set; }
    
}