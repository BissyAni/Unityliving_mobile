using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models
{
    public class ChargesSettled
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string ChargedAmount { get; set; }
        public string DueDate { get; set; }
    }

}
