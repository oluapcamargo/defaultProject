using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace V1.DefaultProject.Domain.ViewModels.Output.ResultView
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResultViewModel(bool _success, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = _success;
            StatusCode = statusCode;
        }

        public ResultViewModel(object _data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Data = _data;
            StatusCode = statusCode;
        }
        public ResultViewModel(string _message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Message = _message;
            StatusCode = statusCode;
        }

        public ResultViewModel(bool _success, object _data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = _success;
            Data = _data;
            StatusCode = statusCode;
        }
        public ResultViewModel(bool _success, string _message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = _success;
            Message = _message;
            StatusCode = statusCode;
        }
        public ResultViewModel(object _data, string _message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Message = _message;
            Data = _data;
            StatusCode = statusCode;
        }
        public ResultViewModel(bool _success, object _data, string message, HttpStatusCode _statusCode = HttpStatusCode.OK, string _title = null)
        {
            Success = _success;
            Data = _data;
            Data = _data;
            StatusCode = _statusCode;
            Title = _title;
        }
    }
}
