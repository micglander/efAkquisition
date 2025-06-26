using System;
using System.ComponentModel.DataAnnotations;

namespace efAkquisition
{
    public class ProjekteMetadata
    {
        [Display(Name = "Datum Angebot via Anbieter")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATUM_ANGEBOT;

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Erinnerung;

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? aktualisiert;

        [Display(Name = "aufgenommen am")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime aufgenommen_am;

        [Display(Name = "aktualisiert von")]
        public string geaendert_von;

        [Display(Name = "Titel")]
        public string TITEL_PROJEKT_FILM;

        [Display(Name = "Skript/Buch")]
        public string Script_Buch;

        [Display(Name = "US Release")]
        public string US_Release;

        [Display(Name = "Aktuelle Marktliste")]
        public Boolean Festival_akt;

        [Display(Name = "Status")]
        public Int32 StatusNr;

        [Display(Name = "Regisseur")]
        public Int32 RegisseurNr;

        [Display(Name = "Anbieter")]
        public Int32 AnbieterNr;

        [Display(Name = "zuständig")]
        public Int32 BearbeiterNr;

        [Display(Name="Drehbeginn / Projektstatus")]
        public string Drehbeginn;

        [Display(Name = "Projektart")]
        public Int32 ProjektartNr;

        [Display(Name = "Format")]
        public Int32 FormatNr;

        [Display(Name = "Lektoratseinschätzung")]
        public Int32 LENr;

        [Display(Name = "verkauft an")]
        public Int32 verkauft_an;

        [Display(Name = "IMDB Nr.")]
        public string ImdbNr;

        [Display(Name = "Age Rating")]
        public string Age_Rating;

        [Display(Name = "Kommentar")]
        public string Age_Rating_Kommentar;

        [Display(Name = "Kommentar")]
        public string Angebot;

        [Display(Name= "P&A")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> PandA;

        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> Admission;

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> Backing;

        [Display(Name = "Budget")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> BudgetX;

        [Display(Name = "Angebot")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> AngebotX;

        [Display(Name = "Asking")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> AskingX;

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> Kaufpreis;

        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> AngebotSchweiz;

        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> AskingSchweiz;

        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> KaufpreisSchweiz;


        [Display(Name = "Kommentar")]
        public string Budget_Kommentar;

        [Display(Name = "TV Kommentar")]
        public string TV_Einschaetzung_Kommentar;

        [DataType(DataType.MultilineText)]
        [Display(Name = "Logline")]
        public string Geschichte;

        [DataType(DataType.MultilineText)]
        public string Synopsis;

        [DataType(DataType.MultilineText)]
        public string Sonstiges;

        [Display(Name = "Beurteilung intern")]
        [DataType(DataType.MultilineText)]
        public string Beurteilung;

        [Display(Name = "Beurteilung Lektor")]
        [DataType(DataType.MultilineText)]
        public string Beurteilung_Lektor;
        

        [DataType(DataType.MultilineText)]
        public string Historie;

        [Display(Name = "Genres")]
        public string GenreString;

        [Display(Name = "Länder")]
        public string LandString;

        [Display(Name = "Themen")]
        public string ThemenString;

        [Display(Name = "Auswertungspotential")]
        public string AuswertungspotentialString;

        [Display(Name = "TV-Einschätzung")]
        public string TV_EinschaetzungString;

        [Display(Name = "Produktionsfirmen")]
        public string FirmenList;
    }
}
