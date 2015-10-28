using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// Descripción breve de storedProcedure
/// </summary>
public class storedProcedure
{
    private string Conexion;
    private SqlConnection conexion;
    SqlCommand comando = null;
    SqlDataReader resultados = null;
    private string conn;

    public storedProcedure(string conn)
    {
        this.conn = conn;
    }
    public void establecerConexion()
    {

        conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[conn].ConnectionString);
    }


    public int InsertaCampos(string campo)
    {
        establecerConexion();
        comando = new SqlCommand(campo, conexion);
        try
        {
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return 1;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return 0;
        }
    }

    public bool ejecutaSQL(string query)
    {
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();

            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }

    }

    #region DataTable
    public DataTable ValoresTree()
    {

        DataTable lista = new DataTable();

        establecerConexion();

        comando = new SqlCommand("crearTree", conexion);

        comando.CommandType = CommandType.StoredProcedure;

        try
        {
            conexion.Open();
            lista.Load(comando.ExecuteReader(), LoadOption.OverwriteChanges);
            conexion.Close();

            return lista;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return null;
        }
    }
    #endregion

    #region RecuperarRegistros
    public List<string> recuperaRegistros(string query)
    {
        List<string> resultado = new List<string>();
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;
        try
        {
            conexion.Open();
            resultados = comando.ExecuteReader();

            if (resultados.HasRows)
            {
                while (resultados.Read())
                {
                    for (int i = 0; i < resultados.FieldCount; i++)
                    {
                        resultado.Add(resultados.GetValue(i).ToString());
                    }
                }

            }
            conexion.Close();
            return resultado;

        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return null;
        }
        finally
        {
            conexion.Dispose();
            conexion.Close();
        }

    }
    #endregion

    #region actualizaDocumento
    public bool actualizarDocumento(string nombre, string descripcion, string adjunto, int idDocumento)
    {
        establecerConexion();
        comando = new SqlCommand("actualizaDocumentoR", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idDocumento", SqlDbType.Int).Value = idDocumento;
        comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
        comando.Parameters.Add("@decripcion", SqlDbType.VarChar).Value = descripcion;
        comando.Parameters.Add("@ruta", SqlDbType.VarChar).Value = adjunto;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }
    }
    #endregion

    #region RecuperaResultados
    public string recuperaValor(string query)
    {
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;
        string resultado = "";
        try
        {
            conexion.Open();
            resultados = comando.ExecuteReader();
            if (resultados.HasRows)
            {
                while (resultados.Read())
                {
                    resultado = resultados.GetValue(0).ToString();
                }
            }
            conexion.Close();

            return resultado;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return "-1";
        }
        finally
        {
            conexion.Dispose();
            conexion.Close();
        }

    }
    #endregion

    #region RecuperaValores
    public int recuperaValornum(string query)
    {
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;
        int resultado;
        try
        {
            conexion.Open();
            object resultados = comando.ExecuteScalar();
            resultado = Convert.ToInt32(resultados);

            return resultado;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return 0;
        }
        finally
        {
            conexion.Dispose();
            conexion.Close();
        }

    }
    #endregion


    #region GeneraContrasenia
    public string CreateRandomPassword()
    {
        string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$?";
        Byte[] randomBytes = new Byte[6];
        char[] chars = new char[6];
        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < 6; i++)
        {
            Random randomObj = new Random();
            randomObj.NextBytes(randomBytes);
            chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
        }

        return new string(chars);
    }
    #endregion

    #region Reglas

    public bool altaRegla(int config, string operacion, string condicion, string correcto, string incorrecto, int campos, int idRegla)
    {
        establecerConexion();
        comando = new SqlCommand("sp_AltaRegla", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idConfEmpresa", SqlDbType.Int).Value = config;
        comando.Parameters.Add("@operacion", SqlDbType.VarChar).Value = operacion;
        comando.Parameters.Add("@condicion", SqlDbType.VarChar).Value = condicion;
        comando.Parameters.Add("@verdadero", SqlDbType.VarChar).Value = correcto;
        comando.Parameters.Add("@falso", SqlDbType.VarChar).Value = incorrecto;
        comando.Parameters.Add("@idcampo", SqlDbType.Int).Value = campos;
        comando.Parameters.Add("@idRegla", SqlDbType.Int).Value = idRegla;
        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }
    }
    #endregion

    #region cargaReglaMasiva
    public bool cargaReglaMasiva(string archivo, int idCE)
    {
        establecerConexion();
        comando = new SqlCommand("spCargaReglas", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@archivo", SqlDbType.VarChar).Value = archivo;
        comando.Parameters.Add("@idCE", SqlDbType.Int).Value = idCE;
        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }
    }

    #endregion


    #region Bitacoras
    public bool logBitacoraA(string reglaschek, int idStatusA, int idUsuario)
    {
        establecerConexion();
        comando = new SqlCommand("splogBitacoraA", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@reglaschek", SqlDbType.VarChar).Value = reglaschek;
        comando.Parameters.Add("@idStatusA", SqlDbType.Int).Value = idStatusA;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        try
        {
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }
    }

    public bool logBitacoraCorrecto(string reglaschek, int idStatusA, int idUsuario)
    {
        establecerConexion();
        comando = new SqlCommand("splogBitacoraCorrecta", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@reglaschek", SqlDbType.VarChar).Value = reglaschek;
        comando.Parameters.Add("@idStatusA", SqlDbType.Int).Value = idStatusA;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        try
        {
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }
    }

    #endregion


    #region Empresa

    public bool altaConfig(int idEmpresa, int toperacion, int tregimen, string fini, string ffin)
    {
        establecerConexion();
        comando = new SqlCommand("sp_insertaConfEmpresa", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
        comando.Parameters.Add("@idTipoOperacion", SqlDbType.Int).Value = toperacion;
        comando.Parameters.Add("@idTipoRegimen", SqlDbType.Int).Value = tregimen;
        comando.Parameters.Add("@fini", SqlDbType.Date).Value = fini;
        comando.Parameters.Add("@ffin", SqlDbType.Date).Value = ffin;
        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }

    public List<string> listas(int idEmpresa)
    {
        SqlCommand comando2 = null;
        List<string> tablas = new List<string>();
        establecerConexion();
        comando = new SqlCommand("tabla_pedimento", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idEmpresa", SqlDbType.VarChar).Value = idEmpresa;
        comando.Parameters.Add("@tabla", SqlDbType.VarChar);
        comando.CommandTimeout = 600;
        comando.Parameters["@tabla"].Direction = System.Data.ParameterDirection.ReturnValue;

        comando2 = new SqlCommand("tabla_pedimento_glosa", conexion);
        comando2.CommandType = CommandType.StoredProcedure;
        comando2.Parameters.Add("@idEmpresa", SqlDbType.VarChar).Value = idEmpresa;
        comando2.Parameters.Add("@tabla2", SqlDbType.VarChar);
        comando2.CommandTimeout = 600;
        comando2.Parameters["@tabla2"].Direction = System.Data.ParameterDirection.ReturnValue;
        try
        {
            conexion.Open();
            //comando.ExecuteReader();
            tablas.Add((string)comando.ExecuteScalar());
            tablas.Add((string)comando2.ExecuteScalar());
            conexion.Close();
            return tablas;
            //lblUsuarios.Text = tablas;
            //lblGlosa.Text = (string)comando.Parameters["@tabla2"].Value;
            //lblUsuarios.Text = tabla.contruirTablaGen(query, "DataStage", encabezado);
            //lblGlosa.Text = tabla.contruirTablaGen(query2, "Glosa", encabezado);
            //return true;
        }
        catch (SqlException ex)
        {
            tablas.Add(ex.ToString());
            Console.Write(ex);
            return tablas;
        }
    }



    #endregion

    #region altaReglaDocumento
    public bool altaReglaDoc(int idDoc, int aplica, int idEmpresa, string condicion, int idConfiguracionEmpresa)
    {
        establecerConexion();
        comando = new SqlCommand("sp_inserta_ReglaDoc", conexion);

        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idDoc", SqlDbType.Int).Value = idDoc;
        comando.Parameters.Add("@aplica", SqlDbType.Int).Value = aplica;
        comando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
        comando.Parameters.Add("@condicion", SqlDbType.VarChar).Value = condicion;
        comando.Parameters.Add("@idConfiguracionEmpresa", SqlDbType.Int).Value = idConfiguracionEmpresa;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }
    }

    #endregion

    #region Detalles

    public string detalles(int idPedimento)
    {
        string tabla = "";
        establecerConexion();
        comando = new SqlCommand("sp_obtenerDetalles", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idpedimento", SqlDbType.Int).Value = idPedimento;
        comando.Parameters.Add("@tabla", SqlDbType.VarChar);
        comando.CommandTimeout = 600;
        comando.Parameters["@tabla"].Direction = System.Data.ParameterDirection.ReturnValue;
        try
        {
            conexion.Open();
            //comando.ExecuteReader();
            tabla = (string)comando.ExecuteScalar();
            conexion.Close();

        }
        catch (SqlException ex)
        {
            tabla = "";
            Console.Write(ex);
        }
        return tabla;
    }
    #endregion

    #region DataStage
    public string cargas(string nombreDS, int idUsuario)
    {
        string error = "";
        establecerConexion();
        comando = new SqlCommand("spCargaCampos", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@cargaDS", SqlDbType.VarChar).Value = nombreDS;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        //se manda un error en caso de existir
        comando.Parameters.Add("@error", SqlDbType.VarChar); //hay que inicializar el valor que se va a regresar
        comando.CommandTimeout = 300;
        comando.Parameters["@error"].Direction = System.Data.ParameterDirection.ReturnValue;//decimos que nos va a retornar una variable


        try
        {
            conexion.Open();
            error = (string)comando.ExecuteScalar();
            comando.ExecuteReader();
            conexion.Close();

        }
        catch (SqlException ex)
        {
            error = "";
            Console.Write(ex);

        }
        return error;
    }
    #endregion

    #region Glosa
    public bool cargaGlosa(string nombreDS)
    {
        SqlCommand comando2 = null;
        establecerConexion();
        comando = new SqlCommand("spCargaGlosaContribuciones", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@@nombreGlosa", SqlDbType.VarChar).Value = nombreDS;
        comando.CommandTimeout = 300;

        comando2 = new SqlCommand("spCargaGlosaPartidas", conexion);
        comando2.CommandType = CommandType.StoredProcedure;
        comando2.Parameters.Add("@@nombreGlosa", SqlDbType.VarChar).Value = nombreDS;
        comando2.CommandTimeout = 300;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            comando2.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {

            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region Reporte
    public string inserTabla(string nombreSeccion)
    {
        string tabla = "";
        establecerConexion();
        comando = new SqlCommand("sp_insertaTabla", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@nombreSeccion", SqlDbType.VarChar).Value = nombreSeccion;
        try
        {
            conexion.Open();
            resultados = comando.ExecuteReader();
            if (resultados.HasRows)
            {
                while (resultados.Read())
                {
                    tabla = resultados.GetValue(0).ToString();
                }
            }
            conexion.Close();
            return tabla;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return "";

        }
    }

    public bool inserCampo(string Nombre, int idUsuario, int idCategoria, string NombreC, string Imagen, string NombreVista, string campCheck)
    {

        establecerConexion();
        comando = new SqlCommand("sp_InsertaReporte1", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Nombre;
        comando.Parameters.Add("@usuario", SqlDbType.Int).Value = idUsuario;
        comando.Parameters.Add("@categoria", SqlDbType.Int).Value = idCategoria;
        comando.Parameters.Add("@nombreCategoria", SqlDbType.VarChar).Value = NombreC;
        comando.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Imagen;
        comando.Parameters.Add("@nombreVista", SqlDbType.VarChar).Value = NombreVista;
        comando.Parameters.Add("@idCampos", SqlDbType.VarChar).Value = campCheck;
        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }

    }

    #endregion

    #region Notificacion
    public bool guardaNot(string para, string cc, int idAccionesCorrec, string fechaComp, string quienAtendera,
        string descripcion, int idPedimento)
    {

        establecerConexion();
        comando = new SqlCommand("sp_guardaNotificacion", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@para", SqlDbType.VarChar).Value = para;
        comando.Parameters.Add("@cc", SqlDbType.VarChar).Value = cc;
        comando.Parameters.Add("@idAccionesCorrec", SqlDbType.Int).Value = idAccionesCorrec;
        comando.Parameters.Add("@fechaComp", SqlDbType.VarChar).Value = fechaComp;
        comando.Parameters.Add("@quienAtendera", SqlDbType.VarChar).Value = quienAtendera;
        comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
        comando.Parameters.Add("@idPedimento", SqlDbType.Int).Value = idPedimento;
        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region ActivosFijos
    public bool guardaActivo(int idActivoFijo, int idUsuario, string num_activoFijo, string descripcion, int idPedimento, string pedimento, string partida,
                             string num_factura, int idProveedor, int idModoAdq, string nombreMarca, string nombreModelo,
                             string num_serie, float importe_marq, int idTipoC, string registro_contable, string descripcionPropietarios, string tasa,
                                string num_mtto, string decripcionMtto, int idPlanta, int idArea)
    {
        establecerConexion();
        comando = new SqlCommand("sp_ActivoFijo", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idActivoFijo", SqlDbType.Int).Value = idActivoFijo;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        comando.Parameters.Add("@num_activoFijo", SqlDbType.VarChar).Value = num_activoFijo;
        comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
        comando.Parameters.Add("@idPedimento", SqlDbType.Int).Value = idPedimento;
        comando.Parameters.Add("@pedimento", SqlDbType.VarChar).Value = pedimento;
        comando.Parameters.Add("@Partida", SqlDbType.VarChar).Value = partida;
        comando.Parameters.Add("@num_factura ", SqlDbType.VarChar).Value = num_factura;
        comando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
        comando.Parameters.Add("@idModoAdq", SqlDbType.Int).Value = idModoAdq;
        comando.Parameters.Add("@nombreMarca ", SqlDbType.VarChar).Value = nombreMarca;
        comando.Parameters.Add("@nombreModelo", SqlDbType.VarChar).Value = nombreModelo;
        comando.Parameters.Add("@num_serie", SqlDbType.VarChar).Value = num_serie;
        comando.Parameters.Add("@importe_maq", SqlDbType.Float).Value = importe_marq;
        comando.Parameters.Add("@idTipoC", SqlDbType.Int).Value = idTipoC;
        comando.Parameters.Add("@registro_contable", SqlDbType.VarChar).Value = registro_contable;
        comando.Parameters.Add("@descripcionPropietarios", SqlDbType.VarChar).Value = descripcionPropietarios;
        comando.Parameters.Add("@tasa", SqlDbType.VarChar).Value = tasa;
        comando.Parameters.Add("@num_mtto", SqlDbType.VarChar).Value = num_mtto;
        comando.Parameters.Add("@decripcionMtto", SqlDbType.VarChar).Value = decripcionMtto;
        comando.Parameters.Add("@idPlanta", SqlDbType.Int).Value = idPlanta;
        comando.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region ComercioActivoFijo
    public bool guardaComercio(int idActivoFijo, int idUsuario, string num_activoFijo, string descripcion, int idPedimento, string pedimento, string partida,
                         string num_factura, string nombreMarca, string nombreModelo,
                         string num_serie, float importe_marq, int idTipoC)
    {
        establecerConexion();
        comando = new SqlCommand("sp_guardaComercioAF", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idActivoFijo", SqlDbType.Int).Value = idActivoFijo;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        comando.Parameters.Add("@num_activoFijo", SqlDbType.VarChar).Value = num_activoFijo;
        comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
        comando.Parameters.Add("@idPedimento", SqlDbType.Int).Value = idPedimento;
        comando.Parameters.Add("@pedimento", SqlDbType.VarChar).Value = pedimento;
        comando.Parameters.Add("@Partida", SqlDbType.VarChar).Value = partida;
        comando.Parameters.Add("@num_factura ", SqlDbType.VarChar).Value = num_factura;
        comando.Parameters.Add("@nombreMarca ", SqlDbType.VarChar).Value = nombreMarca;
        comando.Parameters.Add("@nombreModelo", SqlDbType.VarChar).Value = nombreModelo;
        comando.Parameters.Add("@num_serie", SqlDbType.VarChar).Value = num_serie;
        comando.Parameters.Add("@importe_maq", SqlDbType.Float).Value = importe_marq;
        comando.Parameters.Add("@idTipoC", SqlDbType.Int).Value = idTipoC;


        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region ContabilidadActivo
    public bool guardaContabilidad(int idActivoFijo, int idUsuario, int idProveedor, int idModoAdq, string registro_contable, string descripcionPropietarios,
                            string tasa)
    {
        establecerConexion();
        comando = new SqlCommand("sp_guardaContabilidadAF", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idActivoFijo", SqlDbType.Int).Value = idActivoFijo;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        comando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
        comando.Parameters.Add("@idModoAdq", SqlDbType.Int).Value = idModoAdq;
        comando.Parameters.Add("@registro_contable", SqlDbType.VarChar).Value = registro_contable;
        comando.Parameters.Add("@descripcionPropietarios", SqlDbType.VarChar).Value = descripcionPropietarios;
        comando.Parameters.Add("@tasa", SqlDbType.VarChar).Value = tasa;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region MantenimientoActivo
    public bool guardaMantenimiento(int idActivoFijo, int idUsuario, string num_mtto, string decripcionMtto, int idPlanta, int idArea)
    {
        establecerConexion();
        comando = new SqlCommand("sp_guardaMantenimientoAF", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idActivoFijo", SqlDbType.Int).Value = idActivoFijo;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        comando.Parameters.Add("@num_mtto", SqlDbType.VarChar).Value = num_mtto;
        comando.Parameters.Add("@decripcionMtto", SqlDbType.VarChar).Value = decripcionMtto;
        comando.Parameters.Add("@idPlanta", SqlDbType.Int).Value = idPlanta;
        comando.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region Rectificacion
    public bool guardaRectificacion(int idPedimento, string ubicacion, int idPlanta, string comentario, int usuario)
    {
        establecerConexion();
        comando = new SqlCommand("sp_insertaUbicacion", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idPedimento", SqlDbType.Int).Value = idPedimento;
        comando.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = ubicacion;
        comando.Parameters.Add("@idPlanta", SqlDbType.Int).Value = idPlanta;
        comando.Parameters.Add("@comentario", SqlDbType.VarChar).Value = comentario;
        comando.Parameters.Add("@usuario", SqlDbType.Int).Value = usuario;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region GaleriaActivos
    public bool guardaGaleria(int idActivoFijo, int idUsuario, string path, int idTipoF)
    {
        establecerConexion();
        comando = new SqlCommand("sp_guardaGaleria", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idActivoFijo", SqlDbType.Int).Value = idActivoFijo;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        comando.Parameters.Add("@path", SqlDbType.VarChar).Value = path;
        comando.Parameters.Add("@idTipoF", SqlDbType.Int).Value = idTipoF;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion

    #region ActualizaDocumentos
    public bool spActualizatPediDoc(int idUsuario, int idPediDoc, string comentario, int checado)
    {
        establecerConexion();
        comando = new SqlCommand("spActualizatPediDoc", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idDocPedi", SqlDbType.Int).Value = idPediDoc;
        comando.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = comentario;
        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
        comando.Parameters.Add("@Checado", SqlDbType.Bit).Value = checado;

        try
        {
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }
    }
    #endregion

    #region Estatus
    public bool guardaStatusA(int idPedimento)
    {
        establecerConexion();
        comando = new SqlCommand("sp_cambiaStatusA", conexion);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.Add("@idPedimento", SqlDbType.Int).Value = idPedimento;
        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();
            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;

        }
    }
    #endregion
}


