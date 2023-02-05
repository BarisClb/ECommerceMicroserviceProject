using System.Collections.Generic;

namespace SharedLibrary.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        // Static Factory Method
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccess = true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccess = true };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccess = false, Errors = new List<string>() { error } };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccess = false, Errors = errors };
        }
    }
}
