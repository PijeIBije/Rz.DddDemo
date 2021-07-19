using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping
{
    public class Mapper:IMapper
    {
        private readonly IEnumerable<IValueMapping> valueMappings;

        public Mapper(IEnumerable<IValueMapping> valueMappings)
        {
            this.valueMappings = valueMappings;
        }

        public TResult Map<TSource, TResult>(TSource source)
        {
            if (!TryMap(source, out TResult  result))
            {
                throw new InvalidOperationException($"Cannot map {typeof(TSource).FullName} to {typeof(TResult).FullName}");
            }

            return result;
        }

        public bool TryMap<TSource, TResult>(TSource source, out TResult result)
        {
            if (!TryMap(source,typeof(TResult), out var resultAsObject))
            {
                result = default;
                return false;
            }

            result = (TResult) resultAsObject;
            return true;
        }

        public bool Map(object source, Type resultType, out object result)
        {
            if (!TryMap(source, resultType, out var resultAsObject))
            {
                result = default;
                return false;
            }

            result = resultAsObject;
            return true;
        }

        public bool TryMap(object source, Type resultType, out object result)
        {
            if (source == null)
            {
                result = null;
                return true;
            }

            object valueMapped = default;

            if (valueMappings.Any(x => x.TryMap(source, resultType, this, out valueMapped)))
            {
                result = valueMapped; 
                return true;
            }

            result = default;
            return false;
        }
    }
}
