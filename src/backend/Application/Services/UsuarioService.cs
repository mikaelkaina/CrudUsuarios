using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    public async Task AddAsync(UsuarioDto dto)
    {
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Idade = dto.Idade,
            Email = dto.Email

        };

        await _repository.AddAsync(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<UsuarioDto>> GetAllAsync()
    {
        var usuarios = await _repository.GetAllAsync();
        return usuarios.Select(u => new UsuarioDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Idade = u.Idade,
            Email = u.Email
        }).ToList();
    }

    public async Task<UsuarioDto?> GetByIdAsync(int id)
    {
        var usuario = await _repository.GetByUsuarioId(id);
        if (usuario == null) return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Idade = usuario.Idade,
            Email = usuario.Email  
        };
    }

    public async Task UpdateAsync(int id, UsuarioDto dto)
    {
        var usuario = new Usuario
        {
            Id = id,
            Nome = dto.Nome,
            Idade = dto.Idade,
            Email = dto.Email
        };

        await _repository.UpdateAsync(usuario);
    }
}
