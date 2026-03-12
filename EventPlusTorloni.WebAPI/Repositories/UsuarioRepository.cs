using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using EventPlusTorloni.WebAPI.Util;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;
    //Método construtor que aplica a injeção de dependencia
    public UsuarioRepository(EventContext context)
    {
        _context = context; 
    }

    /// <summary>
    /// Cadastra um novo usuário. A senha é criptografada e o Id gerado pelo banco
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }


    /// <summary>
    /// Busca um usuario pelo Id incluindo os seus dados de seu tipo de usuario
    /// </summary>
    /// <param name="id">id do usuario buscado</param>
    /// <returns>Usuario Buscado</returns>
    public Usuario ListarPorId(Guid id)
    {
        return _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.IdUsuario == id)!;
    }

    /// <summary>
    /// Busca um usuario pelo e-mail e valida o hash da senha
    /// </summary>
    /// <param name="id">Email do usuario a ser validado</param>
    /// <param name="Senha">Senha para validar o usuario</param>
    /// <returns>Usuario Buscado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        //Primeiro, buscar o usuário pelo e-mail
        var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Email == Email);

        //Verificar se o usuário foi encontrado
        if(usuarioBuscado != null)
        {
            //Comparamos o hash da senha digitada como qie está no banco
            bool confere = Criptografia.CompararSenha(Senha,usuarioBuscado.Senha);
            if (confere)
            {
                return usuarioBuscado;
            }
        }
        return null!;
    }

    public List<Usuario> Listar()
    {
        throw new NotImplementedException();
    }


    public void Delete(Guid IdUsuario)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Guid id, Usuario usuario)
    {
        throw new NotImplementedException();
    }
}
