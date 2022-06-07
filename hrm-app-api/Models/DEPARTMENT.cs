using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hrm_app_api.Models
{
    [Table("DEPARTMENT")]
    public class DEPARTMENT
    {
        [Key]
        public int DEPT_ID { get; set; }
        public string DEPT_NAME { get; set; }

        public ICollection<EMPLOYEE> EMPLOYEE { get; set; }
    }
}