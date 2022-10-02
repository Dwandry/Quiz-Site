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
    [Column("quiz_question")]
    [MaxLength(500)]
    public string QuizQuestion { get; set; }

    [Required]
    [Column("is_right_answer")]
    [MaxLength(255)]
    public bool IsRightAnswer { get; set; }

    [Column("question_id")]
    public int QuestionId { get; set; }
    
    public Question Question { get; set; }
}