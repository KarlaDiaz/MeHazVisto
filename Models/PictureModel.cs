using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace MeHazVisto.Models
{
    public class PictureModel
    {
        [Required]
        public HttpPostedFileBase PictureFile { get; set; }
    }
}