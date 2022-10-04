using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace QuizSite.Contracts.Database;

[Table("tbl_quiz_results", Schema = "public")]
public class Result
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("username")]
    [MaxLength(255)]
    public string Username { get; set; }

    [Required]
    [Column("quiz_category")]
    [MaxLength(255)]
    public string QuizCategory { get; set; }

    [Required]
    [Column("date_of_quiz_run")]
    public DateTime DateOfQuizRun { get; set; }

    [Required]
    [Column("score")]
    public int Score { get; set; }
}