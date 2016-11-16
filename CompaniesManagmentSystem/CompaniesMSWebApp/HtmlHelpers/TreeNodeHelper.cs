using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

using CompaniesMSWebApp.Models.CompaniesMS;

namespace CompaniesMSWebApp.HtmlHelpers
{
    public static class TreeNodeHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append(item);
                ul.InnerHtml.AppendHtml(li);
            }
            var writer = new StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        public static HtmlString BuildTree(this IHtmlHelper html, Company[] items)
        {
            var tree = BuildNestedNodes(items);

            return new HtmlString(tree);
        }

        private static string BuildNestedNodes(Company[] companies)
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("dashed");
            foreach (var company in companies)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append(company.Name);
                ul.InnerHtml.AppendHtml(li);
                if(company.Childs != null && company.Childs.Any())
                {
                    var nested = BuildNestedNodes(company.Childs.ToArray());
                    ul.InnerHtml.AppendHtml(nested);
                }
            }
            var writer = new StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);

            return writer.ToString();
        }
        
        //[Obsolete("Used as example for testing HtmlHelpers, no needed anymore.")]
        public static HtmlString CreateTree(this IHtmlHelper html, Company[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append(item.Name);
                ul.InnerHtml.AppendHtml(li);
            }
            var writer = new StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}