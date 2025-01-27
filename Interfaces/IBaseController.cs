using Microsoft.AspNetCore.Mvc;

namespace drakaysa.Interfaces
{
    public interface IBaseController<T>
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<T>> Post(T item);
        Task<ActionResult> Put(int id ,T item);
        Task<ActionResult> Delete(int id);
    }
}
