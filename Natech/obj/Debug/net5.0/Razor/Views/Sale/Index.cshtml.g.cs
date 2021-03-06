#pragma checksum "D:\MyApps\Natech\Natech\Views\Sale\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8812134058f51f4ae8d0e21b9ee1e41a69539445"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sale_Index), @"mvc.1.0.view", @"/Views/Sale/Index.cshtml")]
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
#line 1 "D:\MyApps\Natech\Natech\Views\_ViewImports.cshtml"
using Natech;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyApps\Natech\Natech\Views\_ViewImports.cshtml"
using Natech.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8812134058f51f4ae8d0e21b9ee1e41a69539445", @"/Views/Sale/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f250f116b2f2ef4065b3ab5a2146844f940a99dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Sale_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Natech.Models.SaleView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_AddSaleModal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<table class=""table table-success table-striped"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Amount</th>
            <th scope=""col"">Date</th>
            <th scope=""col"">Seller</th>
            <th scope=""col""><button type=""button"" id=""openSaleModal"" class=""btn btn-success"" data-bs-toggle=""modal"" data-bs-target=""#addSaleModal"">Add</button></th>
        </tr>
    </thead>
    <tbody id=""table_body"">
    </tbody>
</table>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8812134058f51f4ae8d0e21b9ee1e41a695394453792", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function () {\r\n            var model = ");
#nullable restore
#line 28 "D:\MyApps\Natech\Natech\Views\Sale\Index.cshtml"
                   Write(Html.Raw(Json.Serialize(Model.sales)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
            $.each(model, function (index, value) {
                console.log(value);
                var tBody = '<tr id=""' + value.saleId + '""><th scope=""row"">' + index + '</th><td>' + value.amount + '</td><td>'
                    + value.saleDate + '</td><td>'+value.sellerName+"" ""+value.sellerSurName+'</td><td><button type=""button"" class=""btn btn-warning editSale"">Edit</button><button type=""button"" class=""btn btn-danger deleteSale"">Delete</button></td></tr>';
                $('#table_body').append(tBody);
            });

            $(""#openSaleModal"").click(function (evt) {
                evt.preventDefault();
                $(""#FirstNameAdd"").val('');
                $('#addSaleModal').modal('toggle');
            });

            $(""#closeSellerModal"").click(function (evt) {
                evt.preventDefault();
                $('#addSaleModal').modal('toggle');
                $(""#AmountAdd"").val('');
            });



            $("".editSale"").click(function (evt) {
");
                WriteLiteral(@"                evt.preventDefault();
                var id=$(this).parent().parent().attr('id');
                $.ajax({
                    type: ""GET"",
                    url:""/Sale/GetSale"",
                    contentType: ""application/json"",
                    data: {SellerId: id},
                    dataType: ""json"",
                    success: function (msg) {
                        console.log(msg);
                        $('#editSaleModal').modal('toggle');
                        $(""#FirstNameEdit"").val(msg.firstName);
                        $(""#SurNameEdit"").val(msg.surName);
                        $(""#SellerIdEdit"").val(msg.sellerId);
                    },
                    error: function (req, status, error) {
                        console.log(""Failure"");
                    }
                });
            });

            $(""#closeEditSellerModal"").click(function (evt) {
                evt.preventDefault();
                $('#editSellerModal').modal('t");
                WriteLiteral(@"oggle');
                $(""#FirstNameEdit"").val('');
                $(""#SurNameEdit"").val('');
            });



            $(document).on(""click"", "".deleteSale"",function() {
                var sale = {
                    SaleId: $(this).parent().parent().attr('id')
                };
                $.ajax({
                    type: ""POST"",
                    url: '");
#nullable restore
#line 87 "D:\MyApps\Natech\Natech\Views\Sale\Index.cshtml"
                     Write(Url.Action("Delete","Sale"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    contentType: ""application/json"",
                    data: JSON.stringify(sale),
                    success: function (msg) {
                        console.log(""Success"");
                        $('#table_body').empty();
                        $.each(msg.sales, function (index, value) {
                            var tBody = '<tr id=""' + value.saleId + '""><th scope=""row"">' + index + '</th><td>' + value.amount + '</td><td>'
                                + value.saleDate + '</td><td>' + value.sellerName + "" "" + value.sellerSurName + '</td><td><button type=""button"" class=""btn btn-warning editSale"">Edit</button><button type=""button"" class=""btn btn-danger deleteSale"">Delete</button></td></tr>';
                            $('#table_body').append(tBody);
                        });
                    },
                    error: function (req, status, error) {
                        console.log(""FaiUrlure"");

                    }
                });
            })");
                WriteLiteral(";\r\n\r\n\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Natech.Models.SaleView> Html { get; private set; }
    }
}
#pragma warning restore 1591
