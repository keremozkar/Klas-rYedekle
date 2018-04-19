using System;
using System.Windows.Forms;
using System.IO;


namespace KlasörYedekleme
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int x = 0; int Mov, mx, my;
        FolderBrowserDialog FolderBrows = new FolderBrowserDialog();
        string HangiKlasör, Nereye;
        long İlkKlasörBoyutu;
        bool byrk = false;
        int Sayimiz, Sıfırlama, ToplamYedek = 0;
        DateTime dt = new DateTime();
        private void KalanSüremiz_Tick(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue.ToString() == "True")
            {
             //   label1.Text = AlınanTarih.ToShortTimeString() + " ----" + KopyalancakTarih.ToShortTimeString() + " ------" + tmspan.ToString();
                tmspan--;

                KalanSüre.Caption = ya.ToString();
                //if (tmspan != 0)
                //{
                //    if (tmspan > 86400) KalanSüre.Caption = dt.AddSeconds(tmspan).ToString("dd" + " Gün " + "HH") + " Saat " + dt.AddSeconds(tmspan).ToString("mm" + " Dakika " + "ss") + " Saniye";
                //    else if (tmspan > 3600) KalanSüre.Caption = dt.AddSeconds(tmspan).ToString("HH") + " Saat " + dt.AddSeconds(tmspan).ToString("mm" + " Dakika " + "ss") + " Saniye";
                //    else if (tmspan > 60) KalanSüre.Caption = dt.AddSeconds(tmspan).ToString("mm" + " Dakika " + "ss") + " Saniye";
                //    else if (tmspan <= 60) KalanSüre.Caption = dt.AddSeconds(tmspan).ToString("ss") + " Saniye";
                //}
                //else if (tmspan <= 1)
                //{
                //    KopyalancakTarih = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                //    TimeSpan ya = KopyalancakTarih.AddDays(1) - AlınanTarih;
                //    tmspan = Convert.ToInt32(ya.TotalSeconds);
                //    KalanSüre.Caption = "00 Saniye";
                //    ToplamYedek++;
                //    TopYedekText.Caption = ToplamYedek.ToString() + " defa yedek yapıldı";
                //    backgroundWorker1.RunWorkerAsync();
                //}
            }
            else
            {
                Sayimiz--;
                if (Sayimiz != 0)
                {
                    if (Sayimiz > 86400) KalanSüre.Caption = dt.AddSeconds(Sayimiz).ToString("dd" + " Gün " + "HH") + " Saat " + dt.AddSeconds(Sayimiz).ToString("mm" + " Dakika " + "ss") + " Saniye";
                    else if (Sayimiz > 3600) KalanSüre.Caption = dt.AddSeconds(Sayimiz).ToString("HH") + " Saat " + dt.AddSeconds(Sayimiz).ToString("mm" + " Dakika " + "ss") + " Saniye";
                    else if (Sayimiz > 60) KalanSüre.Caption = dt.AddSeconds(Sayimiz).ToString("mm" + " Dakika " + "ss") + " Saniye";
                    else if (Sayimiz <= 60) KalanSüre.Caption = dt.AddSeconds(Sayimiz).ToString("ss") + " Saniye";
                }
                else if (Sayimiz <= 1)
                {
                    KalanSüre.Caption = "00 Saniye";
                    ToplamYedek++;
                    TopYedekText.Caption = ToplamYedek.ToString() + " defa yedek yapıldı";
                    backgroundWorker1.RunWorkerAsync();
                    Sayimiz = Sıfırlama;
                }
            }


        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (radioGroup1.SelectedIndex.ToString() == "0")
            //{
            //    Sayimiz = Sayimiz * 3600;
            //    MessageBox.Show(Sayimiz.ToString());

            //}
            //else if (radioGroup1.SelectedIndex.ToString() == "1")
            //{
            //    Sayimiz = Sayimiz * 60;
            //    MessageBox.Show(Sayimiz.ToString());
            //}
            //else if (radioGroup1.SelectedIndex.ToString() == "2")
            //{
            //    Sayimiz = Sayimiz * 1;
            //    MessageBox.Show(Sayimiz.ToString());
            /**/
            //}
        }
        private void Yedeklenecek_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrows = new FolderBrowserDialog();
            FolderBrows.ShowDialog();
            FolderBrows.ShowNewFolderButton = true;
            Nereye = FolderBrows.SelectedPath;
            YedeklemeYeri.EditValue = Nereye;
            DirectoryInfo dir = new DirectoryInfo(HangiKlasör);
            Nereye = Nereye + "\\" + dir.Name.ToString();

        }//Yedekleme Yeri

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Sayimiz = Convert.ToInt32(spinEdit1.Value.ToString());
            Sıfırlama = Convert.ToInt32(spinEdit1.Value.ToString());
        }


        private void vakit_Tick(object sender, EventArgs e)
        {
            saat.Caption = DateTime.Now.ToString();

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            KlasorKopyalamaSınıf.KlasorCopy(HangiKlasör, Nereye, true);


        }
        string AlınanTarih, KopyalancakTarih;
        private void timeEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void ribbonControl1_MouseUp(object sender, MouseEventArgs e)
        {
            Mov = 0;
        }

        private void ribbonControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Mov = 1;
            mx = e.X;
            my = e.Y;
        }
        TimeSpan ya;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AlınanTarih = timeEdit1.Time.ToShortTimeString();
            KopyalancakTarih = DateTime.Now.ToShortTimeString();
            ya = DateTime.Parse(AlınanTarih).Subtract(DateTime.Parse(KopyalancakTarih));
            label1.Text = ya.ToString();
            tmspan = Convert.ToInt32(ya.TotalSeconds);
            //KalanSüremiz.Start();
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue.ToString() == "True")
            {
                radioGroup1.Visible = false;
                spinEdit1.Visible = false;
                timeEdit1.Visible = true;
                byrk = true;
            }
            if (barEditItem1.EditValue.ToString() == "False")
            {
                radioGroup1.Visible = true;
                spinEdit1.Visible = true;
                timeEdit1.Visible = false;
                byrk = false;
            }
        }
        int tmspan;

        private void timer1_Tick(object sender, EventArgs e)
        {


            Sayimiz = tmspan;

        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DosyaKonumu.Enabled = true;
            YedeklemeYeri.Enabled = true;
            timeEdit1.Enabled = true;
            radioGroup1.Enabled = true;
            spinEdit1.Enabled = true;
            barEditItem1.Enabled = true;
            KalanSüre.Caption = "Yedekleme Sırası İptal Edildi";
            KalanSüremiz.Stop();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DosyaKonumu.Text != "Yedeklenecek Klasör Konumunu Seçiniz...." || YedeklemeYeri.Text != "Yedekleneceği Yeri Seçiniz....")
            {
                DosyaKonumu.Enabled = false;
                YedeklemeYeri.Enabled = false;
                timeEdit1.Enabled = false;
                radioGroup1.Enabled = false;
                spinEdit1.Enabled = false;
                barEditItem1.Enabled = false;
                if (byrk == true)
                {
                 //   AlınanTarih =timeEdit1.Time.ToLongTimeString();
                //    KopyalancakTarih = DateTime.Now.ToLongTimeString());
                   // if (AlınanTarih.ToShortTimeString() == "00:00") { AlınanTarih = Convert.ToDateTime("23:59:00"); }
                   // TimeSpan ya = AlınanTarih - KopyalancakTarih;
                 //   tmspan = Convert.ToInt32(ya.TotalSeconds);
                    KalanSüremiz.Start();

                }
                else
                {
                    Sayimiz = Convert.ToInt32(spinEdit1.Value.ToString());
                    Sıfırlama = Convert.ToInt32(spinEdit1.Value.ToString());
                    if (radioGroup1.SelectedIndex.ToString() == "0")
                    {
                        Sayimiz = Sayimiz * 3600;
                        Sıfırlama = Sayimiz;
                    }
                    else if (radioGroup1.SelectedIndex.ToString() == "1")
                    {
                        Sıfırlama = Sayimiz;
                        Sayimiz = Sayimiz * 60;
                    }
                    else if (radioGroup1.SelectedIndex.ToString() == "2")
                    {
                        Sıfırlama = Sayimiz;
                        Sayimiz = Sayimiz * 1;
                    }
                    KalanSüremiz.Start();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Alanları Kontrol Edini");
            }
        }

        private void DosyaKonumu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrows.ShowDialog();
            FolderBrows.ShowNewFolderButton = false;
            HangiKlasör = FolderBrows.SelectedPath;
            DosyaKonumu.EditValue = HangiKlasör;
            DirectoryInfo dir = new DirectoryInfo(HangiKlasör);
            İlkKlasörBoyutu = BoyutBul.Hesaplama(dir, true);
            DosyaBoyutu.Caption = "Dosyanızın Boyutu: " + BoyutBul.BytesToString(İlkKlasörBoyutu);


        }//Yedeklenecek Klasör

    }
}