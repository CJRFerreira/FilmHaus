using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmHaus.Services
{
    internal static class ReportQueryExtensions
    {
        public static Expression<Func<Report, ReportViewModel>> GetReportViewModel()
        {
            return r => new ReportViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                UserReportedId = r.UserReportedId,
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus
            };
        }
    }
}