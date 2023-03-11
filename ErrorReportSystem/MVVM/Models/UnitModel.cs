namespace ErrorReportSystem.MVVM.Models;

public class UnitModel
{
    public int Id { get; set; }
    public string Street { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string ApartmentNo { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
