using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUV_programer
{
    class Koordinator : Osoba
    {
        private string _titula;
        private string _kontakt;
        public string _sifra_prog_jezika;

        public Koordinator(string ime, string prezime, string dob, string osoba_id, string titula, string kontakt, string sifra_prog_jezika)
        {
            _ime = ime;
            _prezime = prezime;
            _dob = dob;
            _osoba_id = osoba_id;
            _titula = titula;
            _kontakt = kontakt;
            _sifra_prog_jezika = sifra_prog_jezika;
        }
        /*public Koordinator(string titula, string kontakt, List<String> sifre_prog_jezika)
        {
            _titula = titula;
            _kontakt = kontakt;
            _sifre_prog_jezika = sifre_prog_jezika;
        }*/
        public string Titula
        {
            get { return _titula; }
            set { _titula = value; }
        }
        public string Kontakt
        {
            get { return _kontakt; }
            set { _kontakt = value; }
        }
        public string SifraProgJezika
        {
            get { return _sifra_prog_jezika; }
            set { _sifra_prog_jezika = value; }
        }
    }
}
