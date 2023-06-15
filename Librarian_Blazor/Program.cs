using Librarian_Blazor;
using Librarian_Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7027") });

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILibraryMemberService, LibraryMemberService>();
builder.Services.AddScoped<ILoanService, LoanService>();

builder.Services.AddScoped<TempService>();

await builder.Build().RunAsync();
