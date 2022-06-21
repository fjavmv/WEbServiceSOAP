using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//paquete para usar db postgresql
using Npgsql;
using User;

namespace Ejemplmagen
{
    internal class DbPostgresql
    {

        //Datos de configuración para acceder a la db
        static string servidor = "localhost";
        static string dbName = "biblioteca";
        static string usuario = "postgres";
        static string password = "A9BXZWC173";
        static string puerto = "5432";

      /*  public void configuracion()
        {

            try
            {
                var estado = crearDb();

                if (estado.State == System.Data.ConnectionState.Closed)
                {
                    CrearTablaDb();
                }

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private NpgsqlConnection crearDb()
        {

            // 1. Cadena de conexión para crear la db
            string cadenaDeConexionDb = "server= localhost; port= 5432; user id= postgres; password= A9BXZWC173;";

            //2. Query para crear la db
            const string QUERY_CREATE_DB = "CREATE DATABASE dbtest " + "WITH OWNER = postgres " + "ENCODING = 'UTF8' " + "CONNECTION LIMIT = -1;";

            //3. Creamos una instancia de la clase  NpgsqlConnection  para establecer la conexión
            NpgsqlConnection dbConexion = new NpgsqlConnection(cadenaDeConexionDb); // Recibe cadena de conexión al servidor

            //4.Creamos una instancia de NpgsqlCommand para crear la db
            NpgsqlCommand npgsqlCommandQuery = new NpgsqlCommand(QUERY_CREATE_DB, dbConexion);

            //5. Abrimos la conexión para crear la DB
            try
            {
                //Verificamos el estado de la conexión
                if (dbConexion.State == System.Data.ConnectionState.Closed)
                {
                    dbConexion.Open();
                    Console.WriteLine("La conexion se ha realizado de forma exitosa......");
                }
                else
                {
                    Console.WriteLine("La conexion ya se ha realizado......");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //6. Creamos la DB
            try
            {
                //Verificamos si la conexión se ha realizado
                if (dbConexion.State == System.Data.ConnectionState.Open)
                {
                    npgsqlCommandQuery.ExecuteNonQuery();
                    Console.WriteLine("Se ha creado la base de datos.......");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            // 7. Cerramos la conexión
            desconectar(dbConexion);
            return dbConexion;
        }

        private void CrearTablaDb()
        {
            // 1. Cadena de conexión para crear la tabla
            string cadenaDeConexionTabla = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";

            //2. Creamos una instancia de la clase  NpgsqlConnection  para establecer la conexión
            NpgsqlConnection dbConectionTabla = new NpgsqlConnection(cadenaDeConexionTabla); // Recibe cadena de conexión al la db para la tabla

            //3. Query para crear la tabla
            const string QUERY_CREATE_TABLA_DB = "CREATE TABLE public.videogame (game_id SERIAL," +
                "game_name CHARACTER VARYING(30) NOT NULL," +
                "game_description CHARACTER VARYING(500) NOT NULL," +
                "release_year BIGINT NOT NULL," +
                "CONSTRAINT pk_game_id PRIMARY KEY(game_id)" +
                "); ";
            //4. Creamos una instancia de NpgsqlCommand para establecer la conexión
            NpgsqlCommand commandQueryTabla = new NpgsqlCommand(QUERY_CREATE_TABLA_DB, dbConectionTabla);

            // 5. Abrimos la conexión para crear la tabla 
            try
            {
                //Verificamos el estado de la conexión
                if (dbConectionTabla.State == System.Data.ConnectionState.Closed)
                {
                    dbConectionTabla.Open();
                    Console.WriteLine("La conexion esta abierta....");
                }
                else
                {
                    Console.WriteLine("La conexion esta abierta....");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            //6. Creamos la tabla en la DB
            try
            {
                //Verificamos el estado de la conexión
                if (dbConectionTabla.State == System.Data.ConnectionState.Open)
                {
                    commandQueryTabla.ExecuteNonQuery();
                    Console.WriteLine("Tabla creada........");
                }

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            //7. Cerramos conexión
            desconectar(dbConectionTabla);
        }*/


        //Insertar elementos a la Db
        public void insertar(Usuario modelImg)
        {

            // 1. Cadena de conexión para crear la tabla
            string cadenaDeConexionTabla = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";

            // 2. Creamos una instancia de la clase NpgsqlConnection
            NpgsqlConnection connectionInsertarElement = new NpgsqlConnection(cadenaDeConexionTabla);

            //string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO img (image) VALUES (@img);");
            string QUERY_INSERT_ELEMENTOS = "INSERT INTO img (image) VALUES (@img);";
            //5.Creamos uns instancia de NpgsqlWrite
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connectionInsertarElement);


