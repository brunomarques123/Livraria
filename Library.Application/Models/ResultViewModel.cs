using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResultViewModel Success(string message = "Operation completed successfully.")
        {
            return new ResultViewModel(true, message);
        }

        public static ResultViewModel Error(string message)
        {
            return new ResultViewModel(false, message);
        }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
        {
            Data = data;
        }

        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T data, string message = "Operação realizada com sucesso.")
        {
            return new ResultViewModel<T>(data, true, message);
        }

        public static new ResultViewModel<T> Error(string message)
        {
            return new ResultViewModel<T>(default, false, message);
        }
    }
}
