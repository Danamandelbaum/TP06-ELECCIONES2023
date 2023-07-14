using Dapper;
using System.Data.SqlClient;


public static class BD
{
    private static string _connectionString = @"Server = localhost; Database=BD_Elecciones; Trusted_Connection = True;";

    public static void agregarCandidato(Candidato can)
    {
        string sql = "INSERT INTO Candidato  (idPartido, apellido, nombre, fechaNacimiento, foto, postulacion) VALUES ( @pIdPartido, @papellido, @pnombre, @pfechaNacimiento, @pfoto, @pPostulacion)";
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
             DB.Execute(sql, new{pIdpartido = can.idPartido, papellido = can.apellido, pnombre = can.nombre, pfechaNacimiento = can.fechaNacimiento, pfoto = can.foto, pPostulacion = can.postulacion, pIdcandidato = can.idCandidato});
        }
    }

    public static void eliminarCandidato(int idCandidato)
    {
        int eliminado;
        string sql = "DELETE from candidato WHERE candidato = @idCandidato";
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            eliminado = DB.Execute(sql, new {idCandidato = idCandidato});
        }
    }

    public static Partido verInfoPartido(int idPartido)
    {
        Partido objPartido;
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @IDPartido";
            objPartido = DB.QueryFirstOrDefault<Partido>(sql, new {iDPartido = idPartido});
        }
        return objPartido;
    }

    public static Candidato verInfoCandidato(int idCandidato)
    {
        Candidato objcan;
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE idCandidato = @IDCandidato";
            objcan = DB.QueryFirstOrDefault<Candidato>(sql, new {iDCandidato = idCandidato});
        }
        return objcan;
    }

private static List<Partido> _listarPartidos = new List<Partido>();
  public static List<Partido> listarPartidos()
    {
        
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido";
            _listarPartidos =  DB.Query<Partido>(sql).ToList();
        }
        return _listarPartidos;
    }

    private static List<Candidato> _listarCandidatos = new List<Candidato>();
  
    public static List<Candidato> listarCandidatos(int idPartido)
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Candidato";
            _listarCandidatos =  DB.Query<Candidato>(sql).ToList();
        }
        return _listarCandidatos;
    } 
}

