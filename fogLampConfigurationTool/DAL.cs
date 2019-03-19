using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace fogLampConfigurationTool
{
    public class DAL
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        public DAL()
        {
            conn = new SqlConnection();
            ds = new DataSet();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["foglamp"].ConnectionString; ;
            }
            catch(Exception ex)
            {
                throw (new DALEXception("Check your connection"));

            }
            try
            {
                String sql = "SELECT ConfigID, ConfigValue FROM configuration";
                da = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.DeleteCommand = cb.GetDeleteCommand();
                da.UpdateCommand = cb.GetUpdateCommand();
                da.InsertCommand = cb.GetInsertCommand();

            }
            catch
            {

                throw (new DALEXception("Cannot create data adapter"));

            }


        }

        public DataSet GetConfiguration()
        {
            try
            {
                da.Fill(ds);
            }
            catch
            {
                throw (new DALEXception("Cannot get configuration"));

            }
            return ds;

        }

        public void SaveConfiguration(DataSet ds)
        {
            try
            {
                da.Update(ds);
            }
            catch (Exception ex)
            {
                throw (new DALEXception("Cannot save configuration"));
            }
        }







    }

    [Serializable]
    internal class DALEXception : Exception
    {
        public DALEXception()
        {
        }

        public DALEXception(string message) : base(message)
        {
        }

        public DALEXception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DALEXception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
