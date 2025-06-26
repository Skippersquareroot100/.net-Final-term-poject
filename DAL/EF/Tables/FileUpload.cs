using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class FileUpload
{
    [Key]
    public int FileId { get; set; }

    [Required, Column(TypeName = "VARCHAR"), StringLength(200)]
    public string FileName { get; set; }

    [Required, Column(TypeName = "VARCHAR"), StringLength(500)]
    public string FilePath { get; set; }

    public DateTime UploadedAt { get; set; }
}



