﻿namespace QI4N.Framework
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class AppliesToAttribute : Attribute
    {
        public AppliesToAttribute(params Type[] mixinTypes)
        {
            this.AppliesToTypes = mixinTypes;
        }

        public Type[] AppliesToTypes { get; private set; }
    }
}