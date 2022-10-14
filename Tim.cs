using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUV_programer
{
    class Tim 
    {
        private string _id;
        private string _ime_tima;
        private List<Natjecatelj> _natjecatelji; //
        private List<string> _sifre_prog_jezika; //
        private KapetanTima _kapetan;
        private string _kontakt;
        private string _institucija;
        private bool _neaktivan;

        public Tim( string id, string ime_tima, List<Natjecatelj> natjecatelji, List<string> sifre_prog_jezika, KapetanTima kapetan, string kontakt, string institucija, bool neaktivan)
        {
            _id = id;
            _ime_tima = ime_tima;
            _natjecatelji = natjecatelji;
            _sifre_prog_jezika = sifre_prog_jezika;
            _kapetan = kapetan;
            _kontakt = kontakt;
            _institucija = institucija;
            _neaktivan = neaktivan;
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ImeTima
        {
            get { return _ime_tima; }
            set { _ime_tima = value; }
        }
        public List<Natjecatelj> Natjecatelji
        {
            get { return _natjecatelji; }
            set { _natjecatelji = value; }
        }
        public List<string> SifreProgJezika
        {
            get { return _sifre_prog_jezika; }
            set { _sifre_prog_jezika = value; }
        }
        public KapetanTima Kapetan
        {
            get { return _kapetan; }
            set { _kapetan = value; }
        }
        public string Kontakt
        {
            get { return _kontakt; }
            set { _kontakt = value; }
        }
        public string Institucija
        {
            get { return _institucija; }
            set { _institucija = value; }
        }

        public bool Neaktivan
        {
            get { return _neaktivan; }
            set { _neaktivan = value; }
        }
    }
}
