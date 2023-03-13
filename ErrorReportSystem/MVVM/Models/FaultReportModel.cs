using ErrorReportSystem.MVVM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReportSystem.MVVM.Models
{
    internal class FaultReportModel
    {
        public int Id { get; set; }
        public string FaultDescription { get; set; } = null!;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int ResidentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public int StatusId { get; set; }

    }
}
