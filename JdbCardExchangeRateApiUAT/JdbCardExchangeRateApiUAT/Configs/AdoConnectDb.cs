using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDBCardExchageRate.Configs
{
    public class AdoConnectDb
    {
        protected readonly string Constr = "Data Source=FCUATDB;User Id=JDBMBADMIN_UAT;Password=mbuat5678;" +
            "pooling=true; Load Balancing=true; incr Pool Size=5; Decr Pool Size=1; Max Pool Size =100;Min Pool Size =1; Connection Timeout = 60;";
        private static OracleConnection con;
        public AdoConnectDb() { 
        
        }

        public OracleConnection _getConection() {
            try
            {
                return new OracleConnection(Constr);
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        public OracleDataReader ExcuteReader(string sqltext) {
            
            OracleCommand cmd = null;
            try
            {
                con = _getConection();
                con.Open();
                cmd = new OracleCommand(sqltext, con);
                return  cmd.ExecuteReader();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                //con.Dispose();
                //con.Close();
            }
        }

    }
}
