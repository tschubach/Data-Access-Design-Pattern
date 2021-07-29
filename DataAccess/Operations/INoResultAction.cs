namespace DataAccess.Operations
{
    public interface INoResultAction<in TActionData>
        where TActionData : ActionData
    {
        void Execute(TActionData actionData);
    }

    public interface INoResultAction
    {
        void Execute();
    }
}