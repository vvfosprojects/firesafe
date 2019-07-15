using DomainModel.Classes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CompositionRoot")]
[assembly: InternalsVisibleTo("Persistence.MongoDB.DbInitializer")]

namespace Persistence.MongoDB
{
    internal class DbContext
    {
        private readonly IMongoDatabase database;

        public DbContext(string mongoUrl)
        {
            InitDbSettings();
            MapClasses();
            this.database = InitDbInstance(mongoUrl);
            CreateIndexes();
        }

        private IMongoDatabase InitDbInstance(string mongoUrl)
        {
            var url = new MongoUrl(mongoUrl);
            var client = new MongoClient(mongoUrl);
            return client.GetDatabase(url.DatabaseName);
        }

        private void InitDbSettings()
        {
            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camel case", pack, t => true);
        }

        private void CreateIndexes()
        {
            /*{
                var indexDefinition = Builders<MyClassName>.IndexKeys
                    .Ascending(_ => _.FirstProperty)
                    .Descending(_ => _.SecondProperty);

                var indexOptions = new CreateIndexOptions<MyClassName>
                {
                    PartialFilterExpression = Builders<MyClassName>.Filter.Eq(m => m.FirstProperty, true),
                    Background = true
                };

                this.ClassNameCollection.Indexes.CreateOne(indexDefinition, indexOptions);
            }*/
        }

        private void MapClasses()
        {
            BsonClassMap.RegisterClassMap<Prodotto>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);

                // Unmap property
                //cm.UnmapProperty(c => c.Lat);

                /// Map private field
                //cm.MapField("type");

                // change field map name
                //cm.GetMemberMap(c => c.InsertionTime)
                //  .SetElementName("ts");
            });
        }

        public IMongoCollection<Prodotto> ProdottiCollection
        {
            get
            {
                return database.GetCollection<Prodotto>("prodotti");
            }
        }
    }
}
