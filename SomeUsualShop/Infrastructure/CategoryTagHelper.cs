using System;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SomeUsualShop.Models;
using SomeUsualShop.Models.Interfaces;

namespace SomeUsualShop.Infrastructure
{
    [HtmlTargetElement(Attributes = "categories-items")]
    public class CategoryTagHelper : TagHelper
    {
        private ICategoryRepository _categories;

        public CategoryTagHelper(ICategoryRepository categories)
        {
            _categories = categories;
        }
        
        [ViewContext]
        public ViewContext Context { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml(GenerateLink());
            foreach (Category item in _categories.Categories)
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
            
            tagBuilder.AddCssClass($"btn {(id==category.Id ? "btn-primary" : "btn-outline-primary")} btn-sm col-md-2 py-1");
            tagBuilder.MergeAttribute("href", $"/Home/Catalog/{category.Id}");
            
            var writer = new StringWriter();
            tagBuilder.InnerHtml.SetContent(category.Name);
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        private HtmlString GenerateLink()
        {
            TagBuilder tagBuilder = new TagBuilder("a");

            tagBuilder.AddCssClass("btn btn-outline-primary btn-sm col-md-2 py-1");
            tagBuilder.MergeAttribute("href", $"/Home/Catalog");
            
            var writer = new StringWriter();
            tagBuilder.InnerHtml.SetContent("Всё");
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}