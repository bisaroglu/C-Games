using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarGame
{
    public partial class Form1 : Form
    {
        Random rnd = new Random(); 
        int gameSpeed = 6; // Oyun hızı
        int speedCar = 2; // Araç hızı

        public Form1()
        {
            InitializeComponent(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gameSpeed); // Yol çizgilerini hareket ettir
            gameOver(); // Çarpışma kontrolü yap
            coins(); // Madeni para kontrolü yap
        }

        // Çarpışma kontrolü yapan fonksiyon
        void gameOver()
        {
            if (car.Bounds.IntersectsWith(enemy1.Bounds)) // Araç düşman 1 ile çarpışırsa
            {
                timer1.Stop(); // Zamanlayıcıyı durdur
                MessageBox.Show("Game Over!"); // Kullanıcıya "Game Over" mesajı göster
                Application.Exit(); // Uygulamayı kapat
            }
            if (car.Bounds.IntersectsWith(enemy2.Bounds)) // Araç düşman 2 ile çarpışırsa
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
                Application.Exit();
            }
            if (car.Bounds.IntersectsWith(enemy3.Bounds)) // Araç düşman 3 ile çarpışırsa
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
                Application.Exit();
            }
        }

        int collected_coins = 0; // Toplanan madeni para sayısı

        // Madeni paraların hareketini ve toplama kontrolünü yapan fonksiyon
        void coins()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds)) // Araç madeni para 1 ile çarpışırsa
            {
                collected_coins++; // Madeni para sayısını artır
                coin1.Top = -10; // Madeni parayı yukarı taşı
                coin1.Left = rnd.Next(15, 340); // Madeni parayı rastgele bir yere yerleştir
                label1.Text = "Coins: " + collected_coins; // Güncellenmiş madeni para sayısını göster
            }
            else
            {
                coin1.Top += speedCar; // Madeni para aşağı doğru hareket eder
            }
            if (coin1.Top > 500) // Eğer madeni para ekranın altına giderse
            {
                coin1.Top = -10; // Madeni parayı yukarı taşı
                coin1.Left = rnd.Next(15, 340); // Madeni parayı rastgele bir yere yerleştir
            }
            // Aynı işlemler diğer madeni paralar için tekrar et
            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collected_coins++;
                coin2.Top = -10;
                coin2.Left = rnd.Next(15, 340);
                label1.Text = "Coins: " + collected_coins;
            }
            else
            {
                coin2.Top += speedCar;
            }
            if (coin2.Top > 500)
            {
                coin2.Top = -10;
                coin2.Left = rnd.Next(15, 340);
            }
            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collected_coins++;
                coin3.Top = -10;
                coin3.Left = rnd.Next(15, 340);
                label1.Text = "Coins: " + collected_coins;
            }
            else
            {
                coin3.Top += speedCar;
            }
            if (coin3.Top > 500)
            {
                coin3.Top = -10;
                coin3.Left = rnd.Next(15, 340);
            }
            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collected_coins++;
                coin4.Top = -10;
                coin4.Left = rnd.Next(15, 340);
                label1.Text = "Coins: " + collected_coins;
            }
            else
            {
                coin4.Top += speedCar;
            }
            if (coin4.Top > 500)
            {
                coin4.Top = -10;
                coin4.Left = rnd.Next(15, 340);
            }
        }

        // Yol çizgilerini ve düşmanları hareket ettiren fonksiyon
        void moveline(int speed)
        {
            if (enemy1.Top >= 500) // Düşman 1 ekranın altına ulaşırsa
            {
                enemy1.Top = -25; // Yukarı taşı
                enemy1.Left = rnd.Next(15, 340); // Rastgele bir yere yerleştir
            }
            else
            {
                enemy1.Top += speedCar; // Aşağı doğru hareket ettir
            }
            if (enemy2.Top >= 500)
            {
                enemy2.Top = -25;
                enemy2.Left = rnd.Next(15, 340);
            }
            else
            {
                enemy2.Top += speedCar;
            }
            if (enemy3.Top >= 500)
            {
                enemy3.Top = -25;
                enemy3.Left = rnd.Next(15, 340);
            }
            else
            {
                enemy3.Top += speedCar;
            }

            // Yol çizgilerinin hareketi
            if (pictureBox1.Top >= 500)
            {
                pictureBox1.Top = -125;
            }
            else
            {
                pictureBox1.Top += speed;
            }
            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = -125;
            }
            else
            {
                pictureBox2.Top += speed;
            }
            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = -125;
            }
            else
            {
                pictureBox3.Top += speed;
            }
            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = -125;
            }
            else
            {
                pictureBox4.Top += speed;
            }
            if (pictureBox7.Top >= 500)
            {
                pictureBox7.Top = -125;
            }
            else
            {
                pictureBox7.Top += speed;
            }
        }

        // Klavye girdisini işleyen fonksiyon
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // Sol ok tuşuna basıldığında
            {
                if (car.Left > 13) // Araç sol sınırın dışına çıkmasın
                {
                    car.Left += -8; // Aracı sola hareket ettir
                }
            }
            if (e.KeyCode == Keys.Right) // Sağ ok tuşuna basıldığında
            {
                if (car.Left < 315) // Araç sağ sınırın dışına çıkmasın
                {
                    car.Left += 8; // Aracı sağa hareket ettir
                }
            }
            if (e.KeyCode == Keys.Up) // Yukarı ok tuşuna basıldığında
            {
                if (gameSpeed < 8) // Oyun hızı sınırını kontrol et
                {
                    if (gameSpeed >= 6)
                    {
                        speedCar = 3; // Araç hızını artır
                    }
                    if (gameSpeed <= 3)
                    {
                        speedCar = 1; // Araç hızını düşür
                    }
                    car.Top -= 3; // Aracı yukarı hareket ettir
                    gameSpeed++; // Oyun hızını artır
                }
            }
            if (e.KeyCode == Keys.Down) // Aşağı ok tuşuna basıldığında
            {
                if (gameSpeed > 0) // Oyun hızı sınırını kontrol et
                {
                    if (gameSpeed <= 3)
                    {
                        speedCar = 1; // Araç hızını düşür
                    }
                    car.Top += 3; // Aracı aşağı hareket ettir
                    gameSpeed--; // Oyun hızını azalt
                }
                if (gameSpeed == 0) // Oyun hızı sıfırsa
                {
                    speedCar = 0; // Araç hareket etmesin
                }
            }
        }
    }
}
