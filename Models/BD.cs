using Dapper;
using System.Data.SqlClient;

public static class BD
{
    private static string _connectionString = @"ServeName=localhost;Database=BDELECCIONES2023; trusted_connection = True;";

    public static void agregarCandidato(Candidato can)
    {
        string sql = "INSERT INTO candidatos (*) values (@idCandidato, @idPartido, @apellido, @nombre, @fechaNacimiento, @foto, @postulacion)";
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            DB.Execute(sql, new {IDCandidato = can.idCandidato, IDPart = can.idPartido, cApellido = can.apellido, cNombre = can.nombre, cFechaNac = can.fechaNacimiento, cFoto = can.foto, cPostu = can.postulacion});
        }
    }

    public static void eliminarCandidato(int idCandidato)
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string sql = "DELETE from candidato where candidato = @idCandidato";
        }
    }

    public static int verInfoPartido(int idPartido)
    {
        int objPartido = 1;
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @IdPartido";
        }
        return objPartido;
    }

    public static int verInfoCandidato(int idCandidato)
    {
        int objcan = 1;
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE idCandidato = @IDCandidato";
        }
        return objcan;
    }

    
    public static List<Partido> listarPartidos()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            return DB.Query<Partido>("SELECT * FROM Partido").AsList();
        }
    }

     public static List<Partido> listarCandidatos()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            return DB.Query<Partido>("SELECT * FROM Partido").AsList();
        }
    }
      
}
