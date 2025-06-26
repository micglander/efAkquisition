using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace efAkquisition
{

    //[MetadataType(typeof(ProjekteMetadata))]
    public partial class qry_ProjekteASP { }

    [MetadataType(typeof(AnbieterMetadata))]
    public partial class tbl_Anbieter
    {
        public string Projekte
        {
            get
            {
                string retval = String.Empty;

                foreach (tbl_Projekte projekt in this.tbl_Projekte)
                {
                    if (retval == String.Empty)
                    {
                        retval = projekt.TITEL_PROJEKT_FILM;
                    }
                    else
                    {
                        retval += "; " + projekt.TITEL_PROJEKT_FILM;
                    }
                }
                return retval;
            }
                
         }
    }

    public partial class tbl_Personen
    {
        public string Url
        {
            get
            {
                if (String.IsNullOrEmpty(this.ImdbID))
                    return null;

                return String.Format("http://www.imdb.com/name/{0}", this.ImdbID);
            }
        }

    }

    public partial class tbl_Firmen
    {
        public string Url
        {
            get
            {
                if (String.IsNullOrEmpty(this.ImdbID))
                    return null;

                return String.Format("http://www.imdb.com/company/{0}", this.ImdbID);
            }
        }

    }


    public partial class tbl_Regisseure
    {
        public string Projekte
        {
            get
            {
                string retval = String.Empty;

                foreach (tbl_Projekte projekt in this.tbl_Projekte)
                {
                    if (retval == String.Empty)
                    {
                        retval = projekt.TITEL_PROJEKT_FILM;
                    }
                    else
                    {
                        retval += "; " + projekt.TITEL_PROJEKT_FILM;
                    }
                }
                return retval;
            }
        }
    }
}
