﻿using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType
{
    public class ReportTypeOperation
    {
        [JsonConstructor]
        public ReportTypeOperation(ReportTypeOperation reportSettings, FinalSheetSettings finalSettings)
        {
            ReportSettings = reportSettings;
            FinalSettings = finalSettings;
        }

        [JsonProperty]
        public ReportTypeOperation ReportSettings { get; }
        [JsonProperty]
        public FinalSheetSettings FinalSettings { get; }
    }
}
