using System;
using Sah.Klase_Za_Sah;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah
{
    public partial class WinnerForm : Form
    {
        string PobednikJe;

        public WinnerForm()
        {
            InitializeComponent();
        }

        
        public WinnerForm(bool KoJeNaPotez,bool sahmat)
        {
            InitializeComponent();

            if (sahmat)
            {


                NaslovZavrsetka_lb.Text = "Pobeda Matom";

                if (!KoJeNaPotez)
                    PobednikJe = "WHITE";
                else
                    PobednikJe = "BLACK";

                Pobednik_lb.Text = $"Congrats to the { this.PobednikJe}  for WINING !!! ";
            }
            else
            {

                NaslovZavrsetka_lb.Text = "~~~ REMI!~~~";

                Pobednik_lb.Text = "It's a TIE, better luck next time ";

                Ghost_lb.Text = "                  ¯\\_(ツ)_/¯ ";

               

            }


        }

        public WinnerForm(int dminut,int dsekunda,int lminut,int lsekunda)
        {
            InitializeComponent();



                if (dminut == 0 && dsekunda == 0)
                {
                    PobednikJe = "WHITE";

                }
                else if (lminut == 0 && lsekunda == 0)
                {
                    PobednikJe = "BLACK";
                }

               
                NaslovZavrsetka_lb.Text = "TIMES UP !!";

            Pobednik_lb.Text = $"Congrats to the { this.PobednikJe}  for WINING !!! ";

        }

        private void Play_Again_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void Izadji_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

    }
}
