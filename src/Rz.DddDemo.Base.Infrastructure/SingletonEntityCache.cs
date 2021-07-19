using System;
using System.Collections.Generic;
using Rz.DddDemo.Base.Infrastructure.Exceptions;

namespace Rz.DddDemo.Base.Infrastructure
{
    public class SingletonEntityCache
    {
        private readonly Dictionary<Type, object> existing = new Dictionary<Type, object>();

        private readonly Dictionary<Type, object> loaded = new Dictionary<Type, object>();

        private readonly Dictionary<Type, object> toSave = new Dictionary<Type, object>();

        private readonly Dictionary<Type, object> toDelete = new Dictionary<Type, object>();

        private TEntity TryGet<TEntity>(Dictionary<Type, object> entityDictionary)
        {
            if (entityDictionary.TryGetValue(typeof(TEntity), out object entity))
            {
                return (TEntity)entity;
            }

            return default;
        }

        public TEntity TryGetLoaded<TEntity>()
        {
            return TryGet<TEntity>(loaded);
        }

        public TEntity TryGetExisting<TEntity>()
        {
            return TryGet<TEntity>(existing);
        }

        public TEntity TryGetToSave<TEntity>()
        {
            return TryGet<TEntity>(toSave);
        }

        public TEntity TryGetToDelete<TEntity>()
        {
            return TryGet<TEntity>(toDelete);
        }

        private TEntity Get<TEntity>(Dictionary<Type, object> entityDictionary)
        {
            var entity = TryGet<TEntity>(entityDictionary);

            if(entity == null) throw new NoResultsException($"No entity of type {typeof(TEntity).FullName}");

            return entity;
        }

        public TEntity GetLoaded<TEntity>()
        {
            return Get<TEntity>(loaded);
        }

        public TEntity GetExisting<TEntity>()
        {
            return Get<TEntity>(existing);
        }

        public TEntity GetToSave<TEntity>()
        {
            return Get<TEntity>(toSave);
        }

        public TEntity GetToDelete<TEntity>()
        {
            return Get<TEntity>(toDelete);
        }
    }
}
