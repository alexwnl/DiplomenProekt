#pragma checksum "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea9b3ebcd4bb0a70a72383e3728c5c53e349403b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\_ViewImports.cshtml"
using PhoneShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\_ViewImports.cshtml"
using PhoneShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea9b3ebcd4bb0a70a72383e3728c5c53e349403b", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d31ba370dbd452abe410a178c2bfcab386b5c8cd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PhoneShop.Models.ContactUs.ContactMessage>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div style=""border-radius: 10px; padding: 10px; background-color: #f0f0f0;"">
    <h1>Contact Messages</h1>
    <table class=""table"">
        <thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Comment</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 15 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\Contact\Index.cshtml"
             foreach (var message in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\Contact\Index.cshtml"
                   Write(message.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\Contact\Index.cshtml"
                   Write(message.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\Contact\Index.cshtml"
                   Write(message.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\Contact\Index.cshtml"
                   Write(message.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 23 "C:\Users\aleks\Documents\alex\DiplomenProekt\PhoneShop\PhoneShop\Views\Contact\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<style>\r\n    \r\n</style>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PhoneShop.Models.ContactUs.ContactMessage>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
