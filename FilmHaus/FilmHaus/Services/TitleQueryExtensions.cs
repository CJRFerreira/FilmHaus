﻿using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Linq.Expressions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services
{
    internal static class TitleQueryExtensions
    {
        public static Expression<Func<Title, TitleViewModel>> GetTitleViewModel()
        {
            return t => new TitleViewModel()
            {
                DetailId = t.DetailId,
                Name = t.Name
            };
        }
    }
}