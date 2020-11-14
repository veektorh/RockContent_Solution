using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace MyApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }
    }

    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(a => a.Title).NotEmpty().NotNull().WithMessage("Title must not be empty");
            RuleFor(a => a.Body).NotEmpty().NotNull().WithMessage("Body must not be empty");
        }
    }

}
