using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SampleReadWriteFile.BusinessLogic.FileAccess
{
    public static class ReadFile
    {
        public static async Task<List<string>> ReadAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
            {
                return null;
            }

            var result = await File.ReadAllLinesAsync(filePath);
            return result.ToList();
        }
    }
}
