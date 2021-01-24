using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Resource : Base
    {
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Observation")]
        public string Observation { get; set; }
        
        [Display(Name = "ResponsibleInput")]
        public string ResponsibleInput { get; set; }

        [Display(Name = "ResponsibleOutput")]
        public string ResponsibleOutput { get; set; }

    }
}
