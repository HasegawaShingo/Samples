using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SampleReadWriteFile.BusinessLogic.FileAccess
{
    public class WriteFile
    {
        public static bool Write(string filePath, List<string> updateConditionEntities)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (updateConditionEntities == null || updateConditionEntities.Count == 0)
                throw new ArgumentNullException(nameof(updateConditionEntities));

            try
            {
                File.WriteAllLines(filePath, updateConditionEntities);
            }
            catch
            {
                throw;
            }
            return true;
        }
    }
}
