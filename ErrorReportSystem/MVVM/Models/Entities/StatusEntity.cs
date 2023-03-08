using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErrorReportSystem.MVVM.Models.Entities;

internal class StatusEntity
{
    [Key]
    public int Id { get; set; }

    public string StatusDescription { get; set; } = null!;


    //Connects status to fault reports. 
    public ICollection<FaultReportEntity> FaultReports { get; set; } = new HashSet<FaultReportEntity>();


}
