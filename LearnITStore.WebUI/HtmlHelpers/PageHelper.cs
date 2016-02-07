using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnITStore.WebUI.Controllers;
using LearnITStore.WebUI.Models;

namespace LearnITStore.WebUI.HtmlHelpers
{
    public static class PageHelper
    {
        public static IEnumerable<T>
            Paginar<T>(this IEnumerable<T> items,
            int page,int pageSize)
        {
            return items.Skip(pageSize*(page - 1))
                .Take(pageSize);
        }

        public static MvcHtmlString Paginador
            (this HtmlHelper helper,PageInfo page,
            Func<int,string> ruta)
        {
            var result = "";
            for (int i = 1; i <= page.TotalPages; i++)
            {
                var elementoA = new TagBuilder("a");
                elementoA.MergeAttribute("href",ruta(i));
                elementoA.InnerHtml = i.ToString();

                if (i == page.Page)
                {
                    elementoA.AddCssClass("btn-primary");
                    elementoA.AddCssClass("selected");
                }
                elementoA.AddCssClass("btn btn-default");
                result += elementoA.ToString();                
            }
            return MvcHtmlString.Create(result);
        }                               
    }
}