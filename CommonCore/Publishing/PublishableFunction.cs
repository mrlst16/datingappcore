using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommonCore.DTO;
using CommonCore.Responses;

namespace CommonCore.Publishing
{
    public class PublishableFunction
    {
        private Func<IBridge, IBridge> Method;
        public List<Action> Before { get; set; }
        public List<Action> After { get; set; }

        public PublishableFunction()
        {
        }

        internal PublishableFunction(Func<IBridge, IBridge> func)
        {
            this.Method = func;
        }

        public void AddBefore(Action action)
        {
            Before.Add(action);
        }

        public void AddAfter(Action action)
        {
            After.Add(action);
        }

        public Response<IBridge> Call<T>(IBridge request)
        {
            Response<IBridge> response = new Response<IBridge>();
            try
            {
                foreach (var function in Before ?? new List<Action>())
                {
                    try
                    {
                        function();
                    }
                    catch (Exception e)
                    {
                        response += e;
                    }
                }
                response.Result = Method(request);
                foreach (var function in Before ?? new List<Action>())
                {
                    try
                    {
                        function();
                    }
                    catch (Exception e)
                    {
                        response += e;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
    }
}