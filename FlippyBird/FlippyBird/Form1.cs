using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlippyBird
{
    public partial class Form1 : Form
    {
        
        int boruhızı = 6;
        int gravity = 4;
        int Score = 0;
        Random random = new Random(); // Rastgele sayı üretmek için Random nesnesi
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (isGameOver) return;
            FlappyBird.Top += gravity;
            BoruAlt.Left -= boruhızı;
            BoruUst.Left -= boruhızı;
            Zemin.Left -= 6;
            
            scoreText.Text = "Score: " + Score;

            // BoruAlt ekranın dışına çıktıysa, yeniden konumlandır
            if (BoruAlt.Left < -185)
            {
                ResetBoruAlt(); // Alt boruyu rastgele bir pozisyonda yeniden oluştur
                ResetBoruUst(); // Üst boruyu rastgele bir pozisyonda yeniden oluştur
                Score++;
            }
            

            // BoruUst ekranın dışına çıktıysa, yeniden konumlandır ve skoru artır
            
            // Flappy Bird herhangi bir boruya veya zemine çarptığında oyunu bitir
            if (FlappyBird.Bounds.IntersectsWith(BoruAlt.Bounds) || FlappyBird.Bounds.IntersectsWith(BoruUst.Bounds) || FlappyBird.Bounds.IntersectsWith(Zemin.Bounds)||FlappyBird.Bounds.IntersectsWith(ustsınır.Bounds))
            {
                endGame();
                
            }

            // Zemin sonsuz hareket etsin
            if (Zemin.Left < -600)
            {
                Zemin.Left = 0;
            }
        }

        // Oyun esnasında boşluk tuşuna basıldığında kuş yukarı zıplasın
        private void gamekeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (isGameOver)
                {
                    restartGame(); // Restart the game if it is over
                }
                else
                {
                    gravity = -18; // Normal jump action
                }
            }
        }

        // Boşluk tuşu bırakıldığında kuş aşağı düşsün
        private void gamekeyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        // Oyun bitirme fonksiyonu
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over";
            isGameOver = true;
            this.Focus();
        }
        private void restartGame()
        {
            isGameOver = false; // Reset game-over state
            gravity = 4;
            Score = 0;
            scoreText.Text = "Score: " + Score;

            ResetBoruAlt();
            ResetBoruUst();
            FlappyBird.Top = 200; // Reset Flappy Bird's position
            Zemin.Left = 0; // Reset ground position

            gameTimer.Start(); // Restart the game timer
        }

        // Alt boruyu yeniden oluşturma fonksiyonu
        public void ResetBoruAlt()
        {
            
            int randomHeight = random.Next(300, 600); // Random height
            BoruAlt.Left = 610; // Move the lower pipe to the right of the screen
            BoruAlt.Top = randomHeight;
        }

        public void ResetBoruUst()
        {
            int pipeGap = 650;
            int lowerHeight = BoruAlt.Top - pipeGap; // Subtract space from the height of PipeAlt
            BoruUst.Left = 610; // Move the upper pipe to the right of the screen
            BoruUst.Top=lowerHeight;
            
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
