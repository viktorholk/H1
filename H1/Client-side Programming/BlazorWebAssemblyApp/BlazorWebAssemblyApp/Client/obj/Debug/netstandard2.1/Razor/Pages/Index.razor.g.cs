#pragma checksum "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e366fe792a18ede3250eaad3308fc4e41fcf419"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorWebAssemblyApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using BlazorWebAssemblyApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\_Imports.razor"
using BlazorWebAssemblyApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IAsyncDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "form-group");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "label");
            __builder.AddMarkupContent(4, "\r\n        User:\r\n        ");
            __builder.OpenElement(5, "input");
            __builder.AddAttribute(6, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 9 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
                      userInput

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => userInput = __value, userInput));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "form-group");
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "label");
            __builder.AddMarkupContent(15, "\r\n        Message:\r\n        ");
            __builder.OpenElement(16, "input");
            __builder.AddAttribute(17, "size", "50");
            __builder.AddAttribute(18, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 15 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
                      messageInput

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => messageInput = __value, messageInput));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n");
            __builder.OpenElement(23, "button");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
                  Send

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "disabled", 
#nullable restore
#line 18 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
                                    !IsConnected

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(26, "Send");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n\r\n<hr>\r\n\r\n");
            __builder.OpenElement(28, "ul");
            __builder.AddAttribute(29, "id", "messagesList");
            __builder.AddMarkupContent(30, "\r\n");
#nullable restore
#line 23 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
     foreach (var message in messages)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(31, "        ");
            __builder.OpenElement(32, "li");
            __builder.AddContent(33, 
#nullable restore
#line 25 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
             message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
#nullable restore
#line 26 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "C:\Users\Viktor\Desktop\Development\education_datatechnician\H1\Client-side Programming\BlazorWebAssemblyApp\BlazorWebAssemblyApp\Client\Pages\Index.razor"
       
    private HubConnection hubConnection;
    private List<string> messages = new List<string>();
    private string userInput;
    private string messageInput;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            var encodedMsg = $"{user}: {message}";
            messages.Add(encodedMsg);
            StateHasChanged();
        });

        await hubConnection.StartAsync();
    }

    async Task Send() =>
        await hubConnection.SendAsync("SendMessage", userInput, messageInput);

    public bool IsConnected =>
        hubConnection.State == HubConnectionState.Connected;

    public async ValueTask DisposeAsync()
    {
        await hubConnection.DisposeAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
