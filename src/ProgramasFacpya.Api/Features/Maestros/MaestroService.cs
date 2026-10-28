using Dapper;
using System.Data;
using ProgramasFacpya.Api.Features.Maestros.Dominio.Entidad;
using ProgramasFacpya.Api.Common; 
using ProgramasFacpya.Api.Features.Maestros.Dominio.Dto;

namespace ProgramasFacpya.Api.Features.Maestros;

public class MaestroService(IDbConnection connection) 
{
    public async Task<ApiResponse<IEnumerable<Maestro>>> ObtenerTodos()
    {
        try
        {
            var sql = "SELECT * FROM Maestro";
            var maestros = await connection.QueryAsync<Maestro>(sql);
            
            return ApiResponse<IEnumerable<Maestro>>.Ok(maestros);
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<Maestro>>.Error(ex.Message);
        }
    }

    public async Task<ApiResponse<int>> Crear(MaestroDTO maestroDto)
    {
        try
        {
            // Mapeo manual para proteger los campos de sistema
            var maestro = new Maestro 
            {
                Nombre = maestroDto.Nombre,
                APaterno = maestroDto.APaterno,
                AMaterno = maestroDto.AMaterno,
                FecRegistro = DateTime.Now
            };

            var sql = @"INSERT INTO Maestro (Nombre, APaterno, AMaterno, FecRegistro) 
                        VALUES (@Nombre, @APaterno, @AMaterno, @FecRegistro);
                        SELECT CAST(SCOPE_IDENTITY() as int);";

            var id = await connection.ExecuteScalarAsync<int>(sql, maestro);
            
            return ApiResponse<int>.Ok(id);
        }
        catch (Exception ex)
        {
            return ApiResponse<int>.Error(ex.Message);
        }
    }

    public async Task<ApiResponse<Maestro>> ObtenerPorId(int idMaestro)
    {
        try
        {
            var sql = "SELECT * FROM Maestro WHERE idMaestro = @idMaestro";
            var maestro = await connection.QuerySingleOrDefaultAsync<Maestro>(sql, new { idMaestro });

            if (maestro == null)
                return ApiResponse<Maestro>.Error("Maestro no encontrado");

            return ApiResponse<Maestro>.Ok(maestro);
        }
        catch (Exception ex)
        {
            return ApiResponse<Maestro>.Error(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Actualizar(int idMaestro, MaestroDTO maestroDto)
    {
        try
        {
            var sql = @"UPDATE Maestro 
                        SET Nombre = @Nombre, APaterno = @APaterno, AMaterno = @AMaterno 
                        WHERE idMaestro = @idMaestro";

            var rowsAffected = await connection.ExecuteAsync(sql, new { maestroDto.Nombre, maestroDto.APaterno, maestroDto.AMaterno, idMaestro });

            if (rowsAffected == 0)
                return ApiResponse<bool>.Error("Maestro no encontrado");

            return ApiResponse<bool>.Ok(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.Error(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Eliminar(int idMaestro)
    {
        try
        {
            var sql = "DELETE FROM Maestro WHERE idMaestro = @idMaestro";
            var rowsAffected = await connection.ExecuteAsync(sql, new { idMaestro });

            if (rowsAffected == 0)
                return ApiResponse<bool>.Error("Maestro no encontrado");

            return ApiResponse<bool>.Ok(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.Error(ex.Message);
        }
    }
}