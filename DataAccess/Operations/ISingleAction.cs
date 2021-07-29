namespace DataAccess.Operations
{
    public interface ISingleAction<in TActionData, out TActionResult>
        where TActionData : ActionData
    {
        TActionResult Execute(TActionData actionData);
    }

    public interface ISingleAction<out TActionResult>
    {
        TActionResult Execute();
    }
}