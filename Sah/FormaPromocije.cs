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
    public partial class FormaPromocije : Form
    {
        public FormaPromocije()
        {
            InitializeComponent();
        }

        public FormaPromocije(bool Igrabeli)
        {
            InitializeComponent();


            if(Igrabeli)
            {
                this.ZaKraljicu_btn.Image = Sah.Resursi.whitequeen;             
                this.ZaTopa_btn.Image = Sah.Resursi.whiterook;
                this.ZaLovca_btn.Image = Sah.Resursi.whitebishop;
                this.ZaKonja_btn.Image = Sah.Resursi.whiteknight;

            }
            else
            {
                this.ZaKraljicu_btn.Image = Sah.Resursi.blackqueen;
                this.ZaTopa_btn.Image = Sah.Resursi.blackrook;
                this.ZaLovca_btn.Image = Sah.Resursi.blackbishop;
                this.ZaKonja_btn.Image = Sah.Resursi.blackknight;

            }


        }

        private void ZaTopa_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ZaLovca_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ZaKonja_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ZaKraljicu_btn_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
