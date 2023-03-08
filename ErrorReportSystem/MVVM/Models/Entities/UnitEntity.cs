using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorReportSystem.MVVM.Models.Entities;


internal class UnitEntity
{
    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    public string Street { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;

    public string ApartmentNo { get; set; }

    [Column(TypeName = "char(6)")]
    public string PostalCode { get; set; } = null!;
    [StringLength(50)]
    public string City { get; set; } = null!;

    // Connects unit to one or more residents. 
    public ICollection<ResidentEntity> Residents { get; set; } = new HashSet<ResidentEntity>();
}
