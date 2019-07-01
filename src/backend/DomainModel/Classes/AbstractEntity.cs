using System;

namespace DomainModel.Classes
{
    public class AbstractEntity
    {
        public AbstractEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; protected set; }
    }
}
