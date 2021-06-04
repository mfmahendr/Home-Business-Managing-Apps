using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing_App.Entitas
{
    public interface IData
    {
        object GetDataBerdasarkan();

        bool Tambah(object objek);
    }
}
