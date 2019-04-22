using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Responses
{
    public class Response<T> : IResponse
    {

        protected T _result;
        public T Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                Sucess = (value != null);
            }
        }

        public IResponse Inner { get; protected set; }

        public bool Sucess { get; set; }

        public List<Exception> Exceptions { get; protected set; } = new List<Exception>();

        public List<string> Messages { get; protected set; } = new List<string>();

        public Response()
        {
        }

        public Response<T> WithException(Exception e)
        {
            return this + e;
        }

        public Response<T> WithResult(T r)
        {
            return this + r;
        }

        public Response<T> UnSuccessful(bool success)
        {
            this.Sucess = success;
            return this;
        }

        public static Response<T> operator +(Response<T> response, T result)
        {
            response.Result = result;
            response.Sucess = false;
            return response;
        }

        public static Response<T> operator +(Response<T> response, Exception e)
        {
            response.Exceptions.Add(e);
            response.Sucess = false;
            return response;
        }

        public static Response<T> operator +(Response<T> response, bool success)
        {
            response.Sucess = success;
            return response;
        }


        public static Response<T> operator +(Response<T> response, string message)
        {
            response.Messages.Add(message);
            return response;
        }

        public static Response<T> operator +(Response<T> one, IResponse two)
        {
            one.Inner = two;
            one.Exceptions.AddRange(two.Exceptions);
            one.Messages.AddRange(two.Messages);
            return one;
        }

        public static implicit operator T(Response<T> response)
        {
            return response.Result;
        }

        public static implicit operator Response<T>(T response)
        {
            return new Response<T>()
            {
                Result = response
            };
        }

        public static Response<T> Wrap(Func<Response<T>, T> func)
        {
            Response<T> response = new Response<T>();
            try
            {
                response.Result = func(response);
            }
            catch (Exception e)
            {
                response += e;
            }
            return response;
        }

        public static Response<T> Wrap(Func<T> func)
        {
            Response<T> response = new Response<T>();
            try
            {
                response.Result = func();
            }
            catch (Exception e)
            {
                response += e;
            }
            return response;
        }
    }
}
