using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class NegocioArticulo
    {
        public List<Articulo> listar()
        {
            List<Articulo> listado = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, C.Id IdCategoria, M.Id IdMarca from articulos A, MARCAS M, CATEGORIAS C where IdMarca = M.Id and IdCategoria = C.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo articuloAuxiliar = new Articulo();

                    articuloAuxiliar.Id = (int)lector["Id"];
                    articuloAuxiliar.Codigo = (string)lector["Codigo"];
                    articuloAuxiliar.Nombre = (string)lector["Nombre"];
                    articuloAuxiliar.Descripcion = (string)lector["Descripcion"];
                    articuloAuxiliar.Marca = new Marca();
                    articuloAuxiliar.Marca.Descripcion = (string)lector["Marca"];           
                    articuloAuxiliar.Categoria = new Categoria();
                    articuloAuxiliar.Categoria.Descripcion = (string)lector["Categoria"]; 

                    if (!(lector["ImagenUrl"] is DBNull))
                    articuloAuxiliar.ImagenUrl = (string)lector["ImagenUrl"];

                    articuloAuxiliar.Precio = (decimal)lector["Precio"];
                    string valor;
                    valor = articuloAuxiliar.Precio.ToString("N2");
                    articuloAuxiliar.Precio = Convert.ToDecimal(valor);

                    articuloAuxiliar.Categoria.Id = (int)lector["IdCategoria"];
                    articuloAuxiliar.Marca.Id = (int)lector["IdMarca"];

                    listado.Add(articuloAuxiliar);
                }

                conexion.Close();
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }                  
        }    
        
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idmarca, @idcategoria, @urlimagen, @precio)");

                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idmarca", nuevo.Marca.Id);
                datos.setearParametro("@idcategoria", nuevo.Categoria.Id);
                datos.setearParametro("@urlimagen", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, ImagenUrl = @imagenurl, Precio = @precio where Id = @id");

                datos.setearParametro("@codigo", seleccionado.Codigo);
                datos.setearParametro("@nombre", seleccionado.Nombre);
                datos.setearParametro("@descripcion", seleccionado.Descripcion);
                datos.setearParametro("@idmarca", seleccionado.Marca.Id);
                datos.setearParametro("@idcategoria", seleccionado.Categoria.Id);
                datos.setearParametro("@imagenurl", seleccionado.ImagenUrl);
                datos.setearParametro("@precio", seleccionado.Precio);
                datos.setearParametro("@id", seleccionado.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, C.Id IdCategoria, M.Id IdMarca from articulos A, MARCAS M, CATEGORIAS C where IdMarca = M.Id and IdCategoria = C.Id and ";

                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    default:
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articuloAuxiliar = new Articulo();

                    articuloAuxiliar.Id = (int)datos.Lector["Id"];
                    articuloAuxiliar.Codigo = (string)datos.Lector["Codigo"];
                    articuloAuxiliar.Nombre = (string)datos.Lector["Nombre"];
                    articuloAuxiliar.Descripcion = (string)datos.Lector["Descripcion"];
                    articuloAuxiliar.Marca = new Marca();
                    articuloAuxiliar.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articuloAuxiliar.Categoria = new Categoria();
                    articuloAuxiliar.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articuloAuxiliar.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    articuloAuxiliar.Precio = (decimal)datos.Lector["Precio"];
                    string valor;
                    valor = articuloAuxiliar.Precio.ToString("N2");
                    articuloAuxiliar.Precio = Convert.ToDecimal(valor);

                    articuloAuxiliar.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articuloAuxiliar.Marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(articuloAuxiliar);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
