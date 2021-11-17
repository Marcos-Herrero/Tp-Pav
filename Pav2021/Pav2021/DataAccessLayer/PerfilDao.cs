using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Pav2021.BusinessLayer;
using Pav2021.Entities;

namespace Pav2021.DataAccessLayer
{
    class PerfilDao
    {
        private PermisoService oPermisoService= new PermisoService();
        private UsuarioService oUsuarioService = new UsuarioService();
        internal bool Create(Perfil perfil)
        {
            var string_conexion = "Data Source=NBAR15232;Initial Catalog=DB_TP;Integrated Security=true;";

            // Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”
            SqlConnection dbConnection = new SqlConnection();
            SqlTransaction dbTransaction = null;
            try
            {
                dbConnection.ConnectionString = string_conexion;
                dbConnection.Open();
                //Genero la transacción
                dbTransaction = dbConnection.BeginTransaction();

                
                SqlCommand insertPerfil = new SqlCommand();
                insertPerfil.Connection = dbConnection;
                insertPerfil.CommandType = CommandType.Text;
                insertPerfil.Transaction = dbTransaction;
                // Establece la instrucción a ejecutar
                insertPerfil.CommandText = string.Concat("INSERT INTO [dbo].[Perfiles]",
                                            "           ([nombre]   ",
                                            "           ,[borrado])      ",
                                            "     VALUES                 ",
                                            "           (@nombre  ",
                                            "           ,@borrado)       ");



                //Agregamos los parametros
                insertPerfil.Parameters.AddWithValue("Nombre", perfil.Nombre);
                insertPerfil.Parameters.AddWithValue("borrado", false);

                insertPerfil.ExecuteNonQuery();


               
                SqlCommand consultaIDPerfil= new SqlCommand();
                consultaIDPerfil.Connection = dbConnection;
                consultaIDPerfil.CommandType = CommandType.Text;

                insertPerfil.CommandText = " SELECT @@IDENTITY";
                var newId = insertPerfil.ExecuteScalar();
                perfil.Id_Perfil = Convert.ToInt32(newId);


                //INSERT PERMISOS
                foreach (var permisoDetalle in perfil.DetallePermisos)
                {
                    //INSERT PERFIL
                    SqlCommand insertDetalle = new SqlCommand();
                    insertDetalle.Connection = dbConnection;
                    insertDetalle.CommandType = CommandType.Text;
                    insertDetalle.Transaction = dbTransaction;
                    // Establece la instrucción a ejecutar
                    insertDetalle.CommandText = string.Concat(" INSERT INTO [dbo].[Permisos] ",
                                                        "           ([id_formulario]   ",
                                                        "           ,[id_perfil]         ",
                                                        "           ,[borrado])             ",
                                                        "     VALUES                        ",
                                                        "           (@id_formulario           ",
                                                        "           ,@id_perfil          ",                                                     
                                                        "           ,@borrado)               ");

                    insertDetalle.Parameters.AddWithValue("id_perfil", perfil.Id_Perfil);
                    insertDetalle.Parameters.AddWithValue("id_formulario", permisoDetalle.Formulario.Id_Formulario);
                    insertDetalle.Parameters.AddWithValue("borrado", false);

                    insertDetalle.ExecuteNonQuery();
                }

                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw ex;
            }
            return true;
            
        }
        
        public IList<Perfil> GetAll()
        {
            List<Perfil> listadoPerfiles = new List<Perfil>();
            var strSql = "SELECT id_perfil, nombre from Perfiles where borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSql(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoPerfiles.Add(ObjectMapping(row));
            }

            return listadoPerfiles;
        }
       
        public IList<Perfil> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Perfil> lst = new List<Perfil>();
            var strSql = string.Concat(" SELECT p.id_perfil, p.nombre, f.nombre ",
                                        "   FROM Formularios f  INNER JOIN Permisos per ON f.id_formulario = per.id_formulario ",
                                         "   INNER JOIN Perfiles p ON per.id_perfil=p.id_perfil",
                                         "where p.borrado=0");

            if (parametros.ContainsKey("idPerfil"))
                strSql += " AND (id_perfil = @idPerfil) ";


            if (parametros.ContainsKey("nombre"))
                strSql += " AND (nombre =@nombre) ";

