using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUV_programer
{
    class VoditeljNatjecanja : Osoba
    {
        private string _titula;
        private string _kontakt;

        public VoditeljNatjecanja(string ime, string prezime, string dob, string osoba_id, string titula, string kontakt)
        {
            _ime = ime;
            _prezime = prezime;
            _dob = dob;
            _osoba_id = osoba_id;
            _titula = titula;
            _kontakt = kontakt;
        }
        /*public VoditeljNatjecanja(string titula, string kontakt)
        {
            _titula = titula;
            _kontakt = kontakt;
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
    }
}
