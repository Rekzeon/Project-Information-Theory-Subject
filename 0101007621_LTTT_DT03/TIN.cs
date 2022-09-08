using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0101007621_LTTT_DT03
{
    public class TIN : IComparable<TIN>
    {
        int iDoDaiTuMa;
        double dXacSuatTin, dTiLeXS = 0, dDayNhiPhan = 0, dLuongTinRieng;
        string sTenTin, sTuMaWi;

        public int IDoDaiTuMa { get => iDoDaiTuMa; set => iDoDaiTuMa = value; }
        public double DXacSuatTin { get => dXacSuatTin; set => dXacSuatTin = value; }
        public string STenTin { get => sTenTin; set => sTenTin = value; }
        public double DDayNhiPhan { get => dDayNhiPhan; set => dDayNhiPhan = value; }
        public double DTiLeXS { get => dTiLeXS; set => dTiLeXS = value; }
        public string STuMaWi { get => sTuMaWi; set => sTuMaWi = value; }
        public double DLuongTinRieng { get => dLuongTinRieng; set => dLuongTinRieng = value; }

        public int CompareTo(TIN other)
        {
            return this.DXacSuatTin.CompareTo(other.DXacSuatTin);
        }
    }
}
