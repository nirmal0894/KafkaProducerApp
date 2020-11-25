using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace KafkaProducerApp.Ioc
{
    public static class ContainerFactory
    {
        public static IUnityContainer InitialiseContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.AddExtension(new ScheduleFeedFileDependencies());
            return unityContainer;
        }
    }
}
