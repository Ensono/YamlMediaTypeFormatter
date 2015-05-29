using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter {
    public static class TaskHelper {
        private static Task<TResult> FromError<TResult>(Exception exception) {
            var completionSource = new TaskCompletionSource<TResult>();
            completionSource.SetException(exception);
            return completionSource.Task;
        }

        public static Task<TResult> RunSynchronously<TResult>(
            Func<Task<TResult>> func,
            CancellationToken cancellationToken = new CancellationToken()) {
            if (cancellationToken.IsCancellationRequested) {
                return Cancelled<TResult>.Canceled;
            }

            try {
                return func();
            }
            catch (Exception ex) {
                return FromError<TResult>(ex);
            }
        }

        public static Task RunSynchronously(Action action, CancellationToken cancellationToken = new CancellationToken()) {
            if (cancellationToken.IsCancellationRequested) {
                return Cancelled<AsyncVoid>.Canceled;
            }

            try {
                action();
                var completionSource = new TaskCompletionSource<AsyncVoid>();
                completionSource.SetResult(new AsyncVoid());
                return completionSource.Task;
            }
            catch (Exception ex) {
                return FromError<AsyncVoid>(ex);
            }
        }

        private static class Cancelled<TResult> {
            public static readonly Task<TResult> Canceled = GetCancelledTask();

            private static Task<TResult> GetCancelledTask() {
                var completionSource = new TaskCompletionSource<TResult>();
                completionSource.SetCanceled();
                return completionSource.Task;
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid {}
    }
}