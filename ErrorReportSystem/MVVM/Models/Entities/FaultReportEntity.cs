using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorReportSystem.MVVM.Models.Entities;

internal class FaultReportEntity
{
    [Key]
    public int Id { get; set; }
    public string FaultDescription { get; set; } = null!;


    public DateTime TimeStamp { get; set; } = DateTime.Now;


    //Connects fault report to a specific resident.
    public int ResidentId { get; set; }
    public ResidentEntity Resident { get; set; } = null!;


    //Connects fault report to a status. 
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;


    //Connects fault report to one or several comments. 
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();

}
