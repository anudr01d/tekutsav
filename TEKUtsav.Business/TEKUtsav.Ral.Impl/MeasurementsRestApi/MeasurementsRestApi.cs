using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Models;
using TEKUtsav.Ral;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.CloutUtils.Impl;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace TEKUtsav.Ral.Measurements.Impl
{
	public class MeasurementsRestApi : IMeasurementsRestApi
    {
		private readonly ICloudService _cloudService;
		private readonly IAzureClient _azureClient;

		public MeasurementsRestApi(ICloudService cloudService, IAzureClient azureClient)
		{
			if (cloudService == null) throw new ArgumentNullException("cloudservice");
			if (azureClient == null) throw new ArgumentNullException("azureclient");
			_cloudService = cloudService;
			_azureClient = azureClient;
		}

		public async Task<MaterialMeasurement> VerifyMeasurements(MaterialMeasurement materialMeasurements)
		{
			var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
			var poFlow = await _cloudService.InvokeApiAsyncPost<MaterialMeasurement, MaterialMeasurement>(client, Globals.MEASUREMENTS_API, materialMeasurements);
			return poFlow;
		}

		public async Task<MaterialMeasurement> RejectContainer(MaterialMeasurement materialMeasurements)
		{
			var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
			var poFlow = await _cloudService.InvokeApiAsyncPost<MaterialMeasurement, MaterialMeasurement>(client, Globals.MEASUREMENTS_API, materialMeasurements);
			return poFlow;
		}

    }
}
