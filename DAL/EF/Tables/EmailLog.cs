using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EmailLog
{
    [Key]
    public int EmailLogId { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR")]
    [StringLength(100)]
    public string ToEmail { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(200)]
    public string Subject { get; set; }

    public string Body { get; set; }

    public DateTime SentAt { get; set; }
}
 