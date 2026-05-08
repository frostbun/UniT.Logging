#nullable enable
namespace UniT.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public interface ILoggerManager
    {
        public ILogger GetLogger(string name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ILogger GetLogger(Type ownerType) => this.GetLogger(ownerType.Name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ILogger GetLogger(object owner) => this.GetLogger(owner.GetType());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ILogger GetLogger<T>() => this.GetLogger(typeof(T));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ILogger GetDefaultLogger() => this.GetLogger(nameof(UniT));

        public IEnumerable<ILogger> GetAllLoggers();
    }
}