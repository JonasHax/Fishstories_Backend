using FiskeNettet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FiskeNettet.Repositories.Interfaces
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        IQueryable<TDocument> AsQueryable();

        IEnumerable<TDocument> FilterBy(
        Expression<Func<TDocument, bool>> filterExpression);

        List<TDocument> Get();

        TDocument Get(string id);

        void Create(TDocument document);

        void CreateMany(ICollection<TDocument> documents);

        void DeleteById(string id);

        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);
    }
}