using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oyunn
{
    public partial class Form1 : Form
    {// Form2 nesnesi oluştur
        Form2 f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            
        }
        // Mayın tarlası nesnesi
        Mayin_tarlasi mayin_tarlamiz;
        // Mayın listesi
        List<Mayin> mayinlarimiz;
        
        public void Form1_Load(object sender, EventArgs e)
        {
            // Label'deki yazıyı integer'a çevir
            int mayinsayisi = Convert.ToInt32(label1.Text);
            // Yeni bir mayın tarlası oluştur
            mayin_tarlamiz = new Mayin_tarlasi(new Size(400,400),mayinsayisi);
            // Panel boyutunu ayarla
            panel1.Size = mayin_tarlamiz.buyuklugu;
            // Mayınları ekle
            Mayin_ekle();
            //Mayinlari_goster(); Kontrol için
        }
        
        public void Mayin_ekle ()
        {
            // Paneli düğmeler ekle
            for (int x = 0; x < panel1.Width; x += 20)
            {
                for (int y = 0; y < panel1.Height; y += 20)
                {
                    // Her nokta için bir düğme oluştur
                    Button_ekle(new Point(x, y));
                }
            }
        }
        public void Button_ekle(Point loc)
        {
            // Yeni bir düğme oluştur
            Button btn = new Button();
            // Düğme konum bilgisi
            btn.Name = loc.X + "" + loc.Y;
            // Düğme boyutunu ayarla
            btn.Size = new Size(20, 20);
            // Düğmenin konumunu ayarla
            btn.Location = loc;
            // Tıklama olayını bağla
            btn.Click += new EventHandler(btn_Click);
            // Düğmeyi panele ekle
            panel1.Controls.Add(btn);
        }

        public void btn_Click(object sender, EventArgs e)
        {
            // Tıklanan düğmeyi al
            Button btn = (sender as Button);
            // Düğmenin konumundaki mayını al
            Mayin myn = mayin_tarlamiz.mayin_al_loc(btn.Location);
            // Mayın listesi oluştur
            mayinlarimiz = new List<Mayin>();
            if (myn.mayin_var_mi)
            {
                // Mayınları göster
                Mayinlari_goster();
                // Uyarı mesajı göster
                MessageBox.Show("Mayına Bastınız!!!");
                // Uygulamayı kapat
                Application.Exit();

            }
            else
            {
                // Çevredeki mayın sayısını al
                int s = etrafta_kac_mayin_var(myn);
                if (s==0)
                {
                    // Mayını listeye ekle
                    mayinlarimiz.Add(myn);
                    for (int i = 0; i < mayinlarimiz.Count; i++)
                    {
                        Mayin item = mayinlarimiz[i];
                        if (item != null)
                        {
                            // Düğmeyi bul
                            if (item.bakildi_ == false && item.mayin_var_mi == false)
                            {
                                Button btnx = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0];
                                if (etrafta_kac_mayin_var(mayinlarimiz[i]) == 0)
                                {
                                    // Düğmeyi devre dışı bırak
                                    btnx.Enabled = false;
                                    // Çevresindeki hücreleri kontrol et
                                    cevrseindekileri_ekle(item);
                                }
                                else
                                {
                                    // Çevredeki mayın sayısını düğmeye yaz
                                    btnx.Text = etrafta_kac_mayin_var(item).ToString();
                                }
                                // Mayın kontrol edildi olarak işaretle
                                item.bakildi_ = true;
                            }
                        }
                        
                    }
                }
                else
                {
                    // Çevredeki mayın sayısını düğmeye yaz
                    btn.Text = s.ToString();
                }
            }
        }
        public int etrafta_kac_mayin_var(Mayin m)
        {
            // Çevredeki 8 hücreyi kontrol et
            int sayi = 0;
            if (m.konum_al.X > 0 && m.konum_al.Y > 0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y>0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X < panel1.Width - 20 && m.konum_al.Y > 0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > 0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X < panel1.Width-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > 0 && m.konum_al.Y < panel1.Height-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y < panel1.Height-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X < panel1.Width-20 && m.konum_al.Y < panel1.Height-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            // Çevredeki toplam mayın sayısını döndür
            return sayi;
        }
        public void cevrseindekileri_ekle(Mayin m)
        {
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            // Çevresindeki hücreleri listeye ekle
            if (m.konum_al.X>0)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X-20,m.konum_al.Y)));
                b1 = true;
            }
            if (m.konum_al.Y > 0)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X , m.konum_al.Y - 20)));
                b2 = true;
            }
            if (m.konum_al.X < panel1.Width)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y )));
                b3 = true;
            }
            if (m.konum_al.Y < panel1.Height)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X , m.konum_al.Y + 20)));
                b4 = true;
            }
            if (b1 && b2)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y - 20)));
            }
            if (b1 && b4)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y + 20)));
            }
            if (b2 && b3)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y - 20)));
            }
            if (b1 && b4)
            {
                mayinlarimiz.Add(mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y + 20)));
            }
        }
        public void Mayinlari_goster()
        {
            // Tüm mayınları göster
            foreach (Mayin item in mayin_tarlamiz.GetAlMayin)
            {
                if (item.mayin_var_mi)
                {
                   Button btn= (Button)panel1.Controls.Find(item.konum_al.X+""+ item.konum_al.Y,false)[0];
                   // Mayınları siyah olarak işaretle
                   btn.BackColor = Color.Black;
                }
            }
        }
    }
}
