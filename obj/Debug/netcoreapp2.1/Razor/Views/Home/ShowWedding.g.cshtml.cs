#pragma checksum "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90ef18a0c0c3869d067193e5fabfab32c444e70d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowWedding), @"mvc.1.0.view", @"/Views/Home/ShowWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ShowWedding.cshtml", typeof(AspNetCore.Views_Home_ShowWedding))]
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
#line 1 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/_ViewImports.cshtml"
using wedding;

#line default
#line hidden
#line 2 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/_ViewImports.cshtml"
using wedding.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ef18a0c0c3869d067193e5fabfab32c444e70d", @"/Views/Home/ShowWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c4613f5712c8460fbd260d7e3e28487d6aac3fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<wedding.Models.Display>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 5, true);
            WriteLiteral("\n<h1>");
            EndContext();
            BeginContext(36, 12, false);
#line 3 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
Write(Model.Couple);

#line default
#line hidden
            EndContext();
            BeginContext(48, 92, true);
            WriteLiteral("\'s Wedding</h1>\n<a href=\"/dashboard\">Dashboard</a>\n<a href=\"/logout\">Log Out</a>\n\n<h2>Date: ");
            EndContext();
            BeginContext(141, 10, false);
#line 7 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
     Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(151, 22, true);
            WriteLiteral("</h2>\n\n<p>Guests:</p>\n");
            EndContext();
#line 10 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
  
  if (Model.Guests == null)
  {

#line default
#line hidden
            BeginContext(208, 25, true);
            WriteLiteral("    <p>No Guests Yet</p>\n");
            EndContext();
#line 14 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
  }
  else
  {
    foreach (User g in Model.Guests)
    {

#line default
#line hidden
            BeginContext(291, 10, true);
            WriteLiteral("      <li>");
            EndContext();
            BeginContext(302, 11, false);
#line 19 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
     Write(g.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(313, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(315, 10, false);
#line 19 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
                  Write(g.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(325, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 20 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
    }
  }

#line default
#line hidden
            BeginContext(343, 4, true);
            WriteLiteral("<img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 347, "\"", 367, 1);
#line 23 "/Users/sekiryouma/Documents/coding_dojo/C#/assingments/wedding/Views/Home/ShowWedding.cshtml"
WriteAttributeValue("", 353, Model.Address, 353, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(368, 2, true);
            WriteLiteral(">\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<wedding.Models.Display> Html { get; private set; }
    }
}
#pragma warning restore 1591