            //6. Abrir la conexión a la db
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Closed)
                {
                    NpgsqlParameter param = commandInsert.CreateParameter();
                    param.ParameterName = "@img";
                    param.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                   // param.Value = modelImg.img;
                    commandInsert.Parameters.Add(param);

                    connectionInsertarElement.Open();
                    Console.WriteLine("La conexion se ha abierto........");
                }
                else
                {
                    Console.WriteLine("La conexion ya se encuentra abierta.....");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //7. Insertamos elementos
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Open)
                {
                    commandInsert.ExecuteNonQuery();
                   
                    Console.WriteLine("Se ha guardado tu informacion.......");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            desconectar(connectionInsertarElement);

        }

        //Método que permite la consulta de datos
        public List<string> consultarIds()
        {
            
            List<string> lista = new List<string>();  
            // 1. Cadena de conexión para crear la tabla
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";
            // 2. Creamos una instancia de la clase NpgsqlConnection
            NpgsqlConnection connectionConsultar = new NpgsqlConnection(cadenaDeConexion);

            string query = "SELECT id_image FROM img;";

            NpgsqlCommand commandConsultar = new NpgsqlCommand(query, connectionConsultar);
            
            //Establecer conexion
            try
            {
                if (connectionConsultar.State == System.Data.ConnectionState.Closed)
                {
                    connectionConsultar.Open();
                    Console.WriteLine("La conexion se ha abierto........");

                }
                else
                {
                    Console.WriteLine("La conexion ya se encuentra abierta.....");
                }

            }
            catch (NpgsqlException ex)
            {

                Console.WriteLine(ex.Message);
            }

            //Query
            try
            {
                if (connectionConsultar.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader = commandConsultar.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int valorId = dataReader.GetInt16(0);
                        lista.Add(valorId.ToString());
                    }

                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            desconectar(connectionConsultar);
            return lista;
          
        }

        public Usuario consultaId(int id)
        {
            Usuario data = null;
            // 1. Cadena de conexión para crear la tabla
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";
            // 2. Creamos una instancia de la clase NpgsqlConnection
            NpgsqlConnection connectionConsultar = new NpgsqlConnection(cadenaDeConexion);

            string query = string.Format("SELECT * FROM usuarios WHERE id_usuario={0};", id);

            NpgsqlCommand commandConsultar = new NpgsqlCommand(query, connectionConsultar);

            //Establecer conexion
            try
            {
                if (connectionConsultar.State == System.Data.ConnectionState.Closed)
                {
                    connectionConsultar.Open();
                    Console.WriteLine("La conexion se ha abierto........");

                }
                else
                {
                    Console.WriteLine("La conexion ya se encuentra abierta.....");
                }

            }
            catch (NpgsqlException ex)
            {

                Console.WriteLine(ex.Message);
            }

            //Query
            try
            {
                if (connectionConsultar.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader = commandConsultar.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string nombre = dataReader.GetString(1);
                        string apellidoP = dataReader.GetString(2);
                        string apellidoM = dataReader.GetString(3);

                        data = new Usuario(nombre, apellidoP, apellidoM);

                    }

                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            desconectar(connectionConsultar);
            return data;

        }

        public List<Usuario> consultaTodo()
        {
            List<Usuario> data = new List<Usuario>();
            // 1. Cadena de conexión para crear la tabla
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";
            // 2. Creamos una instancia de la clase NpgsqlConnection
            NpgsqlConnection connectionConsultar = new NpgsqlConnection(cadenaDeConexion);

            string query = string.Format("SELECT * FROM usuarios;");

            NpgsqlCommand commandConsultar = new NpgsqlCommand(query, connectionConsultar);

            //Establecer conexion
            try
            {
                if (connectionConsultar.State == System.Data.ConnectionState.Closed)
                {
                    connectionConsultar.Open();
                    Console.WriteLine("La conexion se ha abierto........");

                }
                else
                {
                    Console.WriteLine("La conexion ya se encuentra abierta.....");
                }

            }
            catch (NpgsqlException ex)
            {

                Console.WriteLine(ex.Message);
            }

            //Query
            try
            {
                if (connectionConsultar.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader = commandConsultar.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string nombre = dataReader.GetString(1);
                        string apellidoP = dataReader.GetString(2);
                        string apellidoM = dataReader.GetString(3);

                        data.Add(new Usuario(nombre, apellidoP, apellidoM));

                    }

                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            desconectar(connectionConsultar);
            return data;

        }


        //Insertar elementos a la Db
        /*   public void insertarNombreArchivo(Usuario modelImg)
           {

               // 1. Cadena de conexión para crear la tabla
               string cadenaDeConexionTabla = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";

               // 2. Creamos una instancia de la clase NpgsqlConnection
               NpgsqlConnection connectionInsertarElement = new NpgsqlConnection(cadenaDeConexionTabla);


               string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO nombre_file (nombre_imagen) VALUES ('{0}');",1);
               //5.Creamos uns instancia de NpgsqlWrite
               NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connectionInsertarElement);


               //6. Abrir la conexión a la db
               try
               {
                   if (connectionInsertarElement.State == System.Data.ConnectionState.Closed)
                   {
                       connectionInsertarElement.Open();
                       Console.WriteLine("La conexion se ha abierto........");
                   }
                   else
                   {
                       Console.WriteLine("La conexion ya se encuentra abierta.....");
                   }
               }
               catch (NpgsqlException ex)
               {
                   Console.WriteLine(ex.Message);
               }

               //7. Insertamos elementos
               try
               {
                   if (connectionInsertarElement.State == System.Data.ConnectionState.Open)
                   {
                       commandInsert.ExecuteNonQuery();

                       Console.WriteLine("Se ha guardado tu informacion.......");
                   }
               }
               catch (NpgsqlException ex)
               {
                   Console.WriteLine(ex.Message);
               }

               desconectar(connectionInsertarElement);

           }*/















        /*
        public ModeloGames ConsultaDos(int game_id)
        {

            ModeloGames mGames = new ModeloGames();
            //List<ModeloGames> list = new List<ModeloGames>();

            //Configuración para conectarse a la db
            // 1. Cadena de conexión para crear la tabla
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";

            //3. Instancia de NpgsqlConnection
            NpgsqlConnection connectionDos = new NpgsqlConnection(cadenaDeConexion);
            //4. consulta
            string QUERY_CONSULTA = string.Format("SELECT game_id, game_name, game_description, release_year FROM videogame WHERE game_id = {0};", game_id);
            //5. Instancia de NpgsqlCommand
            NpgsqlCommand commandConsultaDos = new NpgsqlCommand(QUERY_CONSULTA, connectionDos);

            //6 Abrimos la conexion

            try
            {
                if (connectionDos.State == System.Data.ConnectionState.Closed)
                {
                    connectionDos.Open();
                    Console.WriteLine("Se ha realizado la conexion exitosa.........");
                }
                else
                {
                    Console.WriteLine("Ya hay una conexion establecida.........");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //7. ejecutamos query
            try
            {
                if (connectionDos.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsultaDos.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        Console.WriteLine("Almacenando datos......");
                        mGames.GameId = dataReader2.GetInt16(0);
                        mGames.GameName = dataReader2.GetString(1);
                        mGames.GameDescription = dataReader2.GetString(2);
                        mGames.ReleaseYear = dataReader2.GetInt32(3);

                        // list.Insert(mGames);
                    }
                }

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            desconectar(connectionDos);
            return mGames;
        }

        public void eliminar(int game_id)
        {

            ModeloGames mGames = new ModeloGames();
            //List<ModeloGames> list = new List<ModeloGames>();

            //Configuración para conectarse a la db
            // 1. Cadena de conexión para crear la tabla
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + dbName + ";";

            //3. Instancia de NpgsqlConnection
            NpgsqlConnection connectionDos = new NpgsqlConnection(cadenaDeConexion);
            //4. consulta
            string QUERY_CONSULTA = string.Format("DELETE FROM videogame WHERE game_id = {0};", game_id);
            //5. Instancia de NpgsqlCommand
            NpgsqlCommand commandDelete = new NpgsqlCommand(QUERY_CONSULTA, connectionDos);

            //6 Abrimos la conexion

            try
            {
                if (connectionDos.State == System.Data.ConnectionState.Closed)
                {
                    connectionDos.Open();
                    Console.WriteLine("Se ha realizado la conexion exitosa.........");
                }
                else
                {
                    Console.WriteLine("Ya hay una conexion establecida.........");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //7. ejecutamos query
            try
            {
                if (connectionDos.State == System.Data.ConnectionState.Open)
                {
                    commandDelete.ExecuteNonQuery();
                    Console.WriteLine("Registro eliminado.....");
                }

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            desconectar(connectionDos);

        }*/




        //Método para desconectar db
        public void desconectar(NpgsqlConnection connection)
        {

            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Se ha cerrado la conexion a la DB");
                }
                else
                {
                    Console.WriteLine("La conexion ya ha sido cerrada");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("Error al cerrar la conexion {0}", ex);
            }

        }

    }
}
