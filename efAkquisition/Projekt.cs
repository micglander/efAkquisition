using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace efAkquisition
{
    [MetadataType(typeof(ProjekteMetadata))]
    public partial class tbl_Projekte
    {
        // Version 3.0
        // zuständig
        public List<int> BearbeiterIds {
            get { return this.tbl_Bearbeiter1.Select(x => x.BearbeiterNr).ToList(); }
         }

        public IEnumerable<tbl_Bearbeiter> AllBearbeiter 
        {
            get
            {
                AkquiseEntities context = new AkquiseEntities();
                return context.tbl_Bearbeiter.ToList(); 
            }
        }
        


        public Nullable<int>[] Age_Rating_List
        {
            get
            {
                return new Nullable<int>[] { null, 0, 6, 12, 16, 18 };
            }
        }

        public string[] MPAA_List
        {
            get
            {
                return new string[] { String.Empty, "G", "PG", "PG-13", "R", "NC-17" };
            }
        }

        /// <summary>
        /// Platzhalter, um Lektorat zu setzen
        /// </summary>
        public System.Web.HttpPostedFileBase xLektorat
        { get; set; }

        public string LektoratExists
        {
            get
            {
                if (this.tbl_BlobProjekte == null || this.tbl_BlobProjekte.Lektorat == null)
                {
                    return "Lektorat";
                }
                else
                {
                    return "Lektorat (vorhanden)";
                }
            }
        }

        public System.Web.HttpPostedFileBase xVergleichsfilm
        { get; set;  }

        public string VergleichsfilmExists
        {
            get
            {
                if (this.tbl_BlobProjekte == null || this.tbl_BlobProjekte.Vergleichsfilm == null)
                {
                    return "Vergleichsfilm";
                }
                else
                {
                    return "Vergleichsfilm (vorhanden)";
                }
            }
        }

        public string Url
        {
            get
            {
                if (String.IsNullOrEmpty(this.ImdbNr))
                    return null;

                return String.Format("http://www.imdb.com/title/{0}", this.ImdbNr);
            }
        }

        public List<tbl_Personen> PersonenList
        {
            get
            {
                return this.tbl_ProjektPersonRel.OrderBy(x => x.FunktionNr).OrderBy(y => y.Prio).Select(z => z.tbl_Personen).ToList();
            }
        }

        public List<tbl_Personen> RegieList
        {
            get
            {
                return this.tbl_ProjektPersonRel.Where(x => x.FunktionNr == 1).OrderBy(y => y.Prio).Select(z => z.tbl_Personen).ToList();
            }
        }

        public List<tbl_Personen> ProduzentenList
        {
            get
            {
                return this.tbl_ProjektPersonRel.Where(x => x.FunktionNr == 2).OrderBy(y => y.Prio).Select(z => z.tbl_Personen).ToList();
            }
        }

        public List<tbl_Personen> ScriptList
        {
            get
            {
                return this.tbl_ProjektPersonRel.Where(x => x.FunktionNr == 3).OrderBy(y => y.Prio).Select(z => z.tbl_Personen).ToList();
            }
        }

        public List<tbl_Personen> BesetzungList
        {
            get
            {
                return this.tbl_ProjektPersonRel.Where(x => x.FunktionNr == 4).OrderBy(y => y.Prio).Select(z => z.tbl_Personen).ToList();
            }
        }

        public List<tbl_Firmen> FirmenList
        {
            get
            {
                return this.tbl_ProjektFirmaRel.OrderBy(x => x.Prio).Select(y => y.tbl_Firmen).ToList();
            }
        }

        public List<tbl_Links> LinksList
        {
            get
            {
                return this.tbl_Links.ToList();
            }
        }

        public string GenreString
        {
            get
            {
                string retval = String.Empty;
                List<tbl_ProjektGenreRel> liste = this.tbl_ProjektGenreRel.OrderBy(x => x.tbl_Genre.Sortierung).ToList();
                foreach (tbl_ProjektGenreRel rel in liste)
                {
                    retval = append(retval, rel.tbl_Genre.Genre, " / ");
                }
                return retval;
            }
        }

        public string PersonenString
        {
            get
            {
                string retval = String.Empty;
                List<tbl_ProjektPersonRel> liste = this.tbl_ProjektPersonRel.OrderBy(x => x.FunktionNr).OrderBy(x => x.Prio).ToList();
                foreach (tbl_ProjektPersonRel rel in liste)
                {
                    retval = append(retval, rel.tbl_Personen.Name, " / ");
                }
                return retval;
            }
        }

        public string LandString
        {
            get
            {
                string retval = String.Empty;
                List<tbl_ProjektLandRel> liste = this.tbl_ProjektLandRel.OrderBy(x => x.tbl_Land.Sortierung).ToList();
                foreach (var rel in liste)
                {
                    retval = append(retval, rel.tbl_Land.Land, " / ");
                }
                return retval;
            }
        }

        public string ProduktionsfirmenString
        {
            get
            {
                string retval = String.Empty;
                List<tbl_ProjektFirmaRel> liste = this.tbl_ProjektFirmaRel.OrderBy(x => x.Prio).ToList();
                foreach (tbl_ProjektFirmaRel rel in liste)
                {
                    retval = append(retval, rel.tbl_Firmen.Firma, " / ");
                }
                return retval;
            }
        }

        public string ThemenString
        {
            get
            {
                string retval = String.Empty;
                List<tbl_Themen> liste = this.tbl_Themen.OrderBy(x => x.ThemaID).ToList();
                foreach (tbl_Themen rel in liste)
                {
                    retval = append(retval, rel.Thema, " / ");
                }
                return retval;
            }
        }

        public string AuswertungspotentialString
        {
            get
            {
                string retval = String.Empty;
                List<tbl_ProjektAuswertungsArtRel> liste = this.tbl_ProjektAuswertungsArtRel.OrderBy(x => x.tbl_Auswertungsart.AuswertungsartNr).ToList();
                foreach (tbl_ProjektAuswertungsArtRel rel in liste)
                {
                    // Die Sternchen für die schicke Anzeige
                    string sternchen = rel.tbl_Auswertungsart.Auswertungsart + ": ";
                    for (int i = 0; i < rel.Potential; i++)
                    {
                        sternchen += "★";
                    }
                    retval = append(retval, sternchen, " / ");
                }
                return retval;
            }
        }

        public string TV_EinschaetzungString
        {
            get
            {
                string retval = String.Empty;
                List<tbl_TV_Einschaetzung> liste = this.tbl_TV_Einschaetzung.OrderBy(x => x.tbl_Sender.Sender).ToList();
                foreach (tbl_TV_Einschaetzung rel in liste)
                {
                    retval = append(retval, String.Format("{0}: {1}", rel.tbl_Sender.Sender, rel.Kommentar), " / ");
                }
                return retval;
            }
        }

        public string AskingString
        {
            get
            {
                string retval = String.Empty;

                if (this.AskingX.HasValue)
                    retval = String.Format("{0} {1}", this.AskingX.Value.ToString("N2"), this.tbl_AskingWE.Waehrung);

                if (this.AskingGSE)
                {
                    retval = String.Format("{0} GSE", retval);
                }
                else if (this.AskingSchweiz.HasValue)
                {
                    retval = String.Format("{0} + {1} Schweiz", retval, this.AskingSchweiz.Value.ToString("N3"));
                }

                return retval;
            }
        }

        public string AngebotString
        {
            get
            {
                string retval = String.Empty;

                if (this.AngebotX.HasValue)
                    retval = String.Format("{0} {1}", this.AngebotX.Value.ToString("N2"), this.tbl_AngebotWE.Waehrung);

                if (this.AngebotGSE)
                {
                    retval = String.Format("{0} GSE", retval);
                }
                else if (this.AngebotSchweiz.HasValue)
                {
                    retval = String.Format("{0} + {1} Schweiz", retval, this.AngebotSchweiz.Value.ToString("N3"));
                }

                return retval;
            }
        }

        public string KaufpreisString
        {
            get
            {
                string retval = String.Empty;

                if (this.Kaufpreis.HasValue)
                    retval = String.Format("{0} {1}", this.Kaufpreis.Value.ToString("N2"), this.tbl_KaufpreisWE.Waehrung);

                if (this.KaufpreisGSE)
                {
                    retval = String.Format("{0} GSE", retval);
                }
                else if (this.KaufpreisSchweiz.HasValue)
                {
                    retval = String.Format("{0} + {1} Schweiz", retval, this.KaufpreisSchweiz.Value.ToString("N3"));
                }

                return retval;
            }
        }

        protected string append(string alt, string dazu, string trenner)
        {
            if (String.IsNullOrEmpty(alt))
            {
                return dazu;
            }
            else
            {
                return alt + trenner + dazu;
            }
        }
    }
}
