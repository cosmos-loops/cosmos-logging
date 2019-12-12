using System.Collections;
using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace Cosmos.Logging.Extensions.NHibernate.Core {
    /// <summary>
    /// Logging interceptor
    /// </summary>
    public class LoggingInterceptor : EmptyInterceptor {
        internal static LoggingInterceptor Default => new LoggingInterceptor();

        /// <inheritdoc />
        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types) { }

        /// <inheritdoc />
        public override void OnCollectionRecreate(object collection, object key) { }

        /// <inheritdoc />
        public override void OnCollectionRemove(object collection, object key) { }

        /// <inheritdoc />
        public override void OnCollectionUpdate(object collection, object key) { }

        /// <inheritdoc />
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types) {
            return false;
        }

        /// <inheritdoc />
        public override bool OnLoad(object entity, object id, object[] state, string[] propertyNames, IType[] types) {
            return false;
        }

        /// <inheritdoc />
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types) {
            return false;
        }

        /// <inheritdoc />
        public override void PostFlush(ICollection entities) { }

        /// <inheritdoc />
        public override void PreFlush(ICollection entitites) { }

        /// <inheritdoc />
        public override bool? IsTransient(object entity) {
            return new bool?();
        }

        /// <inheritdoc />
        public override object Instantiate(string clazz, object id) {
            return (object) null;
        }

        /// <inheritdoc />
        public override string GetEntityName(object entity) {
            return (string) null;
        }

        /// <inheritdoc />
        public override object GetEntity(string entityName, object id) {
            return (object) null;
        }

        /// <inheritdoc />
        public override int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types) {
            return (int[]) null;
        }

        /// <inheritdoc />
        public override void AfterTransactionBegin(ITransaction tx) { }

        /// <inheritdoc />
        public override void BeforeTransactionCompletion(ITransaction tx) { }

        /// <inheritdoc />
        public override void AfterTransactionCompletion(ITransaction tx) { }

        /// <inheritdoc />
        public override void SetSession(ISession session) { }

        /// <inheritdoc />
        public override SqlString OnPrepareStatement(SqlString sql) {
            return base.OnPrepareStatement(sql);
        }
    }
}