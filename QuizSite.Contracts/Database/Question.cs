using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizSite.Contracts.Database;

[Table("tbl_quiz_questions", Schema = "public")]
public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("quiz_category")]
    [MaxLength(255)]
    public string QuizCategory { get; set; }

    [Required]
    [Column("quiz_question")]
    [MaxLength(500)]
    public string QuizQuestion { get; set; }
}