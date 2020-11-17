using CommonCore.Repo.Repository;
using DatingAppCore.Entities;
using DatingAppCore.Entities.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace DatingAppCore.Api.Custom
{
    public class ApiRequestLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            try
            {
                if (typeof(TState) == typeof(HttpContext))
                {
                    object obj = state;
                    var context = (HttpContext)obj;
                    string requestBody = ReadRequestStream(context.Request.Body);

                    RequestLog log = new RequestLog()
                    {
                        ID = Guid.NewGuid(),
                        Body = requestBody,
                        Method = context.Request.Method,
                        Url = context.Request.Path,
                        CreateDate = DateTime.UtcNow,
                        LastUpdated = DateTime.UtcNow
                    };

                    //RepoCache.Get<RequestLog>()
                    //    .Add(log)
                    //    .Save();
                }
            }
            catch (Exception)
            {
            }
        }

        private string ReadRequestStream(Stream stream)
        {
            string result = string.Empty;
            try
            {
                if (stream.Position > 0 && stream.CanSeek)
                    stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
            }

            return result;
        }
    }
}