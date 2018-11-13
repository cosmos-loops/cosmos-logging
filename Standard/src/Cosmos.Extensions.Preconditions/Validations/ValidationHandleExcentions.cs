using System.Linq;

namespace Cosmos.Validations
{
    public static class ValidationHandleExcentions
    {
        public static ValidationHandleOperation Handle(this ValidationResultCollection collection)
        {
            return new ValidationHandleOperation(collection);
        }

        public static ValidationHandleOperation HandleAll(this ValidationHandleOperation op, IValidationHandler handler)
        {
            op.CheckNull(nameof(op));
            handler.CheckNull(nameof(handler));

            op.Handle(handler);

            return op;
        }

        public static ValidationHandleOperation HandleForSuccess(this ValidationHandleOperation op, IValidationHandler handler)
        {
            op.CheckNull(nameof(op));
            handler.CheckNull(nameof(handler));

            op.Handle(handler, x => x.Where(y => y.IsValid));

            return op;
        }

        public static ValidationHandleOperation HandleForFailure(this ValidationHandleOperation op, IValidationHandler handler)
        {
            op.CheckNull(nameof(op));
            handler.CheckNull(nameof(handler));

            op.Handle(handler, x => x.Where(y => !y.IsValid));

            return op;
        }

        public static ValidationHandleOperation HandleForStrategy(this ValidationHandleOperation op, string name,
            IValidationHandler handler)
        {
            op.CheckNull(nameof(op));
            handler.CheckNull(nameof(handler));

            op.Handle(handler, name);

            return op;
        }
    }
}