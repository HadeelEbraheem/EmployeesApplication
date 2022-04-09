using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Repository
{
  
        [ModelMetadataType(typeof(EmployeeInfoModelMetaData))]
      
        public class EmployeeInfoModelMetaData
        {
            public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        [MaxLength(50)]
        public string EmployeeName { get; set; } = null!;
        [MinLength(10,ErrorMessage ="should be 10 digits")]
        [MaxLength(10)]
        [Required(ErrorMessage = "National ID is required")]
        public string Nid { get; set; } = null!;
        [Required(ErrorMessage = "Department Name is required")]
        [MaxLength(50)]
        public string DepartmentName { get; set; } = null!;
        }
    }
