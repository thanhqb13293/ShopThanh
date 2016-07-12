using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;

namespace ShopThanh.Service
{
    public interface IErrorService
    {
        void Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorReponsitory;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository error, IUnitOfWork iU)
        {
            _errorReponsitory = error;
            _unitOfWork = iU;
        }

        public void Create(Error error)
        {
            _errorReponsitory.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}