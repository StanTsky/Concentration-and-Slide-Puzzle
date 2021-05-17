using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Singleton
{
    class Card
    {
        const int KNIGHT = 0;
        const int SWORD = 1;
        const int TORCH = 2;
        const int DYNAMITE = 3;
        const int COINS = 4;
        const int LAMP = 5;
        const int SHIELD = 6;
        const int BLANK = 7;
        const int CARD_BACK = 8;

        public int Type { get; set; }
        private PictureBox pb;
        public PictureBox Pb {
            get
            {
                return pb;
            }

            set
            {
                pb = value;
                pb.BackColor = Color.Transparent;
            }
        }
        public bool Matched { get; set; }
        static SoundPlayer flipsound = new SoundPlayer(Properties.Resources.snd__flip);
        public Card()
        {
            //Pb.BackColor = Color.Transparent;
        }

        public void Show()
        {
            if (!Matched)
            {
                flipsound.Play();

                switch (Type)
                {
                    case COINS:
                        Pb.Image = Properties.Resources.img_coins;
                        break;
                    case TORCH:
                        Pb.Image = Properties.Resources.img_torch;
                        break;
                    case LAMP:
                        Pb.Image = Properties.Resources.img_lamp;
                        break;
                    case KNIGHT:
                        Pb.Image = Properties.Resources.img_knight;
                        break;
                    case SHIELD:
                        Pb.Image = Properties.Resources.img_shield;
                        break;
                    case SWORD:
                        Pb.Image = Properties.Resources.img_sword;
                        break;
                    case DYNAMITE:
                        Pb.Image = Properties.Resources.img_dynamite;
                        break;
                }
            }
        } //end show

        //flip back over
        public void Hide()
        {
            if (Matched)
            {
                Pb.Image = Properties.Resources.img_blank;
            }
            else
            {
                Pb.Image = Properties.Resources.img_card_back;
            }
        }
    }
}
