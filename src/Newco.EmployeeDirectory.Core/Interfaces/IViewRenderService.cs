using System.Threading.Tasks;

namespace Newco.EmployeeDirectory.Core.Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync(string viewName, object model);
    }
}