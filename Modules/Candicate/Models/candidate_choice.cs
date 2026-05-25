using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using interview_question_010.Modules.Common.Models;

namespace interview_question_010.Modules.Candicate.Models;

public class candidate_choice : base_table
{
    [Key]
    public Guid? candidate_choice_uid { get; set; }
    public Guid? candidate_question_uid { get; set; }
    public Guid? choice_uid { get; set; }
    public string? choice_name { get; set; }
    public bool? is_selected { get; set; }
    public bool? is_correct { get; set; }
}
public class t_candidate_choice : candidate_choice
{
    [JsonIgnore]
    public t_candidate_question? candidate_question { get; set; }
}

public class v_candidate_choice : candidate_choice
{
    [JsonIgnore]
    public v_candidate_question? candidate_question { get; set; }
    
}