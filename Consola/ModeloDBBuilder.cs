using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using ModeloDB;
using System.Configuration;

namespace Consola
{
    public class ModeloDBBuilder
    {
        const string DBTipo = "DBTipo";
        enum DBTipoConn { SqlServer, Postgres, Memoria }
        static ModeloDB.ModeloDB db;

        public static ModeloDB.ModeloDB Crear()
        {
            // Lee la configuración acerca de qué base usar del archivo App.config
            string dbtipo = ConfigurationManager.AppSettings[DBTipo];
            string conn = ConfigurationManager.ConnectionStrings[dbtipo].ConnectionString;
            // Construye la conección acorde con el tipo
            DbContextOptions < ModeloDB.ModeloDB> contextOptions;
            switch (dbtipo)
            {
                case nameof(DBTipoConn.SqlServer):
                    contextOptions = new DbContextOptionsBuilder<ModeloDB.ModeloDB>()
                        .UseSqlServer(conn)
                        .Options;
                    break;
                case nameof(DBTipoConn.Postgres):
                    contextOptions = new DbContextOptionsBuilder<ModeloDB.ModeloDB>()
                        .UseNpgsql(conn)
                        .Options;
                    break;
                default: // Por defecto usa la memoria como base de datos
                    contextOptions = new DbContextOptionsBuilder<ModeloDB.ModeloDB>()
                        .UseInMemoryDatabase(conn)
                        .Options;
                    break;
            }

            db = new ModeloDB.ModeloDB(contextOptions);

            return db;
        }
    }
}