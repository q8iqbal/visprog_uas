#pragma checksum "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f24d7cfb4f8af33b22035c64b2fbab98b9c1fe2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Status), @"mvc.1.0.view", @"/Views/Student/Status.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/_ViewImports.cshtml"
using CampusApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/_ViewImports.cshtml"
using CampusApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f24d7cfb4f8af33b22035c64b2fbab98b9c1fe2", @"/Views/Student/Status.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c3ec1e31ef6aef514311251db57841d372ef4df", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Status : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CampusApp.Models.Student>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"" integrity=""sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
<h1>Update status Mata Kuliah Pada Mahasiswa</h1>

    <ul >
");
#nullable restore
#line 8 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
         foreach (var item in @ViewBag.Enrollment)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li> \n                ");
#nullable restore
#line 11 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
           Write(item.Course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n                <br>\n                <input type=\"radio\"");
            BeginWriteAttribute("name", " name=\"", 535, "\"", 566, 3);
            WriteAttributeValue("", 542, "data[", 542, 5, true);
#nullable restore
#line 13 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
WriteAttributeValue("", 547, item.EnrollmentID, 547, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 565, "]", 565, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 567, "\"", 601, 2);
#nullable restore
#line 13 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
WriteAttributeValue("", 575, item.EnrollmentID, 575, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 593, "diambil", 594, 8, true);
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 13 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
                                                                                                        if(item.Status == "diambil"){ Write("checked"); }

#line default
#line hidden
#nullable disable
            WriteLiteral("/> Belum Selesai\n                <input type=\"radio\"");
            BeginWriteAttribute("name", " name=\"", 705, "\"", 736, 3);
            WriteAttributeValue("", 712, "data[", 712, 5, true);
#nullable restore
#line 14 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
WriteAttributeValue("", 717, item.EnrollmentID, 717, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 735, "]", 735, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 737, "\"", 771, 2);
#nullable restore
#line 14 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
WriteAttributeValue("", 745, item.EnrollmentID, 745, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 763, "selesai", 764, 8, true);
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 14 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
                                                                                                        if(item.Status == "selesai"){ Write("checked"); }

#line default
#line hidden
#nullable disable
            WriteLiteral("/> Selesai\n            </li>\n");
#nullable restore
#line 16 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </ul>
    <input type=""submit"" onclick=""call()"">

<script type=""text/javascript"">
        function call() {
            let data = $('input[name^=""data""]:checked').map(function(){return $(this).val()}).get();
            $.ajax({
                type: 'POST',
                url: '");
#nullable restore
#line 25 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
                 Write(Url.Action("Status","Student"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\n                data: { \'data\': data },\n                datatype: \"json\",\n                success: function(response){\n                    alert(\"data berhasil di update\")\n                }\n            });\n        }\n</script>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n");
#nullable restore
#line 36 "/mnt/hdd/iqbal/kuliah/semester 7/pak muah/w-9/CampusApp/Views/Student/Status.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CampusApp.Models.Student> Html { get; private set; }
    }
}
#pragma warning restore 1591
