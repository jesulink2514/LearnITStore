using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnITStore.WebUI.Models
{
    public class PageInfo
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)Total/PageSize);
            }
        }
    }
}