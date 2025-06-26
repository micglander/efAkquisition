using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace efAkquisition
{
    public partial class AkquiseEntities
    {
        // Alle auswählbaren Jobs
        public static IEnumerable<string> Jobs = (new string[5] { "Director", "Producer", "Writer", "Actor", "Actress" }).AsEnumerable<string>();

        public List<tbl_Land> Laender
        {
            get { return this.tbl_Land.OrderBy(x => x.Sortierung).ThenBy(x => x.Land).ToList<tbl_Land>(); }
        }

        public List<tbl_Personen> Personen
        {
            get { return this.tbl_Personen.OrderBy(x => x.Name).ToList<tbl_Personen>(); }
        }

        //public List<tbl_Personen> Regisseure
        //{
        //    get { return this.tbl_Personen.Where(x => (x.Job1 == "Director" || x.Job2 == "Director" || x.Job3 == "Director")).OrderBy(x => x.Name).ToList<tbl_Personen>(); }
        //}

        //public List<tbl_Personen> Produzenten
        //{
        //    get { return this.tbl_Personen.Where(x => (x.Job1 == "Producer" || x.Job2 == "Producer" || x.Job3 == "Producer")).OrderBy(x => x.Name).ToList<tbl_Personen>(); }
        //}

        //public List<tbl_Personen> Writer
        //{
        //    get { return this.tbl_Personen.Where(x => (x.Job1 == "Writer" || x.Job2 == "Writer" || x.Job3 == "Writer")).OrderBy(x => x.Name).ToList<tbl_Personen>(); }
        //}

        //public List<tbl_Personen> Darsteller
        //{
        //    get { return this.tbl_Personen.Where(x => (x.Job1 == "Actor" || x.Job2 == "Actor" || x.Job3 == "Actor" || x.Job1 == "Actress" || x.Job2 == "Actress" || x.Job3 == "Actress")).OrderBy(x => x.Name).ToList<tbl_Personen>(); }
        //}

        public List<tbl_Personen> GetAuswahl(int Funktion, string Name)
        {
            // Aus Performancegründen erst nach Namen filtern
            IQueryable<tbl_Personen> personen = this.tbl_Personen.Where(x => x.Matchname.Contains(Name));

            // Nach Funktion filtern
            // In Version 2.2 geändert
            //personen = personen.Where(x => (x.JobOne == Funktion || x.JobTwo == Funktion || x.JobThree == Funktion || x.PersonNr == 0)).OrderBy(x => x.Name);
            personen = personen.OrderBy(x => x.Name);

            return personen.ToList<tbl_Personen>();
        }
    }
}
