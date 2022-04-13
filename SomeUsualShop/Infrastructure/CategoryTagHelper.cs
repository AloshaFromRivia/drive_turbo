using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SomeUsualShop.Models;

namespace SomeUsualShop.Infrastructure
{
    [HtmlTargetElement(Attributes = "categories-items")]
    public class CategoryTagHelper : TagHelper
    {
        private IRepository _repository;

        public CategoryTagHelper(IRepository repository)
        {
            _repository = repository;
        }
        
        [ViewContext]
        public ViewContext Context { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml(GenerateLink());
            foreach (Category item in _repository.Categories)
            {
                output.Content.AppendHtml(GenerateLink(item));
            }
        }

        private HtmlString GenerateLink(Category category)
        {

            TagBuilder tagBuilder = new TagBuilder("a");

            int id=-1;
            if (Context.HttpContext.Request.RouteValues.ContainsKey("id"))
            {
                id= Int32.Parse(Context.HttpContext.Request.RouteValues["id"].ToString());
            }
            
            tagBuilder.AddCssClass($"btn {(id==category.Id ? "btn-primary" : "btn-secondary")} btn-sm");
            tagBuilder.MergeAttribute("href", $"/Home/Catalog/{category.Id}");
            
            var writer = new StringWriter();
            tagBuilder.InnerHtml.SetContent(category.Name);
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        private HtmlString GenerateLink()
        {
            TagBuilder tagBuilder = new TagBuilder("a");

            tagBuilder.AddCssClass("btn btn-secondary btn-sm");
            tagBuilder.MergeAttribute("href", $"/Home/Catalog");
            
            var writer = new StringWriter();
            tagBuilder.InnerHtml.SetContent("Всё");
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}