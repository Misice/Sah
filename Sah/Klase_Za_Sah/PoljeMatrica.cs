using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah.Klase_Za_Sah
{
    public class PoljeMatrica
    {

        #region Konstruktori

       public  PoljeMatrica()
        {
            polja = new Polje[8, 8];
        }

        #endregion

        #region Atributi
        private Polje[,] polja;
        private int brojRedova=8;
        private int  brojKolona=8;

        private static PoljeMatrica instanca = null;

        #endregion

        #region Properties

        public int BrojRedova
        {
            get
            {
                return brojRedova;
            }

            set
            {
                brojRedova = value;
            }
        }

        public int BrojKolona
        {
            get
            {
                return brojKolona;
            }

            set
            {
                brojKolona = value;
            }
        }


        public Polje[,] Polja
        {
            get
            {
                return polja;
            }

            set
            {
                polja = value;
            }
        }

        public static PoljeMatrica Instanca
        {
            get
            {
                if (instanca == null)
                {
                    instanca = new PoljeMatrica();

                }
                return instanca;
            }
        }

        #endregion


        #region Funkcije

        public void BojenjeTabele()
        {

            for (int i = 0; i < this.brojRedova; i++)
            {
                for (int j = 0; j < this.brojKolona; j++)
                {
                    polja[i, j].Obelezen = false;
                    polja[i, j].Napadnuta = false;

                   if (i % 2 == 0)
                    {
                        if (j % 2 == 1)
                            polja[i, j].BackColor = System.Drawing.Color.Black;
                        else
                            polja[i, j].BackColor = System.Drawing.Color.WhiteSmoke;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            polja[i, j].BackColor = System.Drawing.Color.Black;
                        else
                            polja[i, j].BackColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
            }
        }

        public void NapraviMatricu()
        {
            for (int i = 0; i < this.brojRedova; i++)
            {
                for (int j = 0; j < this.brojKolona; j++)
                {
                    this.polja[i, j] = new Polje(i, j);                  
               
                    if (i == 0 || i == 1)
                    {
                        polja[i, j].DaLiJeBeli = false;
                    }
                    else if (i == 7 || i == 6)
                    {
                        polja[i, j].DaLiJeBeli = true;
                    }
                }
            }

            this.BojenjeTabele();



            #region PostavljanjeSlika


                            for (int j = 0; j < 8; j++)
                            {
                                polja[1, j].BackgroundImage = Sah.Resursi.blackpawn;
                                polja[1, j].Figura = 0;

                                polja[6, j].BackgroundImage = Sah.Resursi.whitepawn;
                                polja[6, j].Figura = 0;
                            }




                             polja[0, 0].BackgroundImage = Sah.Resursi.blackrook;
                             polja[0, 0].Figura = 2;
                             polja[0, 7].BackgroundImage = Sah.Resursi.blackrook;
                             polja[0, 7].Figura = 2;

                             polja[0, 1].BackgroundImage = Sah.Resursi.blackknight;
                             polja[0, 1].Figura = 1;
                             polja[0, 6].BackgroundImage = Sah.Resursi.blackknight;
                             polja[0, 6].Figura = 1;

                             polja[0, 2].BackgroundImage = Sah.Resursi.blackbishop;
                             polja[0, 2].Figura = 3;
                             polja[0, 5].BackgroundImage = Sah.Resursi.blackbishop;
                             polja[0, 5].Figura = 3;
            

                             polja[0, 4].BackgroundImage = Sah.Resursi.blackqueen;
                             polja[0, 4].Figura = 4;

                             polja[0, 3].BackgroundImage = Sah.Resursi.blackking;
                             polja[0, 3].Figura = 5;


     

                             polja[7, 0].BackgroundImage = Sah.Resursi.whiterook;
                             polja[7, 0].Figura = 2;
                             polja[7, 7].BackgroundImage = Sah.Resursi.whiterook;
                             polja[7, 7].Figura = 2;

                             polja[7, 1].BackgroundImage = Sah.Resursi.whiteknight;
                             polja[7, 1].Figura = 1;
                             polja[7, 6].BackgroundImage = Sah.Resursi.whiteknight;
                             polja[7, 6].Figura = 1;

                             polja[7, 2].BackgroundImage = Sah.Resursi.whitebishop;
                             polja[7, 2].Figura = 3;
                             polja[7, 5].BackgroundImage = Sah.Resursi.whitebishop;
                             polja[7, 5].Figura = 3;


                             polja[7, 4].BackgroundImage = Sah.Resursi.whitequeen;
                             polja[7, 4].Figura = 4;

                             polja[7, 3].BackgroundImage = Sah.Resursi.whiteking;
                             polja[7, 3].Figura = 5;
                            #endregion


        }

        public void ObrisiMatricu()
        {

            for (int i = 0; i < brojRedova; i++)
            {
                for (int j = 0; j < brojKolona; j++)
                {
                    Polja[i, j] = null;

                }
            }

            instanca = new PoljeMatrica();
        }

        public Polje NadjiPolje(Polje b)
        {
            for (int i = 0; i < brojRedova; i++)
            {
                for (int j = 0; j < brojKolona; j++)
                {
                    if (Polja[i, j]==b)
                        return Polja[i, j];
                }
            }

            return null;
        }


        #endregion
    }
}


