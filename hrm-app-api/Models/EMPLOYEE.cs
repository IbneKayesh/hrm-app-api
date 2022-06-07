using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hrm_app_api.Models
{
    public class EMPLOYEE
    {
        [Key]
        public string EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
        public int DEPT_ID { get; set; }
        [ForeignKey("DEPT_ID")]
        public DEPARTMENT DEPARTMENT { get; set; }
    }
}