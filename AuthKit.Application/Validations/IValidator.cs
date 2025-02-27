namespace AuthKit.Application.Validations
{
    public interface IValidator<in TEntity>
    {
        Task<ValidationResult> ValidateAsync(TEntity entity);
    }
}