            var resultado = DataManager.GetInstance().ConsultaSql(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }
        public Perfil GetPermisoByID(int id)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_perfil, ",
                                          "        nombre ",
                                          "   FROM Perfiles ",
                                          "  WHERE id_perfil =@id");

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_perfil", id);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSql(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }
        public Perfil GetPerfil(string nombrePerfil)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_perfil, ",
                                          "        nombre ",
                                          "   FROM Perfiles ",
                                          "  WHERE nombre = @nombrePerfil");

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombrePerfil", nombrePerfil);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSql(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        

        internal bool Update(Perfil oPerfil, int id)
        {             
            var string_conexion = "Data Source=NBAR15232;Initial Catalog=DB_TP;Integrated Security=true;";
            SqlConnection dbConnection = new SqlConnection();           
            SqlTransaction dbTransaction = null;
            List<Permiso> lst = new List<Permiso>();
            try
            {
                dbConnection.ConnectionString = string_conexion;
                dbConnection.Open();
                
                dbTransaction = dbConnection.BeginTransaction();
                
                if(oPerfil.Nombre != "") {
                    SqlCommand insertPerfil = new SqlCommand();
                    insertPerfil.Connection = dbConnection;
                    insertPerfil.CommandType = CommandType.Text;
                    insertPerfil.Transaction = dbTransaction;
                    insertPerfil.CommandText = "     UPDATE Perfiles " +
                             "     SET nombre=@nombre" +
                              "     WHERE id_perfil=@id_perfil";
                    insertPerfil.Parameters.AddWithValue("Nombre", oPerfil.Nombre);
                    insertPerfil.Parameters.AddWithValue("id_perfil", id);
                    insertPerfil.ExecuteNonQuery();
                }
                
                List<Permiso> lista = (List<Permiso>)oPermisoService.GetPermisosByIdPerfil(id);
                if(lista.Count >0 && oPerfil.DetallePermisos.Count > 0 && oPerfil.DetallePermisos.Equals(lista))
                {
                    dbTransaction.Commit();
                }
                else
                {
                    foreach (var permisoDetalle in oPerfil.DetallePermisos)
                    {
                        lst.Add(permisoDetalle);
                        if (lista.Exists(x => x.Perfil.Id_Perfil == permisoDetalle.Perfil.Id_Perfil && x.Formulario.Id_Formulario == permisoDetalle.Formulario.Id_Formulario))
                        { }
                        else
                        { //INSERT PERFIL
                            SqlCommand insertDetalle = new SqlCommand();
                            insertDetalle.Connection = dbConnection;
                            insertDetalle.CommandType = CommandType.Text;
                            insertDetalle.Transaction = dbTransaction;
                            // Establece la instrucción a ejecutar
                            insertDetalle.CommandText = string.Concat(" INSERT INTO [dbo].[Permisos] ",
                                                                "           ([id_formulario]   ",
                                                                "           ,[id_perfil]         ",
                                                                "           ,[borrado])             ",
                                                                "     VALUES                        ",
                                                                "           (@id_formulario           ",
                                                                "           ,@id_perfil          ",
                                                                "           ,@borrado)               ");

                            insertDetalle.Parameters.AddWithValue("id_perfil", id);
                            insertDetalle.Parameters.AddWithValue("id_formulario", permisoDetalle.Formulario.Id_Formulario);
                            insertDetalle.Parameters.AddWithValue("borrado", false);

                            insertDetalle.ExecuteNonQuery();
                        }
                    }
                        foreach (Permiso permiso in lista)
                        {

                            if (lst.Exists(x => x.Perfil.Id_Perfil == permiso.Perfil.Id_Perfil && x.Formulario.Id_Formulario == permiso.Formulario.Id_Formulario)) { }
                            else
                            { //INSERT PERFIL
                                SqlCommand insertDeta = new SqlCommand();
                                insertDeta.Connection = dbConnection;
                                insertDeta.CommandType = CommandType.Text;
                                insertDeta.Transaction = dbTransaction;
                                // Establece la instrucción a ejecutar
                                insertDeta.CommandText = string.Concat(" Delete [dbo].[Permisos] ",
                                                                    "    Where    [id_formulario] = @id_formulario             ",
                                                                    "          and [id_perfil]=@id_perfil");

                                insertDeta.Parameters.AddWithValue("id_perfil", id);
                                insertDeta.Parameters.AddWithValue("id_formulario", permiso.Formulario.Id_Formulario);


                                insertDeta.ExecuteNonQuery();
                            }
                        }

                    
                    
                    dbTransaction.Commit();
                }
                
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw ex;
            }
            return true;
        }

        internal bool Delete(Perfil oPerfil)
        {
            if (oUsuarioService.getUsuariosPerfil(oPerfil.Id_Perfil).Count > 0) { return false; }
            else
            {
                string str_sql = "  UPDATE Perfiles" +
                        "     SET borrado = 1" +
                        "     WHERE id_perfil=@id_perfil";

                var parametros = new Dictionary<string, object>();
                parametros.Add("id_perfil", oPerfil.Id_Perfil);

                // Si una fila es afectada por la actualización retorna TRUE. Caso contrario FALSE
                return (DataManager.GetInstance().EjecutarSql(str_sql, parametros) == 1);
            }
           
        }

        private Perfil ObjectMapping(DataRow row)
        {
            Perfil operfil = new Perfil
            {
                Id_Perfil = Convert.ToInt32(row["id_perfil"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return operfil;
        }
    }
}
