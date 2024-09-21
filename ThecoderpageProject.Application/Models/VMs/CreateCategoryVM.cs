using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class CreateCategoryVM
    {
        [Required]
        public string Name { get; set; }


    }
}
