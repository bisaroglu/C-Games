using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Oyunn
{
    // Mayın tarlası sınıfını tanımlar
    class Mayin_tarlasi
    {
        Size buyukluk_; // Mayın tarlasının boyutu
        List<Mayin> mayinlar; // Mayınların listesi
        int dolu_mayin_sayisi; // Toplam mayın sayısı
        Random rnd = new Random(); // Rastgele sayı üretici

        // Mayın_tarlasi sınıfının yapıcı fonksiyonu
        public Mayin_tarlasi(Size buyukluk, int mayin_sayisi)
        {
            mayinlar = new List<Mayin>(); // Mayın listesini başlat
            dolu_mayin_sayisi = mayin_sayisi; // Mayın sayısını ata
            buyukluk_ = buyukluk; // Boyut bilgisini ata

            // Belirtilen boyutlara göre mayınları ekle
            for (int x = 0; x < buyukluk.Width; x += 20)
            {
                for (int y = 0; y < buyukluk.Height; y += 20)
                {
                    Mayin m = new Mayin(new Point(x, y)); // Yeni bir mayın oluştur
                    Mayin_ekle(m); // Mayını listeye ekle
                }
            }

            Mayinlari_doldur(); // Mayınları rastgele yerleştir
        }

        // Yeni bir mayını listeye ekler
        public void Mayin_ekle(Mayin m)
        {
            mayinlar.Add(m);
        }

        // Mayınları rastgele yerleştirir
        private void Mayinlari_doldur()
        {
            int sayi = 0; // Yerleştirilen mayın sayısı
            while (sayi < dolu_mayin_sayisi)
            {
                int i = rnd.Next(0, mayinlar.Count); // Rastgele bir indeks seç
                Mayin item = mayinlar[i]; // İlgili mayını al
                if (!item.mayin_var_mi) // Eğer mayın yoksa
                {
                    item.mayin_var_mi = true; // Mayın yerleştir
                    sayi++; // Yerleştirilen mayın sayısını artır
                }
            }
        }

        // Mayın tarlasının boyutunu döndürür
        public Size buyuklugu
        {
            get
            {
                return buyukluk_;
            }
        }

        // Belirli bir konumdan mayın döndürür
        public Mayin mayin_al_loc(Point loc)
        {
            foreach (Mayin item in mayinlar) // Tüm mayınları dolaş
            {
                if (item.konum_al == loc) // Eğer konum eşleşirse
                {
                    return item; // Mayını döndür
                }
            }
            return null; // Hiçbiri eşleşmezse null döndür
        }

        // Tüm mayın listesini döndürür
        public List<Mayin> GetAlMayin
        {
            get
            {
                return mayinlar;
            }
        }
    }
}
