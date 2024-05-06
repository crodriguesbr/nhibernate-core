using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.MultiTenancy;

namespace NHibernate.Cfg.Loquacious
{
	public  class MultiTenancyConfigurationProperties
	{
		private Configuration configuration;
		public MultiTenancyConfigurationProperties(Configuration configuration)
		{
			this.configuration = configuration;
		}

		public MultiTenancyStrategy MultiTenancyStrategy { get; set; }

		public void MultiTenancyConnectionProvider(Func<IMultiTenancyConnectionProvider> configure)
		{
			configuration.AddMultiTenancy(configure());
		}				
	}
}
