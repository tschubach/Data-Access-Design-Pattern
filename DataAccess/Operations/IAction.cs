using System.Collections.Generic;

namespace DataAccess.Operations
{
    public interface IAction<in TActionData, out TActionResult>
        where TActionData : ActionData
    {
        IEnumerable<TActionResult> Execute(TActionData actionData);
    }

    public interface IAction<out TActionResult>
    {
        IEnumerable<TActionResult> Execute();
    }
}