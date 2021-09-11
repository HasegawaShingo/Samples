using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleReadWriteFile.BusinessLogic.Entities
{
    public class UpdateConditionEntity
    {
        public int ManageID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double AverageScore { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
