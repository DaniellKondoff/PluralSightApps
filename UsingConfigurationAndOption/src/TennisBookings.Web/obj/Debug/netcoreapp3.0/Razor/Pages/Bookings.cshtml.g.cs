#pragma checksum "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac49f0aadca0f7e6217ab7b192bafd8991b2c4eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TennisBookings.Web.Pages.Pages_Bookings), @"mvc.1.0.razor-page", @"/Pages/Bookings.cshtml")]
namespace TennisBookings.Web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
using TennisBookings.Web.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac49f0aadca0f7e6217ab7b192bafd8991b2c4eb", @"/Pages/Bookings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4393742df5c27a23e3e7143bf7859a40b6c4c550", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Bookings : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
  
    ViewData["Title"] = "Your Bookings";

#line default
#line hidden
            WriteLiteral("\r\n<h1>");
#line 8 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            WriteLiteral("</h1>\r\n\r\n");
#line 10 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
 if (Model.BookingSuccess)
{

#line default
#line hidden
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\">\r\n                <p><strong>You\'ve successfully created a booking!</strong></p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#line 19 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
}

#line default
#line hidden
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h2>");
#line 23 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
       Write(Model.Greeting);

#line default
#line hidden
            WriteLiteral("</h2>\r\n    </div>\r\n</div>\r\n\r\n");
#line 27 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
 foreach (var date in Model.CourtBookings)
{

#line default
#line hidden
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h2>");
#line 31 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
           Write(date.Key.ToString("D"));

#line default
#line hidden
            WriteLiteral("</h2>\r\n\r\n");
#line 33 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
             foreach (var booking in date)
            {

#line default
#line hidden
            WriteLiteral("                <p><strong>Court ");
#line 35 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
                            Write(booking.CourtId);

#line default
#line hidden
            WriteLiteral("</strong>: ");
#line 35 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
                                                       Write(booking.StartDateTime.Hour.To12HourClockString());

#line default
#line hidden
            WriteLiteral(" to ");
#line 35 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
                                                                                                            Write(booking.EndDateTime.Hour.To12HourClockString());

#line default
#line hidden
            WriteLiteral("</p>\r\n");
#line 36 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
            }

#line default
#line hidden
            WriteLiteral("        </div>\r\n    </div>\r\n");
#line 39 "D:\Program Files\GitHub\PluralSightApps\UsingConfigurationAndOption\src\TennisBookings.Web\Pages\Bookings.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookingsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BookingsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BookingsModel>)PageContext?.ViewData;
        public BookingsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
