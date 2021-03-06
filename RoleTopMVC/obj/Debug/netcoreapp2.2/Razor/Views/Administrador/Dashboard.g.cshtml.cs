#pragma checksum "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9f946a6929ecb88e3b3fde51cc829f88268af0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrador_Dashboard), @"mvc.1.0.view", @"/Views/Administrador/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrador/Dashboard.cshtml", typeof(AspNetCore.Views_Administrador_Dashboard))]
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
#line 1 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC;

#line default
#line hidden
#line 2 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9f946a6929ecb88e3b3fde51cc829f88268af0e", @"/Views/Administrador/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fae5be29b1d0446bbdb7fe81a11990f47b34647", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrador_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleTopMVC.ViewModels.DashboardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administrador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Historico", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(50, 245, true);
            WriteLiteral("<main>\r\n    <h2>Dashboard</h2>\r\n\r\n    <section id=\"status-aluguel\">\r\n        <h3>Status dos Alugueis</h3>\r\n        <div id=\"painel\">\r\n            <div class=\"box-status-aluguel aprovados\">\r\n                <h4>Aprovados</h4>\r\n                <p>");
            EndContext();
            BeginContext(296, 25, false);
#line 10 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
              Write(Model.AgendamentoAprovado);

#line default
#line hidden
            EndContext();
            BeginContext(321, 137, true);
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"box-status-aluguel pendentes\">\r\n                <h4>Pendentes</h4>\r\n                <p>");
            EndContext();
            BeginContext(459, 25, false);
#line 14 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
              Write(Model.AgendamentoPendente);

#line default
#line hidden
            EndContext();
            BeginContext(484, 139, true);
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"box-status-aluguel reprovados\">\r\n                <h4>Reprovados</h4>\r\n                <p>");
            EndContext();
            BeginContext(624, 26, false);
#line 18 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
              Write(Model.AgendamentoReprovado);

#line default
#line hidden
            EndContext();
            BeginContext(650, 706, true);
            WriteLiteral(@"</p>
            </div>
        </div>
    </section>

    <section id=""lista de algueis"">
        <h3>Lista de Alugueis Pendentes</h3>
        <table>
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>E-mail</th>
                    <th>Tipo de Evento</th>
                    <th>Evento</th>
                    <th>Nº Convidados</th>
                    <th>Data e Hora</th>
                    <th>Descrição</th>
                    <th colspan=""2"">Aceitar/Negar</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <td colspan=""9"">
                        <p>Atualizado em ");
            EndContext();
            BeginContext(1357, 12, false);
#line 41 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                                    Write(DateTime.Now);

#line default
#line hidden
            EndContext();
            BeginContext(1369, 30, true);
            WriteLiteral("</p>\r\n                        ");
            EndContext();
            BeginContext(1399, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9f946a6929ecb88e3b3fde51cc829f88268af0e6586", async() => {
                BeginContext(1456, 40, true);
                WriteLiteral("<p>Visualizar lista de eventos geral</p>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1500, 95, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </tfoot>\r\n            <tbody>\r\n");
            EndContext();
#line 47 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                 foreach (var agenda in Model.Agendamentos)
                {

#line default
#line hidden
            BeginContext(1675, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1730, 19, false);
#line 50 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                       Write(agenda.Cliente.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1749, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1785, 20, false);
#line 51 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                       Write(agenda.Cliente.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1805, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1841, 18, false);
#line 52 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                       Write(agenda.Agenda.Tipo);

#line default
#line hidden
            EndContext();
            BeginContext(1859, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1895, 20, false);
#line 53 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                       Write(agenda.Agenda.Evento);

#line default
#line hidden
            EndContext();
            BeginContext(1915, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1951, 24, false);
#line 54 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                       Write(agenda.Agenda.Convidados);

#line default
#line hidden
            EndContext();
            BeginContext(1975, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2011, 22, false);
#line 55 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                       Write(agenda.Agenda.DataHora);

#line default
#line hidden
            EndContext();
            BeginContext(2033, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2069, 23, false);
#line 56 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                       Write(agenda.Agenda.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(2092, 37, true);
            WriteLiteral("</td>\r\n                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 2129, "\'", 2191, 1);
#line 57 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
WriteAttributeValue("", 2136, Url.Action("Aprovar", "Agenda", new {id = @agenda.Id}), 2136, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2192, 70, true);
            WriteLiteral("><i class=\"fas fa-check\"></i></a></td>\r\n                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 2262, "\'", 2325, 1);
#line 58 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
WriteAttributeValue("", 2269, Url.Action("Reprovar", "Agenda", new {id = @agenda.Id}), 2269, 56, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2326, 67, true);
            WriteLiteral("><i class=\"fas fa-times\"></i></a></td>\r\n                    </tr>\r\n");
            EndContext();
#line 60 "C:\Users\52850852848\Documents\MVC\RoleTopMVC\Views\Administrador\Dashboard.cshtml"
                }

#line default
#line hidden
            BeginContext(2412, 63, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </section>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleTopMVC.ViewModels.DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
