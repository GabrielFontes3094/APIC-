namespace ProjetoAPI.Rotas
{
    public static class PessoaRotas
    {
        public static void MapPesoaRotas(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pessoa}/{action=Index}/{id?}");
        }
    }
}
