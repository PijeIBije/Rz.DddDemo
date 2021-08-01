﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public TResult Map<TSource, TResult>(TSource source, bool allowPartialMapping = true)
        {
            if (!TryMap(source, out TResult  result))
            {
                throw new InvalidOperationException($"Cannot map {typeof(TSource).FullName} to {typeof(TResult).FullName}");
            }

            return result;
        }

        public bool TryMap<TSource, TResult>(TSource source, out TResult result, bool allowPartialMapping = true)
        {
            if (!TryMap(source, out var resultAsObject, typeof(TResult)))
            {
                result = default;
                return false;
            }

            result = (TResult) resultAsObject;
            return true;
        }

        public object Map(object source, Type resultType, bool allowPartialMapping = true)
        {
            if (!TryMap(source, out var result, resultType, allowPartialMapping))
            {
                throw new InvalidOperationException($"Cannot map {source.GetType().FullName} to {resultType.FullName}");
            }

            return result;
        }

        public bool TryMap(object source, out object result, Type resultType, bool allowPartialMapping = true)
        {
            if (source == null)
            {
                result = null;
                return true;
            }

            object valueMapped = default;

            if (valueMappings.Any(x => x.TryMap(source, resultType, out valueMapped, allowPartialMapping, this)))
            {
                result = valueMapped; 
                return true;
            }

            result = default;
            return false;
        }
    }
}
