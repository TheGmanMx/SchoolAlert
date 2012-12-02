<%@ WebService Language="C#" Class="AppWS.Service1" %>

using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace AppWS
{
	class Service1
	{
		[WebMethod]
		public string hola(){
		return "hey you!";
		}
	
	
	
		MySqlConnection con = new MySqlConnection("Server=localhost; Database=AppStore; Uid=root; Password=nandito3555;");

        [WebMethod]
        public string altaUser(string userName, string pass, string nombreCompleto, string grupo)
        {
            MySqlCommand com = new MySqlCommand();

            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from usuario where userName = @user";
                com.Parameters.AddWithValue("@user", userName);
                if (com.ExecuteNonQuery() > 0)
                {
                    return "Ese nombre de usuario ya existe";
                }
                else
                {
                    com.Parameters.Clear();
                    com.Dispose();

                    com.CommandText = "INSERT INTO usuario (UserName, pass, nombreCompleto, nombreGrupo) VALUES (@user, @pass, @nomCompleto, @nombreGrupo)";
                    com.Parameters.AddWithValue("@user", userName);
                    com.Parameters.AddWithValue("@pass", pass);
                    com.Parameters.AddWithValue("@nomCompleto", nombreCompleto);
                    com.Parameters.AddWithValue("@nombreGrupo", grupo);
                    com.ExecuteNonQuery();
                    con.Close();
                    return "El usuario <b>" + userName + "</b> fue dado de alta exitosamente!";
                }
            }
            catch (Exception)
            {
                return "Hubo un error a la hora de dar de alta al usuario! Intente de nuevo mas tarde!";
            }
        }


        [WebMethod]
        public string[] InfoApp(int idApp)
        {
            MySqlCommand com = new MySqlCommand();
            MySqlDataReader dr;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "select nomApp, downURL, descripcion, rating from apps where idApp = @id";
                com.Parameters.AddWithValue("@id", idApp);
                dr = com.ExecuteReader();
               
                while(dr.Read()){
                string[] retorno =new string[] { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString() };
                con.Close();
                    return retorno;
                    }
                    con.Close();
                    return new string[] { };
               

            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
        }



        [WebMethod]
        public string[][] listaApps()
        {
            MySqlCommand com = new MySqlCommand();
            con.Open();
            com.Connection = con;
            List<string> listaId = new List<string>();
            List<string> listaApps = new List<string>(); ;

            com.CommandText = "select idApp, nomApp from apps";
            MySqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                listaId.Add(dr.GetInt32(0).ToString());
                listaApps.Add(dr.GetString(1));
            }

            string[][] resultado = new string[][] { listaId.ToArray(), listaApps.ToArray() };
            con.Close();
            return resultado;
        }
        
        
        
        [WebMethod]
        public string[] ListaEspera(string user)
        {
            MySqlCommand com = new MySqlCommand();
            MySqlDataReader dr;
            
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from listaespera where userName = @usr";
                com.Parameters.AddWithValue("@usr", user);
                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
               		List<string> ids = new List<string>();
                	while(dr.Read()){
                    	ids.Add(dr[1].ToString());                    
                    }
                    con.Close();
                    return ids.ToArray();
                }
                else
                {
                    con.Close();
                    return new string[] { };
                }

            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
        }
    
	}
}



