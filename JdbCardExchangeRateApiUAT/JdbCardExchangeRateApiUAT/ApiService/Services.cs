using JDBCardExchageRate.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDBCardExchageRate.ApiService
{
    public class Services
    {
        public Services()
        {
        }
        public IActionResult getExchangeRate() 
        {
            
            OracleDataReader reader = null;
            var _sql = "SELECT BUY_RATE FROM VW_MB_WS_EXC_RATE " +
                       "WHERE 1=1 AND BRANCH_CODE ='000' AND RATE_TYPE = 'TTRATE' AND CCY1 ='USD' AND RATE_DT_STAMP = SYSDATE";
            try
            {
                reader = new AdoConnectDb().ExcuteReader(_sql);
                if (reader.Read())
                {
                    do
                    {   double rate = reader.GetDouble(0);
                        return new OkObjectResult(new { result = true, status = StatusCodes.Status200OK, message = "success", data = new { buy_rate = rate } });
                    } while (reader.Read());
                    
                }
                else
                {
                    return new NotFoundObjectResult(new { result = true, status = StatusCodes.Status404NotFound, message = "success", data = "Data Not Found" });
                }
            
            }
            catch (Exception ex)
            {
               return new BadRequestObjectResult(new { result = false, status = StatusCodes.Status400BadRequest, message = "failure", data = ex.Message });
            }
            finally
            {
                reader.Dispose();
            }
            
            //return new OkObjectResult(new { result = true, status = StatusCodes.Status200OK, message = "success", data = new { buy_rate = 8000 } });
        }
    }
}
