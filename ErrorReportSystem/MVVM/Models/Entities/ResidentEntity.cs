using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorReportSystem.MVVM.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class ResidentEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string PhoneNumber { get; set; } = null!;

    //Connects resident to unit. 
    public int UnitId { get; set; }
    public UnitEntity Unit { get; set; } = null!;

    //Connects a specific resident to one or several fault reports.  
    public ICollection<FaultReportEntity> FaultReports { get; set; } = new HashSet<FaultReportEntity>();

}
