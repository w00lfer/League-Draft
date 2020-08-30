﻿using AutoMapper;
using System.Linq;

namespace LeagueDraft_API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static TResult MergeInto<TResult>(this IMapper mapper, object item1, object item2)
        {
            var item1map = mapper.Map<TResult>(item1);
            var item2map = mapper.Map<TResult>(item2);
            return mapper.Map(item2, mapper.Map<TResult>(item1));
        }

        public static TResult MergeInto<TResult>(this IMapper mapper, params object[] objects)
        {
            var res = mapper.Map<TResult>(objects.First());
            return objects.Skip(1).Aggregate(res, (r, obj) => mapper.Map(obj, r));
        }
    }
}