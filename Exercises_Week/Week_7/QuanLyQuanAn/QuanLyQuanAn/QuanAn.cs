using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn
{
    public class QuanAn
    {
        string ten;
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        Diadiem add;
        public Diadiem DiaDiem
        {
            get { return add; }
            set { add = value; }
        }

        int soBan;

        public int SoBan
        {
            get { return soBan; }
            set { soBan = value; }
        }
        public QuanAn()
        {
            ten = null;
            DiaDiem = new Diadiem();
            SoBan = 0;
        }
    }
    public class Diadiem
    {
        string duong;
        public string Duong
        {
            get { return duong; }
            set { duong = value; }
        }

        string quan;
        public string Quan
        {
            get { return quan; }
            set { quan = value; }
        }

        public Diadiem()
        {
            duong = quan = "";
        }
    }
}
