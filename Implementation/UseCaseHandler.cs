using Newtonsoft.Json;
using ProjekatAsp.Application.Exceptions;
using ProjekatAsp.Application.Logging;
using ProjekatAsp.Application.UseCases;
using ProjekatAsp.Domain;
using System;
using System.Diagnostics;
using System.Linq;

namespace Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger;
        private IApplicationUser _user;
        private IUseCaseLogger _useCaseLogger;

        public UseCaseHandler(
            IExceptionLogger logger,
            IApplicationUser user,
            IUseCaseLogger useCaseLogger)
        {
            _logger = logger;
            _user = user;
            _useCaseLogger = useCaseLogger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                //HandleLoggingAndAuthorization(command, data);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            var log = new UseCaseLog
            {
                User = _user.Identity,
                ExecutionDateTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserId = _user.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuthorized
            };

            _useCaseLogger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Name, _user.Identity);
            }
        }
    }

    //public interface IProcessor<T>
    //{
    //    void Execute(T data);
    //}


    //public class ProcessorDecorator : IProcessor<IUseCase>
    //{
    //    private IProcessor<IUseCase> _process;

    //    public ProcessorDecorator(IProcessor<IUseCase> useCase)
    //    {
    //        _process = useCase;
    //    }

    //    public virtual void Execute(IUseCase data)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    //public class ProcessorHandleQueryDecorator : ProcessorDecorator
    //{
    //    private IExceptionLogger _logger;
    //    public ProcessorHandleQueryDecorator(IProcessor<IUseCase> useCase) : base(useCase)
    //    {
    //    }

    //    public override void Execute(IUseCase data)
    //    {
    //        var stopwatch = new Stopwatch();
    //        stopwatch.Start();

    //        base.Execute(data);

    //        stopwatch.Stop();

    //    }

    //}

    //public class ProcessorHandleCommandDecorator : ProcessorDecorator
    //{
    //    public ProcessorHandleCommandDecorator(IProcessor<IUseCase> useCase) : base(useCase)
    //    {
    //    }

    //    public override void Execute(IUseCase data)
    //    {
    //        var stopwatch = new Stopwatch();
    //        stopwatch.Start();

    //        base.Execute(data);

    //        stopwatch.Stop();

    //    }

    //}

}
