using CapaDatosDG;

WebApplicationBuilder lObjConstructorDG = WebApplication.CreateBuilder(args);
lObjConstructorDG.Services.AddRazorPages();

// Misma regla que el escritorio: la variable CUBITO_SQL_DG tiene prioridad sobre appsettings.json
string lStrCadenaDG = Environment.GetEnvironmentVariable("CUBITO_SQL_DG");
if (string.IsNullOrWhiteSpace(lStrCadenaDG))
    lStrCadenaDG = lObjConstructorDG.Configuration.GetConnectionString("CubitoDG");
ConexionDG.gStrCadenaConexionDG = lStrCadenaDG;

WebApplication lObjAplicacionDG = lObjConstructorDG.Build();

if (!lObjAplicacionDG.Environment.IsDevelopment())
{
    lObjAplicacionDG.UseExceptionHandler("/Error");
    lObjAplicacionDG.UseHsts();
}

lObjAplicacionDG.UseHttpsRedirection();
lObjAplicacionDG.UseStaticFiles();
lObjAplicacionDG.UseRouting();
lObjAplicacionDG.MapRazorPages();

lObjAplicacionDG.Run();
