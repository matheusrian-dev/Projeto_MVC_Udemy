using Projeto_LanchesMac_Udemy.Context;
using Microsoft.EntityFrameworkCore;
using Projeto_LanchesMac_Udemy.Repositories.Interfaces;
using Projeto_LanchesMac_Udemy.Repositories;
using Projeto_LanchesMac_Udemy.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient < ILancheRepository, LancheRepository>();
builder.Services.AddTransient < ICategoriaRepository, CategoriaRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

//Também é possível utilizar os métodos MapControllers(mais utilizado com APIs), MapGet(), UseRouting() com a sintaxe abaixo

app.UseEndpoints(endpoints =>
{
    //é importante ordernar de forma correta os endpoints utilizados,
    //pois caso haja uma rota mais genérica acima, as que estão abaixo não serão utilizadas!
    //Abaixo tem uma forma mais simplificada de se definir o mapeamento padrão

    endpoints.MapControllerRoute(
        name: "categoriaFiltro", //nomes devem ser exclusivos!
        pattern: "Lanche/{action}/{categoria?}", //Padrão URL da rota
        defaults: new { Controller = "Lanche", action = "List" }); //Contém valores padrão para os parâmetros de rota

    //endpoints.MapDefaultControllerRoute();
    endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
