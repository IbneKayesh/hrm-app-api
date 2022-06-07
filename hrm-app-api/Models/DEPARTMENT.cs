using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrm_app_api.Models
{
    public class DEPARTMENT
    {
        [Key]
        public int DEPT_ID { get; set; }
        public string DEPT_NAME { get; set; }

        public ICollection<EMPLOYEE> EMPLOYEE { get; set; }
    }
}