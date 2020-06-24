﻿
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings;
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.DefaultSettings
{
    public static class GenerateDefaultSettings
    {
        public static BaseOperationSettings GenerateSaksDefault()
        {
            BaseOperationSettings saksSettings;
            BasicTypeOperationBuilder basicTypeBuilder;
            DataSourceTypeOperationBuilder dataTypeBuilder;

            basicTypeBuilder = new BasicTypeOperationBuilder();
            BasicTypeOperation bitReportSettings =
                basicTypeBuilder.BuildWipSheetSetting(
                    sheetName: "Ttl_Inv",
                    headerRow: 1,
                    writingRow: 1,
                    readingAddress: "A:E")
                .Build();

            dataTypeBuilder = new DataSourceTypeOperationBuilder();
            DataSourceTypeOperation inactiveUpcSettings =
                dataTypeBuilder.BuildWipSheetSetting(
                    sheetName: "Additional Color Sizes Report",
                    headerRow: 2,
                    writingRow: 3,
                    formulaRow: 1,
                    referenceRow: 2,
                    readingAddress: "A:AQ")
                .BuildFinalSheetSettings(
                    sheetName: "Additional Color Sizes Report",
                    writingAddress: "A5")
                .BuildDataSheetSetting(
                    sheetName: "Additional Color Sizes Report",
                    headerRow: 2,
                    writingRow: 3)
                .Build();

            dataTypeBuilder = new DataSourceTypeOperationBuilder();
            DataSourceTypeOperation workflowDetailsSettings =
                dataTypeBuilder.BuildWipSheetSetting(
                    sheetName: "Details-Products",
                    headerRow: 7,
                    writingRow: 8,
                    formulaRow: 2,
                    referenceRow: 3,
                    readingAddress: "C:BS")
                .BuildFinalSheetSettings(
                    sheetName: "Details-Products",
                    writingAddress: "A6")
                .BuildDataSheetSetting(
                    sheetName: "DM_Data",
                    headerRow: 1,
                    writingRow: 1)
                .Build();

            saksSettings = new BaseOperationSettings(
                bitreportSettings: bitReportSettings,
                inactiveUpcSettings: inactiveUpcSettings,
                workflowSettings: workflowDetailsSettings);

            return saksSettings;
        }

        public static void GenerateO5Default()
        {

        }

        public static void GenerateTheBayDefault()
        {

        }


    }
}
