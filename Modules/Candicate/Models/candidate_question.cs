using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using interview_question_010.Modules.Common.Models;

namespace interview_question_010.Modules.Candicate.Models;

public class candidate_question : base_table
{
    [Key]
    public Guid? candidate_question_uid { get; set; }
    public Guid? candidate_uid { get; set; }
    public Guid? question_uid { get; set; }
    public string? question_name { get; set; }
    public bool? is_correct { get; set; }
}

public class t_candidate_question : candidate_question
{
    [JsonIgnore]
    public t_candidate? candidate { get; set; }
    public List<t_candidate_choice>? candidate_choices { get; set; }
}

public class v_candidate_question : candidate_question
{
    [JsonIgnore]
    public v_candidate? candidate { get; set; }
    public List<v_candidate_choice>? candidate_choices { get; set; }
    
}