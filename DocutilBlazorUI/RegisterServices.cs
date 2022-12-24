namespace DocutilBlazorUI
{
   public static class RegisterServices
   {
      public static void ConfigureServices(this WebApplicationBuilder builder)
      {
         // Add services to the container.
         builder.Services.AddRazorPages();
         builder.Services.AddServerSideBlazor();
         builder.Services.AddMemoryCache();

         //Add DataAccess
         builder.Services.AddSingleton<IDbConnection, DbConnection>();
         builder.Services.AddSingleton<ICommentData, MongoCommentData>();
         builder.Services.AddSingleton<IDirectoryData, MongoDirectoryData>();
         builder.Services.AddSingleton<IDocumentData, MongoDocumentData>();
         builder.Services.AddSingleton<IProjectData, MongoProjectData>();
         builder.Services.AddSingleton<IUserData, MongoUserData>();


      }
   }

}
