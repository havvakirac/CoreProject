#pragma checksum "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03ecb57dad31863060b027e1eb2944d36c1df5c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_List), @"mvc.1.0.view", @"/Views/Home/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/List.cshtml", typeof(AspNetCore.Views_Home_List))]
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
#line 1 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\_ViewImports.cshtml"
using CoreCourseApp;

#line default
#line hidden
#line 2 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\_ViewImports.cshtml"
using CoreCourseApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03ecb57dad31863060b027e1eb2944d36c1df5c2", @"/Views/Home/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3716619d94e2706ff6d0480473bdd22ce0bdd5d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Request>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
            BeginContext(71, 626, true);
            WriteLiteral(@"
<div class=""m-5"">
    <div class=""bg-success text-white  p-4"">Request List</div>
    <div class=""table-responsive"">

        <table class=""table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>
                        Id
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        Phone
                    </th>

                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 30 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(762, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(847, 7, false);
#line 34 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml"
                       Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(854, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(946, 9, false);
#line 37 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml"
                       Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(955, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1047, 10, false);
#line 40 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml"
                       Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1057, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1149, 10, false);
#line 43 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml"
                       Write(item.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(1159, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 46 "C:\Users\Section2\source\repos\CoreCourseApp\CoreCourseApp\Views\Home\List.cshtml"
                }

#line default
#line hidden
            BeginContext(1238, 58, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Request>> Html { get; private set; }
    }
}
#pragma warning restore 1591
