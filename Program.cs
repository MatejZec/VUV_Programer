/*
 * -------------------------------------------------------------------------------------------------------
 * 
 * Autor: Matej Zec
 * Projekt: Natjecanje u programiranju
 * Predmet: Objektno-orijentirano programiranje
 * Ustanova: VUV
 * Godina: 2020/21.
 * 
 * -------------------------------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using ConsoleTables;

namespace VUV_programer
{
    

    class Program
    {
        private static string UnesiOIB()
        {
            while(true)
            {
                try
                {
                    string oib = Console.ReadLine();
                    
                    if (oib.Length == 0)
                    {
                        throw new ArgumentNullException("OIB ne smije biti prazan string!");
                    }
                    else if (oib.All(char.IsDigit) == false)
                    {
                        throw new ArgumentException("OIB ne smije sadrzavati znakove ili slova!");
                    }
                    else if (oib.Length != 11)
                    {
                        throw new ArgumentException("OIB se mora sastojati od tocno 11 brojeva!");
                    }
                    else
                    {
                        return oib;
                    }
                }       
                catch (Exception e)
                {
                    UpisIznimkeUdatoteku(e.Message);
                    Console.WriteLine(e.Message);
                    Console.Write("Pogresan Unos! \nPonovi unos: ");
                }
            }    
        }

        static string UnesiString() 
        {
            while (true)
            {
                try
                {
                    string unos = Console.ReadLine();
                    if (unos.Length == 0)
                    {
                        throw new ArgumentNullException("Uneseni string ne smije biti prazan!");
                    }
                    else
                    {
                        return unos;
                    }                   
                }
                catch (Exception e)
                {
                    UpisIznimkeUdatoteku(e.Message);
                    Console.WriteLine(e.Message);
                    Console.Write("Pogresan Unos! \nPonovi unos: ");
                }
            }
        }

        static string UnesiBrojTel()
        {
            while (true)
            {
                try
                {
                    string unos = Console.ReadLine();
                    if (unos.Length == 0)
                    {
                        throw new ArgumentNullException("Broj telefona ne smije biti prazan!");
                    }
                    else if (unos.All(char.IsDigit) == false)
                    {
                        throw new ArgumentException("Broj telefona ne smije sadrzavati slova ili znakove!");
                    }
                    else
                    {
                        return unos;
                    }
                }
                catch (Exception e)
                {
                    UpisIznimkeUdatoteku(e.Message);
                    Console.WriteLine(e.Message);
                    Console.Write("Pogresan Unos! \nPonovi unos: ");
                }
            }
        }


        private static void AzuriranjeDatotekeZaNatjecatelje(List<Natjecatelj> natjecateljs, string putanja_dat_osobe)
        {
            //prebrisavanje datoteke sa vrijednostima u listi
                XmlDocument xmlObject = XMLLOAD(putanja_dat_osobe);
                XmlNode natjecateljiNode = xmlObject.SelectSingleNode("//osobe/natjecatelji");
                natjecateljiNode.RemoveAll();
                foreach(Natjecatelj natjecatelj in natjecateljs)
                {
                    XmlNode natjecatelj_Node = xmlObject.CreateNode(XmlNodeType.Element, "natjecatelj", null);
                    XmlAttribute ime_atr = xmlObject.CreateAttribute("ime");
                    ime_atr.Value = natjecatelj.Ime;
                    natjecatelj_Node.Attributes.Append(ime_atr);
                    XmlAttribute prezime_atr = xmlObject.CreateAttribute("prezime");
                    prezime_atr.Value = natjecatelj.Prezime;
                    natjecatelj_Node.Attributes.Append(prezime_atr);
                    XmlAttribute dob_atr = xmlObject.CreateAttribute("dob");
                    dob_atr.Value = natjecatelj.DOB;
                    natjecatelj_Node.Attributes.Append(dob_atr);
                    XmlAttribute id_atr = xmlObject.CreateAttribute("id");
                    id_atr.Value = natjecatelj.OsobaID;
                    natjecatelj_Node.Attributes.Append(id_atr);
                    XmlAttribute id_tima_atr = xmlObject.CreateAttribute("idTima");
                    id_tima_atr.Value = natjecatelj.IdTima;
                    natjecatelj_Node.Attributes.Append(id_tima_atr);
                    natjecateljiNode.AppendChild(natjecatelj_Node);
                }
                xmlObject.Save(putanja_dat_osobe);
        }

        private static void AzuriranjeDatotekeZaKapetane(List<KapetanTima> kapetanTimas, string putanja_dat_osobe)
        {
            //prebrisavanje datoteke sa vrijednostima u listi
            XmlDocument xmlObject = XMLLOAD(putanja_dat_osobe);
            XmlNode kapetaniTimaNode = xmlObject.SelectSingleNode("//osobe/kapetaniTima");
            kapetaniTimaNode.RemoveAll();
            foreach (KapetanTima kapetan in kapetanTimas)
            {
                XmlNode kapetanTima_Node = xmlObject.CreateNode(XmlNodeType.Element, "kapetanTima", null);
                XmlAttribute ime_atr = xmlObject.CreateAttribute("ime");
                ime_atr.Value = kapetan.Ime;
                kapetanTima_Node.Attributes.Append(ime_atr);
                XmlAttribute prezime_atr = xmlObject.CreateAttribute("prezime");
                prezime_atr.Value = kapetan.Prezime;
                kapetanTima_Node.Attributes.Append(prezime_atr);
                XmlAttribute dob_atr = xmlObject.CreateAttribute("dob");
                dob_atr.Value = kapetan.DOB;
                kapetanTima_Node.Attributes.Append(dob_atr);
                XmlAttribute id_atr = xmlObject.CreateAttribute("id");
                id_atr.Value = kapetan.OsobaID;
                kapetanTima_Node.Attributes.Append(id_atr);
                XmlAttribute id_tima_atr = xmlObject.CreateAttribute("idTima");
                id_tima_atr.Value = kapetan.IdTima;
                kapetanTima_Node.Attributes.Append(id_tima_atr);
                kapetaniTimaNode.AppendChild(kapetanTima_Node);
            }
            xmlObject.Save(putanja_dat_osobe);
        }

        private static void AzuriranjeDatotekeTimovi(List<Tim> tims, string putanja_dat_tim) 
        {
            //prebrisavanje datoteke sa vrijednostima u listi
            XmlDocument xmlObject = XMLLOAD(putanja_dat_tim);
            XmlNode timNode = xmlObject.SelectSingleNode("//timovi");
            timNode.RemoveAll();
            foreach (Tim tim in tims)
            {
                XmlNode noviTimNode = xmlObject.CreateNode(XmlNodeType.Element, "tim", null);
                XmlAttribute id_atribut = xmlObject.CreateAttribute("id");
                id_atribut.Value = tim.ID;
                noviTimNode.Attributes.Append(id_atribut);
                XmlAttribute ime_atribut = xmlObject.CreateAttribute("ime");
                ime_atribut.Value = tim.ImeTima;
                noviTimNode.Attributes.Append(ime_atribut);
                XmlAttribute kapetanId_atribut = xmlObject.CreateAttribute("kapetanID");
                kapetanId_atribut.Value = tim.Kapetan.OsobaID;
                noviTimNode.Attributes.Append(kapetanId_atribut);
                XmlAttribute kontakt_atribut = xmlObject.CreateAttribute("kontakt");
                kontakt_atribut.Value = tim.Kontakt;
                noviTimNode.Attributes.Append(kontakt_atribut);
                XmlAttribute institucija_atribut = xmlObject.CreateAttribute("institucija");
                institucija_atribut.Value = tim.Institucija;
                noviTimNode.Attributes.Append(institucija_atribut);
                XmlAttribute neaktivan_atribut = xmlObject.CreateAttribute("neaktivan");
                neaktivan_atribut.Value = tim.Neaktivan.ToString();
                noviTimNode.Attributes.Append(neaktivan_atribut);
                

                for (int i = 0; i < tim.Natjecatelji.Count; i++)
                {
                    XmlNode natjecatelj_node = xmlObject.CreateNode(XmlNodeType.Element, "natjecatelj", null);
                    XmlAttribute natjecatelj_id_atribut = xmlObject.CreateAttribute("id");
                    natjecatelj_id_atribut.Value = tim.Natjecatelji[i].OsobaID;
                    natjecatelj_node.Attributes.Append(natjecatelj_id_atribut);
                    noviTimNode.AppendChild(natjecatelj_node);
                }


                for (int i = 0; i < tim.SifreProgJezika.Count; i++)
                {
                    XmlNode sifra_node = xmlObject.CreateNode(XmlNodeType.Element, "sifra", null);
                    XmlAttribute sifra_atribut = xmlObject.CreateAttribute("sifra");
                    sifra_atribut.Value = tim.SifreProgJezika[i];
                    sifra_node.Attributes.Append(sifra_atribut);
                    noviTimNode.AppendChild(sifra_node);
                }

                timNode.AppendChild(noviTimNode);

            }
            xmlObject.Save(putanja_dat_tim);
        }


        private static void AzuriranjeTimova(List<Tim> tims, string putanja_dat_tim, List<Natjecatelj> natjecateljs, string putanja_dat_osobe, List<KapetanTima> kapetanTimas, Dictionary<string, string> prog_jezici)
        {
            Console.WriteLine("Trenutni timovi:");
            PregledSvihTimova(tims);
            string odabrani_tim_id = "";
            while (true)
            {
                Console.Write("Unesi ime tima za azuriranje: ");
                string odabrani_tim_ime = Console.ReadLine();
                foreach (Tim tim in tims)
                {
                    if (tim.ImeTima.ToLower() == odabrani_tim_ime.ToLower())
                    {
                        Console.WriteLine("Odabrani tim: {0} (ID {1})", tim.ImeTima, tim.ID);
                        odabrani_tim_id = tim.ID;
                        break;
                    }                   
                }
                if (odabrani_tim_id.Length != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Pogresan unos. Ne postoji tim {0}", odabrani_tim_ime);
                }
                
            }

            //provjera dali tim ima jos mjesta za u rosteru
            bool popunjen_tim = false;
            foreach (Tim tim in tims)
            {
                if (odabrani_tim_id == tim.ID)
                {
                    if (tim.Natjecatelji.Count + 1 == 4) // 1 zbog kapetana
                    {
                        popunjen_tim = true;
                    }
                }
            }

            Console.WriteLine("Opcije azuriranja:");
            Console.WriteLine("1 - Promijeni ime tima");
            Console.WriteLine("2 - Dodaj natjecatelja");
            Console.WriteLine("3 - Ukloni natjecatelja");
            Console.WriteLine("4 - Promijeni kapetana");
            Console.WriteLine("5 - Dodaj programski jezik");
            Console.WriteLine("6 - Ukloni programski jezik");
            Console.WriteLine("7 - Promjeni kontakt informacije");
            Console.Write("Odaberi opciju: ");
            int odabir = Convert.ToInt32(Console.ReadLine());
            switch (odabir)
            {
                case 1:
                    AzuriranjeImenaTima(tims, odabrani_tim_id, putanja_dat_tim);
                    break;
                case 2:
                    DodajNatjecatelja(tims, odabrani_tim_id, natjecateljs, putanja_dat_tim, popunjen_tim, putanja_dat_osobe);
                    break;
                case 3:
                    UkloniNatjecatelja(tims, odabrani_tim_id, natjecateljs, putanja_dat_tim, putanja_dat_osobe);
                    break;
                case 4:
                    PromijeniKapetana(tims, odabrani_tim_id, kapetanTimas, putanja_dat_tim, putanja_dat_osobe);
                    break;
                case 5:
                    DodajProgramskiJezik(tims, odabrani_tim_id, putanja_dat_tim, prog_jezici);
                    break;
                case 6:
                    UkloniProgramskiJezik(tims, odabrani_tim_id, putanja_dat_tim, prog_jezici);
                    break;
                case 7:
                    PromijeniKontakInformacije(tims, odabrani_tim_id, putanja_dat_tim);
                    break;
                default:
                    break;
            }
            //samo jedan meni i ako je tim stacked i odabere se dodaj samo izbacis poruku 
        }

        private static void PromijeniKontakInformacije(List<Tim> tims, string odabrani_tim_id, string putanja_dat_tim)
        {
            //azuriranje liste sa novim imenom odredjenog tima
            foreach (Tim tim in tims)
            {
                if (tim.ID == odabrani_tim_id)
                {
                    Console.WriteLine("Trenuntni kontakt e-mail tima: " + tim.Kontakt);
                    Console.Write("Unesi novi e-mail: ");
                    string novoKontakt = Console.ReadLine();
                    tim.Kontakt = novoKontakt;
                    break;
                }
            }

            AzuriranjeDatotekeTimovi(tims, putanja_dat_tim);
        }

        private static void UkloniProgramskiJezik(List<Tim> tims, string odabrani_tim_id, string putanja_dat_tim, Dictionary<string, string> prog_jezici)
        {
            bool uspjesno_uklanjanje_prog_jezika = false;
            string sifra_jez_za_uklanjanje;
            foreach (Tim tim in tims)
            {
                if (tim.ID == odabrani_tim_id)
                {
                    Console.WriteLine("Jezici u kojima se tim trenutacno natjece:");
                    foreach (KeyValuePair<string, string> kp in prog_jezici)
                    {
                        for (int i = 0; i < tim.SifreProgJezika.Count; i++)
                        {
                            if (kp.Key == tim.SifreProgJezika[i])
                            {
                                Console.WriteLine("Sifra: {0}, Programski jezik: {1}", kp.Key, kp.Value);
                            }
                        }
                    }
                    while (true)
                    {
                        Console.Write("Unesi sifru programskog jezika sa liste: ");
                        sifra_jez_za_uklanjanje = Console.ReadLine();
                        sifra_jez_za_uklanjanje = sifra_jez_za_uklanjanje.ToUpper();
                        foreach (string sifra in tim.SifreProgJezika)
                        {
                            if (sifra == sifra_jez_za_uklanjanje)
                            {
                                tim.SifreProgJezika.Remove(sifra);
                                AzuriranjeDatotekeTimovi(tims, putanja_dat_tim);
                                uspjesno_uklanjanje_prog_jezika = true;
                                break;
                            }
                        }
                        if (uspjesno_uklanjanje_prog_jezika)
                        {
                            Console.WriteLine("Programski jezik uklonjen!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pogresan unos! Pokusaj ponovo");
                        }
                    }
                }
            }
        }

        private static void DodajProgramskiJezik(List<Tim> tims, string odabrani_tim_id, string putanja_dat_tim, Dictionary<string, string> prog_jezici)
        {
            List<string> lista_mogucih_prog_jezika = new List<string>();
            bool uspjesno_dodavanje_prog_jezika = false;
            foreach (Tim tim in tims)
            {
                if (tim.ID == odabrani_tim_id)
                {
                    Console.WriteLine("Jezici u kojima se tim trenutacno natjece:");
                    foreach (KeyValuePair<string, string> kp in prog_jezici)
                    {
                        int cnt = 0;
                        for (int i = 0; i < tim.SifreProgJezika.Count; i++)
                        {
                            if (kp.Key == tim.SifreProgJezika[i])
                            {
                                Console.WriteLine("Sifra: {0}, Programski jezik: {1}", kp.Key, kp.Value);
                            }
                            else
                            {
                                cnt += 1;
                            }
                        }
                        if (cnt == tim.SifreProgJezika.Count)
                        {
                            lista_mogucih_prog_jezika.Add(kp.Key);
                            if (lista_mogucih_prog_jezika.Count == prog_jezici.Count)
                            {
                                Console.WriteLine("N/A");
                            }
                        }
                    }
                    Console.WriteLine("Odaberite programski jezik sa liste");
                    foreach (string jezik in lista_mogucih_prog_jezika)
                    {
                        foreach (KeyValuePair<string, string> p in prog_jezici)
                        {
                            if (jezik == p.Key)
                            {
                                Console.WriteLine("Sifra: {0}, Programski jezik: {1}", p.Key, p.Value);
                            }
                        }
                    }
                    while (true)
                    {
                        Console.Write("Unesi sifru jezika: ");
                        string novi_prog_jez = Console.ReadLine();
                        novi_prog_jez = novi_prog_jez.ToUpper();
                        foreach (string prog_jezik in lista_mogucih_prog_jezika)
                        {
                            if (novi_prog_jez == prog_jezik)
                            {
                                tim.SifreProgJezika.Add(novi_prog_jez);
                                AzuriranjeDatotekeTimovi(tims, putanja_dat_tim);
                                uspjesno_dodavanje_prog_jezika = true;
                            }
                        }
                        if (uspjesno_dodavanje_prog_jezika)
                        {
                            Console.WriteLine("Programski jezik dodan!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pogresan unos! Pokusaj ponovo.");
                            //lista_mogucih_prog_jezika.Clear();
                        }
                    }
                }
            }

        }

        private static void PromijeniKapetana(List<Tim> tims, string odabrani_tim_id, List<KapetanTima> kapetanTimas, string putanja_dat_tim, string putanja_dat_osobe)
        {
            bool uspjesna_promjena_kapetana = false;
            foreach(Tim tim in tims)
            {
                if (tim.ID == odabrani_tim_id)
                {
                    Console.WriteLine("Trenutacni kapetan: " + tim.Kapetan.Ime + " " + tim.Kapetan.Prezime);
                    while (true)
                    {
                        int cnt = 0;
                        Console.WriteLine("Izaberi novog kapetana sa liste:");
                        foreach (KapetanTima kapetan in kapetanTimas)
                        {
                            if (kapetan.IdTima.Length == 0)
                            {
                                cnt++;
                                Console.WriteLine(kapetan.Ime + " " + kapetan.Prezime + " ID: " + kapetan.OsobaID);
                            }
                        }

                        if (cnt != 0)
                        {
                            Console.Write("Unesi ID kapetana sa liste: ");
                            string id_novog_kapitena = Console.ReadLine();

                            foreach (KapetanTima kapetan_stari in kapetanTimas) //uklanjanje id tima starog kapetana
                            {
                                if (kapetan_stari.IdTima == tim.ID)
                                {
                                    kapetan_stari.IdTima = "";
                                    AzuriranjeDatotekeZaKapetane(kapetanTimas, putanja_dat_osobe);
                                }
                            }

                            foreach (KapetanTima kapetan_novi in kapetanTimas)
                            {
                                if (kapetan_novi.OsobaID == id_novog_kapitena)
                                {
                                    tim.Kapetan = kapetan_novi;
                                    kapetan_novi.IdTima = tim.ID;
                                    AzuriranjeDatotekeTimovi(tims, putanja_dat_tim);
                                    AzuriranjeDatotekeZaKapetane(kapetanTimas, putanja_dat_osobe);
                                    uspjesna_promjena_kapetana = true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nema dostupnih kapetana");
                            break;
                        }

                        
                        if (uspjesna_promjena_kapetana)
                        {
                            Console.WriteLine("Kapetan promijenjen!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pogresan unos ID. Pokusaj ponovno.");
                        }
                    }
                }
            }
            
            
        }

        private static void UkloniNatjecatelja(List<Tim> tims, string odabrani_tim_id, List<Natjecatelj> natjecateljs, string putanja_dat_tim, string putanja_dat_osobe)
        {
            Console.WriteLine("Trenutacni natjecatelji u timu:");
            foreach(Tim tim in tims)
            {
                if (tim.ID == odabrani_tim_id)
                {
                    for (int i = 0; i < tim.Natjecatelji.Count; i++)
                    {
                        Console.WriteLine("{0} {1}  ID: {2}", tim.Natjecatelji[i].Ime, tim.Natjecatelji[i].Prezime, tim.Natjecatelji[i].OsobaID);
                    }
                }
            }

            string id_natjecatelja_za_ukloniti = "";
            bool uspjesno_uklanjanje = false;
            while (true)
            {
                Console.Write("Unesi ID natjecatelja sa liste: ");
                id_natjecatelja_za_ukloniti = Console.ReadLine();
                foreach (Tim tim in tims)
                {
                    foreach (Natjecatelj natjecatelj in natjecateljs)
                    {
                        if (natjecatelj.OsobaID == id_natjecatelja_za_ukloniti)
                        {
                            tim.Natjecatelji.Remove(natjecatelj);
                            natjecatelj.IdTima = "";
                            AzuriranjeDatotekeTimovi(tims, putanja_dat_tim);
                            AzuriranjeDatotekeZaNatjecatelje(natjecateljs, putanja_dat_osobe);
                            uspjesno_uklanjanje = true;
                        }
                    }
                }
                if (uspjesno_uklanjanje == false)
                {
                    Console.WriteLine("Pogresan unos ID-a. Pokusaj ponovo");
                }
                else
                {
                    Console.WriteLine("Natjecatelj uklonjen iz tima!");
                    break;
                }
            }
        }

        private static void DodajNatjecatelja(List<Tim> tims, string odabrani_tim_id, List<Natjecatelj> natjecateljs, string putanja_dat_tim, bool popunjen_tim, string putanja_dat_osobe)
        {
            if (popunjen_tim == false)
            {
                Console.WriteLine("Natjecatelji bez tima:");
                foreach (Natjecatelj natjecatelj in natjecateljs) //petlja ispisuje sve natjecatelje koji nemaju tim_id
                {
                    if (natjecatelj.IdTima.Length == 0)
                    {
                        Console.WriteLine(natjecatelj.Ime + " " + natjecatelj.Prezime + " ID: " + natjecatelj.OsobaID);
                    }
                }

                string id_nat_za_dod = "";
                bool uspjesno_dodavanje = false;
                while (true)
                {
                    Console.Write("Unesi ID natjecatelja sa liste: ");
                    id_nat_za_dod = Console.ReadLine();
                    foreach (Natjecatelj natjecatelj in natjecateljs)
                    {
                        if (natjecatelj.IdTima.Length == 0 & natjecatelj.OsobaID == id_nat_za_dod) //ako natjecatelj nema tim i id se podudara sa id_nat_za dod
                        {
                            foreach (Tim tim in tims) //ide po timovima
                            {
                                if (tim.ID == odabrani_tim_id) //matchira odabrani tim preko id -> i u listu natjecatelja mu doda novog natjecatelja
                                {
                                    tim.Natjecatelji.Add(natjecatelj);
                                    AzuriranjeDatotekeTimovi(tims, putanja_dat_tim);
                                    natjecatelj.IdTima = odabrani_tim_id; //dodavanje id_tima natjecatelju
                                    AzuriranjeDatotekeZaNatjecatelje(natjecateljs, putanja_dat_osobe);
                                    uspjesno_dodavanje = true;
                                    Console.WriteLine("Natjecatelj dodan!");
                                    break;
                                }
                            }
                        }
                    }
                    if (uspjesno_dodavanje == false)
                    {
                        Console.WriteLine("Pogresan unos ID-a. Pokusaj ponovo");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else //ako je tim pun gornji dio koda se nece izvrsit
            {
                Console.WriteLine("Tim (ID {0}) je pupunjen", odabrani_tim_id);
                Console.Write("Zelite li kreirati novi tim? (da/ne): ");
                string odluka = Console.ReadLine();
                if (odluka.ToLower() == "da")
                {
                    DodavanjeTimova(tims, putanja_dat_tim);
                    Console.WriteLine("Tim dodan!");
                }
            }

        }

        private static void AzuriranjeImenaTima(List<Tim> tims, string odabrani_tim_id, string putanja_dat_tima)
        {
            //azuriranje liste sa novim imenom odredjenog tima
            foreach (Tim tim in tims)
            {
                if (tim.ID == odabrani_tim_id)
                {
                    Console.WriteLine("Trenuno ime tima: " + tim.ImeTima);
                    Console.Write("Unesi novo ime: ");
                    string novoIme = Console.ReadLine();
                    tim.ImeTima = novoIme;
                    break;
                }
            }

            AzuriranjeDatotekeTimovi(tims, putanja_dat_tima);
        }

        private static void DodavanjeOsoba(string putanja_dat_osobe, List<Natjecatelj> natjecateljs, List<KapetanTima> kapetanTimas, List<Koordinator> koordinators, List<VoditeljNatjecanja> voditeljs, List<string> sifre_prog_jezika)
        {
            Console.WriteLine("\n\t1 - Dodavanje natjecatelja");
            Console.WriteLine("\n\t2 - Dodavanje kapetana tima");
            Console.WriteLine("\n\t3 - Dodavanje koordinatora natjecanja");
            Console.WriteLine("\n\t4 - Dodavanje voditelja natjecanja\n");
            int odabir;
            while (true)
            {
                Console.Write("Odaberite opciju: ");
                odabir = Convert.ToInt32(Console.ReadLine());
                if (odabir < 1 || odabir > 4)
                {
                    Console.WriteLine("Pogresan Unos! Pokusaj ponovo");
                }
                else
                {
                    break;
                }
            }
            
            if (odabir == 1)
            {
                Console.Write("Unesi ime natjecatelja: ");               
                string ime = UnesiString();
                Console.Write("Unesi prezime natjecatelja: ");               
                string prezime = UnesiString();
                Console.Write("Unesi datum rodjenja natjecatelja (dd.mm.yyyy): ");               
                string dob = UnesiString();
                Console.Write("Unesi OIB (11 brojeva): ");                
                string id = UnesiOIB();

                //dodavanje novokreirane osobe u listu
                natjecateljs.Add(new Natjecatelj(ime, prezime, dob, id, ""));

                AzuriranjeDatotekeZaNatjecatelje(natjecateljs, putanja_dat_osobe);
                Console.WriteLine("Natjecatelj dodan!");
            }
            else if (odabir == 2)
            {
                Console.Write("Unesi ime kapetana: ");
                string ime = UnesiString();
                Console.Write("Unesi prezime kapetana: ");
                string prezime = UnesiString();
                Console.Write("Unesi datum rodjenja kapetana (dd.mm.yyyy): ");
                string dob = UnesiString();
                Console.Write("Unesi OIB (11 brojeva): ");
                string id = UnesiOIB();

                //dodavanje novokreiranog kapetana u listu kapetans
                kapetanTimas.Add(new KapetanTima(ime, prezime, dob, id, ""));

                AzuriranjeDatotekeZaKapetane(kapetanTimas, putanja_dat_osobe);
                Console.WriteLine("Kapetan dodan");
            }

            else if (odabir == 3)
            {
                Console.Write("Unesi ime koordinatora: ");
                string ime = UnesiString();
                Console.Write("Unesi prezime koordinatora: ");
                string prezime = UnesiString();
                Console.Write("Unesi datum rodjenja koordinatora (dd.mm.yyyy): ");
                string dob = UnesiString();
                Console.Write("Unesi OIB koordinatora (11 brojeva): ");
                string id = UnesiOIB();
                Console.Write("Titula voditelja: ");
                string titula = UnesiString();
                Console.Write("Unesi kontakt br telefona koordinatora: ");
                string kontakt = UnesiBrojTel();
                Console.WriteLine("Programski jezik koordinatora:");
                foreach (string sifra in sifre_prog_jezika)
                {
                    Console.WriteLine(sifra);
                }
                Console.Write("Unesi sifru jednog od ponudjenih jezika: ");
                string jezik;
                bool zastavica = false;
                while (true)
                {
                    jezik = UnesiString();
                    foreach (string sifra in sifre_prog_jezika)
                    {
                        if (jezik.ToUpper() == sifra)
                        {
                            jezik = jezik.ToUpper();
                            zastavica = true;
                        }
                    }
                    if (zastavica) //ako je zastavica true uspjesno je unesena sifra jezika i moze se nastaviti
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pogresan Unos! Pokusaj ponovo.");
                    }
                }

                //dodavanje novo kreiranog koodrinatora u listu koridnators
                koordinators.Add(new Koordinator(ime, prezime, dob, id, titula, kontakt, jezik));

                //prebrisavanje datoteke sa vrijednostima u listi
                XmlDocument xmlObject = XMLLOAD(putanja_dat_osobe);
                XmlNode koordinatoriNode = xmlObject.SelectSingleNode("//koordinatori"); //selektiranje glavnog "root" cvora
                koordinatoriNode.RemoveAll(); //brisanje svih koordinatori cvorova i njihovih podcvorova
                foreach (Koordinator koordinator in koordinators) //za sve koordinatore u listi ponovna izgradnja atributa
                {
                    XmlNode koordinator_Node = xmlObject.CreateNode(XmlNodeType.Element, "koordinator", null); //kreiranje cvora
                    XmlAttribute ime_atr = xmlObject.CreateAttribute("ime"); //kreiranje atributa
                    ime_atr.Value = koordinator.Ime; //postavljanje vrijednosti atributa
                    koordinator_Node.Attributes.Append(ime_atr); //dodavanje atributa na cvor
                    XmlAttribute prezime_atr = xmlObject.CreateAttribute("prezime");
                    prezime_atr.Value = koordinator.Prezime;
                    koordinator_Node.Attributes.Append(prezime_atr);
                    XmlAttribute dob_atr = xmlObject.CreateAttribute("dob");
                    dob_atr.Value = koordinator.DOB;
                    koordinator_Node.Attributes.Append(dob_atr);
                    XmlAttribute id_atr = xmlObject.CreateAttribute("id");
                    id_atr.Value = koordinator.OsobaID;
                    koordinator_Node.Attributes.Append(id_atr);
                    XmlAttribute titula_atr = xmlObject.CreateAttribute("titula");
                    titula_atr.Value = koordinator.Titula;
                    koordinator_Node.Attributes.Append(titula_atr);
                    XmlAttribute kontakt_atr = xmlObject.CreateAttribute("kontakt");
                    kontakt_atr.Value = koordinator.Kontakt;
                    koordinator_Node.Attributes.Append(kontakt_atr);
                    XmlAttribute sifra_atr = xmlObject.CreateAttribute("sifra");
                    sifra_atr.Value = koordinator.SifraProgJezika;
                    koordinator_Node.Attributes.Append(sifra_atr);
                    koordinatoriNode.AppendChild(koordinator_Node); //dodavanje cvora na root cvor
                }
                xmlObject.Save(putanja_dat_osobe); //spremanje
                Console.WriteLine("Koordinator dodan!");
            }
            else if (odabir == 4)
            {
                Console.Write("Unesi ime voditelja: ");
                string ime = UnesiString();
                Console.Write("Unesi prezime voditelja: ");
                string prezime = UnesiString();
                Console.Write("Unesi datum rodjenja voditelja (dd.mm.yyyy): ");
                string dob = UnesiString();
                Console.Write("Unesi OIB voditelja (11  brojeva): ");
                string id = UnesiOIB();
                Console.Write("Titula voditelja: ");
                string titula = UnesiString();
                Console.Write("Unesi kontakt br telefona voditelja: ");
                string kontakt = UnesiBrojTel();

                //doavanje novokreiranog voditelja u istu
                voditeljs.Add(new VoditeljNatjecanja(ime, prezime, dob, id, titula, kontakt));

                //prebrisavanje datoteke sa vrijednostima u listi
                XmlDocument xmlObject = XMLLOAD(putanja_dat_osobe);
                XmlNode voditeljiNode = xmlObject.SelectSingleNode("//voditelji");
                voditeljiNode.RemoveAll();
                foreach (VoditeljNatjecanja voditelj in voditeljs)
                {
                    XmlNode voditelj_Node = xmlObject.CreateNode(XmlNodeType.Element, "voditelj", null);
                    XmlAttribute ime_atr = xmlObject.CreateAttribute("ime");
                    ime_atr.Value = voditelj.Ime;
                    voditelj_Node.Attributes.Append(ime_atr);
                    XmlAttribute prezime_atr = xmlObject.CreateAttribute("prezime");
                    prezime_atr.Value = voditelj.Prezime;
                    voditelj_Node.Attributes.Append(prezime_atr);
                    XmlAttribute dob_atr = xmlObject.CreateAttribute("dob");
                    dob_atr.Value = voditelj.DOB;
                    voditelj_Node.Attributes.Append(dob_atr);
                    XmlAttribute id_atr = xmlObject.CreateAttribute("id");
                    id_atr.Value = voditelj.OsobaID;
                    voditelj_Node.Attributes.Append(id_atr);
                    XmlAttribute titula_atr = xmlObject.CreateAttribute("titula");
                    titula_atr.Value = voditelj.Titula;
                    voditelj_Node.Attributes.Append(titula_atr);
                    XmlAttribute kontakt_atr = xmlObject.CreateAttribute("kontakt");
                    kontakt_atr.Value = voditelj.Kontakt;
                    voditelj_Node.Attributes.Append(kontakt_atr);
                    voditeljiNode.AppendChild(voditelj_Node);
                }
                xmlObject.Save(putanja_dat_osobe);
                Console.WriteLine("Voditelj dodan!");
            }
        }

        static void DodavanjeTimova(List<Tim> tims, string putanja_datoteke)
        {
            Console.WriteLine("\nDodavanje novog tima");
            Console.Write("\nUnesi ime tima: ");
            string ime_tima = UnesiString();
            Console.Write("Unesi instituciju kojoj tim pripada: ");
            string institucija = UnesiString();
            Console.Write("Unesite kontakt e-mail tima: ");
            string kontakt = UnesiString();
            bool neaktivan = false;

            //prazne liste natjecatelj i sifre prog jezika i placeholder kapetan bez informacija
            List<Natjecatelj> natjecatelji_prazna = new List<Natjecatelj>();
            //natjecatelji_prazna.Add(new Natjecatelj("", "", "", "", ""));
            List<string> sifre_prazna = new List<string>();
            //sifre_prazna.Add("");
            KapetanTima kapetan = new KapetanTima("","","","","");

            //generiranje id-a
            string id = "";
            while (true)
            {
                int cnt = 0;
                Random r = new Random();
                for (int i = 0; i < 3; i++)
                {
                    int a = r.Next(0, 9);
                    id += a.ToString();
                }
                //provjera jel generirani id jedinstven
                foreach (Tim tim in tims)
                {
                    if (tim.ID != id)
                    {
                        cnt++;
                    }
                }
                if (cnt == tims.Count)
                {
                    break;
                }
            }
            
            //dodavanje novog tima u listu
            tims.Add(new Tim(id, ime_tima, natjecatelji_prazna, sifre_prazna, kapetan, kontakt, institucija, neaktivan));

            AzuriranjeDatotekeTimovi(tims, putanja_datoteke);
            Console.WriteLine("Tim {0} dodan!", ime_tima);
        }

        static void Statistika(List<Tim> tims, Dictionary<string, string> programski_jezici)
        {
            Dictionary<string, string>.KeyCollection sifreProgJezika = programski_jezici.Keys; //kolekcija kljuceva iz rjecnika
            
            Dictionary<string, int> najzastupljeniji_prog_jezik = new Dictionary<string, int>(); //novi rjecnik string int -> int ce predstavljat zastupljenost
            foreach (string sifra in sifreProgJezika)
            {
                najzastupljeniji_prog_jezik.Add(sifra, 0); //sifre se uzimaju iz starog rjecnika , zastuplnenost na pocetku 0
            }

            foreach(Tim tim in tims) //petlja iterira kroz timove, podpetlja kroz sve jezika pojedinog tima i kad se matchiraju jezici sa kljucem rjecnika, zastupljenost se poveca 
            {
                for(int i = 0; i < tim.SifreProgJezika.Count; i++)
                {
                    if (najzastupljeniji_prog_jezik.ContainsKey(tim.SifreProgJezika[i]))
                    {
                        najzastupljeniji_prog_jezik[tim.SifreProgJezika[i]] += 1;
                    }
                }
            }

            Console.WriteLine("\n1. Najzastupljeniji programski jezik na natjecanju (najveci broj timova se natjece u njemu)");
            KeyValuePair<string, int> kp = najzastupljeniji_prog_jezik.First(); //.first -> uzme najvecu prvi par 
            foreach(KeyValuePair<string, int> p in najzastupljeniji_prog_jezik) //petlja pronalazi najveci 
            {
                if (p.Value > kp.Value)
                {
                    kp = p;
                }
            }
            Console.WriteLine("Najzastupljeniji programski jezik: " + kp.Key);

            //ispis
            Console.WriteLine("\n2. Broj timova po svakom programskom jeziku:");
            foreach(KeyValuePair<string, int> p in najzastupljeniji_prog_jezik)
            {
                Console.WriteLine("Programski jezik: " + p.Key + "\tBroj timova koji se natjece: " + p.Value);
            }
        }

        static void PretrazivanjeTimova(List<Tim> tims)
        {
            Console.Write("\nPretrazi timove: ");
            string pretrazivanje = Console.ReadLine();

            int cnt = 0; //counter pomocna varijabla
            foreach(Tim tim in tims)
            {
                if (tim.ImeTima.ToLower().Contains(pretrazivanje.ToLower())) //ako pronadje kljucnu rjec u imenu tima -> ispis tima preko konzolne tabele
                {
                    var table = new ConsoleTable("Naziv tima", "Clanovi tima", "Dob", "Kapetan tima",  "Kontakt", "Programski jezici", "Institucija");
                    string prog_jezici_tima = string.Join(",", tim.SifreProgJezika.ToArray()); //
                    table.AddRow(tim.ImeTima, tim.Kapetan.Ime + " " + tim.Kapetan.Prezime, tim.Kapetan.RacunajDob(), tim.Kapetan.Ime + " " + tim.Kapetan.Prezime, tim.Kontakt, prog_jezici_tima, tim.Institucija);
                    for (int i = 0; i < tim.Natjecatelji.Count; i++)
                    {
                        table.AddRow("", tim.Natjecatelji[i].Ime + " " + tim.Natjecatelji[i].Prezime, tim.Natjecatelji[i].RacunajDob(), "", "", "", "");
                    }
                    table.Write(Format.Alternative);
                    prog_jezici_tima = "";
                }
                else // inace povecaj kaunter
                {
                    cnt++;
                }
            }
            if (cnt == tims.Count) // ako je true znaci da nepostoji kljucna rijec u imenu ni jednog tima
            {
                Console.WriteLine("Ne postoji tim koji u sebi sadrzava " + pretrazivanje);
                Console.Write("Pokusaj ponovo? (da/ne): ");
                string odluka = Console.ReadLine();
                if (odluka.ToLower() == "da")
                {
                    PretrazivanjeTimova(tims); //rekurzija
                }
            }
        }

        static void PregledOrganizatoraNatjecanja(List<VoditeljNatjecanja> voditeljs, List<Koordinator> koordinators)
        {
            Console.WriteLine("Voditelj natjecanja:");

            //konzolna tabela
            var table = new ConsoleTable("Titula", "Ime", "Prezime", "Kontakt");
            foreach(VoditeljNatjecanja voditelj in voditeljs)
            {
                table.AddRow(voditelj.Titula, voditelj.Ime, voditelj.Prezime, voditelj.Kontakt);
            }
            table.Write(Format.Alternative);

            Console.WriteLine("\nKoordinatori natjecanja:");
            var table2 = new ConsoleTable("Titula", "Ime", "Prezime", "Programski jezik", "Kontakt");
            foreach(Koordinator koordinator in koordinators)
            {
                table2.AddRow(koordinator.Titula, koordinator.Ime, koordinator.Prezime, koordinator.SifraProgJezika, koordinator.Kontakt);
            }
            table2.Write(Format.Alternative);
        }

        static void PregledSvihTimova(List<Tim> tims)
        {           
            // SORTIRANJE LISTE TIMS PO BROJU PRIJAVLJENIH PROGRAMSKIH JEZIKA
            for(int i = 0; i < tims.Count; i++) //bubble sort
            {
                for (int o = 1; o <= i; o++)
                {
                    if (tims[o - 1].SifreProgJezika.Count < tims[o].SifreProgJezika.Count)
                    {
                        Tim temp = tims[o - 1];
                        tims[o - 1] = tims[o];
                        tims[o] = temp;
                    }
                }
            }
            //SORTIRANJE LISTE TIMS PO IMENU TIMA ABECEDNO
            for (int i = 0; i < tims.Count; i++)
            {
                for (int o = 1; o <= i; o++)
                {
                    if (tims[o - 1].SifreProgJezika.Count == tims[o].SifreProgJezika.Count)
                    {
                        if (String.Compare(tims[o - 1].ImeTima, tims[o].ImeTima) > 0)
                        {
                            Tim temp = tims[o - 1];
                            tims[o - 1] = tims[o];
                            tims[o] = temp;
                        }                        
                    }
                }
            }

            //konzolna tabela
            var table = new ConsoleTable("R.br.", "ID", "Naziv tima", "Clanovi tima", "Kapetan tima", "Kontakt", "Programski jezici", "Institucija");
            int redni_broj = 1;
            
            //pomocna string i lista za popunjavanje svih sifri programskih jezika za pojednican tim
            string sifre_svih_prog_jezika = "";
            List<string> lista_sifri_tim = new List<string>(); 
            foreach(Tim tim in tims)
            {
                for (int i = 0; i < tim.SifreProgJezika.Count; i++)
                {
                    sifre_svih_prog_jezika += tim.SifreProgJezika[i];
                    if (i != tim.SifreProgJezika.Count-1)
                        sifre_svih_prog_jezika += ", ";
                }
                lista_sifri_tim.Add(sifre_svih_prog_jezika);
                sifre_svih_prog_jezika = "";
            }

            //popunjavanje konzolne tabele, prva petlja ide po listi timova, drugo po indeksima natjecatelja u listi timova
            int j = 0;
            foreach (Tim tim in tims)
            {               
                table.AddRow(redni_broj, tim.ID, tim.ImeTima, tim.Kapetan.Ime + " " + tim.Kapetan.Prezime, tim.Kapetan.Ime + " " + tim.Kapetan.Prezime, tim.Kontakt, lista_sifri_tim[j], tim.Institucija);
                
                for (int i = 0; i < tim.Natjecatelji.Count; i++)
                {
                    table.AddRow("", "", "", tim.Natjecatelji[i].Ime + " " + tim.Natjecatelji[i].Prezime,"","","","");
                }
                redni_broj++;
                j++;
            }
            table.Write(Format.Alternative);

        }

        static void Pritisni_tipku(List<Tim> tims, List<VoditeljNatjecanja> voditeljs, List<Koordinator> koordinators, Dictionary<string, string> programski_jezici, string putanja_dat_tim, string putanja_dat_osobe, List<Natjecatelj> natjecateljs, List<KapetanTima> kapetanTimas, List<string> sifre_prog_jezika)
        {
            Console.WriteLine("\nPritisni tipku 'Enter' za povratak u glavni izbornik ili tipku 'Esc' za prekid programa.");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey tipka = Console.ReadKey().Key;
                    if (tipka == ConsoleKey.Enter)
                    {
                        Izbornik(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                        break;
                    }
                    if (tipka == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Pritisni bilo koju tipku za nastavak...");
                        break;
                    }
                }
            }
        }

        static void Izbornik(List<Tim> tims, List<VoditeljNatjecanja> voditeljs, List<Koordinator> koordinators, Dictionary<string, string> programski_jezici, string putanja_dat_tim, string putanja_dat_osobe, List<Natjecatelj> natjecateljs, List<KapetanTima> kapetanTimas, List<string> sifre_prog_jezika)
        {
            Console.Clear();
            Console.WriteLine("#################### GLAVNI IZBORNIK ####################");
            Console.WriteLine("\n\t1 - Pregled svih timova");
            Console.WriteLine("\n\t2 - Pregled organizatora natjecananja");
            Console.WriteLine("\n\t3 - Dodavanje timova");
            Console.WriteLine("\n\t4 - Dodavanje osoba");
            Console.WriteLine("\n\t5 - Azuriranje timova");
            Console.WriteLine("\n\t6 - Brisanje timova");
            Console.WriteLine("\n\t7 - Pretrazivanje timova");
            Console.WriteLine("\n\t8 - Statistika\n");

            int odabir;
            while (true)
            {
                Console.Write("Odaberi opciju: ");
                odabir = Convert.ToInt32(Console.ReadLine());
                if (odabir < 1 || odabir > 8)
                {
                    Console.WriteLine("Pogresan Unos! Pokusaj ponovo");
                }
                else
                {
                    break;
                }
            }

            switch (odabir)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("#################### PREGLED TIMOVA ####################\n");
                    PregledSvihTimova(tims);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("#################### PREGLED ORGANIZATORA NATJECANJA ####################\n");
                    PregledOrganizatoraNatjecanja(voditeljs, koordinators);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("#################### DODAVANJE TIMOVA ####################");
                    DodavanjeTimova(tims, putanja_dat_tim);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("#################### DODAVANJE OSOBA ####################");
                    DodavanjeOsoba(putanja_dat_osobe, natjecateljs, kapetanTimas, koordinators, voditeljs, sifre_prog_jezika);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("#################### AZURIRANJE TIMOVA ####################\n");
                    AzuriranjeTimova(tims, putanja_dat_tim, natjecateljs, putanja_dat_osobe, kapetanTimas, programski_jezici);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("#################### BRISANJE TIMOVA ####################\n");
                    BrisanjeTimova(tims, putanja_dat_tim);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("#################### PRETRAZIVANJE TIMOVA ####################");
                    PretrazivanjeTimova(tims);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("#################### STATISTIKA ####################");
                    Statistika(tims, programski_jezici);
                    Pritisni_tipku(tims, voditeljs, koordinators, programski_jezici, putanja_dat_tim, putanja_dat_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);
                    break;
                default:
                    break;
            }


        }

        private static void BrisanjeTimova(List<Tim> tims, string putanja_dat_tim)
        {
            Console.WriteLine("Trenutni timovi:");
            PregledSvihTimova(tims);
            string odabrani_tim_id = "";
            while (true) //while za slucaj pogresnog unosa
            {
                Console.Write("Unesi ime tima za brisanje: "); 
                string odabrani_tim_ime = Console.ReadLine();
                foreach (Tim tim in tims) //petlja za matchiranje odabranog tima za brisanje u listi
                {
                    if (tim.ImeTima.ToLower() == odabrani_tim_ime.ToLower())
                    {
                        Console.WriteLine("Odabrani tim za brisanje: {0} (ID {1})", tim.ImeTima, tim.ID);
                        odabrani_tim_id = tim.ID; //ako se imena poklapaju pohrani id tima
                        break;
                    }
                }
                if (odabrani_tim_id.Length != 0) //ako odabrani timid nije null sto znaci da je uspjesno selektiran tim za brisanje break iz while
                {
                    break;
                }
                else //inace pokusaj ponovo
                {
                    Console.WriteLine("Pogresan unos. Ne postoji tim {0}", odabrani_tim_ime);
                }
            }
            Console.Write("Potvrdi brisanje tima (da/ne): ");
            string odluka = Console.ReadLine();
            if (odluka.ToLower() == "da")
            {
                foreach (Tim tim in tims) //selektiranje tima sa id za brisanje
                {
                    if (tim.ID == odabrani_tim_id) 
                    {
                        tim.Neaktivan = true; //"brisanje"
                        AzuriranjeDatotekeTimovi(tims, putanja_dat_tim); //azuriranje datoteke (salje joj se lista sa deaktiviranim timom)
                        Console.WriteLine("Tim obrisan!");
                        break;
                    }
                }
            }
        }

        static XmlDocument XMLLOAD(string path) //vraca xmldocument objekt za kreiranje xml-a programski
        {
            string xml = "";
            StreamReader sr = new StreamReader(path);
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            return xmlObject;
        }

        static void Main(string[] args)
        {
            //int b = UnesiBroj();

            // sifrarnik svih programskih jezika
            Dictionary<string, string> programski_jezici = new Dictionary<string, string>();
            programski_jezici.Add("CPP", "C plus plus");
            programski_jezici.Add("CSH", "C sharp");
            programski_jezici.Add("PYT", "Python");
            programski_jezici.Add("CPL", "C programski jezik");
            programski_jezici.Add("JAV", "JavaScript");
            programski_jezici.Add("CBL", "Cobol");
            programski_jezici.Add("FOR", "Fortran");

            // lista svih kljuceva prog jezika
            List<string> sifre_prog_jezika = new List<string>();
            Dictionary<string, string>.KeyCollection kljuceviJezika = programski_jezici.Keys; 
            foreach (string kj in kljuceviJezika)
            {
                sifre_prog_jezika.Add(kj);
            }

            try
            {
                //##################################### PUTANJE, XMLNODE LISTE I NJIHOVO POPUNJAVANJE ####################################################
                string path_osobe = @"C:\Users\Gratisfaction\source\repos\VUV_programer\VUV_programer\osobe.xml"; //path moguce nevalja
                string path_timovi = @"C:\Users\Gratisfaction\source\repos\VUV_programer\VUV_programer\timovi.xml";
                XmlNodeList natjecatelji = XMLLOAD(path_osobe).SelectNodes("//osobe/natjecatelji/natjecatelj");
                XmlNodeList kapetaniTima = XMLLOAD(path_osobe).SelectNodes("//osobe/kapetaniTima/kapetanTima");
                XmlNodeList koordinatori = XMLLOAD(path_osobe).SelectNodes("//osobe/koordinatori/koordinator");
                XmlNodeList voditelji = XMLLOAD(path_osobe).SelectNodes("//osobe/voditelji/voditelj");
                XmlNodeList timovi = XMLLOAD(path_timovi).SelectNodes("//timovi/tim");
                
                // prazne liste tipa objekt klasa koje su spremne za punjenje
                List<Natjecatelj> natjecateljs = new List<Natjecatelj>();
                List<KapetanTima> kapetanTimas = new List<KapetanTima>();
                List<Koordinator> koordinators = new List<Koordinator>();
                List<VoditeljNatjecanja> voditeljs = new List<VoditeljNatjecanja>();
                List<Tim> tims = new List<Tim>();

  
                // POPUNJAVANJE LISTE NATJECATELJA
                foreach (XmlNode natjecatelj in natjecatelji)
                {
                    natjecateljs.Add(new Natjecatelj(
                        natjecatelj.Attributes["ime"].Value,
                        natjecatelj.Attributes["prezime"].Value,
                        natjecatelj.Attributes["dob"].Value,
                        natjecatelj.Attributes["id"].Value,
                        natjecatelj.Attributes["idTima"].Value));
                }
                
                // POPUNJAVANJE LISTE KAPETANA
                foreach (XmlNode kapetanTima in kapetaniTima)
                {
                    kapetanTimas.Add(new KapetanTima(
                        kapetanTima.Attributes["ime"].Value,
                        kapetanTima.Attributes["prezime"].Value,
                        kapetanTima.Attributes["dob"].Value,
                        kapetanTima.Attributes["id"].Value,
                        kapetanTima.Attributes["idTima"].Value));
                }

                // POPUNJAVANJE LISTE KOORDINATORA
                foreach (XmlNode koordinator in koordinatori)
                {
                    foreach (string sifra in sifre_prog_jezika)
                    {
                        if (koordinator.Attributes["sifra"].Value == sifra)
                        {
                            koordinators.Add(new Koordinator(
                                koordinator.Attributes["ime"].Value,
                                koordinator.Attributes["prezime"].Value,
                                koordinator.Attributes["dob"].Value,
                                koordinator.Attributes["id"].Value,
                                koordinator.Attributes["titula"].Value,
                                koordinator.Attributes["kontakt"].Value,
                                sifra));
                        }                            
                    }
                }

                // POPUNJAVANJE LISTE VODITELJA               
                foreach (XmlNode voditelj in voditelji)
                {
                    voditeljs.Add(new VoditeljNatjecanja(
                        voditelj.Attributes["ime"].Value,
                        voditelj.Attributes["prezime"].Value,
                        voditelj.Attributes["dob"].Value,
                        voditelj.Attributes["id"].Value,
                        voditelj.Attributes["titula"].Value,
                        voditelj.Attributes["kontakt"].Value));
                }

                // pomocna lista za slanje odredjenih sifri objektima klase tim
                List<string> specificne_sifre = new List<string>();
                List<Natjecatelj> natjecatelji_specificnog_tima = new List<Natjecatelj>();

                // POPUNJAVANJE LISTE TIMOVA
                foreach (XmlNode tim in timovi)
                {
                    specificne_sifre.Clear();
                    natjecatelji_specificnog_tima.Clear();
                     foreach (XmlNode child in tim.SelectNodes("natjecatelj"))
                     {
                    
                        foreach (Natjecatelj n in natjecateljs)
                        {

                            if (child.Attributes["id"].Value == n.OsobaID)
                            {
                                natjecatelji_specificnog_tima.Add(n);
                              //  Console.WriteLine(natjecatelji_specificnog_tima.Count());
                            }
                        }
                    }
                    foreach (XmlNode child in tim.SelectNodes("sifra"))
                    {
                        foreach (string sifra in sifre_prog_jezika)
                        {
                            if (child.Attributes["sifra"].Value == sifra)
                            {
                                specificne_sifre.Add(sifra);
                            }
                        }

                    }


                    var kapetan_kite = new KapetanTima("","","","", "");
                    foreach(KapetanTima kT in kapetanTimas)
                    {
                        if (tim.Attributes["kapetanID"].Value == kT.OsobaID)
                        {
                            kapetan_kite = kT;
                        }
                    }
                    if (tim.Attributes["neaktivan"].Value == "False")
                    {
                        tims.Add(new Tim(
                                tim.Attributes["id"].Value,
                                tim.Attributes["ime"].Value,
                                new List<Natjecatelj>(natjecatelji_specificnog_tima),// natjecatelji_specificnog_tima,//Salje se kopija te liste
                                new List<string>(specificne_sifre),
                                kapetan_kite,
                                tim.Attributes["kontakt"].Value,
                                tim.Attributes["institucija"].Value,
                                Convert.ToBoolean(tim.Attributes["neaktivan"].Value)));
                    }
                    

                    /*
                    foreach (KapetanTima kT in kapetanTimas)
                    {
                        
                        if (tim.Attributes["kapetanID"].Value == kT.OsobaID)
                        {
                            
                            tims.Add(new Tim(
                                tim.Attributes["id"].Value,
                                tim.Attributes["ime"].Value,
                                new List<Natjecatelj>(natjecatelji_specificnog_tima),// natjecatelji_specificnog_tima,//Salje se kopija te liste, uglavnom neki je problem s pokazivacima pa je bolje poslati kopiju te liste
                                new List<string>(specificne_sifre),
                                kT,
                                tim.Attributes["kontakt"].Value,
                                tim.Attributes["institucija"].Value));
                        }
                        else if(tim.Attributes["kapetanID"].Value == "")
                        {                            
                            tims.Add(new Tim(
                                tim.Attributes["id"].Value,
                                tim.Attributes["ime"].Value,
                                new List<Natjecatelj>(natjecatelji_specificnog_tima),// natjecatelji_specificnog_tima,//Salje se kopija te liste, uglavnom neki je problem s pokazivacima pa je bolje poslati kopiju te liste
                                new List<string>(specificne_sifre),
                                kT,
                                tim.Attributes["kontakt"].Value,
                                tim.Attributes["institucija"].Value));
                        }
                    }
                    */
 
                }


                // TESTIRANJE LISTA
                //Console.WriteLine("kurac");
                /*foreach (Natjecatelj natjecatelj in natjecateljs)
                {
                    Console.WriteLine("ime:" + natjecatelj.Ime);
                    Console.WriteLine("prezime: " +natjecatelj.Prezime);
                }
                foreach (KapetanTima kT in kapetanTimas)
                {
                    Console.WriteLine("ime:" + kT.Ime);
                    Console.WriteLine("prezime: " + kT.Prezime);
                }*/
                /*
                foreach (Tim tim in tims)
                {
                    Console.WriteLine("ID: " + tim.ID);
                    Console.WriteLine("Ime tima: " + tim.ImeTima);
                    Console.WriteLine("Clanovi tima" + tim.Natjecatelji);
                    Console.WriteLine("Kapetan: " + tim.Kapetan.Prezime);
                    Console.WriteLine("Kontakt: " + tim.Kontakt);
                    Console.WriteLine("Prog. jezici: " + tim.SifreProgJezika);
                    Console.WriteLine("Institucija: " + tim.Institucija);
                    foreach (Natjecatelj n in tim.Natjecatelji)
                    {
                        Console.WriteLine(n.Ime + " " + n.Prezime);
                    }
                    foreach(string s in tim.SifreProgJezika)
                    {
                        Console.Write(s + " ");
                    }
                    
                }
                */


                // POZIV IZBORNIKA
                Izbornik(tims, voditeljs, koordinators, programski_jezici, path_timovi, path_osobe, natjecateljs, kapetanTimas, sifre_prog_jezika);      
            }
            catch (Exception e)
            {
                UpisIznimkeUdatoteku(e.Message);
                Console.WriteLine(e.Message);
            }

            


            Console.ReadKey();
        }

        private static void UpisIznimkeUdatoteku(string message)
        {
            string putanja = @"C:\Users\Gratisfaction\source\repos\VUV_programer\VUV_programer\Iznimke.txt";
            FileStream fs = new FileStream(putanja, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("[{0}] - {1}", DateTime.Now, message);
            sw.Close();
        }
    }
}
