namespace ValidatorInterface
{
    public interface IValidator<T>
    {
        void Validate(T someObject);
    }
}
