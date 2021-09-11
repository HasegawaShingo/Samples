using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SampleCustomException
{
    public class SampleClass
    {
        public void CreateHogeHogeException()
        {
            try
            {
                throw new FileNotFoundException("hogehoge message");
            }
            catch(Exception ex)
            {
                var message = $"{ex.GetType().Name} : {ex.Message}";
                throw new HogeHogeException(message, ex);
            }
        }
    }
}
