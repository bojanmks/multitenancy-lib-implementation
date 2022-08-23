using MultiTenancy.Application.Exceptions;
using MultiTenancy.Application.Search;
using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Extensions
{
    public static class SearchObjectExtensions
    {
        public static IQueryable<T> BuildQuery<T>(this ISearchObject search, IQueryable<T> query)
        {
            var searchObjProperties = search.GetType().GetProperties();

            foreach (var p in searchObjProperties)
            {
                var value = p.GetValue(search);

                if(value == null) continue;

                var attributes = p.GetCustomAttributes(true);

                foreach (var attr in attributes)
                {
                    if(attr is WithAnyPropertyAttribute wp)
                    {
                        var comparisonType = wp.ComparisonType;
                        var properties = wp.Properties;

                        foreach (var prop in properties)
                        {
                            query = query.Where(GetComparisonStringAnyProperty(prop, value, comparisonType));
                        }
                    }
                    else if (attr is QueryPropertyAttribute qp)
                    {
                        var comparisonType = qp.ComparisonType;
                        var properties = qp.Properties;

                        foreach (var prop in properties)
                        {
                            query = query.Where(GetComparisonString(prop, value, comparisonType));
                        }
                    }
                }
            }

            return query;
        }

        public static IQueryable<T> BuildOrderBy<T>(this ISearchObject search, IQueryable<T> query)
        {
            var sortByString = search.SortBy;

            if (!string.IsNullOrEmpty(sortByString))
            {
                var sortByArgs = sortByString.Split(',');
                string orderByClause = "";

                foreach(var arg in sortByArgs)
                {
                    var propAndDirection = arg.Split('.');

                    if(propAndDirection.Count() < 2)
                    {
                        throw new InvalidSortFormatException();
                    }

                    if (!SortDirections.Contains(propAndDirection[1]))
                    {
                        throw new InvalidSortDirectionException();
                    }

                    if (search.CustomSortBy.ContainsKey(propAndDirection[0]))
                    {
                        var customSortBy = search.CustomSortBy[propAndDirection[0]];

                        orderByClause += $"{customSortBy} {propAndDirection[1]},";
                        continue;
                    }

                    orderByClause += $"{propAndDirection[0]} {propAndDirection[1]},";
                }

                orderByClause = orderByClause.TrimEnd(',');

                query = query.OrderBy(orderByClause);
            }

            return query;
        }

        private static IEnumerable<string> SortDirections = new List<string> { "asc", "desc" };

        private static string GetComparisonString(string property, object value, ComparisonType comparisonType)
        {
            switch(comparisonType)
            {
                case ComparisonType.Equals:
                    return $"x => x.{property} == {FormatValue(value)}";
                    break;
                case ComparisonType.Contains:
                    return $"x => x.{property}.Contains({FormatValue(value)})";
                    break;
                case ComparisonType.LessThan:
                    return $"x => x.{property} < {FormatValue(value)}";
                    break;
                case ComparisonType.LessThanOrEqual:
                    return $"x => x.{property} <= {FormatValue(value)}";
                    break;
                case ComparisonType.GreaterThan:
                    return $"x => x.{property} > {FormatValue(value)}";
                    break;
                case ComparisonType.GreaterThanOrEqual:
                    return $"x => x.{property} >= {FormatValue(value)}";
                    break;
                default:
                    return $"x => x.{property} == {FormatValue(value)}";
            }
        }

        private static string GetComparisonStringAnyProperty(string property, object value, ComparisonType comparisonType)
        {
            string originalProp = property.Substring(0, property.IndexOf('.'));
            string nestedProps = property.Substring(property.IndexOf('.') + 1);

            return $"y => y.{originalProp}.Any({GetComparisonString(nestedProps, value, comparisonType)})";
        }

        private static object FormatValue(object value)
        {
            if (value is string) return $"\"{value}\"";

            return value;
        }
    }
}
