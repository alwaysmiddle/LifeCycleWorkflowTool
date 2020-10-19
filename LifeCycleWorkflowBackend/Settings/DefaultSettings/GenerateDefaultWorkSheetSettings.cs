using LifeCycleWorkflowBackend.Settings.OperationSettings;
using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;

namespace LifeCycleWorkflowBackend.Settings.DefaultSettings
{
    public static class GenerateDefaultWorkSheetSettings
    {
        public static BaseOperationSettings SaksDefault()
        {
            BaseOperationSettings saksSettings;
            BasicTypeOperationBuilder basicTypeBuilder;
            DataSourceTypeOperationBuilder dataTypeBuilder;
            ReportOperationTypeBuilder reportTypeBuilder;

            reportTypeBuilder = new ReportOperationTypeBuilder();
            ReportTypeOperation summarySettings =
                reportTypeBuilder.BuildReportSheetSetting(
                    sheetName: "WF Summary Chart",
                    dateAddress: "N5",
                    readingAddress: "E1:BI79")
                .BuildFinalSheetSettings(
                    sheetName: "Summary Chart",
                    writingAddress: "E1")
                .Build();

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
                    readingAddress: "A:AR")
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
                    formulaRow: 3,
                    referenceRow: 4,
                    readingAddress: "C:BS")
                .BuildFinalSheetSettings(
                    sheetName: "Workflow Details",
                    writingAddress: "A6")
                .BuildDataSheetSetting(
                    sheetName: "DM_Data",
                    headerRow: 1,
                    writingRow: 1)
                .Build();

            saksSettings = new BaseOperationSettings(
                summarySettings: summarySettings,
                bitreportSettings: bitReportSettings,
                inactiveUpcSettings: inactiveUpcSettings,
                workflowSettings: workflowDetailsSettings);

            return saksSettings;
        }

        public static BaseOperationSettings O5Default()
        {
            BaseOperationSettings o5Settings;
            BasicTypeOperationBuilder basicTypeBuilder;
            DataSourceTypeOperationBuilder dataTypeBuilder;
            ReportOperationTypeBuilder reportTypeBuilder;

            reportTypeBuilder = new ReportOperationTypeBuilder();
            ReportTypeOperation summarySettings =
                reportTypeBuilder.BuildReportSheetSetting(
                    sheetName: "Daily Dash",
                    dateAddress: "N5",
                    readingAddress: "E1:BI25")
                .BuildFinalSheetSettings(
                    sheetName: "Daily Dash",
                    writingAddress: "E1")
                .Build();

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
                    sheetName: "UPCS",
                    headerRow: 2,
                    writingRow: 3,
                    formulaRow: 1,
                    referenceRow: 2,
                    readingAddress: "A:AR")
                .BuildFinalSheetSettings(
                    sheetName: "Inactive UPC-New Color Report",
                    writingAddress: "A5")
                .BuildDataSheetSetting(
                    sheetName: "UPCS",
                    headerRow: 2,
                    writingRow: 3)
                .Build();

            dataTypeBuilder = new DataSourceTypeOperationBuilder();
            DataSourceTypeOperation workflowDetailsSettings =
                dataTypeBuilder.BuildWipSheetSetting(
                    sheetName: "Details-Products",
                    headerRow: 7,
                    writingRow: 8,
                    formulaRow: 3,
                    referenceRow: 4,
                    readingAddress: "C:BO")
                .BuildFinalSheetSettings(
                    sheetName: "Details",
                    writingAddress: "A3")
                .BuildDataSheetSetting(
                    sheetName: "DM_Data",
                    headerRow: 1,
                    writingRow: 1)
                .Build();

            o5Settings = new BaseOperationSettings(
                summarySettings: summarySettings,
                bitreportSettings: bitReportSettings,
                inactiveUpcSettings: inactiveUpcSettings,
                workflowSettings: workflowDetailsSettings);

            return o5Settings;
        }

        public static TheBayOperationSettings TheBayDefault()
        {
            TheBayOperationSettings theBaySettings;
            BasicTypeOperationBuilder basicTypeBuilder;
            DataSourceTypeOperationBuilder dataTypeBuilder;
            ReportOperationTypeBuilder reportTypeBuilder;

            reportTypeBuilder = new ReportOperationTypeBuilder();
            ReportTypeOperation summarySettings =
                reportTypeBuilder.BuildReportSheetSetting(
                    sheetName: "WF Summary Chart",
                    dateAddress: "N5",
                    readingAddress: "E1:BO99")
                .BuildFinalSheetSettings(
                    sheetName: "Summary Chart",
                    writingAddress: "E1")
                .Build();

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
                    sheetName: "Inactive_UPC",
                    headerRow: 7,
                    writingRow: 8,
                    formulaRow: 3,
                    referenceRow: 4,
                    readingAddress: "A:AS")
                .BuildFinalSheetSettings(
                    sheetName: "Additional Color Sizes Report",
                    writingAddress: "A5")
                .BuildDataSheetSetting(
                    sheetName: "UPC_Looker",
                    headerRow: 1,
                    writingRow: 1)
                .Build();

            dataTypeBuilder = new DataSourceTypeOperationBuilder();
            DataSourceTypeOperation workflowDetailsSettings =
                dataTypeBuilder.BuildWipSheetSetting(
                    sheetName: "Details_Products",
                    headerRow: 7,
                    writingRow: 8,
                    formulaRow: 3,
                    referenceRow: 4,
                    readingAddress: "A:BT")
                .BuildFinalSheetSettings(
                    sheetName: "Workflow Details",
                    writingAddress: "A4")
                .BuildDataSheetSetting(
                    sheetName: "Looker_Data",
                    headerRow: 1,
                    writingRow: 1)
                .Build();

            dataTypeBuilder = new DataSourceTypeOperationBuilder();
            DataSourceTypeOperation nosCombinedSettings =
                dataTypeBuilder.BuildWipSheetSetting(
                    sheetName: "NOS_Colour_Combined",
                    headerRow: 2,
                    writingRow: 3,
                    formulaRow: 1,
                    referenceRow: 2,
                    readingAddress: "A:CE")
                .BuildFinalSheetSettings(
                    sheetName: "NOS_Colour_Combined",
                    writingAddress: "A2")
                .BuildDataSheetSetting(
                    sheetName: "NOS_Colour_Combined",
                    headerRow: 2,
                    writingRow: 3)
                .Build();

            theBaySettings = new TheBayOperationSettings(
                summarySettings: summarySettings,
                bitreportSettings: bitReportSettings,
                inactiveUpcSettings: inactiveUpcSettings,
                workflowSettings: workflowDetailsSettings,
                nosCombinedSettings: nosCombinedSettings);

            return theBaySettings;
        }
    }
}
