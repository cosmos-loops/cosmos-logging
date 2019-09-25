using System.Collections;
using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace Cosmos.Logging.Extensions.NHibernate.Core
{
    public class LoggingInterceptor : EmptyInterceptor
    {
        internal static LoggingInterceptor Default => new LoggingInterceptor();

        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types) { }

        public override void OnCollectionRecreate(object collection, object key) { }

        public override void OnCollectionRemove(object collection, object key) { }

        public override void OnCollectionUpdate(object collection, object key) { }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            return false;
        }

        public override bool OnLoad(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            return false;
        }

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            return false;
        }

        public override void PostFlush(ICollection entities) { }

        public override void PreFlush(ICollection entitites) { }

        public override bool? IsTransient(object entity)
        {
            return new bool?();
        }

        public override object Instantiate(string clazz, object id)
        {
            return (object) null;
        }

        public override string GetEntityName(object entity)
        {
            return (string) null;
        }

        public override object GetEntity(string entityName, object id)
        {
            return (object) null;
        }

        public override int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            return (int[]) null;
        }

        public override void AfterTransactionBegin(ITransaction tx) { }

        public override void BeforeTransactionCompletion(ITransaction tx) { }

        public override void AfterTransactionCompletion(ITransaction tx) { }

        public override void SetSession(ISession session) { }

        public override SqlString OnPrepareStatement(SqlString sql)
        {
            return base.OnPrepareStatement(sql);
        }
    }
}