using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

public static class BD
{
    private static string _connectionString = @TP06-ELECCIONES2023 = localhost;
    dataBase = BDELECCIONES2023; trusted_connection = True;

    public static void agregarCandidato(Candidato can)
    {
        string sql = "INSERT INTO candidatos (*) values (@idCandidato, @idPartido, @apellido, @nombre, @fechaNacimiento, @foto, @postulacion)";
        using (sqlConnection DB = new sqlConnection(_connectionString))
        {
            DB.Execute(sql, new {IDCandidato = can.idCandidato, IDPart = can.idPartido, cApellido = can.apellido, cNombre = can.nombre, cFechaNac = can.fechaNacimiento, cFoto = can.foto, cPostu = can.postulacion});
        }
    }

    public static void eliminarCandidato(int idCandidato)
    {
        Using (sqlConnection DB = new sqlConnection(_connectionString))
        {
            string sql = "DELETE from candidato where candidato = @idCandidato";
        }
    }

    public static int verInfoPartido(int idPartido)
    {
        
    }
}