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
    // Form2 sınıfını tanımlar
    public partial class Form2 : Form
    {
        Form1 f1; // Ana formu temsil eden bir nesne

        // Form2'nin yapıcı fonksiyonu
        public Form2()
        {
            InitializeComponent(); // Form bileşenlerini başlat
        }

        // Form2 yüklendiğinde çalışan olay
        public void Form2_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler buraya eklenebilir
        }

        // Button1 tıklandığında çalışan olay
        public void button1_Click(object sender, EventArgs e)
        {
            // TextBox1'den alınan değeri tam sayıya çevirir
            int a = Convert.ToInt32(textBox1.Text);

            // Eğer TextBox1 boş değilse ve geçerli bir sayı girilmişse
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out int mayinSayisi) && a < 400)
            {
                f1 = new Form1(); // Yeni bir Form1 nesnesi oluştur
                f1.label1.Text = textBox1.Text; // Form1'deki Label1'e TextBox1 değerini ata
                f1.Owner = this; // Form1'in sahibi olarak bu formu ayarla
                this.Hide(); // Bu formu gizle
                f1.Show(); // Form1'i göster
            }
            else
            {
                // Geçersiz bir sayı girildiyse hata mesajı göster
                MessageBox.Show("Geçerli bir sayı girilmedi.");
                Application.Exit(); // Uygulamayı kapat
            }
        }
    }
}
