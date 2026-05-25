using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using interview_question_010.Modules.Common.Models;

namespace interview_question_010.Modules.Test.Models;

public class question : base_table
{
    [Key]
    public Guid? question_uid { get; set; }
    public Guid? test_uid { get; set; }
    public string? question_name { get; set; }
}

public class t_question : question
{
    [JsonIgnore]
    public t_test? test { get; set; }
    public List<t_choice>? choices { get; set; }
    
}
public class v_question : question
{
    [JsonIgnore]
    public v_test? test { get; set; }
    public List<v_choice>? choices { get; set; }
}