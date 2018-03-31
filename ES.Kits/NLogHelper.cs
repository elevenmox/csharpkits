using NLog;
using System;

namespace ES.Kits
{
    /// <summary>
    /// 日志处理类
    /// </summary>
    public class NLogHelper
    {
        /* 官网教程： https://github.com/nlog/nlog/wiki/Tutorial
         * 
         * 问题1：logger is disabled for any level
         * 解决：NLog can be configured using XML by adding a NLog.config file to your application project (File Properties: Copy Always).
         * 
         */

        /// <summary>
        /// 日志处理器
        /// </summary>
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="message">调试说明</param>
        public static void Debug(string message)
        {
            _logger.Debug(message);
        }
        /// <summary>
        /// 记录操作信息
        /// </summary>
        /// <param name="message">操作说明</param>
        public static void Info(string message)
        {
            _logger.Info(message);
        }
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="message">错误说明</param>
        /// <param name="ex">异常详情</param>
        public static void Error(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }
        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="message">警告说明</param>
        public static void Warn(string message)
        {
            _logger.Warn(message);
        }
    }
}
