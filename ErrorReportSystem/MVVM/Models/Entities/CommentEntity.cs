using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorReportSystem.MVVM.Models.Entities;

internal class CommentEntity
{
    public int Id { get; set; }


    public byte[]? TimeStamp { get; set; }


    //Connects comment/s to a specific fault report.  
    public int FaultReportId { get; set; }
    public FaultReportEntity FaultReport { get; set; } = null!;


}
