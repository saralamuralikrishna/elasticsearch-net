﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Framework.Configuration
{
	public class EnvironmentConfiguration : TestConfigurationBase
	{
		public override bool DoNotSpawnIfAlreadyRunning { get; protected set; } = false;
		public override bool ForceReseed { get; protected set; } = true;
		public override string ElasticsearchVersion { get; protected set; }
		public override TestMode Mode { get; protected set; } = TestMode.Unit;
		public override string ClusterFilter { get; protected set; }
		public override string TestFilter { get; protected set; }

		public EnvironmentConfiguration()
		{
			//if env var NEST_INTEGRATION_VERSION is set assume integration mode
			//used by the build script FAKE
			this.ElasticsearchVersion = Environment.GetEnvironmentVariable("NEST_INTEGRATION_VERSION");
			if (!string.IsNullOrEmpty(ElasticsearchVersion))
				Mode = TestMode.Integration;
			this.ClusterFilter = Environment.GetEnvironmentVariable("NEST_INTEGRATION_CLUSTER");
			this.TestFilter = Environment.GetEnvironmentVariable("NEST_TEST_FILTER");
		}
	}
}
