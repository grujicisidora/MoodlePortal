﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodlePortal
{
    public partial class UCStudent : UserControl
    {
        public Dictionary<int, String> studenti = new Dictionary<int, String>();
        AdminForm forma;
        public UCStudent(AdminForm forma)
        {
            InitializeComponent();
            this.forma = forma;
            listViewStudenti.Hide();
        }

        private void prikaziStudenteBtn_Click(object sender, EventArgs e)
        {
            studenti = RadSaBazom.SpisakStudenata();
           /* if (RadSaBazom.nadjiStudenta(639))
                MessageBox.Show("639 Postojii"); 
            else
                MessageBox.Show("639 Ne postoji"); */
            if (studenti.Count > 0)
            {
                listViewStudenti.Show();
                foreach (String podaci in studenti.Values)
                {

                    listViewStudenti.Items.Add(podaci);
                    //MessageBox.Show(prepisaniLekoviRecnik.Keys[0]);
                }
            }
            else
            {
                MessageBox.Show("Nema studenata!");
                //forma.Controls.Add(prethodniProzor);

            } 
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            int br_indeksa;
            String ime, prezime, email;

            br_indeksa = int.Parse(brindeksaBox.Text.ToString());
            ime = imeBox.Text.ToString();
            prezime = prezimeBox.Text.ToString();
            email = emailBox.Text.ToString();

            if(RadSaBazom.nadjiStudenta(br_indeksa))
            {
                MessageBox.Show("Ovaj student je vec u bazi!");
                return;
            }
            if (RadSaBazom.Insert(br_indeksa, ime, prezime, email))
                MessageBox.Show("Uspesno uneti podaci!");
            else
                MessageBox.Show("Greska!");
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int br_indeksa;

            if (indeksDeleteTxt.Text.Length>0)
                br_indeksa = int.Parse(indeksDeleteTxt.Text.ToString());
            else
            {
                MessageBox.Show("Unesite broj indeksa!");
                return;
            }
            if (RadSaBazom.nadjiStudenta(br_indeksa))
            {
                if (RadSaBazom.Obrisi(br_indeksa))
                {
                    MessageBox.Show("Uspesno obrisan student!");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom brisanja studenta iz baze!");
                }
            }
            else
                MessageBox.Show("Ne postoji student sa tim brojem indeksa!");
        }
    }
}
