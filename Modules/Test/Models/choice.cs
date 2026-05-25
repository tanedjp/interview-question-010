using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using interview_question_010.Modules.Common.Models;

namespace interview_question_010.Modules.Test.Models;

public class choice :base_table
{
    [Key]
    public Guid? choice_uid { get; set; }
    public Guid? question_uid { get; set; }
    public string? choice_name { get; set; }
    public bool? is_corrent { get; set; }
}

public class t_choice : choice
{
    [JsonIgnore]
    public t_question? question { get; set; }
}
public class v_choice : choice
{
    [JsonIgnore]
    public v_question? question { get; set; }
    
}