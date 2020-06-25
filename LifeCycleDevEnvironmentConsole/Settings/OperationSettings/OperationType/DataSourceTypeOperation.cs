﻿using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType
{
    public class DataSourceTypeOperation
    {
        [JsonProperty]
        public WipSheetWithDataSettings WipSettings { get; }
        [JsonProperty]
        public FinalSheetSettings FinalSettings { get; }
        [JsonProperty]
        public DataSourceSheetSettings DataSourceSettings { get; }
        
        [JsonConstructor]
        public DataSourceTypeOperation(WipSheetWithDataSettings wipSettings, FinalSheetSettings finalSettings, DataSourceSheetSettings dataSourceSettings)
        {
            WipSettings = wipSettings;
            FinalSettings = finalSettings;
            DataSourceSettings = dataSourceSettings;
        }
    }
}
