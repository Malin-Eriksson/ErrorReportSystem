using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorReportSystem.MVVM.Models.Entities;

internal class CommentEntity
{
    public int Id { get; set; }


    public DateTime TimeStamp { get; set; } = DateTime.Now;


    //Connects comment/s to a specific fault report.  
    public int FaultReportId { get; set; }
    public FaultReportEntity FaultReport { get; set; } = null!;


}
