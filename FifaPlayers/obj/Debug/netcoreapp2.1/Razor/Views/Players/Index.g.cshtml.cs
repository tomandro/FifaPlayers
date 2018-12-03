#pragma checksum "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e36648f55edd3f0af5795b9f0f7c72833632c937"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Players_Index), @"mvc.1.0.view", @"/Views/Players/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Players/Index.cshtml", typeof(AspNetCore.Views_Players_Index))]
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
#line 1 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\_ViewImports.cshtml"
using FifaPlayers;

#line default
#line hidden
#line 2 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\_ViewImports.cshtml"
using FifaPlayers.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e36648f55edd3f0af5795b9f0f7c72833632c937", @"/Views/Players/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"385c3c7d387435ace8738def02695dc1fd478f71", @"/Views/_ViewImports.cshtml")]
    public class Views_Players_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
  
    ViewData["Title"] = "Players";


#line default
#line hidden
#line 6 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
  
    // Since Address isn't a string, it requires a cast.
    var playersList = ViewData["Players"] as List<Player>;
    Player[] players = playersList.ToArray();

#line default
#line hidden
            BeginContext(219, 22, true);
            WriteLiteral("\r\n<h2>\r\n    There are ");
            EndContext();
            BeginContext(242, 14, false);
#line 13 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
         Write(players.Length);

#line default
#line hidden
            EndContext();
            BeginContext(256, 688, true);
            WriteLiteral(@" items in the list.
</h2>


<script>
    function toFeet(n) {
        var realFeet = ((n * 0.393700) / 12);
        var feet = Math.floor(realFeet);
        var inches = Math.round((realFeet - feet) * 12);
        return feet + ""\"" "" + inches + '\'';
    }

    //holds player object and 
    function PlayerRow(player)
    {
        self = this;
        self.player = player;
        self.formattedHeight = ko.computed(function () {
            return toFeet(self.player.height);
        });    
    }

    function PlayersViewModel() {
        var self = this;

        // Non-editable catalog data - would come from the server
        self.serverplayers = [
");
            EndContext();
#line 40 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
         for (int i = 0; i < players.Length; i++)
        {
            

#line default
#line hidden
#line 42 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
             if (i != players.Length - 1)
            {

#line default
#line hidden
            BeginContext(1064, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1082, 7, true);
            WriteLiteral("{name:\"");
            EndContext();
            BeginContext(1090, 15, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                    Write(players[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(1105, 7, true);
            WriteLiteral("\",age:\"");
            EndContext();
            BeginContext(1113, 14, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                           Write(players[i].Age);

#line default
#line hidden
            EndContext();
            BeginContext(1127, 10, true);
            WriteLiteral("\",height:\"");
            EndContext();
            BeginContext(1138, 17, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                    Write(players[i].Height);

#line default
#line hidden
            EndContext();
            BeginContext(1155, 10, true);
            WriteLiteral("\",weight:\"");
            EndContext();
            BeginContext(1166, 17, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                Write(players[i].Weight);

#line default
#line hidden
            EndContext();
            BeginContext(1183, 10, true);
            WriteLiteral("\",rating:\"");
            EndContext();
            BeginContext(1194, 17, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                            Write(players[i].Rating);

#line default
#line hidden
            EndContext();
            BeginContext(1211, 8, true);
            WriteLiteral("\",club:\"");
            EndContext();
            BeginContext(1220, 15, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                                                      Write(players[i].Club);

#line default
#line hidden
            EndContext();
            BeginContext(1235, 12, true);
            WriteLiteral("\",position:\"");
            EndContext();
            BeginContext(1248, 19, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                                                                                  Write(players[i].Position);

#line default
#line hidden
            EndContext();
            BeginContext(1267, 15, true);
            WriteLiteral("\",nationality:\"");
            EndContext();
            BeginContext(1283, 22, false);
#line 44 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                                                                                                                     Write(players[i].Nationality);

#line default
#line hidden
            EndContext();
            BeginContext(1305, 5, true);
            WriteLiteral("\"},\r\n");
            EndContext();
#line 45 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1358, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1376, 7, true);
            WriteLiteral("{name:\"");
            EndContext();
            BeginContext(1384, 15, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                    Write(players[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(1399, 7, true);
            WriteLiteral("\",age:\"");
            EndContext();
            BeginContext(1407, 14, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                           Write(players[i].Age);

#line default
#line hidden
            EndContext();
            BeginContext(1421, 10, true);
            WriteLiteral("\",height:\"");
            EndContext();
            BeginContext(1432, 17, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                    Write(players[i].Height);

#line default
#line hidden
            EndContext();
            BeginContext(1449, 10, true);
            WriteLiteral("\",weight:\"");
            EndContext();
            BeginContext(1460, 17, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                Write(players[i].Weight);

#line default
#line hidden
            EndContext();
            BeginContext(1477, 10, true);
            WriteLiteral("\",rating:\"");
            EndContext();
            BeginContext(1488, 17, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                            Write(players[i].Rating);

#line default
#line hidden
            EndContext();
            BeginContext(1505, 8, true);
            WriteLiteral("\",club:\"");
            EndContext();
            BeginContext(1514, 15, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                                                      Write(players[i].Club);

#line default
#line hidden
            EndContext();
            BeginContext(1529, 12, true);
            WriteLiteral("\",position:\"");
            EndContext();
            BeginContext(1542, 19, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                                                                                  Write(players[i].Position);

#line default
#line hidden
            EndContext();
            BeginContext(1561, 15, true);
            WriteLiteral("\",nationality:\"");
            EndContext();
            BeginContext(1577, 22, false);
#line 48 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
                                                                                                                                                                                                                     Write(players[i].Nationality);

#line default
#line hidden
            EndContext();
            BeginContext(1599, 4, true);
            WriteLiteral("\"}\r\n");
            EndContext();
#line 49 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
            }

#line default
#line hidden
#line 49 "C:\Users\Thomas\Source\Repos\FifaPlayers\FifaPlayers\Views\Players\Index.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1629, 1165, true);
            WriteLiteral(@"        ];

        self.players = [];
        for (player in self.serverplayers)
        {
            self.players.push(new PlayerRow(self.serverplayers[player]));
        }

        self.shout = function (player) {
            alert();
        }
    }

    window.onload = function () {
        ko.applyBindings(new PlayersViewModel());
    }
</script>
<div data-bind=""foreach: players"">
    <div class=""row"" data-bind=""click: $root.shout"">

        <div class=""col-md-4"">Name: <span data-bind=""text: player.name""></span></div>

        <div class=""col-md-2"">Age: <span data-bind=""text: player.age""></span></div>

        <div class=""col-md-2"">Club: <span data-bind=""text: player.club""></span></div>

        <div class=""col-md-2"">Position: <span data-bind=""text: player.position""></span></div>

        <div class=""col-md-2"">Rating: <span data-bind=""text: player.rating""></span></div>

    </div>
    <div class=""row"">

        <div class=""col-md-6"">Height: <span data-bind=""text: format");
            WriteLiteral("tedHeight\"></span></div>\r\n\r\n        <div class=\"col-md-6\">Weight: <span data-bind=\"text: player.weight\"></span></div>\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591