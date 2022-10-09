using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizSite.Contracts.Database;

[Table("tbl_quiz_question_choises", Schema = "public")]
public class Choise
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("answer_choise")]
    [MaxLength(500)]
    public string AnswerChoise { get; set; }

    [Required]
    [Column("is_right_answer")]
    public bool IsRightAnswer { get; set; }

    [Column("question_id")]
    public int QuestionId { get; set; }

    public Question Question { get; set; }
}