using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace V1.DefaultProject.Application.ViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResultViewModel(bool _success,
            object _data,
            string message,
            HttpStatusCode _statusCode = HttpStatusCode.OK,
            string _title = null)
        {
            Success = _success;
            Data = _data;
            Message = message;
            StatusCode = _statusCode;
            Title = _title;
        }

        public ResultViewModel(bool _success, HttpStatusCode statusCode = HttpStatusCode.OK) : this(_success, null, "", statusCode)
        {
        }

        public ResultViewModel(object _data, HttpStatusCode statusCode = HttpStatusCode.OK) : this(true, _data, "", statusCode)
        {
        }

        public ResultViewModel(string _message, HttpStatusCode statusCode = HttpStatusCode.OK) : this(true, null, _message, statusCode)
        {
        }

        public ResultViewModel(bool _success, object _data, HttpStatusCode statusCode = HttpStatusCode.OK) : this(_success, _data, "", statusCode)
        {
        }

        public ResultViewModel(bool _success, string _message, HttpStatusCode statusCode = HttpStatusCode.OK) : this(_success, null, _message, statusCode)
        {
        }

        public ResultViewModel(object _data, string _message, HttpStatusCode statusCode = HttpStatusCode.OK) : this(false, _data, _message, statusCode)
        {
        }
    }
    public class ResultViewModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResultViewModel(bool success, T data, string message, string title = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = success;
            Data = data;
            Message = message;
            Title = title;
            StatusCode = statusCode;
        }
    }
}
