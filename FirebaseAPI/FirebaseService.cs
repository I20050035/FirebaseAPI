using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirebaseAPI
{
    public class FirebaseService
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseService()
        {
            _firebaseClient = new FirebaseClient("https://tu-proyecto.firebaseio.com/");
        }

        public async Task<List<Autor>> GetAutoresAsync()
        {
            var autores = await _firebaseClient
                .Child("Autores")
                .OnceAsync<Autor>();

            return autores.Select(a => new Autor
            {
                Id = a.Key,
                ApellidosAutor = a.Object?.ApellidosAutor,
                FechaNacimiento = a.Object?.FechaNacimiento,
                IdAutor = a.Object?.IdAutor,
                LibroEscrito = a.Object?.LibroEscrito,
                NombresAutor = a.Object?.NombresAutor,
                PaisNacimiento = a.Object?.PaisNacimiento,
                UidUsuarioAutor = a.Object?.UidUsuarioAutor
            }).ToList();
        }

        public async Task<Autor> GetAutorAsync(string id)
        {
            var autor = await _firebaseClient
                .Child("Autores")
                .Child(id)
                .OnceSingleAsync<Autor>();

            return autor;
        }

        public async Task CreateAutorAsync(Autor autor)
        {
            await _firebaseClient
                .Child("Autores")
                .PostAsync(autor);
        }

        public async Task UpdateAutorAsync(string id, Autor autor)
        {
            await _firebaseClient
                .Child("Autores")
                .Child(id)
                .PutAsync(autor);
        }

        public async Task DeleteAutorAsync(string id)
        {
            await _firebaseClient
                .Child("Autores")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            var categorias = await _firebaseClient
                .Child("Categorias")
                .OnceAsync<Categoria>();

            return categorias.Select(c => new Categoria
            {
                Id = c.Key,
                Descripcion = c.Object?.Descripcion,
                IdCategoria = c.Object?.IdCategoria,
                LibroCategoria = c.Object?.LibroCategoria,
                NombreCategoria = c.Object?.NombreCategoria,
                UidUsuarioCategorias = c.Object?.UidUsuarioCategorias
            }).ToList();
        }

        public async Task<Categoria> GetCategoriaAsync(string id)
        {
            var categoria = await _firebaseClient
                .Child("Categorias")
                .Child(id)
                .OnceSingleAsync<Categoria>();

            return categoria;
        }

        public async Task CreateCategoriaAsync(Categoria categoria)
        {
            await _firebaseClient
                .Child("Categorias")
                .PostAsync(categoria);
        }

        public async Task UpdateCategoriaAsync(string id, Categoria categoria)
        {
            await _firebaseClient
                .Child("Categorias")
                .Child(id)
                .PutAsync(categoria);
        }

        public async Task DeleteCategoriaAsync(string id)
        {
            await _firebaseClient
                .Child("Categorias")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<List<Editorial>> GetEditorialesAsync()
        {
            var editoriales = await _firebaseClient
                .Child("Editoriales")
                .OnceAsync<Editorial>();

            return editoriales.Select(e => new Editorial
            {
                Id = e.Key,
                AñoFundacionEditorial = e.Object?.AñoFundacionEditorial,
                IdEditorial = e.Object?.IdEditorial,
                LibroEditorial = e.Object?.LibroEditorial,
                NombresEditoriales = e.Object?.NombresEditoriales,
                PaisEditorial = e.Object?.PaisEditorial,
                UidUsuarioEditoriales = e.Object?.UidUsuarioEditoriales
            }).ToList();
        }

        public async Task<Editorial> GetEditorialAsync(string id)
        {
            var editorial = await _firebaseClient
                .Child("Editoriales")
                .Child(id)
                .OnceSingleAsync<Editorial>();

            return editorial;
        }

        public async Task CreateEditorialAsync(Editorial editorial)
        {
            await _firebaseClient
                .Child("Editoriales")
                .PostAsync(editorial);
        }

        public async Task UpdateEditorialAsync(string id, Editorial editorial)
        {
            await _firebaseClient
                .Child("Editoriales")
                .Child(id)
                .PutAsync(editorial);
        }

        public async Task DeleteEditorialAsync(string id)
        {
            await _firebaseClient
                .Child("Editoriales")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            var libros = await _firebaseClient
                .Child("Libros")
                .OnceAsync<Libro>();

            return libros.Select(l => new Libro
            {
                Id = l.Key,
                Autor = l.Object?.Autor,
                AñoPublicacion = l.Object?.AñoPublicacion,
                CantidadDisponible = l.Object?.CantidadDisponible,
                Genero = l.Object?.Genero,
                IdLibro = l.Object?.IdLibro,
                NumeroPaginas = l.Object?.NumeroPaginas,
                Titulo = l.Object?.Titulo,
                UidUsuario = l.Object?.UidUsuario
            }).ToList();
        }

        public async Task<Libro> GetLibroAsync(string id)
        {
            var libro = await _firebaseClient
                .Child("Libros")
                .Child(id)
                .OnceSingleAsync<Libro>();

            return libro;
        }

        public async Task CreateLibroAsync(Libro libro)
        {
            await _firebaseClient
                .Child("Libros")
                .PostAsync(libro);
        }

        public async Task UpdateLibroAsync(string id, Libro libro)
        {
            await _firebaseClient
                .Child("Libros")
                .Child(id)
                .PutAsync(libro);
        }

        public async Task DeleteLibroAsync(string id)
        {
            await _firebaseClient
                .Child("Libros")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<List<Prestamo>> GetPrestamosAsync()
        {
            var prestamos = await _firebaseClient
                .Child("Prestamos")
                .OnceAsync<Prestamo>();

            return prestamos.Select(p => new Prestamo
            {
                Id = p.Key,
                EstadoPrestamo = p.Object?.EstadoPrestamo,
                FechaDevolucion = p.Object?.FechaDevolucion,
                FechaPrestamo = p.Object?.FechaPrestamo,
                IdPrestamo = p.Object?.IdPrestamo,
                Libro = p.Object?.Libro,
                NombreSolicitante = p.Object?.NombreSolicitante
            }).ToList();
        }

        public async Task<Prestamo> GetPrestamoAsync(string id)
        {
            var prestamo = await _firebaseClient
                .Child("Prestamos")
                .Child(id)
                .OnceSingleAsync<Prestamo>();

            return prestamo;
        }

        public async Task CreatePrestamoAsync(Prestamo prestamo)
        {
            await _firebaseClient
                .Child("Prestamos")
                .PostAsync(prestamo);
        }

        public async Task UpdatePrestamoAsync(string id, Prestamo prestamo)
        {
            await _firebaseClient
                .Child("Prestamos")
                .Child(id)
                .PutAsync(prestamo);
        }

        public async Task DeletePrestamoAsync(string id)
        {
            await _firebaseClient
                .Child("Prestamos")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<List<Resena>> GetResenasAsync()
        {
            var resenas = await _firebaseClient
                .Child("Resenas")
                .OnceAsync<Resena>();

            return resenas.Select(r => new Resena
            {
                Id = r.Key,
                AutorResena = r.Object?.AutorResena,
                Calificacion = r.Object?.Calificacion,
                Comentarios = r.Object?.Comentarios,
                FechaResena = r.Object?.FechaResena,
                IdResena = r.Object?.IdResena,
                LibroResena = r.Object?.LibroResena,
                UidUsuarioResenas = r.Object?.UidUsuarioResenas
            }).ToList();
        }

        public async Task<Resena> GetResenaAsync(string id)
        {
            var resena = await _firebaseClient
                .Child("Resenas")
                .Child(id)
                .OnceSingleAsync<Resena>();

            return resena;
        }

        public async Task CreateResenaAsync(Resena resena)
        {
            await _firebaseClient
                .Child("Resenas")
                .PostAsync(resena);
        }

        public async Task UpdateResenaAsync(string id, Resena resena)
        {
            await _firebaseClient
                .Child("Resenas")
                .Child(id)
                .PutAsync(resena);
        }

        public async Task DeleteResenaAsync(string id)
        {
            await _firebaseClient
                .Child("Resenas")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            var usuarios = await _firebaseClient
                .Child("Usuarios")
                .OnceAsync<Usuario>();

            return usuarios.Select(u => new Usuario
            {
                Uid = u.Key,
                Apellidos = u.Object?.Apellidos,
                Correo = u.Object?.Correo,
                Nombres = u.Object?.Nombres,
                Password = u.Object?.Password,
                Telefono = u.Object?.Telefono
            }).ToList();
        }

        public async Task<Usuario> GetUsuarioAsync(string id)
        {
            var usuario = await _firebaseClient
                .Child("Usuarios")
                .Child(id)
                .OnceSingleAsync<Usuario>();

            return usuario;
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _firebaseClient
                .Child("Usuarios")
                .PostAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(string id, Usuario usuario)
        {
            await _firebaseClient
                .Child("Usuarios")
                .Child(id)
                .PutAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(string id)
        {
            await _firebaseClient
                .Child("Usuarios")
                .Child(id)
                .DeleteAsync();
        }
    }
}
