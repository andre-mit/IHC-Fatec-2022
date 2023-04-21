﻿using VendaCarros.Enums;
using VendaCarros.Models;

namespace VendaCarros.Services.Helpers;

public class UsuarioToken
{
    public int Id { get; set; }
    public string Email { get; set; }
    public Funcao Funcao { get; set; }

    public UsuarioToken(Usuario usuario, Funcao funcao)
    {
        Id = usuario.Id;
        Email = usuario.Email;
        Funcao = usuario.Funcao;
        Funcao = funcao;
    }
}