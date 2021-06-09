using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMConsole.Interface
{
    public interface IData
    {
        object GetDataBerdasarkan();
        bool Tambah(object objek);
    }
}
