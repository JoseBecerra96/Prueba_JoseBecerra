using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Usuario
    {
        public static Model.DataResult<Model.Usuario> GetAll()
        {
            Model.DataResult<Model.Usuario> dataResult = new Model.DataResult<Model.Usuario>();
            try
            {
                using (DataSource.PruebaJoseBecerraContext context = new DataSource.PruebaJoseBecerraContext())
                {
                    var data = context.Usuarios.FromSqlRaw("UsuarioGetAll").ToList();
                    if (data != null && data.Count > 0)
                    {
                        dataResult.Values = new List<Model.Usuario>();
                        foreach (var obj in data)
                        {
                            Model.Usuario usuario = new Model.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.Edad = obj.Edad;
                            usuario.Email = obj.Email;

                            dataResult.Values.Add(usuario);
                        }
                        dataResult.Result = true;
                    }

                }
            }
            catch (Exception ex)
            {
                dataResult.Ex = ex;
                dataResult.Message = ex.Message;
                dataResult.Result = false;
            }
            return dataResult;
        }
        public static Model.DataResult<Model.Usuario> Add(Model.Usuario usuario)
        {
            Model.DataResult<Model.Usuario> dataResult = new Model.DataResult<Model.Usuario>();
            try
            {
                using (DataSource.PruebaJoseBecerraContext context = new DataSource.PruebaJoseBecerraContext())
                {
                    int result = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}',{usuario.Edad},'{usuario.Email}'");

                    dataResult.Result = (result > 0) ? true : false;
                }
            }
            catch (Exception ex)
            {
                dataResult.Ex = ex;
                dataResult.Message = ex.Message;
                dataResult.Result = false;
            }
            return dataResult;
        }
        public static Model.DataResult<Model.Usuario> Update(Model.Usuario usuario)
        {
            Model.DataResult<Model.Usuario> dataResult = new Model.DataResult<Model.Usuario>();
            try
            {
                using (DataSource.PruebaJoseBecerraContext context = new DataSource.PruebaJoseBecerraContext())
                {
                    int result = context.Database.ExecuteSqlRaw($"UsuarioUpdate  {usuario.IdUsuario},'{usuario.Nombre}',{usuario.Edad},'{usuario.Email}'");

                    dataResult.Result = (result > 0) ? true : false;
                }
            }
            catch (Exception ex)
            {
                dataResult.Ex = ex;
                dataResult.Message = ex.Message;
                dataResult.Result = false;
            }
            return dataResult;
        }
        public static Model.DataResult<Model.Usuario> Delete(int idUsuario)
        {
            Model.DataResult<Model.Usuario> dataResult = new Model.DataResult<Model.Usuario>();
            try
            {
                using (DataSource.PruebaJoseBecerraContext context = new DataSource.PruebaJoseBecerraContext())
                {
                    int result = context.Database.ExecuteSqlRaw($"UsuarioDelete  {idUsuario}");

                    dataResult.Result = (result > 0) ? true : false;
                }
            }
            catch (Exception ex)
            {
                dataResult.Ex = ex;
                dataResult.Message = ex.Message;
                dataResult.Result = false;
            }
            return dataResult;
        }
        public static Model.DataResult<Model.Usuario> GetById(int idUsuario)
        {
            Model.DataResult<Model.Usuario> dataResult = new Model.DataResult<Model.Usuario>();
            try
            {
                using (DataSource.PruebaJoseBecerraContext context = new DataSource.PruebaJoseBecerraContext())
                {
                    var obj = context.Usuarios.FromSqlRaw($"UsuarioGetById {idUsuario}").AsEnumerable().Single();
                    if (obj != null)
                    {
                        Model.Usuario usuario = new Model.Usuario();
                        usuario.IdUsuario = obj.IdUsuario;
                        usuario.Nombre = obj.Nombre;
                        usuario.Edad = obj.Edad;
                        usuario.Email = obj.Email;

                        dataResult.Value = usuario;
                    }
                    dataResult.Result = true;
                }
            }
            catch (Exception ex)
            {
                dataResult.Ex = ex;
                dataResult.Message = ex.Message;
                dataResult.Result = false;
            }
            return dataResult;
        }
    }
}
