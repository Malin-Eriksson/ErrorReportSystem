using ErrorReportSystem.Contexts;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ErrorReportSystem.Services;

internal class UnitService
{
    private static DataContext _context = new DataContext();
    public static ObservableCollection<UnitModel> units;


    //save new unit
    public static async Task SaveUnitAsync(UnitModel unit)
    {
        var _unitEntity = new UnitEntity
        {
            Street = unit.Street,
            StreetNumber = unit.StreetNumber,
            ApartmentNo = unit.ApartmentNo,
            PostalCode = unit.PostalCode,
            City = unit.City

        };

        _context.Add(_unitEntity);
        await _context.SaveChangesAsync();
    }

    //get all units
    public static async Task<IEnumerable<UnitModel>> GetAllUnitsAsync()
    {
        var _units = new List<UnitModel>();

        foreach (var _unit in await _context.Units.ToListAsync())
            _units.Add(new UnitModel
            {
                Id = _unit.Id,
                Street = _unit.Street,
                StreetNumber = _unit.StreetNumber,
                ApartmentNo = _unit.ApartmentNo,
                PostalCode = _unit.PostalCode,
                City = _unit.City

            });
        return _units;
    }

    //delete unit
    /*    public static async Task DeleteUnitAsync(int id)
        {
            var _unit = await _context.Units.SingleOrDefaultAsync(x => x.Id == id);
            if (_unit != null )
            {
                _context.Remove(_unit);
                await _context.SaveChangesAsync();
            }
        }*/

    public static async Task DeleteUnitAsync(int id)
    {
        var _unit = await _context.Units.FirstOrDefaultAsync(x => x.Id == id);
        if (_unit != null)
        {
            _context.Remove(_unit);
            await _context.SaveChangesAsync();
        }
    }


    public static ObservableCollection<UnitModel> Units()
    {
        return units;
    } 

}
