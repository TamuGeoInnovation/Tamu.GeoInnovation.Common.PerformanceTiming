using System.Diagnostics;
using USC.GISResearchLab.Common.Databases.QueryManagers;

namespace USC.GISResearchLab.Common.Core.PerformanceTiming.PerformanceTimingManagement.Interfaces
{
    public interface IPerformanceTimingManager
    {

        #region properties

        IQueryManager GeocodePerformanceTimingQueryManager { get; set; }

        #endregion


        void InsertTiming(TraceEventType traceEventType, string componentName, string functionName, string message, double timeTaken, string databaseServer, string medium, string service, string source, string apiServer, string userGuid, string inputAddress, string resultType, string resultCount, string resultException);

    }
}