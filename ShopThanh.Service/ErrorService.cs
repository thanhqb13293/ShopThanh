using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Service
{
    public interface IErrorService
    {
        void Create(Error error);
        void Save();
    }

    public class ErrorService : IErrorService
    {
        ErrorRepository _errorReponsitory;
        IUnitOfWork _unitOfWork;
        public ErrorService(ErrorRepository error, IUnitOfWork iU)
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
