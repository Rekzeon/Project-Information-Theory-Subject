using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _0101007621_LTTT_DT03
{
    public class DSNguonTin
    {
        /// <summary>
        /// Phần code Shannon
        /// Kế thừa một số hàm để tiếp tục xây dựng bài toán liên quan
        /// </summary>
        List<TIN> a = new List<TIN>();
        double dEntropy, dDoDaiTB, dHSLapMa;

        public List<TIN> A { get => a; set => a = value; }
        public double DEntropy { get => dEntropy; set => dEntropy = value; }
        public double DDoDaiTB { get => dDoDaiTB; set => dDoDaiTB = value; }
        public double DHSLapMa { get => dHSLapMa; set => dHSLapMa = value; }
    
        public void nhap (string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("/TINS/TIN");
            foreach(XmlNode node in nodeList)
            {
                TIN temp = new TIN();
                temp.STenTin = node["Ten"].InnerText;
                temp.DXacSuatTin = double.Parse(node["XacXuat"].InnerText);
                a.Add(temp);
            }
        }
        public void tinhTiLeTungTIN()
        {
            for(int i=1; i<a.Count;i++)
                a[i].DTiLeXS = a[i-1].DTiLeXS + a[i-1].DXacSuatTin;         
        }
        public void tinhDoDaiTuMa()
        {
            double iTempDD = 0;
            foreach (TIN tin in a)
            {
                iTempDD = Math.Log(1 / tin.DXacSuatTin, 2);
                if ((iTempDD - (int)iTempDD) > 0)              //Xét số lẽ làm tròn lên
                    tin.IDoDaiTuMa = (int)iTempDD + 1;
                else
                    tin.IDoDaiTuMa = (int)iTempDD;
            }     
        }
        public void bdNhiPhan() //Biểu diễn nhị Phân
        {
            foreach(TIN tin in a)
            {
                double temp = tin.DTiLeXS;
                for (int i = 0; i < tin.IDoDaiTuMa; i++)
                    if ((int)(temp * 2) == 1) //1.5
                    {
                        tin.DDayNhiPhan += Math.Pow(10, -i - 1);
                        temp = temp * 2 - 1;
                    }
                    else
                        temp = temp * 2;
            }    
        }
        public void layTuMaWi()
        {
            foreach(TIN tin in a)
            {
                double dDayNhiNhi = tin.DDayNhiPhan;
                List<int> dayTemp = new List<int>();
                for (int i = 0; i < tin.IDoDaiTuMa; i++)
                {
                    dDayNhiNhi *= 10;
                    if ((int)dDayNhiNhi == 0)       //0.1099*10=1.099
                        dayTemp.Add(0);
                    else
                        dayTemp.Add(1);
                    if (dDayNhiNhi >= 1)
                        dDayNhiNhi--;
                    dDayNhiNhi = Math.Round(dDayNhiNhi, tin.IDoDaiTuMa - (i + 1));
                }
                tin.STuMaWi = string.Join("",dayTemp);
            }       
        }
        public double tinhEntropy()
        {
            double dEntropy = 0;
            foreach(TIN tin in a)
                dEntropy += (tin.DXacSuatTin * Math.Log(1/tin.DXacSuatTin, 2));
            return Math.Round(dEntropy,2);
        }
        public double tinhDDTBTuMa()
        {
            double dDDTBTuMa = 0;
            foreach (TIN tin in a)
                dDDTBTuMa += (tin.DXacSuatTin * tin.IDoDaiTuMa);
            return Math.Round(dDDTBTuMa, 2);
        }
        public double tinhHieuSuatLapMa()
        {
            return Math.Round((tinhEntropy() / tinhDDTBTuMa()*100),0);
        }
        public void sapXepTTTin()
        {
            a.Sort();
            a.Reverse();
        }

    }
}
