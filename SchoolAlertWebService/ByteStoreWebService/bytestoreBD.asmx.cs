using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ByteStoreWebService
{
    /// <summary>
    /// Summary description for bytestoreBD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class bytestoreBD : System.Web.Services.WebService
    {
        static string MyConString = "SERVER=localhost;" +
                "DATABASE=SchoolAlert;" +
                "UID=root;" +
                "PASSWORD=nandito3555;";
        MySqlConnection cn = new MySqlConnection(MyConString);
        MySqlCommand sqm;
        /*MySqlDataReader sdr;
        MySqlDataAdapter sad;
        DataSet ds;
        DataTable dt;*/
		/*
		 *0 - Alta, modificacion y baja Usuarios min 3 Y
		 *1 - Alta, modificacion y baja Alumno min 3 Y
		 *2 - Alta, modificacion y baja Docente min 3 Y
		 *3 - Alta, modificacion y baja Personal min 3 Y
		 *4 - Alta, modificacion y baja Depto min 3 Y
		 *5 - Alta, modificacion y baja Materia min 3 Y
		 *6 - Alta, modificacion y baja Grupo min 3
		 *7 - Alta, modificacion Horario min 2
		 * Min 23 métodos D: 
		 */
        /*[WebMethod(CacheDuration = 30,
            Description = "Da de alta un usuario recibiendo como parámetros la clave, idusuario," +
            " password (length = 8), y nivel. Regresa el resultado de la operación.\n\nTener cuidado " + 
		    "de que sólo un usuario de nivel 5 pueda crear usuarios")]
        public string AltaUsuario(string clave, string usuario, string password,
            int nivel)
        {
			if(true)
			{
	            try
	            {
	                //Set insert query
	                string qry = "insert into Usuarios values('" + usuario + "','" + password + "','" + nivel + 
	                    "','" + correo + "')";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
	
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                cn.Close();
	
	                return "Operación exitosa";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
			}
        }

        [WebMethod(CacheDuration = 30,
            Description = "Da de baja un usuario recibiendo como parámetro el idUsuario.")]
        public string BajaUsuario(string usuario)
        {
            try
            {
                //Set insert query
                string qry = "delete Usuarios where idUsuario = '" + usuario + "'";

                //Initialize SqlCommand object for insert.
                MySqlCommand SqlCom = new MySqlCommand(qry, cn);

                //Open connection and execute insert query.
                cn.Open();
                SqlCom.ExecuteNonQuery();
                cn.Close();

                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [WebMethod(CacheDuration = 30,
            Description = "Actualiza el password de un usuario recibiendo como parámetro su idUsuario y la nueva password.")]
        public string ActualizaPasswordUsuario(string usuario, string password)
        {
            try
            {
                //Set insert query
                string qry = "update Usuarios set password = '" + password + "' where idUsuario = '" + usuario + "'";

                //Initialize SqlCommand object for insert.
                MySqlCommand SqlCom = new MySqlCommand(qry, cn);

                //Open connection and execute insert query.
                cn.Open();
                SqlCom.ExecuteNonQuery();
                cn.Close();

                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        [WebMethod(CacheDuration = 30,
            Description = "No sirve esta mugre")]
        public string ConsultarUsuario(string usuario)
        {
            try
            {
                //Llenar la tabla con los datos
                sqm = new MySqlCommand("SELECT * FROM Usuarios where idUsuario = '" + usuario + "'", cn);
                MySqlDataReader sqr = sqm.ExecuteReader();
                if (sqr.HasRows)
                {
                    while (sqr.Read())
                    {
                        List<string> registro = new List<string>();
                        registro.Add(sqr["nombre_usuario"].ToString());
                        registro.Add(sqr["password"].ToString()); 
                        registro.Add(sqr["nombre"].ToString());
                        registro.Add(sqr["correo"].ToString());
                    }
                }
                return "no sirve";
            }
            catch (Exception ex)
            {
                return null;
            }
        }*/
		#region Métodos Usuarios
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de los departamentos recibiendo como parámetros la clave," + 
            "y los valores de búsqueda opcionales id, nombre (MAX 50), teléfono y correo (MAX 40)")]
        public string[][] VerUsuarios(string clave,
            string id = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Usuarios";
					if(id != "")
					{
						qry += " WHERE idUsuario = " + id;
					}
					sqm = new MySqlCommand(qry, cn);
					//sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idUsuario"].ToString());
							registro.Add(sqr["password"].ToString());
							registro.Add(sqr["nivel"].ToString());
							registros.Add(registro);
	                    }
	                }
					else
					{
						List<string> msj = new List<string>();
						msj.Add("No se encontró ningún registro");
						registros.Add(msj);
					}
					return registros.Select(a => a.ToArray()).ToArray();
					cn.Close();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
					registros.Add(registro);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				registros.Add(registro);
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Actualiza la contraseña de un usuario recibiendo su id y la contraseña nueva (MAX 8)")]
		public string ActualizaPasswordUsuario(string clave,
            string id, string nuevaPass)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT * from Usuarios Where idUsuario = @id", cn);
					sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
						
	                }
					else
					{
						return "No existe tal usuario";
					}
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
	                //Set insert query
	                string qry;
	                qry = "UPDATE Usuarios SET password = @nuevaPass WHERE idUsuario = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id", id);
					SqlCom.Parameters.AddWithValue("@nuevaPass", nuevaPass);
					//Open connection and execute insert query.
	                SqlCom.ExecuteNonQuery();
	                return "Usuario actualizado";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		#endregion
		/////////////////////////////Métodos Docente////////////////////////////////////////////////////////////
		#region Métodos Docente
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de alta un profesor recibiendo como parámetros la clave," + 
            "nombre (max 50), apellido paterno (max 50), apellido materno (max 50), " + 
		    "calle (max 60), colonia (max 60), municipio (max 25), estado (max 15), " + 
		    "codigo postal, telefono, correo (max 40), título (max 50) y grado (max 15)")]
        public string[] AltaDocente(string clave,
            string nombre, string apellidoPaterno, string apellidoMaterno, string direccionCalle,
		    string direccionColonia, string municipio, string estado, string codigoPostal, 
		    string telefono, string correo, string titulo, string grado)
        {
			List<string> returnElems = new List<string>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					setIncrementDocentes();
	                //Set insert query
	                string qry;
	                qry = "insert into Docentes values(0,@nom,@apat,@amat,@dCalle,@dColonia,@mun,@edo,@tel,@mail," + 
						"@cp, @titulo, @grado, @fecha)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@nom", nombre);
					SqlCom.Parameters.AddWithValue("@apat", apellidoPaterno);
					SqlCom.Parameters.AddWithValue("@amat", apellidoMaterno);
					SqlCom.Parameters.AddWithValue("@dCalle", direccionCalle);
					SqlCom.Parameters.AddWithValue("@dColonia", direccionColonia);
					SqlCom.Parameters.AddWithValue("@mun", municipio);
					SqlCom.Parameters.AddWithValue("@edo", estado);
					SqlCom.Parameters.AddWithValue("@tel", telefono);
					SqlCom.Parameters.AddWithValue("@mail", correo);
					SqlCom.Parameters.AddWithValue("@cp", codigoPostal);
					SqlCom.Parameters.AddWithValue("@titulo", titulo);
					SqlCom.Parameters.AddWithValue("@grado", grado);
					string dateString = DateTime.Now.ToString("yyyy-MM-dd");
					SqlCom.Parameters.AddWithValue("@fecha", dateString);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                string idDocente = "";
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT LAST_INSERT_ID() as id", cn);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
	                        idDocente = sqr["id"].ToString();
	                    }
	                }
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
					qry = "insert into Usuarios values(@id,@pass,1)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom2 = new MySqlCommand(qry, cn);
					SqlCom2.Parameters.AddWithValue("@id", idDocente);
					string pass = "";
					Random r = new Random();
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					SqlCom2.Parameters.AddWithValue("@pass", pass);
					SqlCom2.ExecuteNonQuery();
	                cn.Close();
					
					returnElems.Add(idDocente);
					returnElems.Add(pass);
	                return returnElems.ToArray();
	            }
	            catch (Exception ex)
	            {
	                returnElems.Add(ex.Message);
					return returnElems.ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				returnElems.Add("La clave es errónea");
				return returnElems.ToArray();
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de baja un profesor y su cuenta de usuario asociada recibiendo como parámetro su id." +
		           "tener cuidado de que sólo usuarios de nivel 5 puedan utilizar este método")]
        public string BajaDocente(string clave, string id)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry = "delete from Docentes where idDocente = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
					cn.Close();
					cn.Open();
					qry = "delete from Usuarios where idUsuario = @id";
	                SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
					SqlCom.ExecuteNonQuery();
	                cn.Close();
					
					
					
	                return "baja satisafactoria";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//1v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Actualiza un profesor recibiendo como parámetros la clave," + 
            "id" + 
		    "y los opcionales a actualizar: calle (max 60), colonia (max 60), municipio (max 25), estado (max 15), " + 
		    "telefono, correo (max 40), codigo postal, título (max 50) y grado (max 15). Se puede actualizar 0-n parámetros, ingresando cadenas vacías"+
		    "en los parámetros que no se deseen actualizar")]
        public string ActualizaDocente(string clave,
            string id, string direccionCalle = "",
		    string direccionColonia = "", string municipio = "", string estado = "", 
		     string telefono = "", string correo = "", string codigoPostal = "", string titulo = "",
		     string grado = "")
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                string calleTemp = "", coloniaTemp = "", municipioTemp = "", estadoTemp = "", correoTemp = "",
						tituloTemp = "", gradoTemp = "";
					int telefonoTemp = 0, cpTemp = 0;
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT * from Docentes Where idDocente = @id", cn);
					sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
	                        calleTemp = sqr["direccionCalle"].ToString();
							coloniaTemp = sqr["direccionColonia"].ToString();
							municipioTemp = sqr["municipio"].ToString();
							estadoTemp = sqr["estado"].ToString();
							correoTemp = sqr["correo"].ToString();
							telefonoTemp = Convert.ToInt32(sqr["telefono"].ToString());
							cpTemp = Convert.ToInt32(sqr["codigoPostal"].ToString());
							tituloTemp = sqr["titulo"].ToString();
							gradoTemp = sqr["grado"].ToString();
	                    }
	                }
					else
					{
						return "No existe tal docente";
					}
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
	                //Set insert query
	                string qry;
	                qry = "UPDATE Docentes SET direccionCalle = @dc, direccionColonia = @dcol, municipio = @m," +
						"estado = @e, correo = @c, telefono = @t, codigoPostal = @cp, titulo = @titulo, " +
					    "grado = @grado WHERE idDocente = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id", id);
					if(direccionCalle != "")
					{
						SqlCom.Parameters.AddWithValue("@dc", direccionCalle);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dc", calleTemp);
					}
					if(direccionColonia != "")
					{
						SqlCom.Parameters.AddWithValue("@dcol", direccionColonia);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dcol", coloniaTemp);
					}
					if(municipio != "")
					{
						SqlCom.Parameters.AddWithValue("@m", municipio);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@m", municipioTemp);
					}
					if(estado != "")
					{
						SqlCom.Parameters.AddWithValue("@e", estado);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@e", estadoTemp);
					}
					if(telefono != "")
					{
						SqlCom.Parameters.AddWithValue("@t", telefono);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@t", telefonoTemp);
					}
					if(correo != "")
					{
						SqlCom.Parameters.AddWithValue("@c", correo);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@c", correoTemp);
					}
					if(codigoPostal != "")
					{
						SqlCom.Parameters.AddWithValue("@cp", codigoPostal);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@cp", cpTemp);
					}
					if(titulo != "")
					{
						SqlCom.Parameters.AddWithValue("@titulo", titulo);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@titulo", tituloTemp);
					}
					if(grado != "")
					{
						SqlCom.Parameters.AddWithValue("@grado", grado);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@grado", gradoTemp);
					}
	                //Open connection and execute insert query.
	                SqlCom.ExecuteNonQuery();
	                return "Docente actualizado";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de los docentes recibiendo como parámetros la clave " + 
            "y los valores de búsqueda opcionales id, nombre (MAX 50), apellidoPaterno (MAX 50)," + 
		     " apellidoMaterno (MAX 50), direccionCalle (max 60), direccionColonia (MAX 60)," + 
		     " municipio (MAX 25), estado (MAX 15), teléfono, correo (MAX 40), codigoPostal," + 
		     "titulo (MAX 50), grado (MAX 15) y fechaAlta (formato YYYY-MM-DD) funciona para búsquedas" +
		     " por fecha completa o sólo año, mes o dia")]
        public string[][] VerDocentes(string clave,
            string id = "", string nombre = "", string apellidoPaterno = "", string apellidoMaterno = "",
		    string direccionCalle = "", string direccionColonia = "", string municipio = "", string estado = "", 
		    string codigoPostal = "", string telefono = "", string correo = "", string titulo = "", string grado = "",
		     string dia = "", string mes = "", string anhio = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Docentes";
					if(string.Compare(id, "") != 0)
					{
						qry += " WHERE idDocente = " + id;
						if(string.Compare(nombre, "") != 0)
						{
							qry += " AND nombre = '" + nombre + "'";
						}
						else if(string.Compare(apellidoPaterno, "") != 0)
						{
							qry += " AND apellidoPaterno = '" + apellidoPaterno + "'";
						}
						else if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(nombre, "") != 0)
					{
						qry += " WHERE nombre = '" + nombre + "'";
						if(string.Compare(apellidoPaterno, "") != 0)
						{
							qry += " AND apellidoPaterno = '" + apellidoPaterno + "'";
						}
						else if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(apellidoPaterno, "") != 0)
					{
						qry += " WHERE apellidoPaterno = '" + apellidoPaterno + "'";
						if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(apellidoMaterno, "") != 0)
					{
						qry += " WHERE apellidoMaterno = '" + apellidoMaterno + "'";
						if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(direccionCalle, "") != 0)
					{
						qry += " WHERE direccionCalle = '" + direccionCalle + "'";
						if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(direccionColonia, "") != 0)
					{
						qry += " WHERE direccionColonia = '" + direccionColonia + "'";
						if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(municipio, "") != 0)
					{
						qry += " WHERE municipio = '" + municipio + "'";
						if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(estado, "") != 0)
					{
						qry += " WHERE estado = '" + estado + "'";
						if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(codigoPostal, "") != 0)
					{
						qry += " WHERE codigoPostal = " + codigoPostal;
						if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(telefono, "") != 0)
					{
						qry += " WHERE telefono = " + telefono;
						if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(correo, "") != 0)
					{
						qry += " WHERE correo = '" + correo + "'";
						if(string.Compare(titulo, "") != 0)
						{
							qry += " AND titulo = '" + titulo + "'";
						}
						else if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(titulo, "") != 0)
					{
						qry += " WHERE titulo = '" + titulo + "'";
						if(string.Compare(grado, "") != 0)
						{
							qry += " AND grado = '" + grado + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(grado, "") != 0)
					{
						qry += " WHERE grado = '" + grado + "'";
						if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" WHERE fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " WHERE YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " WHERE MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " WHERE DAY(fechaAlta) = " + dia;
							}
						}
					sqm = new MySqlCommand(qry, cn);
					//sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idDocente"].ToString());
							registro.Add(sqr["nombre"].ToString());
							registro.Add(sqr["apellidoPaterno"].ToString());
							registro.Add(sqr["apellidoMaterno"].ToString());
							registro.Add(sqr["direccionCalle"].ToString());
							registro.Add(sqr["direccionColonia"].ToString());
							registro.Add(sqr["codigoPostal"].ToString());
							registro.Add(sqr["municipio"].ToString());
							registro.Add(sqr["estado"].ToString());
							registro.Add(sqr["telefono"].ToString());
							registro.Add(sqr["correo"].ToString());
							registro.Add(sqr["titulo"].ToString());
							registro.Add(sqr["grado"].ToString());
							//registro.Add(sqr["fechaAlta"].ToString());
							registro.Add ((Convert.ToDateTime(sqr["fechaAlta"]).ToString("dd/MM/yyyy")).ToString());
							registros.Add(registro);
	                    }
	                }
					else
					{
						return new string[][]{};
					}
					cn.Close();
	                List<string> msj = new List<string>();
					msj.Add("No se encontró ningún registro");
					return registros.Select(a => a.ToArray()).ToArray();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
				    registros.Add (registro);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				registros.Add (registro);
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos Alumno/////////////////////////////////////////////////////////////
		#region Métodos Alumno
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de alta un alumno recibiendo como parámetros la clave," + 
            "nombre (max 50), apellido paterno (max 50), apellido materno (max 50), " + 
		    "calle (max 60), colonia (max 60), municipio (max 25), estado (max 15), " + 
		    "telefono, correo (max 40) y codigo postal")]
        public string[] AltaAlumno(string clave,
            string nombre, string apellidoPaterno, string apellidoMaterno, string direccionCalle,
		    string direccionColonia, string municipio, string estado, string telefono, string correo,
		    string codigoPostal)
        {
			List<string> returnElems = new List<string>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry;
	                qry = "insert into Alumnos values(0,@nom,@apat,@amat,@dCalle,@dColonia,@mun,@edo,@tel,@mail,@cp,1,CURDATE())";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@nom", nombre);
					SqlCom.Parameters.AddWithValue("@apat", apellidoPaterno);
					SqlCom.Parameters.AddWithValue("@amat", apellidoMaterno);
					SqlCom.Parameters.AddWithValue("@dCalle", direccionCalle);
					SqlCom.Parameters.AddWithValue("@dColonia", direccionColonia);
					SqlCom.Parameters.AddWithValue("@mun", municipio);
					SqlCom.Parameters.AddWithValue("@edo", estado);
					SqlCom.Parameters.AddWithValue("@tel", telefono);
					SqlCom.Parameters.AddWithValue("@mail", correo);
					SqlCom.Parameters.AddWithValue("@cp", codigoPostal);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                string idAlumno = "";
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT LAST_INSERT_ID() as id", cn);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
	                        idAlumno = sqr["id"].ToString();
	                    }
	                }
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
					qry = "insert into Usuarios values(@id,@pass,0)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom2 = new MySqlCommand(qry, cn);
					SqlCom2.Parameters.AddWithValue("@id", idAlumno);
					string pass = "";
					Random r = new Random();
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					SqlCom2.Parameters.AddWithValue("@pass", pass);
					SqlCom2.ExecuteNonQuery();
	                cn.Close();
					
					returnElems.Add(idAlumno);
					returnElems.Add(pass);
	                return returnElems.ToArray();
	            }
	            catch (Exception ex)
	            {
	                returnElems.Add(ex.Message);
					return returnElems.ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				returnElems.Add("La clave es errónea");
				return returnElems.ToArray();
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de baja un alumno y su cuenta de usuario asociada recibiendo como parámetro su id.")]
        public string BajaAlumno(string clave, string id)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry = "delete from Alumnos where idAlumno = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
					cn.Close();
					cn.Open();
					qry = "delete from Usuarios where idUsuario = @id";
	                SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
					SqlCom.ExecuteNonQuery();
	                cn.Close();
					
					
					
	                return "baja satisafactoria";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Actualiza un alumno recibiendo como parámetros la clave," + 
            "id" + 
		    "y los opcionales a actualizar: calle (max 60), colonia (max 60), municipio (max 25), estado (max 15), " + 
		    "telefono, correo (max 40),codigo postal  semestre. Se puede actualizar 0-n parámetros, ingresando cadenas vacías"+
		    "en los parámetros que no se deseen actualizar")]
        public string ActualizaAlumno(string clave,
            string id, string direccionCalle = "",
		    string direccionColonia = "", string municipio = "", string estado = "", 
		     string telefono = "", string correo = "", string codigoPostal = "", string semestre = "")
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                string calleTemp = "", coloniaTemp = "", municipioTemp = "", estadoTemp = "", correoTemp = "";
					int telefonoTemp = 0, cpTemp = 0, semestreTemp = 0;
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT * from Alumnos Where idAlumno = @id", cn);
					sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
	                        calleTemp = sqr["direccionCalle"].ToString();
							coloniaTemp = sqr["direccionColonia"].ToString();
							municipioTemp = sqr["municipio"].ToString();
							estadoTemp = sqr["estado"].ToString();
							correoTemp = sqr["correo"].ToString();
							telefonoTemp = Convert.ToInt32(sqr["telefono"].ToString());
							cpTemp = Convert.ToInt32(sqr["codigoPostal"].ToString());
							semestreTemp = Convert.ToInt32(sqr["semestre"].ToString());
	                    }
	                }
					else
					{
						return "No existe tal alumno";
					}
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
	                //Set insert query
	                string qry;
	                qry = "UPDATE Alumnos SET direccionCalle = @dc, direccionColonia = @dcol, municipio = @m," +
						"estado = @e, correo = @c, telefono = @t, codigoPostal = @cp, semestre = @sem WHERE idAlumno = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id", id);
					if(direccionCalle != "")
					{
						SqlCom.Parameters.AddWithValue("@dc", direccionCalle);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dc", calleTemp);
					}
					if(direccionColonia != "")
					{
						SqlCom.Parameters.AddWithValue("@dcol", direccionColonia);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dcol", coloniaTemp);
					}
					if(municipio != "")
					{
						SqlCom.Parameters.AddWithValue("@m", municipio);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@m", municipioTemp);
					}
					if(estado != "")
					{
						SqlCom.Parameters.AddWithValue("@e", estado);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@e", estadoTemp);
					}
					if(telefono != "")
					{
						SqlCom.Parameters.AddWithValue("@t", telefono);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@t", telefonoTemp);
					}
					if(correo != "")
					{
						SqlCom.Parameters.AddWithValue("@c", correo);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@c", correoTemp);
					}
					if(codigoPostal != "")
					{
						SqlCom.Parameters.AddWithValue("@cp", codigoPostal);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@cp", cpTemp);
					}
					if(semestre != "")
					{
						SqlCom.Parameters.AddWithValue("@sem", semestre);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@sem", semestreTemp);
					}
	                //Open connection and execute insert query.
	                SqlCom.ExecuteNonQuery();
	                return "Alumno actualizado";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de los alumnos recibiendo como parámetros la clave " + 
            "y los valores de búsqueda opcionales id, nombre (MAX 50), apellidoPaterno (MAX 50)," + 
		     " apellidoMaterno (MAX 50), direccionCalle (max 60), direccionColonia (MAX 60)," + 
		     " municipio (MAX 25), estado (MAX 15), teléfono, correo (MAX 40), codigoPostal," + 
		     "  y fechaAlta (formato YYYY-MM-DD) funciona para búsquedas" +
		     " por fecha completa o sólo año, mes o dia")]
        public string[][] VerAlumnos(string clave,
            string id = "", string nombre = "", string apellidoPaterno = "", string apellidoMaterno = "",
		    string direccionCalle = "", string direccionColonia = "", string municipio = "", string estado = "", 
		    string codigoPostal = "", string telefono = "", string correo = "", 
		     string dia = "", string mes = "", string anhio = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Alumnos";
					if(string.Compare(id, "") != 0)
					{
						qry += " WHERE idAlumno = " + id;
						if(string.Compare(nombre, "") != 0)
						{
							qry += " AND nombre = '" + nombre + "'";
						}
						else if(string.Compare(apellidoPaterno, "") != 0)
						{
							qry += " AND apellidoPaterno = '" + apellidoPaterno + "'";
						}
						else if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(nombre, "") != 0)
					{
						qry += " WHERE nombre = '" + nombre + "'";
						if(string.Compare(apellidoPaterno, "") != 0)
						{
							qry += " AND apellidoPaterno = '" + apellidoPaterno + "'";
						}
						else if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(apellidoPaterno, "") != 0)
					{
						qry += " WHERE apellidoPaterno = '" + apellidoPaterno + "'";
						if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(apellidoMaterno, "") != 0)
					{
						qry += " WHERE apellidoMaterno = '" + apellidoMaterno + "'";
						if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(direccionCalle, "") != 0)
					{
						qry += " WHERE direccionCalle = '" + direccionCalle + "'";
						if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(direccionColonia, "") != 0)
					{
						qry += " WHERE direccionColonia = '" + direccionColonia + "'";
						if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(municipio, "") != 0)
					{
						qry += " WHERE municipio = '" + municipio + "'";
						if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(estado, "") != 0)
					{
						qry += " WHERE estado = '" + estado + "'";
						if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(codigoPostal, "") != 0)
					{
						qry += " WHERE codigoPostal = " + codigoPostal;
						if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(telefono, "") != 0)
					{
						qry += " WHERE telefono = " + telefono;
						if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(correo, "") != 0)
					{
						qry += " WHERE correo = '" + correo + "'";
						if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" WHERE fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " WHERE YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " WHERE MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " WHERE DAY(fechaAlta) = " + dia;
							}
						}
					sqm = new MySqlCommand(qry, cn);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idAlumno"].ToString());
							registro.Add(sqr["nombre"].ToString());
							registro.Add(sqr["apellidoPaterno"].ToString());
							registro.Add(sqr["apellidoMaterno"].ToString());
							registro.Add(sqr["direccionCalle"].ToString());
							registro.Add(sqr["direccionColonia"].ToString());
							registro.Add(sqr["codigoPostal"].ToString());
							registro.Add(sqr["municipio"].ToString());
							registro.Add(sqr["estado"].ToString());
							registro.Add(sqr["telefono"].ToString());
							registro.Add(sqr["correo"].ToString());
							registro.Add ((Convert.ToDateTime(sqr["fechaAlta"]).ToString("dd/MM/yyyy")).ToString());
							registros.Add(registro);
	                    }
	                }
					else
					{
						return new string[][]{};
					}
					cn.Close();
	                List<string> msj = new List<string>();
					msj.Add("No se encontró ningún registro");
					return registros.Select(a => a.ToArray()).ToArray();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
				    registros.Add (registro);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				registros.Add (registro);
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos Personal///////////////////////////////////////////////////////////
		#region Métodos Personal
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Da de alta un empleado recibiendo como parámetros la clave," + 
            "nombre (max 50), apellido paterno (max 50), apellido materno (max 50), " + 
		    "calle (max 60), colonia (max 60), municipio (max 25), estado (max 15), codigo postal, " + 
		    "telefono, correo (max 40) y puesto (max 25) ")]
        public string[] AltaPersonal(string clave,
            string nombre, string apellidoPaterno, string apellidoMaterno, string direccionCalle,
		    string direccionColonia, string municipio, string estado, string codigoPostal, string telefono, string correo,
		    string puesto)
        {
			List<string> returnElems = new List<string>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					setIncrementDocentes();
	                //Set insert query
	                string qry;
	                qry = "insert into Personal values(0,@nom,@apat,@amat,@dCalle,@dColonia,@mun,@edo,@tel,@mail,@cp,@puesto,CURDATE())";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@nom", nombre);
					SqlCom.Parameters.AddWithValue("@apat", apellidoPaterno);
					SqlCom.Parameters.AddWithValue("@amat", apellidoMaterno);
					SqlCom.Parameters.AddWithValue("@dCalle", direccionCalle);
					SqlCom.Parameters.AddWithValue("@dColonia", direccionColonia);
					SqlCom.Parameters.AddWithValue("@mun", municipio);
					SqlCom.Parameters.AddWithValue("@edo", estado);
					SqlCom.Parameters.AddWithValue("@tel", telefono);
					SqlCom.Parameters.AddWithValue("@mail", correo);
					SqlCom.Parameters.AddWithValue("@cp", codigoPostal);
					SqlCom.Parameters.AddWithValue("@puesto", puesto);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                string idPersonal = "";
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT LAST_INSERT_ID() as id", cn);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
	                        idPersonal = sqr["id"].ToString();
	                    }
	                }
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
					qry = "insert into Usuarios values(@id,@pass,3)";//Si puesto = x el nivel cambia?
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom2 = new MySqlCommand(qry, cn);
					SqlCom2.Parameters.AddWithValue("@id", idPersonal);
					string pass = "";
					Random r = new Random();
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					pass += Convert.ToChar(r.Next(38,126));
					SqlCom2.Parameters.AddWithValue("@pass", pass);
					SqlCom2.ExecuteNonQuery();
	                cn.Close();
					
					returnElems.Add(idPersonal);
					returnElems.Add(pass);
	                return returnElems.ToArray();
	            }
	            catch (Exception ex)
	            {
	                returnElems.Add(ex.Message);
					return returnElems.ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				returnElems.Add("La clave es errónea");
				return returnElems.ToArray();
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de baja un empleado y su cuenta de usuario asociada recibiendo como parámetro su id.")]
        public string BajaPersonal(string clave, string id)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry = "delete from Personal where idPersonal = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
					cn.Close();
					cn.Open();
					qry = "delete from Usuarios where idUsuario = @id";
	                SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
					SqlCom.ExecuteNonQuery();
	                cn.Close();
					
					
					
	                return "baja satisafactoria";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Actualiza un empleado recibiendo como parámetros la clave," + 
            "id" + 
		    "y los opcionales a actualizar: calle (max 60), colonia (max 60), municipio (max 25), estado (max 15), codigo postal" + 
		    "telefono, correo (max 40) y puesto (max 25). Se puede actualizar 0-n parámetros, ingresando cadenas vacías"+
		    "en los parámetros que no se deseen actualizar")]
        public string ActualizaPersonal(string clave,
            string id, string direccionCalle = "",
		    string direccionColonia = "", string municipio = "", string estado = "", string codigoPostal = "", 
		     string telefono = "", string correo = "", string puesto = "")
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                string calleTemp = "", coloniaTemp = "", municipioTemp = "", estadoTemp = "", correoTemp = "",
					puestoTemp = "";
					int telefonoTemp = 0, cpTemp = 0;
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT * from Personal Where idEmpleado = @id", cn);
					sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
	                        calleTemp = sqr["direccionCalle"].ToString();
							coloniaTemp = sqr["direccionColonia"].ToString();
							municipioTemp = sqr["municipio"].ToString();
							estadoTemp = sqr["estado"].ToString();
							correoTemp = sqr["correo"].ToString();
							telefonoTemp = Convert.ToInt32(sqr["telefono"].ToString());
							cpTemp = Convert.ToInt32(sqr["codigoPostal"].ToString());
							puestoTemp = sqr["puesto"].ToString();
	                    }
	                }
					else
					{
						return "No existe tal empleado";
					}
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
	                //Set insert query
	                string qry;
	                qry = "UPDATE Personal SET direccionCalle = @dc, direccionColonia = @dcol, municipio = @m," +
						"estado = @e, correo = @c, telefono = @t, codigoPostal = @cp, puesto = @puesto WHERE idEmpleado = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id", id);
					if(direccionCalle != "")
					{
						SqlCom.Parameters.AddWithValue("@dc", direccionCalle);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dc", calleTemp);
					}
					if(direccionColonia != "")
					{
						SqlCom.Parameters.AddWithValue("@dcol", direccionColonia);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dcol", coloniaTemp);
					}
					if(municipio != "")
					{
						SqlCom.Parameters.AddWithValue("@m", municipio);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@m", municipioTemp);
					}
					if(estado != "")
					{
						SqlCom.Parameters.AddWithValue("@e", estado);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@e", estadoTemp);
					}
					if(telefono != "")
					{
						SqlCom.Parameters.AddWithValue("@t", telefono);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@t", telefonoTemp);
					}
					if(correo != "")
					{
						SqlCom.Parameters.AddWithValue("@c", correo);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@c", correoTemp);
					}
					if(codigoPostal != "")
					{
						SqlCom.Parameters.AddWithValue("@cp", codigoPostal);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@cp", cpTemp);
					}
					if(puesto != "")
					{
						SqlCom.Parameters.AddWithValue("@puesto", puesto);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@puesto", puestoTemp);
					}
	                //Open connection and execute insert query.
	                SqlCom.ExecuteNonQuery();
	                return "Empleado actualizado";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de los docentes recibiendo como parámetros la clave " + 
            "y los valores de búsqueda opcionales id, nombre (MAX 50), apellidoPaterno (MAX 50)," + 
		     " apellidoMaterno (MAX 50), direccionCalle (max 60), direccionColonia (MAX 60)," + 
		     " municipio (MAX 25), estado (MAX 15), teléfono, correo (MAX 40), codigoPostal," + 
		     "titulo (MAX 50), grado (MAX 15) y fechaAlta (formato YYYY-MM-DD) funciona para búsquedas" +
		     " por fecha completa o sólo año, mes o dia")]
        public string[][] VerPersonal(string clave,
            string id = "", string nombre = "", string apellidoPaterno = "", string apellidoMaterno = "",
		    string direccionCalle = "", string direccionColonia = "", string municipio = "", string estado = "", 
		    string codigoPostal = "", string telefono = "", string correo = "", string puesto = "", 
		     string dia = "", string mes = "", string anhio = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Personal";
					if(string.Compare(id, "") != 0)
					{
						qry += " WHERE idEmpleado = " + id;
						if(string.Compare(nombre, "") != 0)
						{
							qry += " AND nombre = '" + nombre + "'";
						}
						else if(string.Compare(apellidoPaterno, "") != 0)
						{
							qry += " AND apellidoPaterno = '" + apellidoPaterno + "'";
						}
						else if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(nombre, "") != 0)
					{
						qry += " WHERE nombre = '" + nombre + "'";
						if(string.Compare(apellidoPaterno, "") != 0)
						{
							qry += " AND apellidoPaterno = '" + apellidoPaterno + "'";
						}
						else if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(apellidoPaterno, "") != 0)
					{
						qry += " WHERE apellidoPaterno = '" + apellidoPaterno + "'";
						if(string.Compare(apellidoMaterno, "") != 0)
						{
							qry += " AND apellidoMaterno = '" + apellidoMaterno + "'";
						}
						else if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(apellidoMaterno, "") != 0)
					{
						qry += " WHERE apellidoMaterno = '" + apellidoMaterno + "'";
						if(string.Compare(direccionCalle, "") != 0)
						{
							qry += " AND direccionCalle = '" + direccionCalle + "'";
						}
						else if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(direccionCalle, "") != 0)
					{
						qry += " WHERE direccionCalle = '" + direccionCalle + "'";
						if(string.Compare(direccionColonia, "") != 0)
						{
							qry += " AND direccionColonia = '" + direccionColonia + "'";
						}
						else if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(direccionColonia, "") != 0)
					{
						qry += " WHERE direccionColonia = '" + direccionColonia + "'";
						if(string.Compare(municipio, "") != 0)
						{
							qry += " AND municipio = '" + municipio + "'";
						}
						else if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(municipio, "") != 0)
					{
						qry += " WHERE municipio = '" + municipio + "'";
						if(string.Compare(estado, "") != 0)
						{
							qry += " AND estado = '" + estado + "'";
						}
						else if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(estado, "") != 0)
					{
						qry += " WHERE estado = '" + estado + "'";
						if(string.Compare(codigoPostal, "") != 0)
						{
							qry += " AND codigoPostal = " + codigoPostal;
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(codigoPostal, "") != 0)
					{
						qry += " WHERE codigoPostal = " + codigoPostal;
						if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(telefono, "") != 0)
					{
						qry += " WHERE telefono = " + telefono;
						if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(correo, "") != 0)
					{
						qry += " WHERE correo = '" + correo + "'";
						if(string.Compare(puesto, "") != 0)
						{
							qry += " AND puesto = '" + puesto + "'";
						}
						else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(puesto, "") != 0)
					{
						qry += " WHERE puesto = '" + puesto + "'";
						if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" AND fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " AND YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " AND MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " AND DAY(fechaAlta) = " + dia;
							}
						}
					}
					else if(string.Compare(anhio, "") != 0 ||
						        string.Compare(mes, "") != 0 ||
						        string.Compare(dia, "") != 0)
						{
							if((string.Compare(anhio, "") != 0 && string.Compare(mes, "") != 0) ||
							   (string.Compare(anhio, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(dia, "") != 0) ||
							   (string.Compare(mes, "") != 0 && string.Compare(anhio, "") != 0))
							{
								qry += (" WHERE fechaAlta = '" + anhio + "-" + mes + "-" + dia + "'");
							}
							else if(string.Compare(anhio, "") != 0)
							{
								qry += " WHERE YEAR(fechaAlta) = " + anhio;
							}
							else if(string.Compare(mes, "") != 0)
							{
								qry += " WHERE MONTH(fechaAlta) = " + mes;
							}
							else if(string.Compare(dia, "") != 0)
							{
								qry += " WHERE DAY(fechaAlta) = " + dia;
							}
						}
					sqm = new MySqlCommand(qry, cn);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idEmpleado"].ToString());
							registro.Add(sqr["nombre"].ToString());
							registro.Add(sqr["apellidoPaterno"].ToString());
							registro.Add(sqr["apellidoMaterno"].ToString());
							registro.Add(sqr["direccionCalle"].ToString());
							registro.Add(sqr["direccionColonia"].ToString());
							registro.Add(sqr["codigoPostal"].ToString());
							registro.Add(sqr["municipio"].ToString());
							registro.Add(sqr["estado"].ToString());
							registro.Add(sqr["telefono"].ToString());
							registro.Add(sqr["correo"].ToString());
							registro.Add(sqr["puesto"].ToString());
							registro.Add ((Convert.ToDateTime(sqr["fechaAlta"]).ToString("dd/MM/yyyy")).ToString());
							registros.Add(registro);
	                    }
	                }
					else
					{
						return new string[][]{};
					}
					cn.Close();
	                List<string> msj = new List<string>();
					msj.Add("No se encontró ningún registro");
					return registros.Select(a => a.ToArray()).ToArray();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
				    registros.Add (registro);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				registros.Add (registro);
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos Departamento///////////////////////////////////////////////////////
		#region Métodos Departamento
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Da de alta un departamento recibiendo como parámetros la clave," + 
            "nombre (max 50), telefono, correo y el idEncargado que es el id de un Empleado de nivel 4" + 
		    ".\n\nCuidado de implementar sólo con usuario nivel 5.")]
        public string AltaDepto(string clave,
            string nombre, string telefono, string correo, string idEncargado)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry;
	                qry = "insert into Depto values(0,@nom,@tel,@correo, @id)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@nom", nombre);
					SqlCom.Parameters.AddWithValue("@tel", telefono);
					SqlCom.Parameters.AddWithValue("@correo", correo);
					SqlCom.Parameters.AddWithValue("@id", idEncargado);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                cn.Close();
					
	                return "Alta exitosa";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de baja un departamento recibiendo como parámetro su id.")]
        public string BajaDepto(string clave, string id)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry = "delete from Depto where idDepto = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
					cn.Close();
					
	                return "baja satisafactoria";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Actualiza un departamento recibiendo como parámetros la clave," + 
            "id, y los valores a cambiar opcionales teléfono y correo (MAX 40)")]
        public string ActualizaDepto(string clave,
            string id, string telefono = "", string correo = "", string idEncargado = "")
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                string correoTemp = "";
					int telefonoTemp = 0, idEncargadoTemp = 0;
	                //Buscar el id que se acaba de insertar
	                sqm = new MySqlCommand("SELECT * from Depto Where idDepto = @id", cn);
					sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
	                        correoTemp = sqr["correo"].ToString();
							telefonoTemp = Convert.ToInt32(sqr["telefono"].ToString());
							idEncargadoTemp = Convert.ToInt32(sqr["idEncargado"].ToString());
	                    }
	                }
					else
					{
						return "No existe tal departmaneto";
					}
					cn.Close();//Tengo que cerrar y abrir la conexión o me 
					cn.Open();//manda al boli
	                //Set insert query
	                string qry;
	                qry = "UPDATE Depto SET correo = @correo, telefono = @tel, idEncargado = @id WHERE idDepto = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id", id);
					if(correo != "")
					{
						SqlCom.Parameters.AddWithValue("@dc", correo);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dc", correoTemp);
					}
					if(telefono != "")
					{
						SqlCom.Parameters.AddWithValue("@dcol", telefono);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dcol", telefonoTemp);
					}
					if(idEncargado != "")
					{
						SqlCom.Parameters.AddWithValue("@dcol", idEncargado);
					}
					else
					{
						SqlCom.Parameters.AddWithValue("@dcol", idEncargadoTemp);
					}
					
	                //Open connection and execute insert query.
	                SqlCom.ExecuteNonQuery();
	                return "Departamento actualizado";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de los departamentos recibiendo como parámetros la clave," + 
            "y los valores de búsqueda opcionales id, nombre (MAX 50), teléfono y correo (MAX 40)")]
        public string[][] VerDeptos(string clave,
            string id = "", string nombre = "", string telefono = "", string correo = "", string idEmpleado = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Depto";
					if(string.Compare(id, "") != 0)
					{
						qry += " WHERE idDepto = " + id;
						if(string.Compare(nombre, "") != 0)
						{
							qry += " AND nombre = '" + nombre + "'";
						}
						else if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(idEmpleado, "") != 0)
						{
							qry += " AND idEmpleado = '" + idEmpleado + "'";
						}
					}
					else if(string.Compare(nombre, "") != 0)
					{
						qry += " WHERE nombre = '" + nombre + "'";
						if(string.Compare(telefono, "") != 0)
						{
							qry += " AND telefono = " + telefono;
						}
						else if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(idEmpleado, "") != 0)
						{
							qry += " AND idEmpleado = " + idEmpleado;
						}
					}
					else if(string.Compare(telefono, "") != 0)
					{
						qry += " WHERE telefono = " + telefono;
						if(string.Compare(correo, "") != 0)
						{
							qry += " AND correo = '" + correo + "'";
						}
						else if(string.Compare(idEmpleado, "") != 0)
						{
							qry += " AND idEmpleado = " + idEmpleado ;
						}
					}
					else if(string.Compare(correo, "") != 0)
					{
						qry += " WHERE correo = '" + correo + "'";
						if(string.Compare(idEmpleado, "") != 0)
						{
							qry += " AND idEmpleado = " + idEmpleado;
						}
					}
					else if(string.Compare(idEmpleado, "") != 0)
					{
						qry += " WHERE idEmpleado = " + idEmpleado;
					}
					sqm = new MySqlCommand(qry, cn);
					//sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idDepto"].ToString());
							registro.Add(sqr["nombre"].ToString());
							registro.Add(sqr["telefono"].ToString());
							registro.Add(sqr["correo"].ToString());
							registro.Add(sqr["idEncargado"].ToString());
							registros.Add(registro);
	                    }
	                }
					else
					{
						return new string[][]{};
					}
					cn.Close();
	                List<string> msj = new List<string>();
					msj.Add("No se encontró ningún registro");
					return registros.Select(a => a.ToArray()).ToArray();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos Materias///////////////////////////////////////////////////////////
		#region Métodos Materias
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Da de alta una materia recibiendo como parámetros la clave," + 
            "nombre (max 50), créditos, area (MAX 50) y si está seriada." + 
		           "Si está seriada, ingresar el id de la materia que la precede, de lo contrario un 0" +
		           "\n\nCuidado de implementar sólo con usuario nivel 4"+
		            "o superior")]
        public string AltaMateria(string clave,
            string nombre, string creditos, string area, string seriada)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry;
	                qry = "insert into Materias values(0,@nom,@cred,@area,@seriada)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@nom", nombre);
					SqlCom.Parameters.AddWithValue("@cred", creditos);
					SqlCom.Parameters.AddWithValue("@area", area);
					SqlCom.Parameters.AddWithValue("@seriada", seriada);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                cn.Close();
					
	                return "Alta exitosa";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de baja una materia recibiendo como parámetro su id.")]
        public string BajaMateria(string clave, string id)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry = "delete from Materias where idMateria = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
					cn.Close();
					
	                return "baja satisafactoria";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de las materias recibiendo como parámetros la clave," + 
            "y los valores de búsqueda opcionales id, nombre (MAX 50), creditos, área (MAX 50) y seriada")]
        public string[][] VerMaterias(string clave,
            string id = "", string nombre = "", string creditos = "", string area = "", string seriada = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Materias";
					if(string.Compare(id, "") != 0)
					{
						qry += " WHERE idDepto = " + id;
						if(string.Compare(nombre, "") != 0)
						{
							qry += " AND nombre = '" + nombre + "'";
						}
						else if(string.Compare(creditos, "") != 0)
						{
							qry += " AND creditos = " + creditos;
						}
						else if(string.Compare(area, "") != 0)
						{
							qry += " AND area = '" + area + "'";
						}
						else if(string.Compare(seriada, "") != 0)
						{
							qry += " AND seriada = " + seriada;
						}
					}
					else if(string.Compare(nombre, "") != 0)
					{
						qry += " WHERE nombre = '" + nombre + "'";
						if(string.Compare(creditos, "") != 0)
						{
							qry += " AND creditos = " + creditos;
						}
						else if(string.Compare(area, "") != 0)
						{
							qry += " AND area = '" + area + "'";
						}
						else if(string.Compare(seriada, "") != 0)
						{
							qry += " AND seriada = " + seriada;
						}
					}
					else if(string.Compare(creditos, "") != 0)
					{
						qry += " WHERE creditos = " + creditos;
						if(string.Compare(area, "") != 0)
						{
							qry += " AND area = '" + area + "'";
						}
						else if(string.Compare(seriada, "") != 0)
						{
							qry += " AND seriada = " + seriada;
						}
					}
					else if(string.Compare(area, "") != 0)
					{
						qry += " WHERE area = '" + area + "'";
						if(string.Compare(seriada, "") != 0)
						{
							qry += " AND seriada = " + seriada;
						}
					}
					else if(string.Compare(seriada, "") != 0)
					{
						qry += " WHERE seriada = " + seriada;
					}
					sqm = new MySqlCommand(qry, cn);
					//sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idMateria"].ToString());
							registro.Add(sqr["nombre"].ToString());
							registro.Add(sqr["creditos"].ToString());
							registro.Add(sqr["area"].ToString());
							registro.Add(sqr["seriada"].ToString());
							registros.Add(registro);
	                    }
	                }
					else
					{
						return new string[][]{};
					}
					cn.Close();
	                List<string> msj = new List<string>();
					msj.Add("No se encontró ningún registro");
					return registros.Select(a => a.ToArray()).ToArray();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos Grupos/////////////////////////////////////////////////////////////
		#region Métodos Grupos
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Da de alta un grupo recibiendo como parámetros la clave," + 
            "el id (MAX 12), hora inicio (cadena en formato hh:mm:ss), hora término (cadena en formato hh:mm:ss), grupo (MAX 3) y aula (MAX 10)." + 
		    "\n\nCuidado de implementar sólo con usuario nivel 4.")]
        public string AltaGrupo(string clave,
            string id, string horaInicio, string horaTermino, string grupo, string aula, string idDocente,
		    string idMateria, string cupoDisponible)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry;
	                qry = "insert into Grupos values(@id,@horIni,@horTer,@grupo,@aula,@idDoc,@idMat,@cupo)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id", id);
					SqlCom.Parameters.AddWithValue("@horIni", horaInicio);
					SqlCom.Parameters.AddWithValue("@horTer", horaTermino);
					SqlCom.Parameters.AddWithValue("@grupo", grupo);
					SqlCom.Parameters.AddWithValue("@aula", aula);
					SqlCom.Parameters.AddWithValue("@idDoc", idDocente);
					SqlCom.Parameters.AddWithValue("@idMat", idMateria);
					SqlCom.Parameters.AddWithValue("@cupo", cupoDisponible);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                cn.Close();
	                return "Alta exitosa";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de baja un grupo recibiendo como parámetro su id.")]
        public string BajaGrupo(string clave, string id)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry = "delete from Grupos where idGrupo = @id";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",id);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
					cn.Close();
	                return "baja satisafactoria";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de las materias recibiendo como parámetros la clave," + 
            "y los valores de búsqueda opcionales id (MAX 12), horario (MAX 15, formato 00:00-00:00)," + 
		    " grupo (MAX 3), aula (MAX 10), idDocente, idMateria y cupoDisponible")]
        public string[][] VerGrupos(string clave,
            string id = "", string horaInicio = "", string horaTermino = "", string grupo = "", 
		    string aula = "", string idDocente = "",
		    string idMateria = "", string cupo = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Grupos";
					if(string.Compare(id, "") != 0)
					{
						qry += " WHERE idGrupo = " + id;
						if(string.Compare(horaInicio, "") != 0)
						{
							qry += " AND horaInicio = '" + horaInicio + "'";
						}
						else if(string.Compare(horaTermino, "") != 0)
						{
							qry += " AND horaTermino = '" + horaTermino + "'";
						}
						else if(string.Compare(grupo, "") != 0)
						{
							qry += " AND grupo = " + grupo;
						}
						else if(string.Compare(aula, "") != 0)
						{
							qry += " AND aula = '" + aula + "'";
						}
						else if(string.Compare(idDocente, "") != 0)
						{
							qry += " AND idDocente = " + idDocente;
						}
						else if(string.Compare(idMateria, "") != 0)
						{
							qry += " AND idMateria = " + idMateria;
						}
						else if(string.Compare(cupo, "") != 0)
						{
							qry += " AND cupoDisponible = " + cupo;
						}
					}
					else if(string.Compare(horaInicio, "") != 0)
					{
						qry += " WHERE horaInicio = '" + horaInicio + "'";
						if(string.Compare(horaTermino, "") != 0)
						{
							qry += " AND horaTermino = '" + horaTermino + "'";
						}
						else if(string.Compare(grupo, "") != 0)
						{
							qry += " AND grupo = " + grupo;
						}
						else if(string.Compare(aula, "") != 0)
						{
							qry += " AND aula = '" + aula + "'";
						}
						else if(string.Compare(idDocente, "") != 0)
						{
							qry += " AND idDocente = " + idDocente;
						}
						else if(string.Compare(idMateria, "") != 0)
						{
							qry += " AND idMateria = " + idMateria;
						}
						else if(string.Compare(cupo, "") != 0)
						{
							qry += " AND cupoDisponible = " + cupo;
						}
					}
					else if(string.Compare(horaTermino, "") != 0)
					{
						qry += " WHERE horaTermino = '" + horaTermino + "'";
						if(string.Compare(grupo, "") != 0)
						{
							qry += " AND grupo = " + grupo;
						}
						else if(string.Compare(aula, "") != 0)
						{
							qry += " AND aula = '" + aula + "'";
						}
						else if(string.Compare(idDocente, "") != 0)
						{
							qry += " AND idDocente = " + idDocente;
						}
						else if(string.Compare(idMateria, "") != 0)
						{
							qry += " AND idMateria = " + idMateria;
						}
						else if(string.Compare(cupo, "") != 0)
						{
							qry += " AND cupoDisponible = " + cupo;
						}
					}
					else if(string.Compare(grupo, "") != 0)
					{
						qry += " WHERE grupo = " + grupo;
						if(string.Compare(aula, "") != 0)
						{
							qry += " AND aula = '" + aula + "'";
						}
						else if(string.Compare(idDocente, "") != 0)
						{
							qry += " AND idDocente = " + idDocente;
						}
						else if(string.Compare(idMateria, "") != 0)
						{
							qry += " AND idMateria = " + idMateria;
						}
						else if(string.Compare(cupo, "") != 0)
						{
							qry += " AND cupoDisponible = " + cupo;
						}
					}
					else if(string.Compare(aula, "") != 0)
					{
						qry += " WHERE aula = '" + aula + "'";
						if(string.Compare(idDocente, "") != 0)
						{
							qry += " AND idDocente = " + idDocente;
						}
						else if(string.Compare(idMateria, "") != 0)
						{
							qry += " AND idMateria = " + idMateria;
						}
						else if(string.Compare(cupo, "") != 0)
						{
							qry += " AND cupoDisponible = " + cupo;
						}
					}
					else if(string.Compare(idDocente, "") != 0)
					{
						qry += " WHERE idDocente = " + idDocente;
						if(string.Compare(idMateria, "") != 0)
						{
							qry += " AND idMateria = " + idMateria;
						}
						else if(string.Compare(cupo, "") != 0)
						{
							qry += " AND cupoDisponible = " + cupo;
						}
					}
					else if(string.Compare(idMateria, "") != 0)
					{
						qry += " WHERE idMateria = " + idMateria;
						if(string.Compare(cupo, "") != 0)
						{
							qry += " AND cupoDisponible = " + cupo;
						}
					}
					else if(string.Compare(cupo, "") != 0)
					{
						qry += " WHERE cupoDisponible = " + cupo;
					}
					sqm = new MySqlCommand(qry, cn);
					//sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idGrupo"].ToString());
							registro.Add(sqr["horaInicio"].ToString());
							registro.Add(sqr["horaTermino"].ToString());
							registro.Add(sqr["grupo"].ToString());
							registro.Add(sqr["aula"].ToString());
							registro.Add(sqr["idDocente"].ToString());
							registro.Add(sqr["idMateria"].ToString());
							registro.Add(sqr["cupoDisponible"].ToString());
							registros.Add(registro);
	                    }
						return registros.Select(a => a.ToArray()).ToArray();
	                }
					else
					{
		                List<string> msj = new List<string>();
						msj.Add("No se encontró ningún registro");
						registros.Add(msj);
						return registros.Select(a => a.ToArray()).ToArray();
					}
					cn.Close();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
					registros.Add (registro);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos AlumnoGrupo////////////////////////////////////////////////////////
		#region Métodos AlumnoGrupo
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Da de alta un alumno en un grupo recibiendo como parámetros la clave," + 
            "el id del Alumno (MAX 12) y el id del Grupo (max 12)" + 
		    "\n\nCuidado de implementar sólo con usuario nivel 4.")]
        public string AltaAlumnoGrupo(string clave,
            string idAlumno, string idGrupo)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry;
	                qry = "insert into AlumnoGrupo values(@id,@grupo)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id", idAlumno);
					SqlCom.Parameters.AddWithValue("@grupo", idGrupo);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                cn.Close();
	                return "Alta exitosa";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
        [WebMethod(CacheDuration = 30,
            Description = "Da de baja un alumno de un grupo recibiendo como parámetro el id" + 
		           "del alumno y el id del Grupo (max 12)")]
        public string BajaAlumnoGrupo(string clave, string idAlumno, string idGrupo)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry = "delete from AlumnoGrupo where idAlumno = @id AND idGrupo = @idGrupo";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@id",idAlumno);
					SqlCom.Parameters.AddWithValue("@idGrupo",idGrupo);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
					cn.Close();
	                return "baja satisafactoria";
	            }
	            catch (Exception ex)
	            {
	                return ex.ToString();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
			
        }
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los grupos a los que está inscrito un Alumno ingresando idAlumno o " + 
            "los alumnos inscritos en un grupo ingresando el idGrupo (MAX 12). O si lo mandas llamar solo " +
		    "hay te encargo que interpretes los resultados")]
        public string[][] VerAlumnosGrupos(string clave,
            string idAlumno = "", string idGrupo = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from AlumnoGrupo";
					if(string.Compare(idGrupo, "") != 0)
					{
						qry += " WHERE idGrupo = '" + idGrupo + "'";
						if(string.Compare(idAlumno, "") != 0)
						{
							qry += " AND idAlumno = " + idAlumno;
						}
					}
					else if(string.Compare(idAlumno, "") != 0)
					{
						qry += " WHERE idAlumno = " + idAlumno;
					}
					sqm = new MySqlCommand(qry, cn);
					//sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idGrupo"].ToString());
							registro.Add(sqr["idAlumno"].ToString());
							registros.Add(registro);
	                    }
						return registros.Select(a => a.ToArray()).ToArray();
	                }
					else
					{
		                List<string> msj = new List<string>();
						msj.Add("No se encontró ningún registro");
						registros.Add(msj);
						return registros.Select(a => a.ToArray()).ToArray();
					}
					cn.Close();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
					registros.Add(registro);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos Avisos/////////////////////////////////////////////////////////////
		#region Métodos Avisos
		[WebMethod(CacheDuration = 30,
            Description = "Da de alta un aviso recibiendo como parámetros la clave," + 
            " el id del Grupo al que va dirigido el aviso (MAX 12), el aviso (MAX 200)," + 
		    " la fecha de expiración (formato YYYY/MM/DD hh:mm:ss)" + 
		    "y el titulo (MAX 50)")]
        public string AltaAviso(string clave,
            string idGrupo, string aviso, string fechaExpiracion, string titulo)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					DateTime prueba = Convert.ToDateTime(fechaExpiracion);
					if(prueba.Year == 0 || prueba.Month == 0 || prueba.Day == 0)
					{
						return "No se aceptan fechas en 0's";
					}
	                //Set insert query
	                string qry;
	                qry = "insert into Avisos values(@idGrupo,@aviso,@fecha,@titulo)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@idGrupo", idGrupo);
					SqlCom.Parameters.AddWithValue("@aviso", aviso);
					SqlCom.Parameters.AddWithValue("@fecha", fechaExpiracion);
					SqlCom.Parameters.AddWithValue("@titulo", titulo);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                cn.Close();
	                return "Alta exitosa";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		//v1.0.1
		[WebMethod(CacheDuration = 30,
            Description = "Regresa los datos de las materias recibiendo como parámetros la clave," + 
            "y los valores de búsqueda opcionales id (MAX 12), horario (MAX 15, formato 00:00-00:00)," + 
		    " grupo (MAX 3), aula (MAX 10), idDocente, idMateria y cupoDisponible")]
        public string[][] VerAvisos(string clave,
            string idGrupo = "", string diaExp = "", string mesExp = "", string horaExp = "")
        {
			List<List<string>> registros = new List<List<string>>();
			if(true)//Validar a futuro la clave
			{
	            try
	            {
					cn.Open();
	                //Buscar el id que se acaba de insertar
	                string qry = "SELECT * from Avisos";
					if(string.Compare(idGrupo, "") != 0)
					{
						qry += " WHERE idGrupo = '" + idGrupo + "'";
						if(string.Compare(horaExp, "") != 0)
						{
							qry += " AND HOUR(fechaExpiracion) = " + horaExp;
						}
						else if(string.Compare(diaExp, "") != 0 ||
						        string.Compare(mesExp, "") != 0)
						{
							if((string.Compare(diaExp, "") != 0 && string.Compare(mesExp, "") != 0))
							{
								qry += (" AND fechaExpiracion = 'YEAR(CURDATE())-" + mesExp + "-" + diaExp + "'");
							}
							else if(string.Compare(diaExp, "") != 0)
							{
								qry += " AND DAY(fechaExpiracion) = " + diaExp;
							}
							else if(string.Compare(mesExp, "") != 0)
							{
								qry += " AND MONTH(fechaExpiracion) = " + mesExp;
							}
						}
					}
					else if(string.Compare(horaExp, "") != 0)
					{
						qry += " WHERE HOUR(fechaExpiracion) = " + horaExp;
						if(string.Compare(diaExp, "") != 0 ||
						        string.Compare(mesExp, "") != 0)
						{
							if((string.Compare(diaExp, "") != 0 && string.Compare(mesExp, "") != 0))
							{
								qry += (" AND fechaExpiracion = 'YEAR(CURDATE())-" + mesExp + "-" + diaExp + "'");
							}
							else if(string.Compare(diaExp, "") != 0)
							{
								qry += " AND DAY(fechaExpiracion) = " + diaExp;
							}
							else if(string.Compare(mesExp, "") != 0)
							{
								qry += " AND MONTH(fechaExpiracion) = " + mesExp;
							}
						}
					}
					if(string.Compare(diaExp, "") != 0 ||
						        string.Compare(mesExp, "") != 0)
						{
							if((string.Compare(diaExp, "") != 0 && string.Compare(mesExp, "") != 0))
							{
								qry += (" WHERE fechaExpiracion = 'YEAR(CURDATE())-" + mesExp + "-" + diaExp + "'");
							}
							else if(string.Compare(diaExp, "") != 0)
							{
								qry += " WHERE DAY(fechaExpiracion) = " + diaExp;
							}
							else if(string.Compare(mesExp, "") != 0)
							{
								qry += " WHERE MONTH(fechaExpiracion) = " + mesExp;
							}
						}
					sqm = new MySqlCommand(qry, cn);
					//sqm.Parameters.AddWithValue("@id", id);
	                MySqlDataReader sqr = sqm.ExecuteReader();
	                if (sqr.HasRows)
	                {
	                    while (sqr.Read())
	                    {
							List<string> registro = new List<string>();
	                        registro.Add(sqr["idGrupo"].ToString());
							registro.Add(sqr["aviso"].ToString());
							registro.Add((Convert.ToDateTime(sqr["fechaExpiracion"])).ToString());
							registro.Add(sqr["titulo"].ToString());
							registros.Add(registro);
	                    }
						return registros.Select(a => a.ToArray()).ToArray();
	                }
					else
					{
		                List<string> msj = new List<string>();
						msj.Add("No se encontró ningún registro");
						registros.Add(msj);
						return registros.Select(a => a.ToArray()).ToArray();
					}
					cn.Close();
	            }
	            catch (Exception ex)
	            {
					List<string> registro = new List<string>();
					registro.Add(ex.Message);
					registros.Add(registro);
					return registros.Select(a => a.ToArray()).ToArray();
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				//return "La clave es errónea";
				List<string> registro = new List<string>();
				registro.Add("La clave es errónea");
				return registros.Select(a => a.ToArray()).ToArray();
			}
        }
		#endregion
		/////////////////////////////Métodos Calificaciones/////////////////////////////////////////////////////
		#region Métodos Calificaciones
		[WebMethod(CacheDuration = 30,
            Description = "Da de alta una calificación recibiendo como parámetros la clave," + 
            " el id del Grupo (MAX 12) en el qu esta inscrito el Alumno, el idAlumno, " + 
		    " el tipo de calificacion (ordinaria, regularización o extraordinario), y la unidad (0 para calificación final)")]
        public string AltaCalificacion(string clave,
            string idGrupo, string idAlumno, string tipo, string unidad)
        {
			if(true)//Validar a futuro la clave
			{
	            try
	            {
	                //Set insert query
	                string qry;
	                qry = "insert into Calificaciones values(@idGrupo,@idAlumno,@tipo,@unidad)";
	
	                //Initialize SqlCommand object for insert.
	                MySqlCommand SqlCom = new MySqlCommand(qry, cn);
					SqlCom.Parameters.AddWithValue("@idGrupo", idGrupo);
					SqlCom.Parameters.AddWithValue("@idAlumno", idAlumno);
					SqlCom.Parameters.AddWithValue("@tipo", tipo);
					SqlCom.Parameters.AddWithValue("@unidad", unidad);
	                //Open connection and execute insert query.
	                cn.Open();
	                SqlCom.ExecuteNonQuery();
	                cn.Close();
	                return "Alta exitosa";
	            }
	            catch (Exception ex)
	            {
					return ex.Message;
	            }
				finally
				{
					MySqlConnection.ClearPool(cn);
					MySqlConnection.ClearAllPools();
				}
			}
			else
			{
				return "La clave es errónea";
			}
        }
		
		
		#endregion
		/*[WebMethod(CacheDuration = 30,
            Description = "Consulta la lista de espera de las Apps a instalar")]
        public string[] ListaEspera(string user)
        {
            MySqlCommand com = new MySqlCommand();
            MySqlDataReader dr;
            
            try
            {
                cn.Open();
                com.Connection = cn;
                com.CommandText = "select * from listaespera where idUsuario = @usr";
                com.Parameters.AddWithValue("@usr", user);
                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
               		List<string> ids = new List<string>();
                	while(dr.Read()){
                    	ids.Add(dr[1].ToString());                    
                    }
                    cn.Close();
                    return ids.ToArray();
                }
                else
                {
                    cn.Close();
                    return new string[] { };
                }

            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
        }*/
		
		public void setIncrementDocentes()
		{
			try
			{
				cn.Open();
				//ALTER TABLE table AUTO_INCREMENT = 1000;
				MySqlCommand sqm = new MySqlCommand("ALTER TABLE Docentes AUTO_INCREMENT = 555050",cn);
				sqm.ExecuteNonQuery();
				cn.Close();
			}
			catch (Exception ex)
	        {
				//return ex.Message;
	        }
			finally
			{
				MySqlConnection.ClearPool(cn);
				MySqlConnection.ClearAllPools();
			}
		}
		
		public void setIncrementAdministrativos()
		{
			try
			{
				cn.Open();
				//ALTER TABLE table AUTO_INCREMENT = 1000;
				MySqlCommand sqm = new MySqlCommand("ALTER TABLE Personal AUTO_INCREMENT = 888050",cn);
				sqm.ExecuteNonQuery();
				cn.Close();
			}
			catch (Exception ex)
	        {
				//return ex.Message;
	        }
			finally
			{
				MySqlConnection.ClearPool(cn);
				MySqlConnection.ClearAllPools();
			}
		}
    }

        
}
