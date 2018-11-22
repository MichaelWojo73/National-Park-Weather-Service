using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int Count { get; set; }

        public string ParkCode { get; set; }

        public string ParkName { get; set; }

        [Required(ErrorMessage ="*")]
        [EmailAddress(ErrorMessage = "not a valid email")]
        public string EmailAddress { get; set; }

        public string State { get; set; }

        public string ActivityLevel { get; set; }


        public static IList<SelectListItem> states = new List<SelectListItem>()
        {
             new SelectListItem() { Text = "Please Select", Value = "Please select your state" },
            new SelectListItem() { Text = "Alabama - AL", Value = "AL" },
            new SelectListItem() { Text = "Alaska - AK", Value = "AK" },
            new SelectListItem() { Text = "Arizona - AZ", Value = "AZ" },
            new SelectListItem() { Text = "Arkansas - AR", Value = "AR" },
            new SelectListItem() { Text = "California - CA", Value = "CA" },
            new SelectListItem() { Text = "Colorado - CO", Value = "CO" },
            new SelectListItem() { Text = "Connecticut - CT", Value = "CT" },
            new SelectListItem() { Text = "Delaware - DE", Value = "DE" },
            new SelectListItem() { Text = "Florida - FL", Value = "FL" },
            new SelectListItem() { Text = "Georgia - GA", Value = "GA" },
            new SelectListItem() { Text = "Hawaii - HI", Value = "HI" },
            new SelectListItem() { Text = "Idaho - ID", Value = "ID" },
            new SelectListItem() { Text = "Illinois - IL", Value = "IL" },
            new SelectListItem() { Text = "Indiana - IN", Value = "IN" },
            new SelectListItem() { Text = "Iowa - IA", Value = "IA" },
            new SelectListItem() { Text = "Kansas - KS", Value = "KS" },
            new SelectListItem() { Text = "Kentucky - KY", Value = "KY" },
            new SelectListItem() { Text = "Louisiana - LA", Value = "LA" },
            new SelectListItem() { Text = "Maine - ME", Value = "ME" },
            new SelectListItem() { Text = "Maryland - MD", Value = "MD" },
            new SelectListItem() { Text = "Massachusetts - MA", Value = "MA" },
            new SelectListItem() { Text = "Michigan - MI", Value = "MI" },
            new SelectListItem() { Text = "Minnesota - MN", Value = "MN" },
            new SelectListItem() { Text = "Mississippi - MS", Value = "MS" },
            new SelectListItem() { Text = "Missouri - MO", Value = "MO" },
            new SelectListItem() { Text = "Montana - MT", Value = "MT" },
            new SelectListItem() { Text = "Nebraska - NE", Value = "NE" },
            new SelectListItem() { Text = "Nevada - NV", Value = "NV" },
            new SelectListItem() { Text = "New Hampshire - NH", Value = "NH" },
            new SelectListItem() { Text = "New Jersey - NJ", Value = "NJ" },
            new SelectListItem() { Text = "New Mexico - NM", Value = "NM" },
            new SelectListItem() { Text = "New York - NY", Value = "NY" },
            new SelectListItem() { Text = "North Carolina - NC", Value = "NC" },
            new SelectListItem() { Text = "North Dakota - ND", Value = "ND" },
            new SelectListItem() { Text = "Ohio - OH", Value = "OH" },
            new SelectListItem() { Text = "Oklahoma - OK", Value = "OK" },
            new SelectListItem() { Text = "Oregon - OR", Value = "OR" },
            new SelectListItem() { Text = "Pennsylvania - PA", Value = "PA" },
            new SelectListItem() { Text = "Rhode Island - RI", Value = "RI" },
            new SelectListItem() { Text = "South Carolina - SC", Value = "SC" },
            new SelectListItem() { Text = "South Dakota - SD", Value = "SD" },
            new SelectListItem() { Text = "Tennessee - TN", Value = "TN" },
            new SelectListItem() { Text = "Texas - TX", Value = "TX" },
            new SelectListItem() { Text = "Utah - UT", Value = "UT" },
            new SelectListItem() { Text = "Vermont - VT", Value = "VT" },
            new SelectListItem() { Text = "Virginia - VA", Value = "VA" },
            new SelectListItem() { Text = "Washington - WA", Value = "WA" },
            new SelectListItem() { Text = "West Virginia - WV", Value = "WV" },
            new SelectListItem() { Text = "Wisconsin - WI", Value = "WI" },
            new SelectListItem() { Text = "Wyoming - WY", Value = "WY" },
        };


        public static IList<SelectListItem> nationalPark = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Please select", Value = "Select" },
            new SelectListItem() { Text = "Cuyahoga Valley National Park", Value = "CVNP" },
            new SelectListItem() { Text = "Evergaldes National Park", Value = "ENP" },
            new SelectListItem() { Text = "Glacier National Park", Value = "GNP" },
            new SelectListItem() { Text = "Grand Canyon National Park", Value = "GCNP" },
            new SelectListItem() { Text = "Grand Teton National Park - CA", Value = "GTNP" },
            new SelectListItem() { Text = "Great Smoky Mountain National Park", Value = "GSMNP" },
            new SelectListItem() { Text = "Mount Rainier National Park", Value = "MRNP" },
            new SelectListItem() { Text = "Rocky Mountain National Park", Value = "RMNP" },
            new SelectListItem() { Text = "Yellowstone National Park", Value = "YNP" },
            new SelectListItem() { Text = "Yosemite National Park", Value = "YNP2" },

        };

    }
}
