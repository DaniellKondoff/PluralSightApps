namespace Logic.Utils
{
    public class CommandsConnectionString
    {
        public string Value { get; }

        public CommandsConnectionString(string value)
        {
            this.Value = value;
        }
    }

    public class QueriesConnectionString
    {
        public string Value { get; }

        public QueriesConnectionString(string value)
        {
            this.Value = value;
        }
    }
}