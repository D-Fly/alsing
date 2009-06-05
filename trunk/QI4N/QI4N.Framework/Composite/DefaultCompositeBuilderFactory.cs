﻿namespace QI4N.Framework
{
    public class DefaultCompositeBuilderFactory : CompositeBuilderFactory
    {
        public T NewComposite<T>()
        {
            CompositeBuilder<T> builder = GetBuilder<T>();
            return builder.NewInstance();
        }

        public CompositeBuilder<T> NewCompositeBuilder<T>()
        {
            CompositeBuilder<T> builder = GetBuilder<T>();
            return builder;
        }

        private static CompositeBuilder<T> GetBuilder<T>()
        {
            return new DefaultCompositeBuilder<T>();
        }
    }
}