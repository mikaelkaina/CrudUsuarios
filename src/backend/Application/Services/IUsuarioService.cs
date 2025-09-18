using Application.DTOs;

namespace Application.Services;

public interface IUsuarioService
{
    Task <List<UsuarioDto>> GetAllAsync();
    Task<UsuarioDto?> GetByIdAsync(int id);
    Task AddAsync(UsuarioDto dto);
    Task UpdateAsync(int id, UsuarioDto usuarioDto);
    Task DeleteAsync(int id);
}
