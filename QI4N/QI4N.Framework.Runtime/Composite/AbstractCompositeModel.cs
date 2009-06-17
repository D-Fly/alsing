﻿namespace QI4N.Framework.Runtime
{
    using System;
    using System.Reflection;

    using JavaProxy;

    public abstract class AbstractCompositeModel
    {
        protected CompositeMethodsModel compositeMethodsModel;

        protected Type compositeType;

        protected AbstractMixinsModel mixinsModel;

        protected Type proxyType;

        protected AbstractStateModel stateModel;

        protected AbstractCompositeModel(Type compositeType, Visibility visibility, MetaInfo metaInfo, AbstractMixinsModel mixinsModel, AbstractStateModel stateModel, CompositeMethodsModel compositeMethodsModel)
        {
            this.stateModel = stateModel;
            this.compositeType = compositeType;
            this.compositeMethodsModel = compositeMethodsModel;
            this.mixinsModel = mixinsModel;
            this.proxyType = Proxy.BuildProxyType(compositeType);
        }


        public Type CompositeType
        {
            get
            {
                return this.compositeType;
            }
        }

        public AbstractStateModel State
        {
            get
            {
                return this.stateModel;
            }
        }

#if !DEBUG
        [DebuggerStepThrough]
        [DebuggerHidden]
#endif

        public object Invoke(MixinsInstance mixins, CompositeInstance compositeInstance, object proxy, MethodInfo method, object[] args, ModuleInstance moduleInstance)
        {
            return this.compositeMethodsModel.Invoke(mixins, proxy, method, args, moduleInstance);
        }

        public StateHolder NewBuilderState()
        {
            return this.stateModel.NewBuilderState();
        }

        public StateHolder NewInitialState()
        {
            return this.stateModel.NewInitialState();
        }

        public Composite NewProxy(InvocationHandler invocationHandler)
        {
            // TODO: linqify
            var instance = Activator.CreateInstance(this.proxyType, invocationHandler) as Composite;

            return instance;
        }

        public StateHolder NewState(StateHolder state)
        {
            return this.stateModel.NewState(state);
        }

        //    public abstract CompositeInstance NewCompositeInstance(ModuleInstance moduleInstance, UsesInstance usesInstance, StateHolder instanceState);
    }
}