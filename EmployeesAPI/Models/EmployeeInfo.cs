using System;
using System.Collections.Generic;

namespace EmployeesAPI.Models
{
    public partial class EmployeeInfo
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Nid { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
    }
}
