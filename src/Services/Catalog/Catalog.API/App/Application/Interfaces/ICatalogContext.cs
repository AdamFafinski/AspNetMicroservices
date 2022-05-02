using Catalog.API.App.Domain.Entities;
using MongoDB.Driver;

namespace Catalog.API.App.Application.Interfaces;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}
