using System.ComponentModel.DataAnnotations;
using interview_question_010.Modules.Common.Models;

namespace interview_question_010.Modules.Test.Models;

public class test :base_table
{
    [Key]
    public Guid? test_uid { get; set; }
    public string? test_name { get; set; }
}

public class t_test : test
{
    public List<t_question>? questions { get; set; }
}
public class v_test : test
{
    public List<v_question>? questions { get; set; }
}