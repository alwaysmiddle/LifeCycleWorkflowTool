using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowLibrary.Settings
{
    abstract class WorksheetSettingsBase
    {
        public int HeaderRow { get; protected set; }
        public string StartingAddress { get; protected set; }

        public WorksheetSettingsBase(int HeaderRow, string StartingAddress)
        {
            this.HeaderRow = HeaderRow;
            this.StartingAddress = StartingAddress;
        }

        public override string ToString()
            => $"Header Row: {HeaderRow}, Starting Address: {StartingAddress} ";
    }
}
