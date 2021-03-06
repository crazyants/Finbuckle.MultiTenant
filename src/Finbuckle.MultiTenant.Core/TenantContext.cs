using System;
using System.Collections.Generic;

namespace Finbuckle.MultiTenant.Core
{
    /// <summary>
    /// Contains information for a specific tenant.
    /// </summary>
    public class TenantContext
    {
        public string Id
        {
            get
            {
                Items.TryGetValue(nameof(Id), out object id);
                return (string)id;
            }
            internal set
            {
                if(value != null && value.Length > Constants.TenantIdMaxLength)
                    throw new MultiTenantException($"TenantContext Id length must be {Constants.TenantIdMaxLength} or less.");
                Items[nameof(Id)] = value;
            }
        }

        public string Identifier
        {
            get
            {
                Items.TryGetValue(nameof(Identifier), out object identifier);
                return (string)identifier;
            }
            internal set
            {
                Items[nameof(Identifier)] = value;
            }
        }

        public string Name
        {
            get
            {
                Items.TryGetValue(nameof(Name), out object name);
                return (string)name;
            }
            internal set
            {
                Items[nameof(Name)] = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                Items.TryGetValue(nameof(ConnectionString), out object connectionString);
                return (string)connectionString;
            }
            internal set
            {
                Items[nameof(ConnectionString)] = value;
            }
        }
        public Type MultiTenantStrategyType
        {
            get
            {
                Items.TryGetValue(nameof(MultiTenantStrategyType), out object resolverType);
                return (Type)resolverType;
            }
            internal set
            {
                Items[nameof(MultiTenantStrategyType)] = value;
            }
        }

        public Type MultiTenantStoreType
        {
            get
            {
                Items.TryGetValue(nameof(MultiTenantStoreType), out object storeType);
                return (Type)storeType;
            }
            internal set
            {
                Items[nameof(MultiTenantStoreType)] = value;
            }
        }

        public Dictionary<string, object> Items { get; } =
            new Dictionary<string, object>();

        public TenantContext(string id,
                             string identifier,
                             string name,
                             string connectionString,
                             Type resolverType,
                             Type storeType)
        {
            Id = id;
            Identifier = identifier;
            Name = name;
            ConnectionString = connectionString;
            MultiTenantStrategyType = resolverType;
            MultiTenantStoreType = storeType;
        }

        public TenantContext(TenantContext tenantContext)
        {
            foreach (var item in tenantContext.Items)
                Items.Add(item.Key, item.Value);
        }
    }
}