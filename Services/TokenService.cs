﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class TokenService
{
    public string GenerateToken(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", usuario.UserName),
            new Claim("usuarioId", usuario.Id),
            new Claim("dataNascimento", usuario.DataNascimento.ToString()),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gGASDPF8IASGFDSFP8IGDSOF241325435"));

        var signingCredentials = new  SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}