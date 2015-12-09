namespace Libellus.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Linq;

    /// <summary>
    /// Define un contron html para presentar datos que no son modificables.
    /// </summary>
    public static class TextoSoloLecturaHelper
    {
        public static MvcHtmlString TextBoxDisabled(this HtmlHelper helper, string texto)
        {
            TagBuilder textoHelper = new TagBuilder("span");
            textoHelper.AddCssClass("form-control disabled");
            textoHelper.InnerHtml = texto;

            return new MvcHtmlString(textoHelper.ToString());
        }

        public static MvcHtmlString TextBoxDisabledFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper, 
            Expression<Func<TModel, TProperty>> expression, 
            bool disabled = false, 
            object htmlAttributes = null)
        {
            if (disabled)
            {
                var valueGetter = expression.Compile();
                var model = valueGetter(helper.ViewData.Model);
                TagBuilder textoHelper = new TagBuilder("span");
                textoHelper.AddCssClass("form-control disabled");
                textoHelper.InnerHtml = model != null ? model.ToString() : string.Empty;
                return MvcHtmlString.Create(textoHelper.ToString());
            }
            else
            {
                return helper.TextBoxFor(expression, htmlAttributes);
            }
        }

        public static MvcHtmlString DropDownListDisabledFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            bool disabled = false,
            object htmlAttributes = null)
        {
            if (disabled)
            {
                var valueGetter = expression.Compile();
                var model = valueGetter(htmlHelper.ViewData.Model);
                TagBuilder builder = new TagBuilder("span");
                builder.AddCssClass("form-control disabled");
                var item = model != null ? selectList.FirstOrDefault(e => e.Value == model.ToString()) : null;
                if (item != null)
                {
                    builder.InnerHtml = item.Text;
                }
                else
                {
                    builder.InnerHtml = string.Empty;
                }
                
                return MvcHtmlString.Create(builder.ToString());
            }
            else
            {
                return htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);
            }
        }

        
    }
}