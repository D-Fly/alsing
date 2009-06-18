namespace ConsoleApplication23
{
    using System;

    using QI4N.Framework;
    using QI4N.Framework.Bootstrap;
    using QI4N.Framework.Runtime;

    internal class Program
    {
        private static void Main()
        {
            Qi4nRuntime qi4j;

            ApplicationAssembly app = qi4j.NewApplicationAssembly();

            LayerAssembly runtimeLayer = CreateRuntimeLayer(app);
            LayerAssembly designerLayer = CreateDesignerLayer(app);
            LayerAssembly domainLayer = CreateDomainLayer(app);
            LayerAssembly messagingLayer = CreateMessagingLayer(app);
            LayerAssembly persistenceLayer = CreatePersistenceLayer(app);

            // declare structure between layers
            domainLayer.Uses(messagingLayer);
            domainLayer.Uses(persistenceLayer);
            designerLayer.Uses(persistenceLayer);
            designerLayer.Uses(domainLayer);
            runtimeLayer.Uses(domainLayer);

            // Instantiate the Application Model.
            application = qi4j.NewApplication(app);
        }

        private static LayerAssembly CreatePersistenceLayer(ApplicationAssembly app)
        {
            throw new NotImplementedException();
        }

        private static LayerAssembly CreateMessagingLayer(ApplicationAssembly app)
        {
            throw new NotImplementedException();
        }

        private static LayerAssembly CreateDomainLayer(ApplicationAssembly app)
        {
            LayerAssembly layer = app.NewLayerAssembly();

            ModuleAssembly peopleModule = CreatePeopleModule(layer);
            return layer;


        }

        private static ModuleAssembly CreatePeopleModule(LayerAssembly layer)
        {
            ModuleAssembly module = layer.NewModuleAssembly();
    
            module.AddEntity<CarEntity>();
            module.AddService<ManufacturerRepositoryService>().VisibleIn( Visibility.Layer );
            module.AddValue<AccidentValue>();
            module.AddTransient<PersonComposite>();

            return module;


        }

        private static LayerAssembly CreateDesignerLayer(ApplicationAssembly app)
        {
            throw new NotImplementedException();
        }

        private static LayerAssembly CreateRuntimeLayer(ApplicationAssembly app)
        {
            throw new NotImplementedException();
        }
    }
}