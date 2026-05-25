namespace interview_question_010.Modules.Common.Models;

public class base_table
{
    public bool? is_deleted { get; set; }
    public string? created_by { get; set; }
    public string? updated_by { get; set; }
    public DateTime? created_date { get; set; }
    public DateTime? updated_date { get; set; }
}