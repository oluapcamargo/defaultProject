using System;
using System.Threading;

namespace V1.DefaultProject.FunctionsAzure.Util
{
    public static class DefaultProjectThreadPool
    {
        private static readonly int _minWorker = 0;
        private static readonly int _minIOC = 0;

        public static void SetMinThreads()
        {
            int minWorker, minIOC;
            // Get the current settings.
            ThreadPool.GetMinThreads(out minWorker, out minIOC);
            // Change the minimum number of worker threads to four, but
            // keep the old setting for minimum asynchronous I/O 
            // completion threads.

            string logMinThreads;

            if (_minWorker < 1 || _minIOC < 1 || (minWorker == _minWorker && minIOC == _minIOC))
            {
                // The minimum number of threads was not changed.
                logMinThreads = $"DefaultProjectThreadPool ignored - not changed. " +
                    $"minWorker: {minWorker}, minIOC: {minIOC}, >> " +
                    $"newMinWorker: {_minWorker}, newMinIOC: {_minIOC}.";
            }
            else if (ThreadPool.SetMinThreads(_minWorker, _minIOC))
            {
                // The minimum number of threads was set successfully.
                logMinThreads = $"DefaultProjectThreadPool successfully. " +
                    $"minWorker: {minWorker}, minIOC: {minIOC}, >> " +
                    $"newMinWorker: {_minWorker}, newMinIOC: {_minIOC}.";
            }
            else
            {
                // The minimum number of threads was not changed.
                logMinThreads = $"DefaultProjectThreadPool erro - not changed. " +
                    $"minWorker: {minWorker}, minIOC: {minIOC}, >> " +
                    $"newMinWorker: {_minWorker}, newMinIOC: {_minIOC}.";
            }

            Console.WriteLine($"SetMinThreads: {logMinThreads}", "Startup");
        }

    }
}
