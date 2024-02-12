using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Models;

public class Job
{

    [Key]
    public int Id { get; set; }
    [Required]
    public string Position { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Company { get; set; }
    [Required]
    public string Location { get; set; }
    public double? Salary { get; set; }
    [Required]
    public string CompanyUrl { get; set; }
    [Required]
    public string JobUrl { get; set; }
    [Required]
    public string ContactName { get; set; }




    public string? WorkType { get; set; }
    public string? Notes { get; set; }
    public DateTime? DateApplied { get; set; }
    public DateTime? DateInterviewed { get; set; }
    public DateTime? DateOffered { get; set; }
    public DateTime? DateRejected { get; set; }
    public DateTime? DateAccepted { get; set; }
    [Required]
    public string? Status { get; set; }
    [Required]
    public string? Source { get; set; }






}




