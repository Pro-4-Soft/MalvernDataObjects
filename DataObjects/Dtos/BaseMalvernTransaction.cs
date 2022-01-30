using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Pro4Soft.Malvern.DataObjects.Dtos
{
    public abstract class BaseMalvernRequest: BaseMalvernTransaction
    {
        public string Sscc18Code { get; set; }
        public string PoNumber { get; set; }
        public string PickTicketNumber { get; set; }
        public string Customer { get; set; }
        public string TrackingNumber { get; set; }
    }

    public abstract class BaseMalvernResponse : BaseMalvernTransaction
    {
        
    }

    public abstract class BaseMalvernTransaction: BaseMalvernEntity
    {
        protected BaseMalvernTransaction()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [MalvernField("0", 3)] 
        public string TransactionType => ((MalvernTransactionAttribute) Attribute.GetCustomAttribute(GetType(), typeof(MalvernTransactionAttribute))).TransactionId;

        [MalvernField("1", 15)]
        public string TransactionId { get; set; }

        [MalvernField("2")]
        public string ErrorCode { get; set; }

        [MalvernField("3")]
        public string ErrorMessage { get; set; }

        [MalvernField("99")] 
        public string EndRecord => string.Empty;
    }

    public class BaseMalvernEntity
    {
        public string Encode(Dictionary<string, List<string>> carrierServiceMap = null, string suffix = null)
        {
            var type = GetType();
            var properties = type.GetProperties()
                .Select(c => new
                {
                    Attr = Attribute.GetCustomAttribute(c, typeof(MalvernFieldAttribute)) as MalvernFieldAttribute,
                    Type = c
                })
                .Where(c => c.Attr != null)
                .OrderBy(c => c.Attr.FieldId)
                .Select(c => c.Type)
                .ToList();

            var last = properties.SingleOrDefault(c => ((MalvernFieldAttribute)Attribute.GetCustomAttribute(c, typeof(MalvernFieldAttribute))).FieldId == "99");
            if (last != null)
            {
                properties.Remove(last);
                properties.Add(last);
            }

            var builder = new StringBuilder();

            foreach (var prop in properties)
            {
                var attr = Attribute.GetCustomAttribute(prop, typeof(MalvernFieldAttribute)) as MalvernFieldAttribute;
                if (attr == null)
                    continue;

                var val = prop.GetValue(this);
                var fieldId = attr.FieldId;
                if (!string.IsNullOrWhiteSpace(suffix))
                    fieldId = $"{fieldId}-{suffix}";

                if (string.IsNullOrWhiteSpace(val?.ToString()))
                {
                    if (!attr.IsOptional)
                        builder.Append($@"{fieldId},""""");
                    continue;
                }
                
                switch (val)
                {
                    case string str:
                        builder.Append($@"{fieldId},""{str.Substring(0, attr.Length > 0 && str.Length > attr.Length ? attr.Length : str.Length)}""");
                        break;
                    case decimal dec:
                        builder.Append($@"{fieldId},""{decimal.Round(dec, attr.DecimalLength)}""");
                        break;
                    case bool bol:
                        builder.Append($@"{fieldId},""{(bol ? "Y" : string.Empty)}""");
                        break;
                    case List<CarrierServiceRate> rates:
                        {
                            var subList = new List<string>();
                            foreach (var rate in rates)
                            {
                                if (carrierServiceMap != null && carrierServiceMap.TryGetValue(rate.ToString(), out var replacement))
                                    subList.AddRange(replacement);
                                else
                                    subList.Add(rate.ToString());
                            }
                            builder.Append($@"{fieldId},""{string.Join(",", subList)}""");
                        }
                        break;
                    case List<CustomsLineItem> customs:
                        {
                            var lines = customs.Select((line, i) => line.Encode(carrierServiceMap, $"{i+1}")).ToList();
                            foreach (var line in lines)
                                builder.Append(line);
                        }
                        break;
                    default:
                        builder.Append($@"{fieldId},""{val}""");
                        break;
                }
            }
            return builder.ToString();
        }

        public static BaseMalvernTransaction Decode(string toDecode)
        {
            var fieldPropMap = new Dictionary<string, string>();

            var curString = toDecode;
            while (true)
            {
                var next = curString.IndexOf(",\"", StringComparison.Ordinal);
                var key = curString.Substring(0, next);
                curString = curString.Substring(next + ",\"".Length);

                next = curString.IndexOf(",\"", StringComparison.Ordinal);
                if (next < 0)
                {
                    fieldPropMap[key] = curString.Trim('"');
                    break;//Last element
                }

                var lastQuote = curString.Substring(0, next).LastIndexOf("\"", StringComparison.Ordinal);
                var val = curString.Substring(0, lastQuote);
                fieldPropMap[key] = val;
                curString = curString.Substring(lastQuote + 1);
            }

            var transactionType = fieldPropMap.TryGetValue("0", out var t) ? t : throw new MalvernFormatException("Invalid Malvern string format", toDecode);
            var resultType = typeof(BaseMalvernTransaction).Assembly.GetTypes()
                .Where(c => typeof(BaseMalvernTransaction).IsAssignableFrom(c))
                .Where(c => Attribute.IsDefined(c, typeof(MalvernTransactionAttribute)))
                .Where(c => !c.IsAbstract)
                .FirstOrDefault(c => ((MalvernTransactionAttribute)Attribute.GetCustomAttribute(c, typeof(MalvernTransactionAttribute))).TransactionId == transactionType);
            if (resultType == null)
                throw new MalvernFormatException($"No class that implements Transaction Type [{transactionType}]", toDecode);

            var result = Activator.CreateInstance(resultType) as BaseMalvernTransaction;
            var properties = resultType.GetProperties()
                .Where(c => Attribute.IsDefined(c, typeof(MalvernFieldAttribute)))
                .Where(c => c.CanWrite)
                .ToList();

            foreach (var prop in properties)
            {
                var attr = Attribute.GetCustomAttribute(prop, typeof(MalvernFieldAttribute)) as MalvernFieldAttribute;
                if (attr == null)
                    continue;
                if (!fieldPropMap.TryGetValue(attr.FieldId, out var val))
                    continue;

                if (string.IsNullOrWhiteSpace(val))
                    prop.SetValue(result, null);
                else if (prop.PropertyType == typeof(string))
                    prop.SetValue(result, val);
                else if (prop.PropertyType == typeof(decimal?))
                    prop.SetValue(result, decimal.TryParse(val, out var dec) ? dec : throw new FormatException($"Invalid decimal value [{val}]"));
                else if (prop.PropertyType == typeof(bool?))
                    prop.SetValue(result, val.Trim().ToLower() == "y");
                else if (prop.PropertyType == typeof(List<CarrierServiceRate>))
                    prop.SetValue(result, val.Split(',').Select(c =>
                    {
                        var split = c.Split(' ');
                        return new CarrierServiceRate
                        {
                            Carrier = split[0],
                            Service = split[1],
                            Rate = split.Length > 2 ? decimal.Parse(split[2]) : (decimal?)null
                        };
                    }).ToList());
            }

            return result;
        }
    }
}
