﻿using System.IO;
using System.Runtime.CompilerServices;
using StackExchange.Exceptional.Stores;
using Xunit.Abstractions;

namespace StackExchange.Exceptional.Tests.Storage
{
    public class JSONStorage : StoreBase
    {
        protected override bool StoreHardDeletes => true;

        public JSONStorage(ITestOutputHelper output) : base(output)
        {
        }

        protected override ErrorStore GetStore([CallerMemberName]string appName = null) =>
            new JSONErrorStore(new ErrorStoreSettings
            {
                ApplicationName = appName,
                Path = GetUniqueFolder()
            });

        protected string GetUniqueFolder()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
    }
}
