using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.UI.WebControls;
using USC.GISResearchLab.Common.Databases.QueryManagers;
using USC.GISResearchLab.Common.Utils.Databases;
using System.Text;
using System.Diagnostics;
using USC.GISResearchLab.Common.Core.PerformanceTiming.PerformanceTimingManagement.Interfaces;

namespace USC.GISResearchLab.Common.Core.PerformanceTiming.PerformanceTimingManagement.AbstractClasses
{
    public abstract class AbstractPerformanceTimingManager : IPerformanceTimingManager
    {
        #region Properties

        public IQueryManager GeocodePerformanceTimingQueryManager { get; set; }

        #endregion

        public AbstractPerformanceTimingManager()
            : base()
        {
            
        }

        public virtual void InsertTiming(TraceEventType traceEventType, string componentName, string functionName, string message, double timeTaken, string databaseServer, string medium, string service, string source, string apiServer, string userGuid, string inputAddress, string resultType, string resultCount, string resultException)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" SET ANSI_WARNINGS OFF; ");
                sb.Append(" INSERT INTO TimingMeasurements ");
                sb.Append(" ( ");

                sb.Append("  added, ");
                sb.Append("  componentName, ");
                sb.Append("  functionName, ");
                sb.Append("  message, ");
                sb.Append("  traceEventType, ");
                sb.Append("  timeTaken, ");
                sb.Append("  databaseServer, ");
                sb.Append("  medium, ");
                sb.Append("  service, ");
                sb.Append("  source, ");
                sb.Append("  apiServer, ");
                sb.Append("  inputAddress, ");
                sb.Append("  resultType, ");
                sb.Append("  resultCount, ");
                sb.Append("  exception, ");
                sb.Append("  userGuid ");


                sb.Append(" ) ");
                sb.Append(" VALUES ");
                sb.Append(" ( ");
                sb.Append("  @added, ");
                sb.Append("  @componentName, ");
                sb.Append("  @functionName, ");
                sb.Append("  @message, ");
                sb.Append("  @traceEventType, ");
                sb.Append("  @timeTaken, ");
                sb.Append("  @databaseServer, ");
                sb.Append("  @medium, ");
                sb.Append("  @service, ");
                sb.Append("  @source, ");
                sb.Append("  @apiServer, ");
                sb.Append("  @inputAddress, ");
                sb.Append("  @resultType, ");
                sb.Append("  @resultCount, ");
                sb.Append("  @exception, ");
                sb.Append("  @userGuid ");
                sb.Append(" ) ");

                SqlCommand cmd = new SqlCommand(sb.ToString());

                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("added", SqlDbType.DateTime, DateTime.Now));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("componentName", SqlDbType.VarChar, componentName));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("functionName", SqlDbType.VarChar, functionName));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("message", SqlDbType.VarChar, message));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("traceEventType", SqlDbType.VarChar, traceEventType));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("timeTaken", SqlDbType.Float, timeTaken));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("databaseServer", SqlDbType.VarChar, databaseServer));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("medium", SqlDbType.VarChar, medium));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("service", SqlDbType.VarChar, service));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("source", SqlDbType.VarChar, source));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("apiServer", SqlDbType.VarChar, apiServer));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("inputAddress", SqlDbType.VarChar, inputAddress));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("resultType", SqlDbType.VarChar, resultType));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("resultCount", SqlDbType.VarChar, resultCount));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("exception", SqlDbType.VarChar, resultException));
                cmd.Parameters.Add(SqlParameterUtils.BuildSqlParameter("userGuid", SqlDbType.VarChar, userGuid));

                IQueryManager qm = GeocodePerformanceTimingQueryManager;
                qm.AddParameters(cmd.Parameters);
                qm.ExecuteNonQuery(CommandType.Text, cmd.CommandText, 2, true);

            }
            catch (ThreadAbortException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                string msg = "Error InsertTiming: " + ex.Message;
                throw new Exception(msg, ex);
            }
        }

    }
}