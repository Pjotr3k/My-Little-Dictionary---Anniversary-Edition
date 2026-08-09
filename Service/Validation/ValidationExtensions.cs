namespace Service.Validation
{
    public static class ValidationExtensions
    {
        public static TItem ValidateOnNull<TItem>(this TItem item, List<string> messages)
        {
            if (item == null) throw new ValidationException(messages);
            return item;
        }

        public static TItem ValidateOnNull<TItem>(this TItem item, string message = "Item not found") => item.ValidateOnNull([message]);

        public static TItem ValidateOnNull<TItem, TValue>(this TItem item, TValue value, string type = "Item", string property = "ID")
            => item.ValidateOnNull(value.ToString(), type, property);

        public static TItem ValidateOnNull<TItem>(this TItem item, string value, string type = "Item", string property = "ID")
            => item.ValidateOnNull($"{type} with {property} {value} not found");
    }
}
