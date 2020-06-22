using Sah.Klase_Za_Sah;
using System;
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
    public partial class MainForma : Form
    {

         int Dminuti;
         int Dsekunda;
         int Lminuti;
         int Lsekunda;
         int clicked;
         bool sah;
         bool sahmat;
         int brojfigura;
         Polje Odabrano;
         bool Stopirano;
        bool igraBeli;

         public MainForma()
        {

            InitializeComponent();
        }

         private void MainForma_Load(object sender, EventArgs e)
        {

            this.Width = 8 * 80;
            this.Height = 8 * 90;

            Odabrano = new Polje();
            this.NoviGame();

        }

         private void ZameniPolozajTabele()
        {

            int VrstaOdPozadi = 7;
            int KolonaOdPozadi = 7;


            // Vertikalna zamena

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Polje pom = new Polje();

                    pom.BackgroundImage = PoljeMatrica.Instanca.Polja[i, j].BackgroundImage;
                    pom.Figura = PoljeMatrica.Instanca.Polja[i, j].Figura;
                    pom.DaLiJeBeli = PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli;

                    PoljeMatrica.Instanca.Polja[i, j].BackgroundImage = PoljeMatrica.Instanca.Polja[VrstaOdPozadi - i, j].BackgroundImage;
                    PoljeMatrica.Instanca.Polja[i, j].Figura = PoljeMatrica.Instanca.Polja[VrstaOdPozadi - i, j].Figura;
                    PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli = PoljeMatrica.Instanca.Polja[VrstaOdPozadi - i, j].DaLiJeBeli;


                    PoljeMatrica.Instanca.Polja[VrstaOdPozadi - i, j].BackgroundImage = pom.BackgroundImage;
                    PoljeMatrica.Instanca.Polja[VrstaOdPozadi - i, j].Figura = pom.Figura;
                    PoljeMatrica.Instanca.Polja[VrstaOdPozadi - i, j].DaLiJeBeli = pom.DaLiJeBeli;

                }
            }


            // horizontalna zamena

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {


                    Polje pom = new Polje();

                    pom.BackgroundImage = PoljeMatrica.Instanca.Polja[i, j].BackgroundImage;
                    pom.Figura = PoljeMatrica.Instanca.Polja[i, j].Figura;
                    pom.DaLiJeBeli = PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli;

                    PoljeMatrica.Instanca.Polja[i, j].BackgroundImage = PoljeMatrica.Instanca.Polja[i, KolonaOdPozadi - j].BackgroundImage;
                    PoljeMatrica.Instanca.Polja[i, j].Figura = PoljeMatrica.Instanca.Polja[i, KolonaOdPozadi - j].Figura;
                    PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli = PoljeMatrica.Instanca.Polja[i, KolonaOdPozadi - j].DaLiJeBeli;


                    PoljeMatrica.Instanca.Polja[i, KolonaOdPozadi - j].BackgroundImage = pom.BackgroundImage;
                    PoljeMatrica.Instanca.Polja[i, KolonaOdPozadi - j].Figura = pom.Figura;
                    PoljeMatrica.Instanca.Polja[i, KolonaOdPozadi - j].DaLiJeBeli = pom.DaLiJeBeli;
                }

            }

            MatricaSaha.Visible = false;

            this.NapraviMatricuSaha();

            MatricaSaha.Visible = true;


            igraBeli = !igraBeli;

            if(igraBeli)
            {
                WhitePlayer_lb.ForeColor = Color.IndianRed;
                BlackPlayer_lb.ForeColor = Color.Black;
            }
            else
            {
      
                WhitePlayer_lb.ForeColor = Color.Black;
                BlackPlayer_lb.ForeColor = Color.IndianRed;
            }


        }

         private void NapraviMatricuSaha()
        {

            MatricaSaha.Controls.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    MatricaSaha.Controls.Add(PoljeMatrica.Instanca.Polja[i, j], j, i);
                    PoljeMatrica.Instanca.Polja[i, j].MouseDown -= new MouseEventHandler(PritisakPolja);
                    PoljeMatrica.Instanca.Polja[i, j].MouseDown += new MouseEventHandler(PritisakPolja);
                }
            }

            MatricaSaha.RowCount = 8;
            MatricaSaha.ColumnCount = 8;
        }

         private void NoviGame()
        {
            Tajmer.Stop();

            // Ako neko zeli da promeni vreme za vreme restarta moze

            var IzborVremena = new IzborVremena();

            IzborVremena.ShowDialog();

          

            if (IzborVremena.DialogResult == DialogResult.Abort)
                this.Close();
            else if (IzborVremena.DialogResult == DialogResult.Yes)
                Dminuti = Lminuti = 3;
            else if (IzborVremena.DialogResult == DialogResult.No)
                 Dminuti = Lminuti = 15;



            Dsekunda = Lsekunda = 0;
            Stopirano = true;
            igraBeli = true;
            clicked = 0;
            sah = false;
            sahmat = false;
            brojfigura = 32;

            Restart_btn.Enabled = false;
            StartStop_btn.Enabled = true;

           
            MatricaSaha.Enabled = false;
            StartStop_btn.Text = "Start The Game";

            PoljeMatrica.Instanca.NapraviMatricu();
            this.NapraviMatricuSaha();

            DMinuti_lb.Text = Convert.ToString(Dminuti);
            DSekunda_lb.Text = Convert.ToString(Dsekunda);

            LMinuti_lb.Text = Convert.ToString(Lminuti);
            LSekunda_lb.Text = Convert.ToString(Lsekunda);

          
            WhitePlayer_lb.ForeColor = Color.IndianRed;
            BlackPlayer_lb.ForeColor = Color.Black;
        }

         private void RestartIgre()
        {
            PoljeMatrica.Instanca.ObrisiMatricu();
            MatricaSaha.Controls.Clear();

            this.NoviGame();
        }

         private void ZavrsenaIgra(bool IstekloVreme)
        {
            Tajmer.Stop();
            MatricaSaha.Enabled = false;
            StartStop_btn.Enabled = false;
            Restart_btn.Enabled = true;

            Form novaforma;

            if (IstekloVreme)
            {
                novaforma = new WinnerForm(Dminuti, Dsekunda, Lminuti, Lsekunda);
            }
            else
            {
                novaforma= new WinnerForm(igraBeli, sahmat);
            }
        
          

            novaforma.ShowDialog();

           

            if (novaforma.DialogResult==DialogResult.Yes)
            {
                this.RestartIgre();
            }
            else if (novaforma.DialogResult == DialogResult.No)
            {
                this.Close();
            }

            PoljeMatrica.Instanca.BojenjeTabele();

        }

        private void Promocija(Polje polje)
        {
            Tajmer.Stop();

            var formanova = new FormaPromocije(polje.DaLiJeBeli);


            formanova.ShowDialog();


            if (formanova.DialogResult == DialogResult.Yes)
            {
                polje.Figura = 4;

                if (polje.DaLiJeBeli)
                    polje.BackgroundImage =  Sah.Resursi.whitequeen;
                else
                    polje.BackgroundImage = Sah.Resursi.blackqueen;
                

            }
            else if (formanova.DialogResult == DialogResult.No)
            {
                polje.Figura = 2;

                if (polje.DaLiJeBeli)
                    polje.BackgroundImage = Sah.Resursi.whiterook;
                else
                    polje.BackgroundImage = Sah.Resursi.blackrook;

            }
            else if (formanova.DialogResult == DialogResult.OK)
            {

                polje.Figura = 3;

                if (polje.DaLiJeBeli)
                    polje.BackgroundImage = Sah.Resursi.whitebishop;
                else
                    polje.BackgroundImage = Sah.Resursi.blackbishop;

            }
            else if (formanova.DialogResult == DialogResult.Cancel)
            {

                polje.Figura = 1;

                if (polje.DaLiJeBeli)
                    polje.BackgroundImage = Sah.Resursi.whiteknight;
                else
                    polje.BackgroundImage = Sah.Resursi.blackknight;

            }


            this.NapadiFigura();

            Tajmer.Start();
        }

        private void PromenaPolozajaFigure(Polje pom)
        {
            pom.BackgroundImage = this.Odabrano.BackgroundImage;
            pom.Figura = this.Odabrano.Figura;
            pom.DaLiJeBeli = this.Odabrano.DaLiJeBeli;

            this.Odabrano.BackgroundImage = null;
            this.Odabrano.Figura = -1;

            PoljeMatrica.Instanca.BojenjeTabele();
            this.ZameniPolozajTabele();
        }

         private void PritisakPolja(object sender, MouseEventArgs e)
        {
            Polje pom = PoljeMatrica.Instanca.NadjiPolje(sender as Polje);

            if (clicked == 1)
            {
                if (pom.Figura > -1 && !pom.Obelezen && !sah)
                {
                   
                    PoljeMatrica.Instanca.BojenjeTabele();
                    this.clicked--;
                    this.NapadiFigura();

                    if (pom.DaLiJeBeli == igraBeli && this.Odabrano!=pom)
                        this.PritisakPolja(pom, e);
                    
                }

                if (pom.Obelezen)
                {

                    if (sah)
                      sah = false;


                    if (pom.Figura > -1)
                        brojfigura--;

                    this.PromenaPolozajaFigure(pom);

                    this.clicked--;
                    this.NapadiFigura();


                    if (brojfigura < 7)
                        this.DaLiJeRemi();

                    if (sah)
                     this.NadjiKralja();
                    
                    if (sahmat)
                        this.ZavrsenaIgra(false);


                }

               

            }
           else if (clicked == 0)
            {
                if (pom.Figura > -1)
                {
                    if (this.igraBeli==pom.DaLiJeBeli)
                    {

                            this.KretanjeFigura(pom);

                            this.Odabrano = pom;

                            this.clicked++;
                                          
                                                              
                    }                   
                }
            }

        }

        private void DaLiJeRemi()
        {
            int Belilovci = 0;
            int Belikonji = 0;

            int CrniLovci = 0;
            int CrniKonji = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                                     
                   if (PoljeMatrica.Instanca.Polja[i, j].Figura == 4 || PoljeMatrica.Instanca.Polja[i, j].Figura == 2 || PoljeMatrica.Instanca.Polja[i, j].Figura == 0)
                       return;                

                   if(PoljeMatrica.Instanca.Polja[i, j].Figura == 3 && PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli==true)
                        Belilovci++;
                   else if(PoljeMatrica.Instanca.Polja[i, j].Figura == 3 && PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli == false)
                        CrniLovci++;
                   else if(PoljeMatrica.Instanca.Polja[i, j].Figura == 1 && PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli == true)
                        Belikonji++;
                   else if(PoljeMatrica.Instanca.Polja[i, j].Figura == 1 && PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli == false)                   
                        CrniKonji++;

                    if (CrniLovci == 2 || Belilovci == 2)
                        return;
                }
            }
                                              
            if ((Belilovci == 1 &&  Belikonji > 0) || (CrniLovci == 1 && CrniKonji > 0))
                return;


            this.ZavrsenaIgra(false);

        }

        private void NadjiKralja()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli == this.igraBeli && PoljeMatrica.Instanca.Polja[i, j].Figura == 5)
                    {
                        PoljeMatrica.Instanca.Polja[i, j].BackColor = Color.Gold;

                        this.Odabrano = PoljeMatrica.Instanca.Polja[i, j];
                        this.clicked++;

                        this.KretanjeKralja(i,j,true);
                    }
                }
            }
        }

        private bool DaLiJeKraljSiguran(Polje polje)
        {
            int pom;
            int pom2;

            for (int k = 1; k < 8; k++)
            {
                pom = polje.Red - k;

                if (pom >= 0)
                {
                    if ((PoljeMatrica.Instanca.Polja[pom, polje.Kolona].Figura == 2 || PoljeMatrica.Instanca.Polja[pom, polje.Kolona].Figura == 4) && PoljeMatrica.Instanca.Polja[pom, polje.Kolona].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Red + i;

                            if (pom3 < 8)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom3, polje.Kolona].Figura == 5 && PoljeMatrica.Instanca.Polja[pom3, polje.Kolona].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[pom3, polje.Kolona].Figura > -1)
                                    break;
                            }
                        }
                    }
                    else if (PoljeMatrica.Instanca.Polja[pom, polje.Kolona].Figura > -1)
                        break;    

                }

            }

            for (int k = 1; k < 8; k++)
            {
                pom2 = polje.Kolona - k;

                if (pom2 >= 0)
                {

                    if ((PoljeMatrica.Instanca.Polja[polje.Red, pom2].Figura == 2 || PoljeMatrica.Instanca.Polja[polje.Red, pom2].Figura == 4) && PoljeMatrica.Instanca.Polja[polje.Red, pom2].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Kolona + i;

                            if (pom3 < 8)
                            {
                                if (PoljeMatrica.Instanca.Polja[polje.Red, pom3].Figura == 5 && PoljeMatrica.Instanca.Polja[polje.Red, pom3].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[polje.Red, pom3].Figura > -1)
                                    break;
                            }
                        }

                     
                       
                    }
                    else if (PoljeMatrica.Instanca.Polja[polje.Red, pom2].Figura > -1)
                        break;

                }
            }

            for (int k = 1; k < 8; k++)
            {
                pom = polje.Red + k;


                if (pom < 8)
                {
                    if ((PoljeMatrica.Instanca.Polja[pom, polje.Kolona].Figura == 2 || PoljeMatrica.Instanca.Polja[pom, polje.Kolona].Figura == 4) && PoljeMatrica.Instanca.Polja[pom, polje.Kolona].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Red - i;

                            if (pom3 >= 0)
                            {
                                if ( PoljeMatrica.Instanca.Polja[pom3, polje.Kolona].Figura == 5 && PoljeMatrica.Instanca.Polja[pom3, polje.Kolona].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[pom3, polje.Kolona].Figura > -1)
                                    break;
                            }
                        }
                    }
                    else if (PoljeMatrica.Instanca.Polja[pom, polje.Kolona].Figura > -1)
                        break;

                }
            }


                for (int k = 1; k < 8; k++)
            {
                pom2 = polje.Kolona + k;

                if (pom2 < 8)
                {

                    if ((PoljeMatrica.Instanca.Polja[polje.Red, pom2].Figura == 2 || PoljeMatrica.Instanca.Polja[polje.Red, pom2].Figura == 4) && PoljeMatrica.Instanca.Polja[polje.Red, pom2].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Kolona - i;
                            if (pom3 >= 0)
                            {
                                if ( PoljeMatrica.Instanca.Polja[polje.Red, pom3].Figura == 5 && PoljeMatrica.Instanca.Polja[polje.Red, pom3].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[polje.Red, pom3].Figura > -1)
                                    break;
                            }
                        }



                    }
                    else if (PoljeMatrica.Instanca.Polja[polje.Red, pom2].Figura > -1)
                        break;

                }
            }


            for (int k = 1; k < 8; k++)
            {

                pom = polje.Red - k;
                pom2 = polje.Kolona - k;

                if (pom >= 0 && pom2 >= 0)
                {

                    if ((PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 3 || PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 4) && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;
                        int pom4 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Red + i;
                            pom4 = polje.Kolona + i;

                            if (pom3 < 8 && pom4 < 8)
                            {
                                if ( PoljeMatrica.Instanca.Polja[pom3, pom4].Figura == 5 && PoljeMatrica.Instanca.Polja[pom3, pom4].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[pom3, pom4].Figura > -1)
                                    break;
                            }
                        }



                    }
                    else if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura > -1)
                        break;

                    
                }
            }

            for (int k = 1; k < 8; k++)
            {

                pom = polje.Red - k;
                pom2 = polje.Kolona + k;

                if (pom >= 0 && pom2 < 8)
                {

                    if ((PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 3 || PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 4) && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;
                        int pom4 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Red + i;
                            pom4 = polje.Kolona - i;

                            if (pom3 < 8 && pom4 >= 0)
                            {
                                if ( PoljeMatrica.Instanca.Polja[pom3, pom4].Figura == 5 && PoljeMatrica.Instanca.Polja[pom3, pom4].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[pom3, pom4].Figura > -1)
                                    break;
                            }
                        }



                    }
                    else if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura > -1)
                        break;




                }

            }

            for (int k = 1; k < 8; k++)
            {
                pom = polje.Red + k;
                pom2 = polje.Kolona - k;

                if (pom < 8 && pom2 >= 0)
                {

                    if ((PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 3 || PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 4) && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;
                        int pom4 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Red - i;
                            pom4 = polje.Kolona + i;
                            if (pom3 >= 0 && pom4 < 8)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom3, pom4].Figura == 5 && PoljeMatrica.Instanca.Polja[pom3, pom4].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[pom3, pom4].Figura > -1)
                                    break;
                            }
                        }
                    }
                }
            }


            for (int k = 1; k < 8; k++)
            {
                pom = polje.Red + k;
                pom2 = polje.Kolona + k;

                if (pom < 8 && pom2 < 8)
                {
                    if ((PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 3 || PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 4) && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != igraBeli)
                    {
                        int pom3 = 0;
                        int pom4 = 0;

                        for (int i = 1; i < 8; i++)
                        {
                            pom3 = polje.Red - i;
                            pom4 = polje.Kolona - i;
                            if (pom3 >= 0 && pom4 >=0)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom3, pom4].Figura == 5 && PoljeMatrica.Instanca.Polja[pom3, pom4].DaLiJeBeli == igraBeli)
                                    return false;
                                else if ( PoljeMatrica.Instanca.Polja[pom3, pom4].Figura > -1)
                                    break;
                            }
                        }



                    }
                    else if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura > -1)
                        break;
                }

            }

            return true;
        } 

        private void KretanjeKonja(int i, int j,bool Koigra)
        {
            if(Koigra)
            {
                if (i - 2 >= 0 && j - 1 >= 0)
                {
                    if (PoljeMatrica.Instanca.Polja[i - 2, j - 1].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i - 2, j - 1].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i - 2, j - 1].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i - 2, j - 1].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i - 2, j - 1].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i - 2, j - 1].Obelezen = true;
                    }
                }

                if (i - 2 >= 0 && j + 1 < 8)
                {
                    if (PoljeMatrica.Instanca.Polja[i - 2, j + 1].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i - 2, j + 1].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i - 2, j + 1].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i - 2, j + 1].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i - 2, j + 1].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i - 2, j + 1].Obelezen = true;
                    }

                }

                if (i + 2 < 8 && j + 1 < 8)
                {
                    if (PoljeMatrica.Instanca.Polja[i + 2, j + 1].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i + 2, j + 1].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i + 2, j + 1].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i + 2, j + 1].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i + 2, j + 1].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i + 2, j + 1].Obelezen = true;
                    }
                }

                if (i + 2 < 8 && j - 1 >= 0)
                {
                    if (PoljeMatrica.Instanca.Polja[i + 2, j - 1].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i + 2, j - 1].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i + 2, j - 1].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i + 2, j - 1].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i + 2, j - 1].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i + 2, j - 1].Obelezen = true;

                    }
                }

                if (i - 1 >= 0 && j - 2 >= 0)
                {
                    if (PoljeMatrica.Instanca.Polja[i - 1, j - 2].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i - 1, j - 2].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i - 1, j - 2].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i - 1, j - 2].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i - 1, j - 2].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i - 1, j - 2].Obelezen = true;
                    }
                }

                if (i - 1 >= 0 && j + 2 < 8)
                {
                    if (PoljeMatrica.Instanca.Polja[i - 1, j + 2].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i - 1, j + 2].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i - 1, j + 2].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i - 1, j + 2].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i - 1, j + 2].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i - 1, j + 2].Obelezen = true;
                    }

                }

                if (i + 1 < 8 && j + 2 < 8)
                {
                    if (PoljeMatrica.Instanca.Polja[i + 1, j + 2].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i + 1, j + 2].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i + 1, j + 2].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i + 1, j + 2].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i + 1, j + 2].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i + 1, j + 2].Obelezen = true;
                    }

                }
                if (i + 1 < 8 && j - 2 >= 0)
                {
                    if (PoljeMatrica.Instanca.Polja[i + 1, j - 2].Figura == -1)
                    {
                        PoljeMatrica.Instanca.Polja[i + 1, j - 2].BackColor = Color.PowderBlue;
                        PoljeMatrica.Instanca.Polja[i + 1, j - 2].Obelezen = true;
                    }
                    else if (PoljeMatrica.Instanca.Polja[i + 1, j - 2].DaLiJeBeli != this.igraBeli)
                    {
                        PoljeMatrica.Instanca.Polja[i + 1, j - 2].BackColor = Color.Red;
                        PoljeMatrica.Instanca.Polja[i + 1, j - 2].Obelezen = true;
                    }
                }

            }
            else
            {
                if (i - 2 >= 0 && j - 1 >= 0)
                {
                    PoljeMatrica.Instanca.Polja[i - 2, j - 1].Napadnuta = true;

                    if(PoljeMatrica.Instanca.Polja[i - 2, j - 1].Figura==5 && PoljeMatrica.Instanca.Polja[i - 2, j - 1].DaLiJeBeli==igraBeli)
                        sah = true;
                    

                }

                if (i - 2 >= 0 && j + 1 < 8)
                {
                    PoljeMatrica.Instanca.Polja[i - 2, j + 1].Napadnuta = true;

                    if (PoljeMatrica.Instanca.Polja[i - 2, j + 1].Figura == 5 && PoljeMatrica.Instanca.Polja[i - 2, j + 1].DaLiJeBeli == igraBeli)
                        sah = true;
                }

                if (i + 2 < 8 && j + 1 < 8)
                {

                    PoljeMatrica.Instanca.Polja[i + 2, j + 1].Napadnuta = true;

                    if (PoljeMatrica.Instanca.Polja[i + 2, j + 1].Figura == 5 && PoljeMatrica.Instanca.Polja[i + 2, j + 1].DaLiJeBeli == igraBeli)
                        sah = true;
                }

                if (i + 2 < 8 && j - 1 >= 0)
                {

                    PoljeMatrica.Instanca.Polja[i + 2, j - 1].Napadnuta = true;

                    if (PoljeMatrica.Instanca.Polja[i + 2, j - 1].Figura == 5 && PoljeMatrica.Instanca.Polja[i + 2, j - 1].DaLiJeBeli == igraBeli)
                        sah = true;

                }

                if (i - 1 >= 0 && j - 2 >= 0)
                {
                    PoljeMatrica.Instanca.Polja[i - 1, j - 2].Napadnuta = true;


                    if (PoljeMatrica.Instanca.Polja[i - 1, j - 2].Figura == 5 && PoljeMatrica.Instanca.Polja[i - 1, j - 2].DaLiJeBeli == igraBeli)
                        sah = true;
                }

                if (i - 1 >= 0 && j + 2 < 8)
                {
                    PoljeMatrica.Instanca.Polja[i - 1, j + 2].Napadnuta = true;

                    if (PoljeMatrica.Instanca.Polja[i - 1, j + 2].Figura == 5 && PoljeMatrica.Instanca.Polja[i - 1, j + 2].DaLiJeBeli == igraBeli)
                        sah = true;

                }

                if (i + 1 < 8 && j + 2 < 8)
                {
                    PoljeMatrica.Instanca.Polja[i + 1, j + 2].Napadnuta = true;

                    if (PoljeMatrica.Instanca.Polja[i + 1, j + 2].Figura == 5 && PoljeMatrica.Instanca.Polja[i + 1, j + 2].DaLiJeBeli == igraBeli)
                        sah = true;

                }
                if (i + 1 < 8 && j - 2 >= 0)
                {
                    PoljeMatrica.Instanca.Polja[i + 1, j - 2].Napadnuta = true;


                    if (PoljeMatrica.Instanca.Polja[i + 1, j - 2].Figura == 5 && PoljeMatrica.Instanca.Polja[i + 1, j - 2].DaLiJeBeli == igraBeli)
                        sah = true;

                }

            }


        }

        private void KretanjeLovca(int i, int j, bool Koigra)
        {
            int pom;
            int pom2;


            if(Koigra)
            {
                        for (int k = 1; k < 8; k++)
                        {

                            pom = i - k;
                            pom2 = j - k;

                            if (pom >= 0 && pom2 >= 0)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                {
                                    PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.PowderBlue;
                                    PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;
                                }
                                else
                                {
                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != this.igraBeli)
                                    {
                                        PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.Red;
                                        PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;

                                    }

                                    break;
                                }
                            }
                        }

                        for (int k = 1; k < 8; k++)
                        {

                            pom = i - k;
                            pom2 = j + k;

                            if (pom >= 0 && pom2 < 8)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                {
                                    PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.PowderBlue;
                                    PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;
                                }
                                else
                                {
                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != this.igraBeli)
                                    {
                                        PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.Red;
                                        PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;
                                    }

                                    break;
                                }
                            }

                        }

                        for (int k = 1; k < 8; k++)
                        {
                            pom = i + k;
                            pom2 = j - k;

                            if (pom < 8 && pom2 >= 0)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                {
                                    PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.PowderBlue;
                                    PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;
                                }
                                else
                                {
                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != this.igraBeli)
                                    {
                                        PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.Red;
                                        PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;

                                    }
                                    break;
                                }
                            }
                        }


                        for (int k = 1; k < 8; k++)
                        {
                            pom = i + k;
                            pom2 = j + k;

                            if (pom < 8 && pom2 < 8)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                {
                                    PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.PowderBlue;
                                    PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;

                                }
                                else
                                {
                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != this.igraBeli)
                                    {
                                        PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.Red;
                                        PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;

                                    }
                                    break;
                                }
                            }

                        }




            }
            else
            {
                        for (int k = 1; k < 8; k++)
                        {

                            pom = i - k;
                            pom2 = j - k;

                            if (pom >= 0 && pom2 >= 0)
                            {
                                if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                {
                                    PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;
                                }
                                else
                                {
                                    PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;

                                if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 5 && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli == this.igraBeli)
                                {
                                    sah = true;
                                    continue;
                                }


                                      break;
                                }
                           }
                    
                        }

                        for (int k = 1; k < 8; k++)
                        {

                            pom = i - k;
                            pom2 = j + k;

                            if (pom >= 0 && pom2 < 8)
                            {

                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                    {

                                        PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;
                                    }
                                    else
                                    {
                                            PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;


                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 5  && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli == this.igraBeli)
                                    {
                                        sah = true;
                                        continue;
                                    }

                                      break;
                                    }

                             }

                        }

                        for (int k = 1; k < 8; k++)
                        {
                            pom = i + k;
                            pom2 = j - k;

                            if (pom < 8 && pom2 >= 0)
                            {
                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                    {

                                        PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;
                                    }
                                    else
                                    {
                                        
                                            PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;


                                            if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 5 && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli == this.igraBeli)
                                            {
                                                sah = true;
                                                continue;
                                            };

                                            break;
                                    }
                             }
                        }


                        for (int k = 1; k < 8; k++)
                        {
                            pom = i + k;
                            pom2 = j + k;

                            if (pom < 8 && pom2 < 8)
                            {
                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                                    {

                                        PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;
                                    }
                                    else
                                    {
                                            PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;


                                             if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 5 && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli == this.igraBeli)
                                                {
                                                    sah = true;
                                                    continue;
                                                }

                                        break;
                                    }

                             }

                        }
            }
        }

        private void KretanjeTopa(int i, int j, bool Koigra)
        {
            int pom;
            int pom2;

            if(Koigra)
            {
                for (int k = 1; k < 8; k++)
                {
                    pom = i - k;

                    if (pom >= 0)
                    {

                        if (PoljeMatrica.Instanca.Polja[pom, j].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[pom, j].BackColor = Color.PowderBlue;
                            PoljeMatrica.Instanca.Polja[pom, j].Obelezen = true;
                        }
                        else
                        {
                            if (PoljeMatrica.Instanca.Polja[pom, j].DaLiJeBeli != this.igraBeli)
                            {
                                PoljeMatrica.Instanca.Polja[pom, j].BackColor = Color.Red;
                                PoljeMatrica.Instanca.Polja[pom, j].Obelezen = true;

                            }

                            break;

                        }
                    }


                }

                for (int k = 1; k < 8; k++)
                {
                    pom2 = j - k;

                    if (pom2 >= 0)
                    {

                        if (PoljeMatrica.Instanca.Polja[i, pom2].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[i, pom2].BackColor = Color.PowderBlue;
                            PoljeMatrica.Instanca.Polja[i, pom2].Obelezen = true;
                        }
                        else
                        {
                            if (PoljeMatrica.Instanca.Polja[i, pom2].DaLiJeBeli != this.igraBeli)
                            {
                                PoljeMatrica.Instanca.Polja[i, pom2].BackColor = Color.Red;
                                PoljeMatrica.Instanca.Polja[i, pom2].Obelezen = true;

                            }
                            break;
                        }
                    }
                }

                for (int k = 1; k < 8; k++)
                {
                    pom = i + k;

                    if (pom < 8)
                    {
                        if (PoljeMatrica.Instanca.Polja[pom, j].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[pom, j].BackColor = Color.PowderBlue;
                            PoljeMatrica.Instanca.Polja[pom, j].Obelezen = true;
                        }
                        else
                        {

                            if (PoljeMatrica.Instanca.Polja[pom, j].DaLiJeBeli != this.igraBeli)
                            {
                                PoljeMatrica.Instanca.Polja[pom, j].BackColor = Color.Red;
                                PoljeMatrica.Instanca.Polja[pom, j].Obelezen = true;


                            }

                            break;
                        }
                    }
                }


                for (int k = 1; k < 8; k++)
                {
                    pom2 = j + k;

                    if (pom2 < 8)
                    {
                        if (PoljeMatrica.Instanca.Polja[i, pom2].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[i, pom2].BackColor = Color.PowderBlue;
                            PoljeMatrica.Instanca.Polja[i, pom2].Obelezen = true;
                        }
                        else
                        {
                            if (PoljeMatrica.Instanca.Polja[i, pom2].DaLiJeBeli != this.igraBeli)
                            {
                                PoljeMatrica.Instanca.Polja[i, pom2].BackColor = Color.Red;
                                PoljeMatrica.Instanca.Polja[i, pom2].Obelezen = true;

                            }
                            break;
                        }
                    }
                }


            }
            else
            {
                for (int k = 1; k < 8; k++)
                {
                    pom = i - k;

                    if (pom >= 0)
                    {

                        if (PoljeMatrica.Instanca.Polja[pom, j].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[pom, j].Napadnuta = true;
                        }
                        else
                        {
                                PoljeMatrica.Instanca.Polja[pom, j].Napadnuta = true;


                            if (PoljeMatrica.Instanca.Polja[pom, j].Figura == 5 && PoljeMatrica.Instanca.Polja[pom, j].DaLiJeBeli == this.igraBeli)
                            {
                                sah = true;
                                continue;
                            }

                            break;
                        }
                    }


                }

                for (int k = 1; k < 8; k++)
                {
                    pom2 = j - k;

                    if (pom2 >= 0)
                    {

                        if (PoljeMatrica.Instanca.Polja[i, pom2].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[i, pom2].Napadnuta = true;
                        }
                        else
                        {
                                PoljeMatrica.Instanca.Polja[i, pom2].Napadnuta = true;


                            if (PoljeMatrica.Instanca.Polja[i, pom2].Figura == 5 && PoljeMatrica.Instanca.Polja[i, pom2].DaLiJeBeli == this.igraBeli)
                            {
                                sah = true;
                                continue;
                            }

                            break;
                        }
                    }
                }

                for (int k = 1; k < 8; k++)
                {
                    pom = i + k;

                    if (pom < 8)
                    {
                        if (PoljeMatrica.Instanca.Polja[pom, j].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[pom, j].Napadnuta = true;
                        }
                        else
                        {
                                PoljeMatrica.Instanca.Polja[pom, j].Napadnuta = true;


                            if (PoljeMatrica.Instanca.Polja[pom, j].Figura == 5 && PoljeMatrica.Instanca.Polja[pom, j].DaLiJeBeli == this.igraBeli)
                            {
                                sah = true;
                                continue;
                            }

                            break;
                        }
                    }
                }


                for (int k = 1; k < 8; k++)
                {
                    pom2 = j + k;

                    if (pom2 < 8)
                    {
                        if (PoljeMatrica.Instanca.Polja[i, pom2].Figura == -1)
                        {
                            PoljeMatrica.Instanca.Polja[i, pom2].Napadnuta = true;
                        }
                        else
                        {
                                PoljeMatrica.Instanca.Polja[i, pom2].Napadnuta = true;

                            if (PoljeMatrica.Instanca.Polja[i, pom2].Figura == 5 && PoljeMatrica.Instanca.Polja[i, pom2].DaLiJeBeli == this.igraBeli)
                            {
                                sah = true;
                                continue;
                            }

                            break;
                        }
                    }
                }





            }

        }

        private void KretanjeKralja(int i,int j,bool Koigra)
        {
            int pom;
            int pom2;

            if (Koigra)
            {
                if(sah)
                sahmat = true;

                for (int k = -1; k < 2; k++)
                {
                    for (int o = -1; o < 2; o++)
                    {
                        pom = i + k;
                        pom2 = j + o;

                        if (pom >= 0 && pom < 8 && pom2 >= 0 && pom2 < 8)
                        {
                            if (PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta == true)
                                continue;
                            

                            if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                            {
                                sahmat = false;
                                PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.PowderBlue;
                                PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;
                            }
                            else if (PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != this.igraBeli)
                            {
                                sahmat = false;
                                PoljeMatrica.Instanca.Polja[pom, pom2].BackColor = Color.Red;
                                PoljeMatrica.Instanca.Polja[pom, pom2].Obelezen = true;
                            }



                        }
                    }
                }


            }
            else
            {
                for (int k = -1; k < 2; k++)
                {

                    for (int o = -1; o < 2; o++)
                    {
                        pom = i + k;
                        pom2 = j + o;

                        if (pom >= 0 && pom < 8 && pom2 >= 0 && pom2 < 8)
                        {
                            if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == -1)
                            {
                                PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;
                            }
                            else if (PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli != this.igraBeli)
                            {
                                PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;
                            }

                        }
                    }
                }

            }

        }

        private void KretanjeFigura(Polje a)
        {

            if ( a.Napadnuta && !this.DaLiJeKraljSiguran(a))
            {
                a.BackColor = Color.Purple;
                return;
            }

                switch (a.Figura)
            {
                case 0:

                    #region Pesak

                    

                        if (a.Red == 6)
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                if (PoljeMatrica.Instanca.Polja[a.Red - i, a.Kolona].Figura == -1)
                                {
                                    PoljeMatrica.Instanca.Polja[a.Red - i, a.Kolona].BackColor = Color.PowderBlue;
                                    PoljeMatrica.Instanca.Polja[a.Red - i, a.Kolona].Obelezen = true;
                                }
                                else
                                {
                                    break;

                                }

                            }
                        }
                        else
                        {
                            if (PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona].Figura == -1)
                            {
                                PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona].BackColor = Color.PowderBlue;
                                PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona].Obelezen = true;
                            }
                        }

                 
                    
                        if (a.Kolona + 1 < 8 && PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona + 1].Figura > -1 && PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona + 1].DaLiJeBeli != this.igraBeli)
                        {
                            PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona + 1].BackColor = Color.Red;
                            PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona + 1].Obelezen = true;
                        }



                        if (a.Kolona - 1 >= 0 && PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona - 1].Figura > -1 && PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona - 1].DaLiJeBeli != this.igraBeli)
                        {
                            PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona - 1].BackColor = Color.Red;
                            PoljeMatrica.Instanca.Polja[a.Red - 1, a.Kolona - 1].Obelezen = true;
                        }

                    
                    #endregion

                    break;

          
                case 1:

                    this.KretanjeKonja(a.Red,a.Kolona,true);

                    break;

                case 2:

                  



                    this.KretanjeTopa(a.Red,a.Kolona,true);

                    break;

         

                case 3:

                

                    this.KretanjeLovca(a.Red,a.Kolona,true);
                             
                    break;

          
                case 4:


                    this.KretanjeTopa(a.Red, a.Kolona, true);

                    this.KretanjeLovca(a.Red, a.Kolona, true);
             

                    break;

                case 5:

                    this.KretanjeKralja(a.Red,a.Kolona,true);

                break;
            }
        } //Validnost poteza

        private void NapadiFigura()
        {
            int pom;
            int pom2;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (PoljeMatrica.Instanca.Polja[i, j].DaLiJeBeli == !this.igraBeli)
                    {
                        switch (PoljeMatrica.Instanca.Polja[i, j].Figura)
                        {
                                 case 0:

                                #region Pesak
                              
                                    pom = i + 1;
                                    pom2 = j + 1;

                                    if (pom < 8 && pom2 < 8)
                                    {
                                        PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;

                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 5 && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli == igraBeli)
                                        sah = true;
                                    }

                                    pom2 = j - 1;

                                    if (pom < 8 && pom2 >= 0)
                                    {
                                        PoljeMatrica.Instanca.Polja[pom, pom2].Napadnuta = true;

                                    if (PoljeMatrica.Instanca.Polja[pom, pom2].Figura == 5 && PoljeMatrica.Instanca.Polja[pom, pom2].DaLiJeBeli==igraBeli)
                                        sah = true;
                                }                               

                                #endregion

                                    if(PoljeMatrica.Instanca.Polja[i, j].Red==7)
                                    {

                                    this.Promocija(PoljeMatrica.Instanca.Polja[i, j]);

                                    }


                                break;


                            case 1:


                                this.KretanjeKonja(i, j,false);


                              break;

                            case 2:

                                this.KretanjeTopa(i, j, false);

                                break;



                            case 3:

                                this.KretanjeLovca(i, j, false);

                             break;


                            case 4:

                             

                                this.KretanjeLovca(i, j, false);

                                this.KretanjeTopa(i, j, false);


                            break;

                            case 5:

                                this.KretanjeKralja(i,j,false);

                             break;


                        }
                    }

                }
            }


        }  //Provera saha

         private void Tajmer_Tick(object sender, EventArgs e)
    {
         
        switch (igraBeli)
        {
            case true:

                if (Lsekunda == 0)
                {
                    Lsekunda = 59;
                    LSekunda_lb.Text = Convert.ToString(Lsekunda);
                    LMinuti_lb.Text = Convert.ToString(--Lminuti);

                }
                else
                {
                    LSekunda_lb.Text = Convert.ToString(--Lsekunda);
                }


                break;

            case false:

                if (Dsekunda == 0)
                {
                    Dsekunda = 59;
                    DSekunda_lb.Text = Convert.ToString(Dsekunda);
                    DMinuti_lb.Text = Convert.ToString(--Dminuti);

                }
                else
                {
                    DSekunda_lb.Text = Convert.ToString(--Dsekunda);
                }

                break;
        }


            if ((Dsekunda == 0 && Dminuti == 0) || (Lsekunda == 0 && Lminuti == 0))
            {
                this.ZavrsenaIgra(true);
            }


    }

         private void StartStop_btn_Click(object sender, EventArgs e)
    {

        Stopirano = !Stopirano;

        if (Stopirano)
        {
            Tajmer.Stop();
            StartStop_btn.Text = "Start The Game";
            MatricaSaha.Enabled = false;
            Restart_btn.Enabled = true;
        }
        else
        {
            Tajmer.Start();
            StartStop_btn.Text = "Pause The Game";
            MatricaSaha.Enabled = true;
            Restart_btn.Enabled = false;
        }

    }

         private void Restart_btn_Click(object sender, EventArgs e)
         {       
                    this.RestartIgre();
      
         }
    }
}