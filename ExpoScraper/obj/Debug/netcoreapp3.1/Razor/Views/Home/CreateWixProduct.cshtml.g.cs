#pragma checksum "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25d6cd4f4eb78537b220978c843ec7487fdf9aac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreateWixProduct), @"mvc.1.0.view", @"/Views/Home/CreateWixProduct.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\_ViewImports.cshtml"
using ExpoScraper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\_ViewImports.cshtml"
using ExpoScraper.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25d6cd4f4eb78537b220978c843ec7487fdf9aac", @"/Views/Home/CreateWixProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b508d6386c193b71fedb53f2dac8ffc6a206325c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CreateWixProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WixProductModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25d6cd4f4eb78537b220978c843ec7487fdf9aac3616", async() => {
                WriteLiteral("\r\n        <div class=\"col-md-12\">\r\n            <div class=\"col-md-6\">\r\n                ");
#nullable restore
#line 7 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.LabelFor(x => x.name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 8 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.EditorFor(x => x.name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                ");
#nullable restore
#line 11 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.LabelFor(x => x.weight));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 12 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.EditorFor(x => x.weight));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n\r\n            ");
#nullable restore
#line 17 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.LabelFor(x => x.priceData.price));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 18 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.EditorFor(x => x.priceData.price));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.LabelFor(x => x.description));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 24 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.TextAreaFor(x => x.description, new { @class = "desc" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.LabelFor(x => x.category));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 28 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.EditorFor(x => x.category));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            ");
#nullable restore
#line 31 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.LabelFor(x => x.ribbon));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 32 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.EditorFor(x => x.ribbon));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            ");
#nullable restore
#line 35 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.LabelFor(x => x.sku));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 36 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.EditorFor(x => x.sku));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n            <div class=\"col-md-6\">\r\n                ");
#nullable restore
#line 40 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.LabelFor(x => x.customname));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 41 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.EditorFor(x => x.customname));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                ");
#nullable restore
#line 44 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.LabelFor(x => x.customdesc));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 45 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
           Write(Html.EditorFor(x => x.customdesc));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 49 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
         if (Model != null && !string.IsNullOrEmpty(Model.imageUrl))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"col-md-12\">\r\n                <img class=\"preview-img\"");
                BeginWriteAttribute("src", " src=\"", 1752, "\"", 1773, 1);
#nullable restore
#line 52 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
WriteAttributeValue("", 1758, Model.imageUrl, 1758, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"col-md-12\">\r\n                <img class=\"preview-img\"");
                BeginWriteAttribute("src", " src=\"", 1876, "\"", 1904, 2);
                WriteAttributeValue("", 1882, "..", 1882, 2, true);
#nullable restore
#line 55 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
WriteAttributeValue("", 1884, Model.existingImage, 1884, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n");
#nullable restore
#line 57 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
       Write(Html.HiddenFor(x => x.imageUrl));

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
                                            ;
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Submit Data\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 4 "C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\Views\Home\CreateWixProduct.cshtml"
AddHtmlAttributeValue("", 78, Url.Action("GenerateExcel", "Home", new {model = Model}), 78, 57, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WixProductModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
