namespace Cosmos.Validations {
    public interface IValidationHandler {
        void Handle(ValidationResultCollection results);
    }
}