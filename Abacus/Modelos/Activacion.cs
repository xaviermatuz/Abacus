using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Abacus.Modelos
{
    class Activacion
    {
        [BsonId]  // _id
        public Guid Id { get; set; }        
        [BsonElement("Cliente")]
        public string Cliente { get; set; }
        [BsonElement("Serial")]
        public string Serial { get; set; }        
        [BsonElement("Estado")]
        public Boolean Estado { get; set; }

        public Activacion(string cliente, string serial, bool estado)
        {
            Cliente = cliente;
            Serial = serial;
            Estado = estado;
        }
    }
}
