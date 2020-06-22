using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Sah.Klase_Za_Sah
{
    public class Polje:Button
    {
       
        #region Konstruktori

        public Polje()
        {

            this.Height = 70;
            this.Width = 70;
            this.Margin = new Padding(0, 0, 0, 0);
        }

        public Polje(int red,int kolona)
        {
            this.Height = 70;
            this.Width = 70;
            this.Margin = new Padding(0, 0, 0, 0);
            this.red = red;
            this.kolona = kolona;
        }

     

        #endregion

        #region Atributi
        private int red;
        private int kolona;
        private int figura=-1; //0-pesak,1-konj,2-top,3-lovac ,4-kraljica,5-kralj
        private bool daLiJeBeli;
        private bool obelezen;
        private bool napadnuta;

        #endregion

        #region Properties

        public int Red
        {
            get
            {
                return red;
            }

            set
            {
                red = value;
            }
        }

        public int Kolona
        {
            get
            {
                return kolona;
            }

            set
            {
                kolona = value;
            }
        }

        public int Figura
        {
            get
            {
                return figura;
            }

            set
            {
                figura = value;
            }
        }

        public bool DaLiJeBeli
        {
            get
            {
                return daLiJeBeli;
            }

            set
            {
                this.daLiJeBeli = value;
            }
        }

        public bool Obelezen
        {
            get
            {
                return obelezen;
            }

            set
            {

                obelezen = value;
            }
        }

        public bool Napadnuta
        {
            get
            {
                return napadnuta;
            }

            set
            {
                napadnuta = value;
            }
        }


        #endregion

    }
}
