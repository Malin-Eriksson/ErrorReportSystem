using ErrorReportSystem.Contexts;
using ErrorReportSystem.MVVM.Models.Entities;
using ErrorReportSystem.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ErrorReportSystem.Services
{
    internal class FaultReportService
    {
        private static DataContext _context = new DataContext();
        public static ObservableCollection<FaultReportModel> faultReports;


        //function to save resident and their unit id. 
        public static async Task SaveFaultReportAsync(FaultReportModel faultReport)
        {
            var _faultReportEntity = new FaultReportEntity
            {
                FaultDescription = faultReport.FaultDescription,
                TimeStamp = faultReport.TimeStamp,
                ResidentId = faultReport.ResidentId,
                StatusId = faultReport.StatusId
            };


            //match the entered unitId to an existing unit
            var _residentEntity = await _context.Residents.FirstOrDefaultAsync(x => x.Id == faultReport.ResidentId);
            if (_residentEntity != null)
                _faultReportEntity.ResidentId = _residentEntity.Id;
            else
                _faultReportEntity.ResidentId = 0;



            _context.Add(_faultReportEntity);
            await _context.SaveChangesAsync();
        }

        //Get all residents and their unit id. 
        public static async Task<IEnumerable<FaultReportModel>> GetAllFaultReportsAsync()
        {
            var _faultReports = new List<FaultReportModel>();

            foreach (var _faultReport in await _context.FaultReports.Include(x => x.Resident).ToListAsync())
                _faultReports.Add(new FaultReportModel
                {
                    Id = _faultReport.Id,
                    FaultDescription = _faultReport.FaultDescription,
                    TimeStamp = _faultReport.TimeStamp,
                    ResidentId = _faultReport.ResidentId,
                    FirstName = _faultReport.Resident.FirstName,
                    LastName = _faultReport.Resident.LastName,
                    Email = _faultReport.Resident.Email,
                    PhoneNumber= _faultReport.Resident.PhoneNumber,
                    StatusId = _faultReport.StatusId

                });
            return _faultReports;
        }

        //Get one resident based on email.
        public static async Task<FaultReportModel> GetOneFaultReportAsync(int id)
        {
            var _faultReport = await _context.FaultReports.Include(x => x.Resident).FirstOrDefaultAsync(x => x.Id == id);
            if (_faultReport != null)
                return new FaultReportModel
                {
                    Id = _faultReport.Id,
                    FaultDescription = _faultReport.FaultDescription,
                    TimeStamp = _faultReport.TimeStamp,
                    ResidentId = _faultReport.ResidentId,
                    FirstName = _faultReport.Resident.FirstName,
                    LastName = _faultReport.Resident.LastName,
                    Email = _faultReport.Resident.Email,
                    PhoneNumber = _faultReport.Resident.PhoneNumber,
                    StatusId = _faultReport.StatusId
                };
            else
                return null!;
        }


        //Delete resident
        public static async Task DeleteFaultReportAsync(int id)
        {
            var _faultReport = await _context.FaultReports.FirstOrDefaultAsync(x => x.Id == id);
            if (_faultReport != null)
            {
                _context.Remove(_faultReport);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<FaultReportModel> FaultReports()
        {
            return faultReports;
        }
    }
}
