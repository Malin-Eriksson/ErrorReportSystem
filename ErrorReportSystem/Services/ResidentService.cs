using ErrorReportSystem.Contexts;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ErrorReportSystem.Services;

internal class ResidentService
{
    private static DataContext _context = new DataContext();


    //function to save resident and their unit id. 
    public static async Task SaveResidentAsync(ResidentModel resident)
    {
        var _residentEntity = new ResidentEntity
        {
            FirstName = resident.FirstName,
            LastName = resident.LastName,
            Email = resident.Email,
            PhoneNumber = resident.PhoneNumber,
            UnitId = resident.UnitId
        };


        //match the entered unitId to an existing unit
        var _unitEntity = await _context.Units.FirstOrDefaultAsync(x => x.Id == resident.UnitId);
        if (_unitEntity != null)
            _residentEntity.UnitId = _unitEntity.Id;
        else
            _residentEntity.UnitId = 0;

            

        _context.Add(_residentEntity);
        await _context.SaveChangesAsync();
    }

    //Get all residents and their unit id. 
    public static async Task<IEnumerable<ResidentModel>> GetAllResidentsAsync()
    {
        var _residents = new List<ResidentModel>();

        foreach (var _resident in await _context.Residents.Include(x => x.Unit).ToListAsync())
            _residents.Add(new ResidentModel
            {
                Id= _resident.Id,
                FirstName = _resident.FirstName,
                LastName = _resident.LastName,
                Email = _resident.Email,
                PhoneNumber = _resident.PhoneNumber,
                UnitId= _resident.UnitId
            });
        return _residents;
    }

    //Get one resident based on email.
    public static async Task<ResidentModel> GetOneResidentAsync(string email)
    {
        var _resident = await _context.Residents.Include(x => x.Unit).FirstOrDefaultAsync(x => x.Email == email);
        if (_resident != null)
            return new ResidentModel
            {
                Id = _resident.Id,
                FirstName = _resident.FirstName,
                LastName = _resident.LastName,
                Email = _resident.Email,
                PhoneNumber = _resident.PhoneNumber,
                UnitId = _resident.UnitId
            };
        else
            return null!;
    }


    //Delete resident
    public static async Task DeleteResidentAsync(string email)
    {
        var _resident = await _context.Residents.Include(x => x.Unit).FirstOrDefaultAsync(x => x.Email == email);
        if (_resident != null)
        {
            _context.Remove(_resident);
            await _context.SaveChangesAsync();
        }
    }
}
