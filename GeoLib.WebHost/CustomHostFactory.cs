using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace GeoLib.WebHost
{
    public class CustomHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            //return base.CreateServiceHost(serviceType, baseAddresses);

            //Code only for visualization, it is what previous code call already does
            ServiceHost host = new ServiceHost(serviceType, baseAddresses);
            return host;
        }
    }
}