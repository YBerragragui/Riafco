using NLog;
using System;

namespace Riafco.Framework.Dataflex.pro.Nlog
{
    /// <summary>
    /// The LogManager class.
    /// </summary>
    public sealed class LoggingManager
    {
        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly Logger _logger;

        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="logger">THhe logger.</param>
        public LoggingManager(Type type)
        {
            _logger = LogManager.GetLogger("NlogLogger", type);
        }

        public void Trace(Exception exception)
        {
            _logger.Trace(exception);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Debug(Exception exception)
        {
            _logger.Debug(exception);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(Exception exception)
        {
            _logger.Info(exception);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(Exception exception)
        {
            _logger.Warn(exception);
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }

        public void Fatal(Exception exception)
        {
            _logger.Fatal(exception);
        }
    }
}
