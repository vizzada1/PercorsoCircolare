﻿using System;
using log4net;

namespace PercorsoCircolare.Common
{
    public class LogManager
    {
        private static readonly ILog log = log4net.LogManager.GetLogger("PercorsoCircolare");

        public static void Error(Exception ex)
        {
            log.Error(ex.Message, ex);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }

        public static void Warning(string message)
        {
            log.Warn(message);
        }

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Debug(string message)
        {
            log.Debug(message);
        }
    }
}