using MvcCoreAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Hospital> GetHospitales()
        {
            string sql = "select * from HOSPITAL";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> hospitalesList = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital =
                    int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas =
                    int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitalesList.Add(hospital);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitalesList;
        }

        public Hospital FindHospitalById(int idhospital)
        {
            string sql = "select * from HOSPITAL where HOSPITAL_COD=@IDHOSPITAL";
            SqlParameter pamIdHospital =
                new SqlParameter("@IDHOSPITAL", idhospital);
            this.com.Parameters.Add(pamIdHospital);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();
            Hospital hospital = new Hospital();
            hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            hospital.Nombre = this.reader["NOMBRE"].ToString();
            hospital.Direccion = this.reader["DIRECCION"].ToString();
            hospital.Telefono = this.reader["TELEFONO"].ToString();
            hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return hospital;
        }

        public void InsertHospital
            (int idhospital, string nombre, string direccion
            , string telefono, int camas)
        {
            string sql = "insert into HOSPITAL values (@idhospital, @nombre "
                + ", @direccion, @telefono, @camas)";
            SqlParameter pamId = new SqlParameter("@idhospital", idhospital);
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            SqlParameter pamDireccion = new SqlParameter("@direccion", direccion);
            SqlParameter pamTelefono = new SqlParameter("@telefono", telefono);
            SqlParameter pamCamas = new SqlParameter("@camas", camas);
            this.com.Parameters.Add(pamId);
            this.com.Parameters.Add(pamNombre);
            this.com.Parameters.Add(pamDireccion);
            this.com.Parameters.Add(pamTelefono);
            this.com.Parameters.Add(pamCamas);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int af = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateHospital(int idhospital, string nombre
            , string direccion, string telefono, int camas)
        {
            string sql = "update HOSPITAL set NOMBRE=@nombre, DIRECCION=@direccion "
                + ", TELEFONO=@telefono, NUM_CAMA=@camas "
                + " where HOSPITAL_COD=@idhospital";
            //CREAMOS Y AÑADIMOS LOS PARAMETROS
            //VAMOS A REALIZARLO TODO EN UNO, AÑADIR Y CREAR EL PARAMETRO
            this.com.Parameters.AddWithValue("@idhospital", idhospital);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@camas", camas);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int af = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void DeleteHospital(int idhospital)
        {
            string sql = "delete from HOSPITAL where HOSPITAL_COD=@idhospital";
            this.com.Parameters.AddWithValue("@idhospital", idhospital);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int af = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
