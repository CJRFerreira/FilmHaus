using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinqKit;
using FilmHaus.Enums;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Base;
using FilmHaus.Exceptions;
using static FilmHaus.Services.ReportQueryExtensions;

namespace FilmHaus.Services.Reports
{
    public class ReportService : IReportService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ReportService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}