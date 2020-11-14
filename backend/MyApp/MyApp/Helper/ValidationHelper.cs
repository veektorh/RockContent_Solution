using FluentValidation.Results;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Helper
{
    public static class ValidationHelper
    {
        public static ValidationResult Validate(this Article article)
        {
            var result = new ArticleValidator().Validate(article);
            return result;
        }
    }
}
