using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUV_programer
{
    class KapetanTima : Osoba
    {
        private string _idTima;

        public KapetanTima(string ime, string prezime, string dob, string osoba_id, string idTima)
        {
            _ime = ime;
            _prezime = prezime;
            _dob = dob;
            _osoba_id = osoba_id;
            _idTima = idTima;

        }
        /*public Natjecatelj(string idTima)
        {
            _idTima = idTima;
        }*/

        
        public string IdTima
        {
            get { return _idTima; }
            set { _idTima = value; }
        }

        public string RacunajDob()
        {
            string novi = "";
            string[] b = DOB.Split('.');
            novi += b[2];
            novi += "/";
            novi += b[1];
            novi += "/";
            novi += b[0];

            DateTime dob = Convert.ToDateTime(novi);

            DateTime sad = DateTime.Now;

            int starost = 0;
            starost = sad.Year - dob.Year;
            if (sad.DayOfYear < dob.DayOfYear)
            {
                starost -= 1;
            }

            return starost.ToString();
        }
    }
}
