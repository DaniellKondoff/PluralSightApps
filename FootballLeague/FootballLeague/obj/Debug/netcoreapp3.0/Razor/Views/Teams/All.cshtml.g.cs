#pragma checksum "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b29a5d7beaaead00a8d029c6f84c7f8589c3eb5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teams_All), @"mvc.1.0.view", @"/Views/Teams/All.cshtml")]
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
#line 1 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\_ViewImports.cshtml"
using FootballLeague;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\_ViewImports.cshtml"
using FootballLeague.Controllers.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\_ViewImports.cshtml"
using FootballLeague.Controllers.Models.Teams;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\_ViewImports.cshtml"
using FootballLeague.Services.Models.Teams;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\_ViewImports.cshtml"
using FootballLeague.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b29a5d7beaaead00a8d029c6f84c7f8589c3eb5", @"/Views/Teams/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48076a104cdc4a3c7d9d5e1d2ecfe1838d491fad", @"/Views/_ViewImports.cshtml")]
    public class Views_Teams_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeamListingViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Previous"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Next"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
  
    ViewData["Title"] = "All Teams";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 8 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
  
    var previouseDisabled = Model.CurrentPage == 1 ? "disabled" : string.Empty;
    var nextDisabled = Model.CurrentPage == Model.TotalPages ? "disabled" : string.Empty;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ul class=\"pagination\">\r\n    <li");
            BeginWriteAttribute("class", " class=\"", 320, "\"", 356, 2);
            WriteAttributeValue("", 328, "page-item", 328, 9, true);
#nullable restore
#line 14 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
WriteAttributeValue(" ", 337, previouseDisabled, 338, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b29a5d7beaaead00a8d029c6f84c7f8589c3eb56191", async() => {
                WriteLiteral("\r\n            <span aria-hidden=\"true\">&laquo;</span>\r\n            <span class=\"sr-only\">Previous</span>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 378, "page-link", 378, 9, true);
#nullable restore
#line 15 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
AddHtmlAttributeValue(" ", 387, previouseDisabled, 388, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
                                                    WriteLiteral(Model.PreviousPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </li>\r\n");
#nullable restore
#line 20 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
     for (int i = 1; i <= Model.TotalPages; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li");
            BeginWriteAttribute("class", " class=\"", 666, "\"", 734, 2);
            WriteAttributeValue("", 674, "page-item", 674, 9, true);
#nullable restore
#line 22 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
WriteAttributeValue(" ", 683, Model.CurrentPage == i ?"active" : string.Empty, 684, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b29a5d7beaaead00a8d029c6f84c7f8589c3eb59703", async() => {
#nullable restore
#line 22 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
                                                                                                                     Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
                                                                                                          WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 23 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li");
            BeginWriteAttribute("class", " class=\"", 804, "\"", 835, 2);
            WriteAttributeValue("", 812, "page-item", 812, 9, true);
#nullable restore
#line 24 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
WriteAttributeValue(" ", 821, nextDisabled, 822, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b29a5d7beaaead00a8d029c6f84c7f8589c3eb512759", async() => {
                WriteLiteral("\r\n            <span aria-hidden=\"true\">&raquo;</span>\r\n            <span class=\"sr-only\">Next</span>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 857, "page-link", 857, 9, true);
#nullable restore
#line 25 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
AddHtmlAttributeValue(" ", 866, nextDisabled, 867, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
                                               WriteLiteral(Model.NextPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </li>
</ul>

<table class=""table table-bordered table-hover"">
    <thead>
        <tr>
            <th>Name</th>
            <th>Wins</th>
            <th>Losts</th>
            <th>Draws</th>
            <th>GoalsFor</th>
            <th>GoalsAgainst</th>
            <th>Points</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 45 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
         foreach (var team in Model.Teams)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 48 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
               Write(team.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 49 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
               Write(team.Wins);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 50 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
               Write(team.Losts);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 51 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
               Write(team.Draws);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 52 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
               Write(team.GoalsScored);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 53 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
               Write(team.GoalsAgainst);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 54 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
               Write(team.Points);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 56 "D:\Program Files\GitHub\PluralSightApps\FootballLeague\FootballLeague\Views\Teams\All.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeamListingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591