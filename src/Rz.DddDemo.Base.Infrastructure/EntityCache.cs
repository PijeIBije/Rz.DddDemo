using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Infrastructure.Exceptions;

namespace Rz.DddDemo.Base.Infrastructure
{
    public class EntityCache
    {
        private readonly Dictionary<Type, Dictionary<object, object>> existing = new Dictionary<Type, Dictionary<object, object>>();

        private readonly Dictionary<Type, Dictionary<object, object>> loaded = new Dictionary<Type, Dictionary<object, object>>();

        private readonly Dictionary<Type, Dictionary<object, object>> toDelete = new Dictionary<Type, Dictionary<object, object>>();

        private readonly Dictionary<Type, Dictionary<object, object>> toSave = new Dictionary<Type, Dictionary<object, object>>();

        private Dictionary<object,object> GetEntityDictionaryForType(Dictionary<Type, Dictionary<object, object>> entityDictionary, Type entityType)
        {
            if (entityType == null) throw new ArgumentException("Entity cannot be null", nameof(entityType));

            if (entityDictionary.TryGetValue(entityType, out Dictionary<object, object> entityDictionaryForType))
                return entityDictionaryForType;

            entityDictionaryForType = new Dictionary<object, object>();
            entityDictionary.Add(entityType,entityDictionaryForType);

            return entityDictionaryForType;
        }

        private void RemoveFromDictionary(Dictionary<Type, Dictionary<object, object>> entityDictionary, object id,
            object entity)
        {
            if (entity == null) throw new ArgumentException("Entity cannot be null", nameof(entity));

            var entityType = entity.GetType();

            var entityDictionaryForType = GetEntityDictionaryForType(entityDictionary, entityType);
            if (entityDictionaryForType.ContainsKey(id)) entityDictionaryForType.Remove(id);
        }

        private void AddToDictionary(Dictionary<Type, Dictionary<object, object>> entityDictionary, object id,
            object entity)
        {
            if (entity == null) throw new ArgumentException("Entity cannot be null", nameof(entity));

            var entityType = entity.GetType();

            var entityDictionaryForType = GetEntityDictionaryForType(entityDictionary, entityType);

            if (entityDictionaryForType.TryGetValue(id,out object entityFromDictionary))
            {
                if(!ReferenceEquals(entity,entityFromDictionary)) throw new InvalidOperationException($"Entity already exists under id {id}");
            }

            entityDictionaryForType[id]=entity;
        }

        public IEnumerable<TEntity> TryGetLoaded<TEntity>(Func<TEntity,bool> predicate)
        {
            var entityType = typeof(TEntity);

            var toDeleteForType = GetEntityDictionaryForType(toDelete, entityType);

            var loadedForType = GetEntityDictionaryForType(loaded,entityType);

            var result = loadedForType.Values.Cast<TEntity>().Where(predicate).Except(toDeleteForType.Values.Cast<TEntity>());

            return result;
        }

        private IEnumerable<TEntity> GetAll<TEntity>(Dictionary<Type, Dictionary<object, object>> entityDictionary)
        {
            var entityType = typeof(TEntity);

            var entityDictionaryForType = GetEntityDictionaryForType(entityDictionary, entityType);

            return entityDictionaryForType.Values.Cast<TEntity>();
        }

        public IEnumerable<TEntity> GetLoaded<TEntity>()
        {
            return GetAll<TEntity>(loaded);
        }

        public IEnumerable<TEntity> GetExisting<TEntity>()
        {
            return GetAll<TEntity>(existing);
        }

        public IEnumerable<TEntity> GetToSave<TEntity>()
        {
            return GetAll<TEntity>(toSave);
        }

        public IEnumerable<TEntity> GetToDelete<TEntity>()
        {
            return GetAll<TEntity>(toDelete);
        }

        private TEntity TryGetById<TEntity, TId>(TId id, Dictionary<Type, Dictionary<object, object>> entityDictionary)
        {
            var entityDictionaryForType = GetEntityDictionaryForType(entityDictionary, typeof(TEntity));

            if (entityDictionaryForType.TryGetValue(id, out object entity))
            {
                return (TEntity)entity;
            }

            return default;
        }

        public TEntity TryGetLoaded<TEntity,TId>(TId id)
        {
            return TryGetById<TEntity,TId>(id,loaded);
        }

        public TEntity TryGetExisting<TEntity, TId>(TId id)
        {
            return TryGetById<TEntity, TId>(id, existing);
        }

        public TEntity TryGetToSave<TEntity, TId>(TId id)
        {
            return TryGetById<TEntity, TId>(id, toSave);
        }

        public TEntity TryGetToDelete<TEntity, TId>(TId id)
        {
            return TryGetById<TEntity, TId>(id, toDelete);
        }

        private TEntity GetById<TEntity, TId>(TId id, Dictionary<Type, Dictionary<object, object>> entityDictionary)
        {
            var entity = TryGetById<TEntity, TId>(id, entityDictionary);

            if (entity == null)
            {
                throw new NoResultsException($"No entity with id {id}");
            }

            return entity;
        }

        public TEntity GetLoaded<TEntity, TId>(TId id)
        {
            return GetById<TEntity, TId>(id, loaded);
        }

        public TEntity GetExisting<TEntity, TId>(TId id)
        {
            return GetById<TEntity, TId>(id, existing);
        }

        public TEntity GetToSave<TEntity, TId>(TId id)
        {
            return GetById<TEntity, TId>(id, toSave);
        }

        public TEntity GetToDelete<TEntity, TId>(TId id)
        {
            return GetById<TEntity, TId>(id, toDelete);
        }

        public void AddToSave<TId, TEntity>(TId id, TEntity entity)
        {
            AddToDictionary(loaded,id,entity);
            AddToDictionary(existing,id,entity);
            RemoveFromDictionary(toDelete,id,entity);
            AddToDictionary(toSave,id,entity);
        }

        public void AddToDelete<TId, TEntity>(TId id, TEntity entity)
        {
            AddToDictionary(loaded,id,entity);

            RemoveFromDictionary(toSave,id,entity);

            RemoveFromDictionary(existing,id,entity);

            AddToDictionary(toDelete,id,entity);
        }

        public void AddToLoaded<TId, TEntity>(TId id, TEntity entity)
        {
            AddToDictionary(loaded,id,entity);
            AddToDictionary(existing,id,entity);
        }
    }
}
