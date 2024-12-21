using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Oyunn
{
    // Mayin sınıfını tanımlar
    public class Mayin
    {
        Point loc; // Mayının konumunu temsil eder
        bool dolu; // Mayın var mı bilgisini tutar
        bool bakildi; // Mayına bakıldı mı bilgisini tutar

        // Mayin sınıfının yapıcı metodu, başlangıç konumunu alır
        public Mayin(Point loca)
        {
            dolu = false; // Başlangıçta mayın yok
            loc = loca; // Konumu ata
        }

        // Mayının konumunu döndüren özellik
        public Point konum_al
        {
            get { return loc; }
        }

        // Mayın var mı bilgisini ayarlayan ve döndüren özellik
        public bool mayin_var_mi
        {
            set
            {
                dolu = value; // Mayın var mı değerini ata
            }
            get
            {
                return dolu; // Mayın var mı bilgisini döndür
            }
        }

        // Mayına bakıldı mı bilgisini ayarlayan ve döndüren özellik
        public bool bakildi_
        {
            get
            {
                return bakildi; // Bakıldı mı bilgisini döndür
            }
            set
            {
                bakildi = value; // Bakıldı mı değerini ata
            }
        }
    }
}