using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Tests
{
    public class TaskHelperTests {
        private readonly Func<Task<string>> nullFunc = () => Task.FromResult("done");

        private readonly Action nullAction = () => { };

        private readonly Func<Task<string>> errorFunc = () => { throw new InvalidOperationException("err"); };

        private readonly Action errorAction = () => { throw new InvalidOperationException("err"); };

        [Fact]
        public void RunSynchronouslyWithFuncCancelsTask() {
            var task = TaskHelper.RunSynchronously(nullFunc, new CancellationToken(canceled: true));
            Assert.True(task.IsCanceled);
        }

        [Fact]
        public void RunSynchronouslyWithFuncErrorsOut() {
            var task = TaskHelper.RunSynchronously(errorFunc);
            Assert.True(task.IsFaulted);
        }

        [Fact]
        public void RunSynchronouslyWithActionCancelsTask() {
            var task = TaskHelper.RunSynchronously(nullAction, new CancellationToken(canceled: true));
            Assert.True(task.IsCanceled);
        }

        [Fact]
        public void RunSynchronouslyWithActionErrorsOut()
        {
            var task = TaskHelper.RunSynchronously(errorAction);
            Assert.True(task.IsFaulted);
        }
    }
}
