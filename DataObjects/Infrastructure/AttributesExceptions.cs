using System;

namespace Pro4Soft.Malvern.DataObjects.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MalvernTransactionAttribute : Attribute
    {
        public readonly string TransactionId;

        public MalvernTransactionAttribute(string transactionId)
        {
            TransactionId = transactionId;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MalvernFieldAttribute : Attribute
    {
        public string FieldId { get; }
        public int Length { get; }
        public int DecimalLength { get; }
        public bool IsOptional { get; }

        public MalvernFieldAttribute(string fieldId, int length = 0, int decimalLength = 0, bool isOptional = false)
        {
            FieldId = fieldId;
            Length = length;
            DecimalLength = decimalLength;
            IsOptional = isOptional;
        }

        //public MalvernFieldAttribute(int fieldId, int length = 0, int decimalLength = 0, bool isOptional = false)
        //{
        //    FieldId = fieldId.ToString();
        //    Length = length;
        //    DecimalLength = decimalLength;
        //    IsOptional = isOptional;
        //}
    }

    public class MalvernFormatException : Exception
    {
        public string Payload { get; }

        public MalvernFormatException(string message, string payload) : base(message)
        {
            Payload = payload;
        }
    }

    public class MalvernBusinessException : Exception
    {
        public string ErrorCode { get; }

        public MalvernBusinessException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}