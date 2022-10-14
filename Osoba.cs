using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUV_programer
{
    abstract class Osoba
    {
        internal string _ime;
        internal string _prezime;
        internal string _dob;
        internal string _osoba_id;

        /*public Osoba(string ime, string prezime, string dob, string osoba_id)
        {
            _ime = ime;
            _prezime = prezime;
            _dob = dob;
            _osoba_id = osoba_id;
        }*/

        public string Ime
        {
            get { return _ime ; }
            set { _ime = value; }
        }
        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }
        public string DOB 
        {
            get { return _dob; }
            set { _dob = value; }
        }
        public string OsobaID
        {
            get { return _osoba_id; }
            set { _osoba_id = value; }
        }
    }
}
